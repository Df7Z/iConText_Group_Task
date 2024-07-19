using System;

namespace iConText_Group_Task
{
    //Добавляет в файл новую запись.
    //Поля FirstName, LastName и SalaryPerHour заполняются из аргументов (John, Doe, 100.50).
    //Поле Id генерируется автоматически по следующему принципу: самое большое значение столбца Id, из всех имеющихся в файле, + 1.
    public class AddCommand : CommandDataBase
    {
        private string[] _parameters;

        public AddCommand(string[] data) : base(data)
        {
            if (data is null || data.Length != 3) {   
               throw new Exception("Неверное количество параметров!");              
            }

            _parameters = data;
        }

        public override void Execute<E>(DataBase<E> dataBase) => dataBase.Add(_parameters);
        
    }
}
