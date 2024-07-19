namespace iConText_Group_Task
{
    public class GetAllCommand : CommandDataBase
    {
        public GetAllCommand(string[] data) : base(data) {}

        public override void Execute<E>(DataBase<E> dataBase)
        {
            dataBase.GetAll();
        }
    }
}
