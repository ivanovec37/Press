using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Press.Forms
{
    public partial class Registration : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Press;Integrated Security=true;");
        SqlDataAdapter adapter;
        SqlCommand command;
        DataSet ds = new DataSet();

        public Registration()
        {
            InitializeComponent();

        }

        private void AuthorizationButton_Click(object sender, EventArgs e)
        {
            if (Login_TextBox1.Text.Length > Parameters.MAX_LOGIN_LENGTH)
            {
                MessageBox.Show($"Логин должен быть короче {Parameters.MAX_LOGIN_LENGTH} символов ");
                return;
            }
            if (Password_TextBox1.Text.Length > Parameters.MAX_PASSWORD_LENGTH)
            {
                MessageBox.Show($"Пароль должен быть короче {Parameters.MAX_PASSWORD_LENGTH} символов ");
                return;
            }
            if (Login_TextBox1.Text.Length == 0 || Password_TextBox1.Text.Length == 0)
            {
                MessageBox.Show($"Введите логин и пароль!");
                return;
            }

            adapter = new SqlDataAdapter($"select Users.ID from Users" +
                $" where Users.Login = '{Login_TextBox1.Text}' and Users.Password ='{Password_TextBox1.Text}'; ", connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            if(ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Нет такого пользователя");
                return;
            }

            Form1 form1 = new Form1();

            form1.Show();
            this.Visible = false;

        }

        private void Registration_Button_Click(object sender, EventArgs e)
        {
            if (Login_TextBox2.Text.Length > Parameters.MAX_LOGIN_LENGTH)
            {
                MessageBox.Show($"Логин должен быть короче {Parameters.MAX_LOGIN_LENGTH} символов ");
                return;
            }
            if (Password_TextBox2.Text.Length > Parameters.MAX_PASSWORD_LENGTH)
            {
                MessageBox.Show($"Пароль должен быть короче {Parameters.MAX_PASSWORD_LENGTH} символов ");
                return;
            }
            if (Login_TextBox2.Text.Length == 0 || Password_TextBox2.Text.Length == 0)
            {
                MessageBox.Show($"Введите логин и пароль!");
                return;
            }
            adapter = new SqlDataAdapter($"select Users.ID from Users" +
               $" where Users.Login = '{Login_TextBox2.Text}' ; ", connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }
            connection.Open();
            command = new SqlCommand( $"insert into Users values (\'{Login_TextBox2.Text}\',\'{Password_TextBox2.Text}\');", connection);
            int number = command.ExecuteNonQuery();
            connection.Close();
            if (number == 0)
            {
                MessageBox.Show("Неудачная попытка входа");
                return;
            }

            Form1 form1 = new Form1();
            form1.Show();
            this.Visible = false;

        }
    }
}
