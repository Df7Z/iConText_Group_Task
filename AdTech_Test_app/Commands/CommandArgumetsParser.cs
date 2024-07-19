using System;
using System.Collections.Generic;

namespace iConText_Group_Task
{
    public static class CommandArgumetsParser
    {
        private class CommandData
        {
            public string Signature;
            public List<string> Parameters = new List<string>();
        }

        public static List<CommandDataBase> ParseArguments(string[] args)
        {
            if (args == null || args.Length == 0) return null;

            List<CommandData> commandDatas = new List<CommandData>();

            CommandData tempCommandData = null;

            foreach (var arg in args)
            {
                if (arg.StartsWith("-"))
                {
                    tempCommandData = new CommandData() { Signature = arg };
                    commandDatas.Add(tempCommandData);
                }
                else
                {
                    tempCommandData.Parameters.Add(arg);
                }
            }

            List <CommandDataBase> result = new List <CommandDataBase>(commandDatas.Capacity);

            foreach (var data in commandDatas)
            {
                var command = Parse(data);

                if (command == null) continue;

                result.Add(command);
            }

            return result;
        }

        private static CommandDataBase Parse(CommandData data)
        {
            var dataParameters = data.Parameters.ToArray();

            switch (data.Signature)
            {
                case "-add":
                {
                    return new AddCommand(dataParameters);
                }
                case "-update":
                {
                    return new UpdateCommand(dataParameters);
                }
                case "-get":
                {
                    return new GetCommand(dataParameters);
                }
                case "-delete":
                {
                    return new DeleteCommand(dataParameters);
                }
                case "-getall":
                {
                    return new GetAllCommand(dataParameters);
                }
                default:
                {
                    return null;
                }
            }
        }

        public static int ParseId(string data)
        {
            if (Int32.TryParse(data.Remove(0, 3), out int id))
            {
                return id;
            }
            else
            {
                throw new Exception("Не удалось преобразовать id!");
            }
        }
    }
}
