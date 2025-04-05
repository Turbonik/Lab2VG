using System;
using System.Collections.Generic;
using System.IO;

namespace MenuDLL
{
    public class MenuReader
    {
        public static MenuStructure ReadMenuFromFile(string menuFilePath)
        {
            MenuStructure menuStructure = new MenuStructure();
            Dictionary<int, MenuItemData> parentMenuItems = new Dictionary<int, MenuItemData>();
            MenuItemData previousItem = null;
            try
            {
                string[] lines = File.ReadAllLines(menuFilePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');

                    if (parts.Length >= 2)
                    {
                        if (int.TryParse(parts[0], out int level))
                        {
                            string itemName = parts[1];
                            string methodName = parts.Length > 3 ? parts[3] : null;

                            MenuItemData menuItem = new MenuItemData();
                            menuItem.Text = itemName;
                            menuItem.MethodName = methodName;
                            menuItem.Name = methodName;
          

                            if (level == 0)
                            {
                                menuStructure.Items.Add(menuItem);
                            }
                            else if (parentMenuItems.ContainsKey(level - 1))
                            {
                                parentMenuItems[level - 1].SubItems.Add(menuItem);
                            }
                            parentMenuItems[level] = menuItem;
                            previousItem = menuItem;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 throw new Exception($"Данные в файле имеют некорректный формат: {ex.Message}");
            }

            return menuStructure;
        }
    }
}