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
    public partial class Query : Form
    {
        public Query()
        {
            InitializeComponent();
        }

        private void a_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                {
                    connection.Open();
                    string sql = "select room_number 'Комната', category_name 'Категория',check_in 'Дата Заезда',check_out 'Дата Выписки',CASE WHEN client_room=room_id AND check_in<=CAST(GETDATE() AS Date) AND check_out>CAST(GETDATE() AS Date) THEN 'Занято' ELSE 'Не Занято' END 'Статус' from rooms left JOIN clients ON client_room=room_id left JOIN reservations ON client_reservation=reservation_id JOIN categories on room_category=category_id";
                    SqlCommand sqlCmd = new SqlCommand(sql, connection);
                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
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

        private void button2_Click(object sender, EventArgs e)
        {
           try
            {
                using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                {
                    connection.Open();
                    string sql = "SELECT client_id, lastname FROM clients WHERE client_reservation = ANY (SELECT reservation_id FROM reservations WHERE number_of_people='1')";
                    SqlCommand sqlCmd = new SqlCommand(sql, connection);
                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
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

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from view_view ";
            switch (comboBox1.SelectedItem)
            {
                case "client_id":
                    sql += "order by client_id";
                    break;
                case "Имя":
                    sql += "order by Имя";
                    break;
                case "Среднее Имя":
                    sql += "order by [Среднее имя]";
                    break;
                case "Фамилия":
                    sql += "order by Фамилия";
                    break;
                case "Комната":
                    sql += "order by Комната";
                    break;
                case "Категория":
                    sql += "order by Категория";
                    break;
                case "Дата Заезда":
                    sql += "order by [Дата Заезда]";
                    break;
                case "Дата Выписки":
                    sql += "order by [Дата выписки]";
                    break;
                default:
                    MessageBox.Show("Choose Column");
                    sql = "";
                    break;
            }
            if (sql != "")
                try
                {
                    using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                    {
                        connection.Open();
                        SqlDataAdapter sqlDA = new SqlDataAdapter(sql, connection);
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                {
                    bool flag = false;
                    connection.Open();
                    SqlCommand sqlCmd = new SqlCommand("price110", connection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        DataTable dt = new DataTable();
                        dt.Load(sqlCmd.ExecuteReader());
                        dataGridView1.DataSource = dt;
                        flag = true;

                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Error: " + x.Message);
                    }
                    if (flag == true)
                        MessageBox.Show("Success");
                    
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                {
                    connection.Open();
                    string sql = "SELECT category_id, category_name, t.bed_q FROM categories JOIN (SELECT room_category, sum(number_of_beds) bed_q FROM rooms GROUP BY room_category having sum(number_of_beds)<6) t ON category_id=t.room_category";
                    SqlCommand sqlCmd = new SqlCommand(sql, connection);
                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                {
                    connection.Open();
                    string sql = "select client_id, lastname, dbo.daycount(client_id) 'daycount' from clients";
                    SqlCommand sqlCmd = new SqlCommand(sql, connection);
                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
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

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "";
            switch (comboBox2.SelectedItem)
            {
                case "non-c where":
                    sql = "SELECT room_number 'Комната',number_of_beds 'Кровати' FROM rooms WHERE room_category = (SELECT category_id FROM categories where category_name='Делюкс')";
                    break;
                case "non-c select":
                    sql = "select max(check_out)'max дата выписки', (select max(room_number) from rooms)'max номер комнаты' from reservations";
                    break;
                case "non-c from":
                    sql = "SELECT MAX(check_out) FROM (select check_out from reservations) a";
                    break;
                case "c where":
                    sql = "SELECT lastname FROM clients WHERE '2' IN (SELECT number_of_people FROM reservations WHERE reservation_id = client_reservation)";
                    break;
                case "c select":
                    sql = "SELECT client_id,lastname 'Фамилия',(select room_number from rooms where room_id=client_room) 'Комната' FROM clients";
                    break;
                case "c from":
                    sql = "SELECT category_id, category_name, t.bed_q FROM categories JOIN (SELECT room_category, sum(number_of_beds) bed_q FROM rooms GROUP BY room_category) t ON category_id=t.room_category";
                    break;
                default:
                    MessageBox.Show("Choose Query");
                    break;
            }
            if (sql != "")
                try
                {
                    using (SqlConnection connection = new SqlConnection(Form1.sqlCon))
                    {
                        connection.Open();
                        SqlDataAdapter sqlDA = new SqlDataAdapter(sql, connection);
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
}
