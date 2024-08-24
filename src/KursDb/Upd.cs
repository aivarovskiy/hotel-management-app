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
    public partial class Upd : Form
    {
        public Upd()
        {
            InitializeComponent();
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
                        SqlDataAdapter sqlDA3 = new SqlDataAdapter("select room_id from rooms", connection);
                        DataTable dt3 = new DataTable();
                        sqlDA3.Fill(dt3);
                        comboBox6.DataSource = dt3;
                        comboBox6.DisplayMember = "room_id";
                        comboBox6.ValueMember = "room_id";
                        SqlDataAdapter sqlDA2 = new SqlDataAdapter("select room_id, room_number, category_name, number_of_beds from rooms join categories on category_id = room_category", connection);
                        DataTable dt2 = new DataTable();
                        sqlDA2.Fill(dt2);
                        dataGridView3.DataSource = dt2;
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
                        SqlDataAdapter sqlDA3 = new SqlDataAdapter("select reservation_id from reservations", connection);
                        DataTable dt3 = new DataTable();
                        sqlDA3.Fill(dt3);
                        comboBox8.DataSource = dt3;
                        comboBox8.DisplayMember = "reservation_id";
                        comboBox8.ValueMember = "reservation_id";
                        SqlDataAdapter sqlDA2 = new SqlDataAdapter("select reservation_id, check_in, check_out, number_of_people, payment_type_name from reservations join payment_types on payment_type_id = payment_type", connection);
                        DataTable dt2 = new DataTable();
                        sqlDA2.Fill(dt2);
                        dataGridView4.DataSource = dt2;
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
                        SqlDataAdapter sqlDA3 = new SqlDataAdapter("select client_id from clients", connection);
                        DataTable dt3 = new DataTable();
                        sqlDA3.Fill(dt3);
                        comboBox7.DataSource = dt3;
                        comboBox7.DisplayMember = "client_id";
                        comboBox7.ValueMember = "client_id";
                        SqlDataAdapter sqlDA4 = new SqlDataAdapter("select client_id, room_number, client_reservation, firstname, middlename, lastname, invoice from clients join rooms on room_id = client_room", connection);
                        DataTable dt4 = new DataTable();
                        sqlDA4.Fill(dt4);
                        dataGridView5.DataSource = dt4;
                    }
                    if(tabControl1.SelectedTab == tabPage5)
                    {
                        connection.Open();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select payment_type_id from payment_types", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        comboBox9.DataSource = dt;
                        comboBox9.DisplayMember = "payment_type_id";
                        comboBox9.ValueMember = "payment_type_id";
                        SqlDataAdapter sqlDA2 = new SqlDataAdapter("select * from payment_types", connection);
                        DataTable dt2 = new DataTable();
                        sqlDA2.Fill(dt2);
                        dataGridView1.DataSource = dt2;
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
                    comboBox3.DataSource = dt;
                    comboBox3.DisplayMember = "category_id";
                    comboBox3.ValueMember = "category_id";
                    SqlDataAdapter sqlDA2 = new SqlDataAdapter("select * from categories", connection);
                    DataTable dt2 = new DataTable();
                    sqlDA2.Fill(dt2);
                    dataGridView2.DataSource = dt2;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox3.Text == "") || (textBox2.Text == "") || (comboBox3.SelectedIndex == -1))
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
                        SqlCommand sqlCmd = new SqlCommand("categories_update", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@id", comboBox3.SelectedValue);
                        sqlCmd.Parameters.AddWithValue("@name", textBox3.Text);
                        sqlCmd.Parameters.AddWithValue("@price", textBox2.Text);
                        sqlCmd.Parameters.AddWithValue("@tv", checkBox1.Checked);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select * from categories", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView2.DataSource = dt;
                        MessageBox.Show("Updated");
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
            if ((textBox4.Text == "") || (textBox6.Text == "") || (comboBox6.SelectedIndex == -1) || (comboBox1.SelectedIndex == -1))
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
                        SqlCommand sqlCmd = new SqlCommand("room_update", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@id", comboBox6.SelectedValue);
                        sqlCmd.Parameters.AddWithValue("@nob", textBox4.Text);
                        sqlCmd.Parameters.AddWithValue("@rn", textBox6.Text);
                        sqlCmd.Parameters.AddWithValue("@rc", comboBox1.SelectedValue);
                        sqlCmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("select room_id, room_number, category_name, number_of_beds from rooms join categories on category_id = room_category", connection);
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView3.DataSource = dt;
                        MessageBox.Show("Updated");
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
            if ((textBox7.Text == "") || (comboBox8.SelectedIndex == -1) || (comboBox2.SelectedIndex == -1))
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
                            SqlCommand sqlCmd = new SqlCommand("res_update", connection);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@id", comboBox8.SelectedValue);
                            sqlCmd.Parameters.AddWithValue("@nop", textBox7.Text);
                            sqlCmd.Parameters.AddWithValue("@ci", dateTimePicker2.Value);
                            sqlCmd.Parameters.AddWithValue("@co", dateTimePicker1.Value);
                            sqlCmd.Parameters.AddWithValue("@pt", comboBox2.SelectedValue);
                            sqlCmd.ExecuteNonQuery();
                            SqlDataAdapter sqlDA = new SqlDataAdapter("select reservation_id, check_in, check_out, number_of_people, payment_type_name from reservations join payment_types on payment_type_id = payment_type;", connection);
                            DataTable dt = new DataTable();
                            sqlDA.Fill(dt);
                            dataGridView4.DataSource = dt;
                            MessageBox.Show("Updated");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (comboBox9.SelectedIndex == -1))
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
                            SqlCommand sqlCmd = new SqlCommand("pt_update", connection);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@id", comboBox9.SelectedValue);
                            sqlCmd.Parameters.AddWithValue("@name", textBox1.Text);
                            sqlCmd.ExecuteNonQuery();
                            SqlDataAdapter sqlDA = new SqlDataAdapter("select * from payment_types", connection);
                            DataTable dt = new DataTable();
                            sqlDA.Fill(dt);
                            dataGridView1.DataSource = dt;
                            MessageBox.Show("Updated");
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
            if ((textBox5.Text == "") || (textBox8.Text == "") || (textBox9.Text == "") || (comboBox4.SelectedIndex == -1) || (comboBox5.SelectedIndex == -1) || (comboBox7.SelectedIndex == -1))
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
                        SqlCommand sqlCmd = new SqlCommand("clients_update", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@id", comboBox7.SelectedValue);
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
                        MessageBox.Show("Updated");
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
