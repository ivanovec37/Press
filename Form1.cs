using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Press
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Press;Integrated Security=true;");
        SqlDataAdapter adapter;
        SqlCommand command;
        DataSet ds = new DataSet();


        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataError += (object sender, DataGridViewDataErrorEventArgs anError) =>
            {
                MessageBox.Show("Некорректный формат данных!");
                ShowTable();
            };
            ShowTable();
        }

        private void ShowTable()
        {
            try
            {
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].Rows.Clear();
                }

                adapter = new SqlDataAdapter("select Products.id as 'ID', [Name] as'Название',Circulation as 'Тираж',Price as 'Цена',Date_of_Sale as'Дата продажи'" +
                    ",Demand as'Спрос',Name_PUBL as'Издательство',Name_CNTR as 'Страна',Type.Name_TP as 'Тип'   from Products  " +
                    " inner join Publishing on Publishing.ID = Products.Publishing_FK " +
                    " inner join Type on Type.ID = Products.Type_FK" +
                    " inner join Country on Country.Id = Products.Country_FK; ", connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void SaveUpdate()
        {
            try
            {
                string save = "update Products set [Name] = @pName,Circulation = @pCirculation,Price = @pPrice," +
                    "Date_of_Sale=@pDate_of_Sale,Demand = @pDemand where Products.ID = @pID;";
                command = new SqlCommand(save, connection);
                command.Parameters.Add(new SqlParameter("@pName", SqlDbType.NVarChar, Parameters.MAX_PRODUCTS_NAME_LENGTH));
                command.Parameters.Add(new SqlParameter("@pCirculation", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@pPrice", SqlDbType.Money));
                command.Parameters.Add(new SqlParameter("@pDate_of_Sale", SqlDbType.Date));
                command.Parameters.Add(new SqlParameter("@pDemand", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@pID", SqlDbType.Int));

                command.Parameters["@pName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@pCirculation"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@pPrice"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@pDate_of_Sale"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@pDemand"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@pID"].SourceVersion = DataRowVersion.Original;

                command.Parameters["@pName"].SourceColumn = "Название";
                command.Parameters["@pCirculation"].SourceColumn = "Тираж";
                command.Parameters["@pPrice"].SourceColumn = "Цена";
                command.Parameters["@pDate_of_Sale"].SourceColumn = "Дата продажи";
                command.Parameters["@pDemand"].SourceColumn = "Спрос";
                command.Parameters["@pID"].SourceColumn = "ID";

                adapter.UpdateCommand = command;
                adapter.Update(ds);
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].Rows.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Некорректный формат данных!");
                ShowTable();
            }
        }
        //ДОДЕЛАТЬ
        //Издательство Поменять текст бокс на комбобокс и проверки исправить
        private void AddData()
        {
            if(Product_Name_TextBox.Text == "" || Publish_Name_TextBox.Text == "" ||
                Type_Press_ComboBox.SelectedIndex == -1 ||
                Country_ComboBox.SelectedIndex == -1 ||
                numericUpDown1.Value < Parameters.MIN_CIRCULATION ||
                Demand_NumericUpDown.Value < Parameters.MIN_DEMOND ||
                Price_NumericUpDown.Value < Parameters.MIN_PRICE ||
                Product_Name_TextBox.Text.Length > Parameters.MAX_PRODUCTS_NAME_LENGTH ||
                Publish_Name_TextBox.Text.Length > Parameters.MAX_PUBLICHING_NAME_LENGTH)
            {
                MessageBox.Show("Некорректно заполнены данные");
                return;
            }

            connection.Open();
            command = new SqlCommand($"insert into Users values (\'{Login_TextBox2.Text}\',\'{Password_TextBox2.Text}\');", connection);
            int number = command.ExecuteNonQuery();
            connection.Close();
            if (number == 0)
            {
                MessageBox.Show("Неудачная попытка входа");
                return;
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            SaveUpdate();
            ShowTable();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
