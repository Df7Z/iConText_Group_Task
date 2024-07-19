namespace iConText_Group_Task
{
    public abstract class CommandDataBase
    {
        public CommandDataBase(string[] data) { }

        public abstract void Execute<E>(DataBase<E> dataBase) where E : IDataBaseElement;
    }
}

