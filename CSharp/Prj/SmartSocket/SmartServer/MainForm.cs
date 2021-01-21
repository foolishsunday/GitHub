using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SmartServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint point = new IPEndPoint(ip, 99);
            server.Bind(point);
            server.Listen(10);
            string message = "";

            var connect = server.Accept();
            Task.Run(() =>
            {
                while (true)
                {

                    byte[] buffer = new byte[2048];
                    int count = connect.Receive(buffer);
                    if (count > 0)
                    {
                        message = Encoding.Default.GetString(buffer, 0, count);
                        Show(connect.RemoteEndPoint.AddressFamily.ToString()+" " + message);
                        //await Task.Yield();
                    }


                }
            });
        }
        private void Show(string message)
        {
            Action async = delegate ()
            {
                rtbLog.AppendText(message + Environment.NewLine);
            };
            this.BeginInvoke(async);
        }
    }
}
