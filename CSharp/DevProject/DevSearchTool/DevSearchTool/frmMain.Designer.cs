namespace DevSearchTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbDocPath = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.tbOkWord = new DevExpress.XtraEditors.TextEdit();
            this.tbNgWord = new DevExpress.XtraEditors.TextEdit();
            this.tbKey = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblSum = new DevExpress.XtraEditors.LabelControl();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.rtbLog = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.tbDocPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOkWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNgWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbLog)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDocPath
            // 
            this.tbDocPath.Location = new System.Drawing.Point(21, 26);
            this.tbDocPath.Name = "tbDocPath";
            this.tbDocPath.Size = new System.Drawing.Size(595, 20);
            this.tbDocPath.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(640, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbOkWord
            // 
            this.tbOkWord.Location = new System.Drawing.Point(21, 89);
            this.tbOkWord.Name = "tbOkWord";
            this.tbOkWord.Size = new System.Drawing.Size(185, 20);
            this.tbOkWord.TabIndex = 2;
            // 
            // tbNgWord
            // 
            this.tbNgWord.EditValue = "";
            this.tbNgWord.Location = new System.Drawing.Point(271, 89);
            this.tbNgWord.Name = "tbNgWord";
            this.tbNgWord.Size = new System.Drawing.Size(185, 20);
            this.tbNgWord.TabIndex = 3;
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(530, 89);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(185, 20);
            this.tbKey.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "包含文件名：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(271, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "屏蔽文件名：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(530, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 14);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "搜索关键词：";
            // 
            // lblSum
            // 
            this.lblSum.Location = new System.Drawing.Point(643, 52);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(7, 14);
            this.lblSum.TabIndex = 9;
            this.lblSum.Text = "0";
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Location = new System.Drawing.Point(182, 257);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(8, 8);
            this.listBoxControl1.TabIndex = 10;
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(35, 134);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(625, 235);
            this.rtbLog.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 404);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.listBoxControl1);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.tbNgWord);
            this.Controls.Add(this.tbOkWord);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbDocPath);
            this.Name = "MainForm";
            this.Text = "Dev Search Tool";
            ((System.ComponentModel.ISupportInitialize)(this.tbDocPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOkWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNgWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tbDocPath;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit tbOkWord;
        private DevExpress.XtraEditors.TextEdit tbNgWord;
        private DevExpress.XtraEditors.TextEdit tbKey;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblSum;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.ListBoxControl rtbLog;

    }
}

