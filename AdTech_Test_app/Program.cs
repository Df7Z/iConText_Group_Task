using System;
using System.IO;

namespace iConText_Group_Task
{
    internal class Program
    {
        private const string EMPLOYEES_DB_PATH = "Employees.json";

        static void Main(string[] args)
        {
            var commands = CommandArgumetsParser.ParseArguments(args);

            if (commands is null) Console.WriteLine("Аргументы не заданы!");

            var pathDatabase = Path.Combine(Environment.CurrentDirectory, EMPLOYEES_DB_PATH);
   
            var employeesDataBase = DataBaseFileHandler.Open(pathDatabase);

            foreach (var command in commands)
            {
                command.Execute(employeesDataBase);
            }

            DataBaseFileHandler.Write(employeesDataBase, pathDatabase);

            Console.ReadLine();
        }
    }
}
