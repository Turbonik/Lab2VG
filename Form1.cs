using System;
using System.Windows.Forms;
using AuthenticationDLL;
using Lab2VG;

namespace Lab2VG
{
    public partial class Form1 : Form
    {
        private Authentication.UserRole _currentUserRole = Authentication.UserRole.Guest;
        private AuthoriseUserControl authoriseUserControl;
        private MenuUserControl menuUserControl;
        //private MenuStrip menuStrip1; // Remove this, use Menustrip from MenuUserControl

        public Form1()
        {
            InitializeComponent();

            authoriseUserControl = new AuthoriseUserControl();
            authoriseUserControl.AuthenticationCompleted += AuthoriseUserControl_AuthenticationCompleted;
            authoriseUserControl.Dock = DockStyle.Fill;
            Controls.Add(authoriseUserControl);

            menuUserControl = new MenuUserControl();
            menuUserControl.Dock = DockStyle.Fill;
            menuUserControl.Visible = false;  // Initially hidden
            Controls.Add(menuUserControl);

            //menuStrip1.Visible = false; // Initially hide the menu
        }

        private void AuthoriseUserControl_AuthenticationCompleted(object sender, Authentication.UserRole userRole)
        {
            _currentUserRole = userRole;
            authoriseUserControl.Visible = false;
            menuUserControl.Visible = true;


        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Это приложение виртуальной памяти.");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Справка");
        }

        private void разныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разные");
        }
        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сотрудники");
        }

        private void приказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приказы");
        }
        private void документыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Документы");
        }

        private void отделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Отделы");
        }

        private void городаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Города");
        }
        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Должности");
        }
        private void окноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Окно");
        }
    }
}