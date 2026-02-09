using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameProject.manu;
using MainMenu = GameProject.manu.MainMenu;

namespace GameProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(username.Text == "admin" && password.Text == "123")
            {
                this.Hide();

                MainMenu menu = new MainMenu();
                menu.FormClosed += (s, args) => this.Close();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
