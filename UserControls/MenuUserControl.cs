using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuthenticationDLL;


namespace Lab2VG
{
    public partial class MenuUserControl : UserControl
    {

        private Authentication.UserRole _userRole;
        private object _menuStructure;
        private const string menuFilePath = "menu.txt";
        private const string menuDllPath = @"C:\Users\2013o\source\repos\Lab2VG\bin\Debug\MenuDLL.dll";
        private static Assembly _menuAssembly;

        public MenuUserControl(Authentication.UserRole userRole)
        {
            InitializeComponent();
            _userRole = userRole;
            LoadMenu();
        }

        private void LoadMenu()
        {
            try
            {
                _menuAssembly = LoadAssembly(menuDllPath);
                if (_menuAssembly == null)
                {
                    MessageBox.Show("Не удалось загрузить MenuDLL.dll", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _menuStructure = DynamicMenuLoader.ReadMenuFromFile(_menuAssembly, menuFilePath);

                if (_menuStructure != null)
                {
                    Type menuStructureType = _menuStructure.GetType();
                    PropertyInfo itemsProperty = menuStructureType.GetProperty("Items");
                    IEnumerable enumerable = (IEnumerable)itemsProperty.GetValue(_menuStructure);
                    List<object> menuItems = enumerable.Cast<object>().ToList();

                    BuildMenu(menuItems, menuStrip1.Items);
                }
                else
                {
                    MessageBox.Show("Не удалось загрузить структуру меню.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке меню: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static Assembly LoadAssembly(string dllPath)
        {
            try
            {
                return Assembly.LoadFrom(dllPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке сборки: {ex.Message}");
                return null;
            }
        }

        private void BuildMenu(List<object> menuItems, ToolStripItemCollection parentMenuItems)
        {
            foreach (object menuItemDataObject in menuItems)
            {
                Type menuItemDataType = menuItemDataObject.GetType();
                PropertyInfo textProperty = menuItemDataType.GetProperty("Text");
                PropertyInfo methodNameProperty = menuItemDataType.GetProperty("MethodName");
                PropertyInfo subItemsProperty = menuItemDataType.GetProperty("SubItems");
                PropertyInfo nameProperty = menuItemDataType.GetProperty("Name");

                string itemName = (string)textProperty.GetValue(menuItemDataObject);
              
               
                List<object> subItems = ((IEnumerable)subItemsProperty.GetValue(menuItemDataObject))?.Cast<object>().ToList(); 

                string name = (string)nameProperty.GetValue(menuItemDataObject);

                int accessLevel = Authentication.GetMenuItemAccessLevel(_userRole, itemName);
                ToolStripMenuItem menuItem = new ToolStripMenuItem(itemName);

                menuItem.Name = name;
                menuItem.Click += MenuItem_Click;
                menuItem.Visible = (accessLevel != 2);
                menuItem.Enabled = (accessLevel == 0);

                parentMenuItems.Add(menuItem);

                if (subItems != null && subItems.Count > 0)
                {
                    BuildMenu(subItems, menuItem.DropDownItems);
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
                    MethodInfo method = GetType().GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);

                    if (method != null)
                    {
                        method.Invoke(this, null);
                    }
                    else
                    {
                        MessageBox.Show($"Метод {methodName} не найден в MenuUserControl.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при вызове метода {methodName}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExampleMethod()
        {
            MessageBox.Show("Example method called!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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