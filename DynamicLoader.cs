using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Lab2VG
{
    public class DynamicMenuLoader
    {
        public static object ReadMenuFromFile(Assembly assembly, string menuFilePath)
        {
            try
            {
                Type menuReaderType = assembly.GetType("MenuDLL.MenuReader");
                if (menuReaderType == null)
                {
                    throw new Exception("Не удалось найти класс MenuReader.");
                }

                MethodInfo readMenuFromFileMethod = menuReaderType.GetMethod("ReadMenuFromFile", new Type[] { typeof(string) });
                if (readMenuFromFileMethod == null)
                {
                    throw new Exception("Не удалось найти метод ReadMenuFromFile.");
                }

                object menuStructure = readMenuFromFileMethod.Invoke(null, new object[] { menuFilePath });

                return menuStructure;
            }
            catch (Exception ex)
            {
               throw new Exception($"Ошибка динамической загрузки: {ex.Message}");
            }
        }
    }
}
