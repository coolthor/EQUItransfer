namespace EQUItransfer
{
    partial class frmEQTramsfer
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetXmlList = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetXmlList
            // 
            this.btnGetXmlList.Location = new System.Drawing.Point(12, 82);
            this.btnGetXmlList.Name = "btnGetXmlList";
            this.btnGetXmlList.Size = new System.Drawing.Size(180, 23);
            this.btnGetXmlList.TabIndex = 1;
            this.btnGetXmlList.Text = "Get File List";
            this.btnGetXmlList.UseVisualStyleBackColor = true;
            this.btnGetXmlList.Visible = false;
            this.btnGetXmlList.Click += new System.EventHandler(this.btnGetXmlList_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(12, 12);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(435, 64);
            this.btnTransfer.TabIndex = 2;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // frmEQTramsfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 113);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnGetXmlList);
            this.Name = "frmEQTramsfer";
            this.Text = "EQUI中文化輔助工具 v.0.0.0.1 By Thor Lin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetXmlList;
        private System.Windows.Forms.Button btnTransfer;
    }
}

