using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuthenticationDLL;

namespace Lab2VG
{
    public partial class AuthoriseUserControl : UserControl
    {
        private Authentication authentication;
        private string usersFilePath = "users.txt";

        public event EventHandler<Authentication.UserRole> AuthenticationCompleted;

        public AuthoriseUserControl()
        {
            InitializeComponent();
            authentication = new Authentication(usersFilePath);
            string usersList = "Список пользователей:\n";
            foreach (var user in authentication.GetUsers())
            {
                usersList += $"Имя: {user.Key}, Пароль: {user.Value.password}, Роль: {user.Value.role}\n";
            }
            MessageBox.Show(usersList, "Отладка: Список пользователей");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
          
            MessageBox.Show($"Попытка входа: Имя = {username}, Пароль = {password}");
            Authentication.UserRole userRole = Authentication.AuthenticateUser(username, password);
            MessageBox.Show($"Роль пользователя: {userRole}");
     
            if (AuthenticationCompleted != null)
            {
                AuthenticationCompleted(this, userRole);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
