using System;
using System.Collections.Generic;
using System.Text;

namespace iConText_Group_Task
{
    public class EmployeesDataBase : DataBase<EmployeesDataBaseElement> {

        public override string GetConsoleOutput(EmployeesDataBaseElement element)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(element.Id);
            stringBuilder.Append(" | ");
            stringBuilder.Append(element.FirstName);
            stringBuilder.Append(" | ");
            stringBuilder.Append(element.LastName);
            stringBuilder.Append(" | ");
            stringBuilder.Append(element.SalaryPerHour);

            return stringBuilder.ToString();
        }

        public override void Update(int id, string[] parameters)
        {
            var newElement = Get(id);

            ParseProperties(ref newElement, parameters);

            Update(id, newElement);            
        }

        public override void Add(string[] parameters) {
            EmployeesDataBaseElement newElement = new EmployeesDataBaseElement();

            ParseProperties(ref newElement, parameters);

            Add(newElement);
        }

        private void ParseProperties(ref EmployeesDataBaseElement newElement, string[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                var splitParam = parameters[i].Split(':');

                if (splitParam.Length != 2)
                {
                    throw new Exception("Неверное количество параметров!");
                }

                ParseProperties(ref newElement, splitParam[0], splitParam[1]);
            }

            void ParseProperties(ref EmployeesDataBaseElement element, string signature, string value)
            {

                switch (signature)
                {
                    case "FirstName":
                        {
                            element.FirstName = value;

                            break;
                        }
                    case "LastName":
                        {
                            element.LastName = value;

                            break;
                        }
                    case "Salary":
                        {
                            var decimalString = value.Replace('.', ',');

                            if (Decimal.TryParse(decimalString, out var decimalValue))
                            {
                                element.SalaryPerHour = decimalValue;
                            }
                            else
                            {
                                throw new Exception("Не удалось преобразовать Decimal!");
                            }

                            break;
                        }
                }
            }
        }

        #region SaveLoad

        public void Load(EmployeesDataBaseFileElement[] elements)
        {
            foreach (EmployeesDataBaseFileElement element in elements)
            {
                _elements.Add(element.GetDataBaseElement());
            }
        }

        public EmployeesDataBaseFileElement[] Save()
        {
            List<EmployeesDataBaseFileElement> list = new List<EmployeesDataBaseFileElement>();

            foreach (var element in _elements)
            {
                list.Add(new EmployeesDataBaseFileElement { Data = element});
            }

            return list.ToArray();
        }

        #endregion

    }
}
