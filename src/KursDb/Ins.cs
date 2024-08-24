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
    public partial class Ins : Form
    {
        public Ins()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == ""))
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
                        SqlCommand sqlCmd = new SqlCommand("pt_insert", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@name", textBox1.Text);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select * from payment_types", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox3.Text == "")|| (textBox2.Text == ""))
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
                        SqlCommand sqlCmd = new SqlCommand("categories_insert", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@name", textBox3.Text);
                        sqlCmd.Parameters.AddWithValue("@price", textBox2.Text);
                        sqlCmd.Parameters.AddWithValue("@tv", checkBox1.Checked);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select * from categories", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox4.Text == "") || (textBox6.Text == "") || (comboBox1.SelectedIndex == -1))
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
                        SqlCommand sqlCmd = new SqlCommand("room_insert", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@nob", textBox4.Text);
                        sqlCmd.Parameters.AddWithValue("@rn", textBox6.Text);
                        sqlCmd.Parameters.AddWithValue("@rc", comboBox1.SelectedValue);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select room_id, room_number, category_name, number_of_beds from rooms join categories on category_id = room_category", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView3.DataSource = dt;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
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
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select category_id, category_name from categories", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = "category_name";
                        comboBox1.ValueMember = "category_id";
                    }
                    if (tabControl1.SelectedTab == tabPage4)
                    {
                        connection.Open();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select payment_type_id, payment_type_name from payment_types", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        comboBox2.DataSource = dt;
                        comboBox2.DisplayMember = "payment_type_name";
                        comboBox2.ValueMember = "payment_type_id";
                    }
                    if (tabControl1.SelectedTab == tabPage3)
                    {
                        connection.Open();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select room_id, room_number from rooms", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        comboBox5.DataSource = dt;
                        comboBox5.DisplayMember = "room_number";
                        comboBox5.ValueMember = "room_id";
                        SqlDataAdapter sqlDA2 = new SqlDataAdapter("select reservation_id from reservations", connection);
                        DataTable dt2 = new DataTable();
                        sqlDA2.Fill(dt2);
                        comboBox4.DataSource = dt2;
                        comboBox4.DisplayMember = "reservation_id";
                        comboBox4.ValueMember = "reservation_id";
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (comboBox2.SelectedIndex == -1))
            {
                MessageBox.Show("Fill Empty Spaces");
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                    {
                        if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
                        {
                            connection.Open();
                            SqlCommand sqlCmd = new SqlCommand("res_insert", connection);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@nop", textBox7.Text);
                            sqlCmd.Parameters.AddWithValue("@ci", dateTimePicker2.Value);
                            sqlCmd.Parameters.AddWithValue("@co", dateTimePicker1.Value);
                            sqlCmd.Parameters.AddWithValue("@pt", comboBox2.SelectedValue);
                            sqlCmd.ExecuteNonQuery();
                            SqlDataAdapter sqlDA = new SqlDataAdapter("select reservation_id, check_in, check_out, number_of_people, payment_type_name from reservations join payment_types on payment_type_id = payment_type", connection);
                            DataTable dt = new DataTable();
                            sqlDA.Fill(dt);
                            dataGridView4.DataSource = dt;
                        }
                        else
                            MessageBox.Show("check-out date must be greater than check-in date");
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox5.Text == "") || (textBox8.Text == "") || (textBox9.Text == "") || (comboBox4.SelectedIndex == -1) || (comboBox5.SelectedIndex == -1))
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
                        SqlCommand sqlCmd = new SqlCommand("clients_insert", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@client_room", comboBox5.SelectedValue);
                        sqlCmd.Parameters.AddWithValue("@client_reservation", comboBox4.SelectedValue);
                        sqlCmd.Parameters.AddWithValue("@firstname", textBox8.Text);
                        sqlCmd.Parameters.AddWithValue("@middlename", textBox5.Text);
                        sqlCmd.Parameters.AddWithValue("@lastname", textBox9.Text);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select client_id, room_number, client_reservation, firstname, middlename, lastname, invoice from clients join rooms on room_id = client_room", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView5.DataSource = dt;
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

        private void button8_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            Close();
        }
    }
}
