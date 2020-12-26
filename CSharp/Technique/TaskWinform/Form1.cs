using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskWinform
{
    /// <summary>
    /// 本代码演示了：winform创建两个线程，线程完成后结果更新显示到UI上，同时UI不卡死。
    /// 本代码主旨为了解决线程同步和UI卡死问题
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //记录线程的运行时间信息等，最后打印出来，为了验证线程是不是同时启动
        private List<string> mulLog = new List<string>();
        private List<string> addLog = new List<string>();

        //按键按下去后
        private void button1_Click(object sender, EventArgs e)
        {
            double[] arr = new double[2];

            //创建一个当前线程的任务计划
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();

            //异步线程
            Task.Run(() =>
            {
                //启动两个线程，并记录结果
                var m = Multiply();
                var a = Add();
                arr = new double[2] { m.Result, a.Result };

            }).ContinueWith(x =>
            {   //任务完成时，异步执行与scheduler相关的延续任务 ，x => 所指向的就是延续任务          
                //记录结果后，把结果打印出来，这里采用了委托异步调用，为了防止richTextBox打印大量log时，ui卡住问题
                Action act = delegate ()
                {
                    label1.Text = arr[0].ToString();
                    label2.Text = arr[1].ToString();
                    mulLog.ForEach(p => richTextBox1.AppendText(p + Environment.NewLine));
                    richTextBox1.AppendText("--------------------------------" + Environment.NewLine);
                    addLog.ForEach(p => richTextBox1.AppendText(p + Environment.NewLine));
                };
                this.BeginInvoke(act, null);

            }, scheduler);


        }

        //模拟一个耗时的线程，如获取数据库数据、计算数据等等
        private async Task<double> Multiply()
        {
            var task = Task.Run(() =>
            {
                double sum = 1, i = 1;
                long mi , preMi = 0;

                Stopwatch sw = new Stopwatch();     //创建一个Stopwatch，为了计时
                sw.Start();                         //计时开始

                //在设定的毫秒数内循环，模拟一个耗时的任务
                do
                {
                    sum *= i;
                    i++;
                    mi = sw.ElapsedMilliseconds;    //获取从计时开始的毫秒数        

                    //log记录task id，当前时间
                    string text = string.Format("{0}: task id = {1}, i={2}", DateTime.Now.ToString("yy-MM-dd hh:mm:ss.fff"), Task.CurrentId, i);
                    //每100ms记录一条不重复的log
                    //preMi：防止重复 , mi = preMi的log就不记录了
                    if (mi % 100 == 0 && mi != preMi)   
                    {
                        preMi = mi; 
                        mulLog.Add(text);
                    }
                       
                } while (mi < 2000);                 

                sw.Stop();
                return sum;

            });
            return await task;
        }

        //同上，模拟一个耗时的线程
        private async Task<double> Add()
        {
            var task = Task.Run(() =>
            {
                double sum = 0, j = 1;
                long mi, preMi = 0;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                do
                {
                    sum += j;
                    j++;
                    mi = sw.ElapsedMilliseconds;
                    string text = string.Format("{0}: task id = {1}, j={2}", DateTime.Now.ToString("yy-MM-dd hh:mm:ss.fff"), Task.CurrentId, j);
                    if (mi % 100 == 0 && mi != preMi)
                    {
                        preMi = mi;
                        addLog.Add(text);
                    }
                } while (mi < 3000);

                sw.Stop();
                return sum;

            });
            return await task;
        }
    }
}
