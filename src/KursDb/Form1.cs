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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string sqlCon { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Fill Empty Spaces");
            }
            else
            {
                string log_in = string.Format(@"Data Source=localhost,1433;database=KursDb; User ID={0};Password={1}", textBox1.Text, textBox2.Text);
                sqlCon = log_in;
                try
                {
                    using (SqlConnection connection = new SqlConnection(sqlCon))
                    {
                        connection.Open();
                        Form2 f2 = new Form2();
                        f2.Show();
                        this.Hide();
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
        }
    }
}
