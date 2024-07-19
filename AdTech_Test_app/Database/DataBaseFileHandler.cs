using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace iConText_Group_Task
{
    [Serializable]
    public class EmployeesDataBaseFile
    {
        public EmployeesDataBaseFileElement[] Elements;

        public EmployeesDataBaseFile(EmployeesDataBaseFileElement[] elements)
        {
            Elements = elements;
        }
    }

    [Serializable]
    public struct EmployeesDataBaseFileElement
    {
        public EmployeesDataBaseElement Data;

        public EmployeesDataBaseFileElement(int id, EmployeesDataBaseElement publicData)
        {     
            Data = publicData;
        }

        public EmployeesDataBaseElement GetDataBaseElement()
        {
            var newElement = Data;

            return newElement;
        }
    }

    public static class DataBaseFileHandler
    {
        public static EmployeesDataBase Open(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            EmployeesDataBaseFile databaseFile = null;

            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();

                databaseFile = JsonConvert.DeserializeObject<EmployeesDataBaseFile>(json);
            }

            if (databaseFile is null)
            {
                databaseFile = new EmployeesDataBaseFile(new EmployeesDataBaseFileElement[0]);
            }


            EmployeesDataBase database = new EmployeesDataBase();

            database.Load(databaseFile.Elements);

            return database;
        }

        public static void Write(EmployeesDataBase database, string path)
        {
            EmployeesDataBaseFile databaseFile = new EmployeesDataBaseFile(database.Save().ToArray());

            var json = JsonConvert.SerializeObject(databaseFile, Formatting.Indented,
               new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                streamWriter.Write(json);
            }
        }
    }
}
