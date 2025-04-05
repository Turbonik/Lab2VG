using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AuthenticationDLL;
using Lab2VG;
using MenuDLL;

namespace Lab2VG
{
    public partial class Form1 : Form
    {
        private Authentication.UserRole _currentUserRole;
   

        public Form1()
        {
            InitializeComponent();
     
            authoriseUserControl1.Visible = true;
            this.Activated += Form1_Activated; 
            this.Deactivate += Form1_Deactivated;
            this.Load += Form1_Load;
            authoriseUserControl1.OnUpdateStatus += UpdateStatusStripLabels;


        }

      

        private void Form1_Activated(object sender, EventArgs e)
        {
          
            UpdateStatus();
        }
        private void Form1_Deactivated(object sender, EventArgs e)
        {

            UpdateStatus();
        }
       
        private void UpdateStatusStripLabels(string language, string capsLock)
        {
            authoriseUserControl1.UpdateStatusLabels(language, capsLock);
        }


        private void UpdateStatus()
        {
            authoriseUserControl1.UpdateStatus();
        }

        protected override void WndProc(ref Message m)
        {
            
            if (m.Msg == 0x0051)
            {
                UpdateStatus(); 
            }

            
            if (m.Msg == 0x0101 || m.Msg == 0x0100)
            {
                Keys keyCode = (Keys)(int)m.WParam;
                if (keyCode == Keys.CapsLock)
                {
                    UpdateStatus();
                }

            }

            base.WndProc(ref m);
        }
    
    private void Form1_Load(object sender, EventArgs e)
        {
            StartAutentication();

        }

        private void StartAutentication()
        {

                authoriseUserControl1.AuthenticationCompleted += AuthoriseUserControl_AuthenticationCompleted;
                authoriseUserControl1.Dock = DockStyle.Fill;
                Controls.Add(authoriseUserControl1);
        
        }
        private void AuthoriseUserControl_AuthenticationCompleted(object sender, Authentication.UserRole userRole)
        {
            MenuUserControl menuControl;
            _currentUserRole = userRole;
            Controls.Clear();
         
            authoriseUserControl1.Visible = false;
          
            try
            {
                menuControl = new MenuUserControl(userRole);
                menuControl.Dock = DockStyle.Fill;
                menuControl.Visible = true;
                this.Controls.Add(menuControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

    
          
         

        }

    }

}