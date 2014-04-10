using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Web;
using System.IO;
using System.Data.OleDb;

namespace EQUItransfer
{
    public partial class frmEQTramsfer : Form
    {
        List<string> EQxmlFilesList = new List<string>();
        DataTable dt;
        List<string> NodeTypeList = new List<string>();
        public frmEQTramsfer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = "dictionary.xlsx";
            try
            {
                OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES'");
                conn.Open();

                string strSql = "Select * From [工作表1$]";
                OleDbCommand comm = new OleDbCommand(strSql, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(comm);

                if (dt == null) dt = new DataTable();
                da.Fill(dt);
                conn.Close();

                //取的要抓的Node種類清單

                DataTable distinctdt = dt.DefaultView.ToTable(true, "Node");
                foreach (DataRow dr in distinctdt.Rows)
                    NodeTypeList.Add("<"+dr.Field<string>("Node")+">");

                btnGetXmlList_Click(null, null);
                //btnGetXmlList.PerformClick();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetXmlList_Click(object sender, EventArgs e)
        {
            if (EQxmlFilesList != null)
                EQxmlFilesList.Clear();
            else
                EQxmlFilesList = new List<string>();

            XmlDocument EQxmlList = new XmlDocument();
            if (!File.Exists("EQUI.xml"))
            {
                MessageBox.Show("找不到EQUI.xml!");
                return;
            }

            EQxmlList.Load("EQUI.xml");
            XmlNodeList xmlNodeList = EQxmlList.SelectNodes("//Include");

            foreach (XmlNode xn in xmlNodeList)
                EQxmlFilesList.Add(xn.InnerText);
        }

        private string StringToUTF8(string str)
        {
            string result ="";

            //for (int i = 0; i < str.Length; i++)
            //{

            //    if (str[i] == 'A' || str[i] == '/')
            //    {
            //        result += (Microsoft.JScript.GlobalObject.escape(str[i])).Replace("%u", "&#x");
            //    }
            //    else if (str[i] == ':')
            //    {
            //        result += ':';
            //    }
            //    else
            //    {
            //        result += (Microsoft.JScript.GlobalObject.escape(str[i]) + ";").Replace("%u", "&#x");
            //    }
            //}

            result = str;
            return result;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists("zh")) Directory.CreateDirectory("zh");

            foreach (string fileName in EQxmlFilesList)
            {
                if (!File.Exists(fileName)) continue;

                StreamReader sr = new StreamReader(fileName);
                StreamWriter sw = new StreamWriter("zh\\" + fileName);
               
                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();
                        foreach (string node in NodeTypeList)
                        {
                            if (str.Contains(node))
                            {
                                string Value = str.Trim().Replace(node, "").Replace(node.Insert(1, "/"), "");
                                
                                if (Value.Contains("'")) Value =Value.Replace("'", "''");

                                DataRow[] dr = dt.Select(string.Format("File='{0}' and Node ='{1}' and Source='{2}' ", fileName, node.Trim('<').Trim('>'), Value));
                                    
                                if (dr.Length > 0)
                                        str = str.Replace(Value, StringToUTF8(dr[0].Field<string>("Replace")));

                            }
                        }
                        sw.WriteLine(str);
                    }
                
                sr.Close();
                sw.Close();

            }
        }

    }
}
