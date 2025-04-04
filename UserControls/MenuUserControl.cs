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
using MenuDLL;

namespace Lab2VG
{
    public partial class MenuUserControl : UserControl 
    {
        private Authentication.UserRole _userRole;
        private MenuStructure _menuStructure;
        private const string menuFilePath = "menu.txt";
        public MenuUserControl(Authentication.UserRole userRole)
        {
            InitializeComponent();

            _userRole = userRole;
            LoadMenu();
        }

        private void LoadMenu()
        {
            _menuStructure = MenuReader.ReadMenuFromFile(menuFilePath);

            BuildMenu(_menuStructure.Items, menuStrip1.Items); 
        }

        private void BuildMenu(List<MenuItemData> menuItems, ToolStripItemCollection parentMenuItems)
        {
         
            foreach (MenuItemData menuItemData in menuItems)
            {
                
                int accessLevel = Authentication.GetMenuItemAccessLevel(_userRole, menuItemData.Text); 
                ToolStripMenuItem menuItem = new ToolStripMenuItem(menuItemData.Text);
               
                menuItem.Name = menuItemData.Name;
                menuItem.Click += MenuItem_Click; 
                menuItem.Visible = (accessLevel != 2); 
                menuItem.Enabled = (accessLevel == 0);  

                parentMenuItems.Add(menuItem);

               
                if (menuItemData.SubItems.Count > 0)
                {
                    BuildMenu(menuItemData.SubItems, menuItem.DropDownItems);
                }
            }
         
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
          
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string methodName = menuItem.Name; 
            if (!string.IsNullOrEmpty(methodName))
            {
                try
                {
                    GetType().GetMethod(methodName).Invoke(this, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при вызове метода {methodName}: {ex.Message}");
                }
            }
        }
        public void Others()
        {
            MessageBox.Show("Выбран пункт меню: Разное");
        }

        public void Stuff()
        {
            MessageBox.Show("Выбран пункт меню: Сотрудники");
        }

        public void Orders()
        {
            MessageBox.Show("Выбран пункт меню: Приказы");
        }

        public void Docs()
        {
            MessageBox.Show("Выбран пункт меню: Документы");
        }

        public void Spravochniki()
        {
            MessageBox.Show("Выбран пункт меню: Справочники");
        }

        public void Departs()
        {
            MessageBox.Show("Выбран пункт меню: Отделы");
        }

        public void Towns()
        {
            MessageBox.Show("Выбран пункт меню: Города");
        }

        public void Posts()
        {
            MessageBox.Show("Выбран пункт меню: Должности");
        }

        public void Window()
        {
            MessageBox.Show("Выбран пункт меню: Окно");
        }

        public void Help()
        {
            MessageBox.Show("Выбран пункт меню: Справка");
        }

        public void Content()
        {
            MessageBox.Show("Выбран пункт меню: Оглавление");
        }

        public void About()
        {
            MessageBox.Show("Информация о программе");
        }

        public void ApplicationExit()
        {
            Application.Exit();
        }
    }
}