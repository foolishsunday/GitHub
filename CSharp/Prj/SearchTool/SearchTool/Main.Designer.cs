namespace SearchTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbDocPath = new System.Windows.Forms.TextBox();
            this.tbOkWord = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblNg = new System.Windows.Forms.Label();
            this.tbNgWord = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbDocPath
            // 
            this.tbDocPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbDocPath.Location = new System.Drawing.Point(0, 0);
            this.tbDocPath.Name = "tbDocPath";
            this.tbDocPath.Size = new System.Drawing.Size(800, 21);
            this.tbDocPath.TabIndex = 0;
            this.tbDocPath.Text = "F:\\Work\\Project\\Repository\\GitHub\\CSharp\\App";
            // 
            // tbOkWord
            // 
            this.tbOkWord.Location = new System.Drawing.Point(13, 64);
            this.tbOkWord.Name = "tbOkWord";
            this.tbOkWord.Size = new System.Drawing.Size(269, 21);
            this.tbOkWord.TabIndex = 1;
            this.tbOkWord.Text = ".cs";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(13, 46);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(113, 12);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "文件名包含的关键字";
            // 
            // lblNg
            // 
            this.lblNg.AutoSize = true;
            this.lblNg.Location = new System.Drawing.Point(461, 46);
            this.lblNg.Name = "lblNg";
            this.lblNg.Size = new System.Drawing.Size(113, 12);
            this.lblNg.TabIndex = 4;
            this.lblNg.Text = "文件名屏蔽的关键字";
            // 
            // tbNgWord
            // 
            this.tbNgWord.Location = new System.Drawing.Point(461, 64);
            this.tbNgWord.Name = "tbNgWord";
            this.tbNgWord.Size = new System.Drawing.Size(288, 21);
            this.tbNgWord.TabIndex = 3;
            this.tbNgWord.Text = ".csproj .csv";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(463, 101);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbLog.Location = new System.Drawing.Point(0, 153);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(800, 297);
            this.rtbLog.TabIndex = 6;
            this.rtbLog.Text = "";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(12, 101);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(269, 21);
            this.tbKey.TabIndex = 7;
            this.tbKey.Text = "interface";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(633, 111);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(11, 12);
            this.lblSum.TabIndex = 8;
            this.lblSum.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblNg);
            this.Controls.Add(this.tbNgWord);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.tbOkWord);
            this.Controls.Add(this.tbDocPath);
            this.Name = "MainForm";
            this.Text = "Search Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDocPath;
        private System.Windows.Forms.TextBox tbOkWord;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblNg;
        private System.Windows.Forms.TextBox tbNgWord;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label lblSum;
    }
}

