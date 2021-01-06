using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private async Task<string> SearchTask(IEnumerable<string> docs, string key)
        {
            return await Task.Run(() =>
            {
                int i = 1;
                string text = string.Empty;
                foreach (var item in docs)
                {
                    int lineNum = Util.LineNum(item, key);
                    if (lineNum > 0)
                    {
                        text += i.ToString() + " " + item + "行号:" + lineNum.ToString() + Environment.NewLine;
                        i++;
                    }
                }
                return text;
            });
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var path = tbDocPath.Text;
            var ok = tbOkWord.Text;
            var ng = tbNgWord.Text;
            var key = tbKey.Text;

            TaskScheduler ui = TaskScheduler.FromCurrentSynchronizationContext();
            string text = string.Empty;
            var lists = Util.FilesName(path, ok, ng);
            Task.Run(async() =>
            {
                text = await SearchTask(lists, key);
            }).ContinueWith(m =>
            {
                rtbLog.Text = text;
                rtbLog.AppendText("完成");
            }, ui);
        }
    }
}
