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
        private string menuFilePath = "menu.txt";
        private MenuStructure menuStructure; // Declare the menuStructure here

        public MenuUserControl()
        {
            InitializeComponent();
            //LoadMenu(menuStrip1); // Load the menu
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadMenu(); // Call LoadMenu without passing menuStrip
        }

        private void LoadMenu() // Removed MenuStrip parameter
        {
            Console.WriteLine("LoadMenu вызван!"); // Добавлено для отладки
            menuStructure = MenuReader.ReadMenuFromFile(menuFilePath); // Load menuStructure

            CreateMenuItems(); // Call CreateMenuItems without passing menuStructure
        }

        // New method to generate the MenuItems
        private void CreateMenuItems() // Removed MenuStrip parameter
        {
            Console.WriteLine("CreateMenuItems вызван!"); // Добавлено для отладки
            menuStrip1.Items.Clear(); // Clear existing items
            foreach (MenuItemData menuItemData in menuStructure.Items) // Use menuStructure here
            {
                ToolStripMenuItem menuItem = CreateMenuItem(menuItemData);
                menuStrip1.Items.Add(menuItem);
            }
        }

        private ToolStripMenuItem CreateMenuItem(MenuItemData menuItemData)
        {
            Console.WriteLine($"Создание пункта меню: {menuItemData.Text}"); // Добавлено для отладки
            ToolStripMenuItem menuItem = new ToolStripMenuItem(menuItemData.Text);
            menuItem.Name = menuItemData.Name; // Set the name
            if (!string.IsNullOrEmpty(menuItemData.MethodName))
            {
                menuItem.Click += (sender, e) =>
                {
                    MessageBox.Show($"Вызван метод: {menuItemData.MethodName}");
                };
            }

            foreach (MenuItemData subItemData in menuItemData.SubItems)
            {
                menuItem.DropDownItems.Add(CreateMenuItem(subItemData));
            }

            return menuItem;
        }
    }
}