using MiniRedis.Handlers;
using System.Net;
using System.Net.Sockets;

namespace MiniRedis.Network
{
    public class RedisTcpServer
    {
        int port;
        CommandHandler handler;
        TcpListener listener;

        public RedisTcpServer(int port, CommandHandler handler)
        {
            this.port = port;
            this.handler = handler;

        }

        public void Start()
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected");
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);

                string? input = reader.ReadLine();
                if (input == null)
                {
                    client.Close();
                }
                if(input == "EXIT")
                {
                    break;
                }
                else
                {

                    string response = handler.Handle(input);
                    writer.WriteLine(response);

                    //writer.WriteLine();
                    writer.Flush();
                }



                client.Close();
            }
        }


    }
}
