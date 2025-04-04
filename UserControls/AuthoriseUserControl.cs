﻿using System;
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
        private IAuthenticationModel model;
        private string usersFilePath = "users.txt";
        public event EventHandler<Authentication.UserRole> AuthenticationCompleted;

        public delegate void UpdateStatusDelegate(string language, string capsLock);
        public event UpdateStatusDelegate OnUpdateStatus;
        

        public AuthoriseUserControl()
        {
            InitializeComponent();
            model = new AuthenticationModel(usersFilePath);
            

        }
        public void UpdateStatusLabels(string language, string capsLock)
        {
            languageStatusLabel.Text = language;
            capsLockStatusLabel.Text = capsLock;
        }

        private void OnFormDeactivate(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        public void UpdateStatus()
        {
            string languageName = InputLanguage.CurrentInputLanguage.Culture.DisplayName;
            bool capsLock = Control.IsKeyLocked(Keys.CapsLock);
           
            OnUpdateStatus?.Invoke($"Язык ввода: {languageName}", $"Caps Lock: {(capsLock ? "Нажата" : "Отжата")}");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
          
       
            try
            {
               Authentication.UserRole userRole = model.AuthenticateUser(username, password);
                AuthenticationCompleted?.Invoke(this, userRole);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
