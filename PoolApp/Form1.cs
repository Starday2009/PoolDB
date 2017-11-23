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
        
       

        public Form1()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fuckDataSet.client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.fuckDataSet.client);


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
            string fio = textBox1.Text;
            int phone = Convert.ToInt32(textBox2.Text);
            DateTime bday = Convert.ToDateTime(dateTimePicker1.Text); ;
            string address = textBox4.Text;

            clientTableAdapter.Insert(fio, phone, bday, address);
            //обновляем таблицу
            clientTableAdapter.Fill(fuckDataSet.client);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Переносим значение текстового поля в таблицу
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            selectedRow.Cells["fioDataGridViewTextBoxColumn"].Value = textBox3.Text;
            selectedRow.Cells["phoneDataGridViewTextBoxColumn"].Value = textBox14.Text;
            selectedRow.Cells["bdayDataGridViewTextBoxColumn"].Value = textBox15.Text;
            selectedRow.Cells["addressDataGridViewTextBoxColumn"].Value = textBox16.Text;
            try
            {
                //сохраняем таблицу
                Validate();
                clientBindingSource.EndEdit();
                clientTableAdapter.Update(fuckDataSet.client);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Операция завершилась неудачей", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            int cell1 = Convert.ToInt16(selectedRow.Cells["idclientGridViewTextBoxColumn1"].Value);
            int cell2 = Convert.ToInt16(selectedRow.Cells["phoneDataGridViewTextBoxColumn"].Value);
            DateTime cell3 = Convert.ToDateTime(selectedRow.Cells["bdateDataGridViewTextBoxColumn"].Value);
            clientTableAdapter.Delete(cell1, cell2, cell3);
            clientTableAdapter.Fill(fuckDataSet.client);
        }
    }
}
