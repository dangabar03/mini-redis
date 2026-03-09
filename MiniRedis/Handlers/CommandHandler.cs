using MiniRedis.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRedis.Handlers
{
    public class CommandHandler
    {
        private readonly InMemoryStore store;

        public CommandHandler(InMemoryStore store)
        {
            this.store = store;
        }


        public string Handle(string input)
        {

            //string[] arr = input.Split(' ');
            input = input.Trim();
            string[] arr = input.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);


            if (input == "")
            {
                return "string empty";
            }
            else if(input == "EXIT")
            {
                
            }
            else if (arr.Length < 2)
            {
                return "command err";
            }
            else if (arr[0] == "SET" && arr.Length < 3)
            {
                return "set command err";
            }
            else if ((arr[0] == "GET" || arr[0] == "DELETE") && arr.Length < 2)
            {
                return "get or del command err";
            }

            if (arr[0] == "SET")
            {
                store.Set(arr[1], arr[2]);
                return "Ok";
            }
            else if (arr[0] == "GET")
            {
                var b = store.Get(arr[1]);
                if (b == null) return "There is no item with specified key.";
                return b;
            }
            else if (arr[0] == "DELETE")
            {
                var d = store.Delete(arr[1]);
                return d.ToString();
            }
            else
            {
                return "There is no valid command";
            }

        }

    }
}
