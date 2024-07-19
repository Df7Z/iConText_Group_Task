using System;
using System.ComponentModel;

namespace iConText_Group_Task
{
    public struct EmployeesDataBaseElement : IDataBaseElement
    {
        private int _id;
        public string FirstName;
        public string LastName;
        public decimal SalaryPerHour;

        public int Id { get => _id; set => _id = value; }
    }

}
