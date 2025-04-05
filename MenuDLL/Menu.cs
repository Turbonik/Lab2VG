using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;

using AuthenticationDLL;

namespace MenuDLL
{
  
    public class MenuItemData
    {
        public string Text { get; set; } 
        public string MethodName { get; set; } 
        public List<MenuItemData> SubItems { get; set; } 
        public string Name { get; set; }
   
        public Authentication.UserRole UserRole { get; set; }

        public MenuItemData()
        {
            SubItems = new List<MenuItemData>();
        }
    }


    public class MenuStructure
    {
        public List<MenuItemData> Items { get; set; }

        public MenuStructure()
        {
            Items = new List<MenuItemData>();
        }
    }
}