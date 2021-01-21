using EFDatabaseSqlite.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDatabaseSqlite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = DataBase.GetDbContext())
            {

                var product = new ProductInfo()
                {
                    Id = 100,
                    Name = "Panda"
                };
                db.ProductInfo.Add(product);
                db.SaveChanges();
                var cnt = (from p in db.ProductInfo
                             select p).Count();
                richTextBox1.Text = string.Format("change {0} lines", cnt);
                //richTextBox1.Text = query.First().Id.ToString() + " : " + query.First().Name;
            }
        }
    }
}
