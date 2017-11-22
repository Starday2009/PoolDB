using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using System.Data.SqlClient;

namespace PoolApp
{
    public partial class Form1 : Form
    {
        String connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123;Database=Pool;";
       

        public Form1()
        {
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            NpgsqlCommand client = new NpgsqlCommand("SELECT * FROM client WHERE \"id_client\" > :val1", conn);
            try
            {
                client.Parameters.Add(new NpgsqlParameter("val1", NpgsqlDbType.Integer));
                client.Parameters[0].Value = 1;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(client);
                DataSet ds = new DataSet();
                da.Fill(ds);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            finally
            {
                conn.Close();
            }

            NpgsqlCommand instructor = new NpgsqlCommand("SELECT * FROM instructor WHERE \"id_instructor\" > :val1", conn);
            try
            {
                instructor.Parameters.Add(new NpgsqlParameter("val1", NpgsqlDbType.Integer));
                instructor.Parameters[0].Value = 1;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(instructor);
                DataSet ds = new DataSet();
                da.Fill(ds);
                this.dataGridView2.DataSource = ds.Tables[0];
            }
            finally
            {
                conn.Close();
            }

            NpgsqlCommand pool = new NpgsqlCommand("SELECT * FROM pool WHERE \"id_pool\" > :val1", conn);
            try
            {
                pool.Parameters.Add(new NpgsqlParameter("val1", NpgsqlDbType.Integer));
                pool.Parameters[0].Value = 1;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(pool);
                DataSet ds = new DataSet();
                da.Fill(ds);
                this.dataGridView3.DataSource = ds.Tables[0];
            }
            finally
            {
                conn.Close();
            }

            NpgsqlCommand  lesson = new NpgsqlCommand("SELECT * FROM lesson WHERE \"id_lesson\" > :val1", conn);
            try
            {
                lesson.Parameters.Add(new NpgsqlParameter("val1", NpgsqlDbType.Integer));
                lesson.Parameters[0].Value = 1;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(lesson);
                DataSet ds = new DataSet();
                da.Fill(ds);
                this.dataGridView4.DataSource = ds.Tables[0];
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "poolDataSet.client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.poolDataSet.client);

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString);


            //String connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123;Database=Pool;";
            String connectionString = "Server=127.0.0.1;User Id=postgres;Password=123;Database=Pool;";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "INSERT client (fio, phone, bday,address ) VALUES ( @fio, @phone,@bday,@address)";
            SqlCommand cmd_SQL = new SqlCommand(sql, conn);
            
            cmd_SQL.Parameters.AddWithValue("@fio", textBox1.Text);
            cmd_SQL.Parameters.AddWithValue("@phone", textBox2.Text);
            cmd_SQL.Parameters.AddWithValue("@bday", textBox3.Text);
            cmd_SQL.Parameters.AddWithValue("@address", textBox4.Text);
            try
            {
                {
                    conn.Open();
                int n = cmd_SQL.ExecuteNonQuery();
               // lbl_Delete.Text += String.Format("Добавлено {0} записей", n);
            }
            catch (SqlException ex)
            {
                 throw new ApplicationException("error insert new_tovar", ex);
            }
            finally
            {
                conn.Close();
            }


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            
            NpgsqlCommand ifo = new NpgsqlCommand("SELECT fio FROM client WHERE \"id_client\" > :val1", conn);

                ifo.Parameters.Add(new NpgsqlParameter("val1", NpgsqlDbType.Integer));
                ifo.Parameters[0].Value = 1;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(ifo);
                DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
                conn.Close();
                this.comboBox1.DataSource = ds.Tables[0];
                this.comboBox1.DisplayMember = "fio";
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
