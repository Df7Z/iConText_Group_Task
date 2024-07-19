using System;

namespace iConText_Group_Task
{
    public class UpdateCommand : CommandDataBase
    {
        public string[] _parameters;
        public int _id;

        public UpdateCommand(string[] data) : base(data)
        {
            if (data is null || data.Length != 2)
            {
                throw new Exception("Неверное количество параметров!");
            }

            _id = CommandArgumetsParser.ParseId(data[0]);

            _parameters = data;
        }

        public override void Execute<E>(DataBase<E> dataBase)
        {
            dataBase.Update(_id, _parameters);
        }
    }
}
