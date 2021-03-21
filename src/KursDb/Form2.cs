using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KursDb
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void log_out_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            Close();
        }

        private void view_view_Click(object sender, EventArgs e)
        {
            View f1 = new View();
            f1.Show();
            Close();
        }

        private void query_Click(object sender, EventArgs e)
        {
            Query f1 = new Query();
            f1.Show();
            Close();
        }

        private void del_Click(object sender, EventArgs e)
        {
            Del f1 = new Del();
            f1.Show();
            Close();
        }

        private void ins_Click(object sender, EventArgs e)
        {
            Ins f1 = new Ins();
            f1.Show();
            Close();
        }

        private void upd_Click(object sender, EventArgs e)
        {
            Upd f1 = new Upd();
            f1.Show();
            Close();
        }
    }
}
