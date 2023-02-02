using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Press.Forms
{
    public partial class Registration : Form
    {
        private User newUser;
        public User NewUser
        {
            get
            {
                return newUser;
            }
        }
        public Registration()
        {
            InitializeComponent();
        }

        private void AuthorizationButton_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            var res = controller.Authorization(Login_TextBox1.Text, Password_TextBox1.Text);
            if (res == null)
            {
                Form1 form1 = new Form1(controller);

                form1.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show(res);
            }
        }

        private void Registration_Button_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            var res = controller.Registration(LoginTextBox2.Text, PasswordTextBox2.Text);
            if (res == null)
            {
                Form1 form1 = new Form1(controller);

                form1.Show();

                this.Visible = false;
            }
            else
            {
                MessageBox.Show(res);
            }
        }
    }
}
