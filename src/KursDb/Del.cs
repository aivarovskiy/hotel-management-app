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
    public partial class Del : Form
    {
        public Del()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                {
                    if (tabControl1.SelectedTab == tabPage2)
                    {
                        connection.Open();
                        SqlDataAdapter sqlDA3 = new SqlDataAdapter("select room_id from rooms", connection);
                        DataTable dt3 = new DataTable();
                        sqlDA3.Fill(dt3);
                        comboBox2.DataSource = dt3;
                        comboBox2.DisplayMember = "room_id";
                        comboBox2.ValueMember = "room_id";
                    }
                    if (tabControl1.SelectedTab == tabPage4)
                    {
                        connection.Open();
                        SqlDataAdapter sqlDA3 = new SqlDataAdapter("select reservation_id from reservations", connection);
                        DataTable dt3 = new DataTable();
                        sqlDA3.Fill(dt3);
                        comboBox4.DataSource = dt3;
                        comboBox4.DisplayMember = "reservation_id";
                        comboBox4.ValueMember = "reservation_id";
                    }
                    if (tabControl1.SelectedTab == tabPage3)
                    {
                        connection.Open();
                        SqlDataAdapter sqlDA3 = new SqlDataAdapter("select client_id from clients", connection);
                        DataTable dt3 = new DataTable();
                        sqlDA3.Fill(dt3);
                        comboBox3.DataSource = dt3;
                        comboBox3.DisplayMember = "client_id";
                        comboBox3.ValueMember = "client_id";
                    }
                    if (tabControl1.SelectedTab == tabPage5)
                    {
                        connection.Open();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select payment_type_id from payment_types", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        comboBox5.DataSource = dt;
                        comboBox5.DisplayMember = "payment_type_id";
                        comboBox5.ValueMember = "payment_type_id";
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x.Message);
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                {
                    connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter("select category_id from categories", connection);
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "category_id";
                    comboBox1.ValueMember = "category_id";
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Fill Empty Spaces");
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                    {
                        connection.Open();
                        SqlCommand sqlCmd = new SqlCommand("categories_delete", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@id", comboBox1.SelectedValue);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA2 = new SqlDataAdapter("select category_id from categories", connection);
                        DataTable dt2 = new DataTable();
                        sqlDA2.Fill(dt2);
                        comboBox1.DataSource = dt2;
                        comboBox1.DisplayMember = "category_id";
                        comboBox1.ValueMember = "category_id";
                        MessageBox.Show("Deleted");
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Fill Empty Spaces");
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                    {
                        connection.Open();
                        SqlCommand sqlCmd = new SqlCommand("room_delete", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@id", comboBox2.SelectedValue);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA3 = new SqlDataAdapter("select room_id from rooms", connection);
                        DataTable dt3 = new DataTable();
                        sqlDA3.Fill(dt3);
                        comboBox2.DataSource = dt3;
                        comboBox2.DisplayMember = "room_id";
                        comboBox2.ValueMember = "room_id";
                        MessageBox.Show("Deleted");
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Fill Empty Spaces");
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                    {
                        connection.Open();
                        SqlCommand sqlCmd = new SqlCommand("clients_delete", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@id", comboBox3.SelectedValue);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA3 = new SqlDataAdapter("select client_id from clients", connection);
                        DataTable dt3 = new DataTable();
                        sqlDA3.Fill(dt3);
                        comboBox3.DataSource = dt3;
                        comboBox3.DisplayMember = "client_id";
                        comboBox3.ValueMember = "client_id";
                        MessageBox.Show("Deleted");
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Fill Empty Spaces");
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                    {
                        connection.Open();
                        SqlCommand sqlCmd = new SqlCommand("res_delete", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@id", comboBox4.SelectedValue);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA3 = new SqlDataAdapter("select reservation_id from reservations", connection);
                        DataTable dt3 = new DataTable();
                        sqlDA3.Fill(dt3);
                        comboBox4.DataSource = dt3;
                        comboBox4.DisplayMember = "reservation_id";
                        comboBox4.ValueMember = "reservation_id";
                        MessageBox.Show("Deleted");
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Fill Empty Spaces");
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                    {
                        connection.Open();
                        SqlCommand sqlCmd = new SqlCommand("pt_delete", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@id", comboBox5.SelectedValue);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA2 = new SqlDataAdapter("select payment_type_id from payment_types", connection);
                        DataTable dt2 = new DataTable();
                        sqlDA2.Fill(dt2);
                        comboBox5.DataSource = dt2;
                        comboBox5.DisplayMember = "payment_type_id";
                        comboBox5.ValueMember = "payment_type_id";
                        MessageBox.Show("Deleted");
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
