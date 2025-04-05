using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace AuthenticationDLL
{

    public class Authentication
    {
        public enum UserRole
        {
            Guest,
            Boss,
            HR,
            OO
        }

        public UserRole GetUserRole(string role)
        {
            switch (role)
            {
                case "Boss":
                    return UserRole.Boss;
                case "HR":
                    return UserRole.HR;
                case "OO":
                    return UserRole.OO;
                default:
                    return UserRole.Guest;
            }
        }

        private static Dictionary<string, (string password, UserRole role)> _users = new Dictionary<string, (string password, UserRole role)>();

       
        public static Dictionary<UserRole, Dictionary<string, int>> _roleMenuItems = new Dictionary<UserRole, Dictionary<string, int>>();

        public Authentication(string usersFilePath)
        {
            LoadUsersFromFile(usersFilePath);
        }

        public static UserRole AuthenticateUser(string username, string password)
        {
            foreach (var user in _users)
            {
                if (user.Key == username && user.Value.password == password)
                {
                    return user.Value.role;
                }
            }
            return UserRole.Guest;
        }

        private void LoadUsersFromFile(string usersFilePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(usersFilePath);

                foreach (string line in lines)
                {
                    if (line.StartsWith("#"))
                    {
                        string[] parts = line.Substring(1).Split(' ');
                        if (parts.Length == 2)
                        {
                            string username = parts[0];
                            string password = parts[1];
                            UserRole userRole = GetUserRole(username);
                            _users[username] = (password, userRole);

                          
                            if (!_roleMenuItems.ContainsKey(userRole))
                            {
                                _roleMenuItems[userRole] = new Dictionary<string, int>();
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(line))
                    {
                        int line_length = 2;
                        string[] parts = line.Split(' ');
                        if (parts.Length == line_length)
                        {
                            string menuItemName = parts[0];
                            if (int.TryParse(parts[1], out int accessLevel))
                            {
                             
                                string username = _users.Last().Key; 
                                UserRole userRole = _users[username].role;

                           
                                _roleMenuItems[userRole][menuItemName] = accessLevel;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Данные в файле имеют некорректный формат: {ex.Message}");
            }
        }

       
        public static int GetMenuItemAccessLevel(UserRole userRole, string menuItemName)
        {
            int closed_index = 2;
            if (_roleMenuItems.ContainsKey(userRole) && _roleMenuItems[userRole].ContainsKey(menuItemName))
            {
           
                return _roleMenuItems[userRole][menuItemName];
            }
            return closed_index; 
        }
    }
}