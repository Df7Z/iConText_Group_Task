using System;

namespace iConText_Group_Task
{
    public class GetCommand : CommandDataBase
    {
        private int _id;

        public GetCommand(string[] data) : base(data) {
            if (data is null || data.Length != 1)
            {
                throw new Exception("Неверное количество параметров!");
            }

            _id = CommandArgumetsParser.ParseId(data[0]);
        }

        public override void Execute<E>(DataBase<E> dataBase)
        {
            dataBase.Get(_id);
        }
    }
}
