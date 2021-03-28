using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevSearchTool
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async Task<string> SearchTask(IEnumerable<string> docs, string key)
        {
            return await Task.Run(() =>
            {
                int i = 1, finishedCount = 0;
                string text = string.Empty;
                foreach (var item in docs)
                {
                    int lineNum = Util.LineNum(item, key);
                    if (lineNum > 0)
                    {
                        text += i.ToString() + " " + item + "行号:" + lineNum.ToString() + Environment.NewLine;
                        i++;
                    }
                    finishedCount++;
                    Update_FinishedSum(finishedCount);
                }
                return text;
            });
        }
        private void Update_FinishedSum(int i)
        {
            Action async = () =>
            {
                lblSum.Text = i.ToString() + "//" + cnt.ToString();
            };
            this.BeginInvoke(async);

        }
        private int cnt = 0;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var path = tbDocPath.Text;
            var ok = tbOkWord.Text;
            var ng = tbNgWord.Text;
            var key = tbKey.Text;

            TaskScheduler ui = TaskScheduler.FromCurrentSynchronizationContext();
            string text = string.Empty;
            var lists = Util.FilesName(path, ok, ng);
            cnt = lists.Count();

            Task.Run(async () =>
            {
                text = await SearchTask(lists, key);
            }).ContinueWith(m =>
            {
                var strs = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                strs.ToList().ForEach(x => rtbLog.Items.Add(x));
                //rtbLog.Text = text;
                rtbLog.Items.Add("完成");
            }, ui);
        }
    }
}
