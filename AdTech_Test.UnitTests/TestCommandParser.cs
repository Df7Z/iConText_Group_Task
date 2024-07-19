using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace iConText_Group_Task.UnitTests
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void ParseCommandData_add()
        {
            string input = "-add FirstName:John LastName:Doe Salary:100.50.";
          
            var mainStrings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
           
            var result = CommandArgumetsParser.ParseArguments(mainStrings);
       
            Assert.IsNotNull(result[0]);
        }

        [TestMethod]
        public void GetCommand()
        {
            EmployeesDataBase employeesDataBase = new EmployeesDataBase();

            employeesDataBase.Load(new EmployeesDataBaseFileElement[] { new EmployeesDataBaseFileElement() {
                Data = new EmployeesDataBaseElement() {
                 FirstName = "John",
                 LastName = "Doe",
                 SalaryPerHour = 100.50m,
                 Id = 6
                }
            }}); 

            var element = employeesDataBase.Get(6);

            Assert.IsNotNull(element);
        }
    }
}
