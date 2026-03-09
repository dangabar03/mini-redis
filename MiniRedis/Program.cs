using MiniRedis.Handlers;
using MiniRedis.Network;
using MiniRedis.Storage;

public class Program
{
    static void Main(string[] args)
    {
        InMemoryStore mem = new InMemoryStore();
        CommandHandler cmd = new CommandHandler(mem);
        RedisTcpServer server = new RedisTcpServer(6379, cmd);

        server.Start();

    }
}







//RedisTcpServer tcp = new RedisTcpServer(6379, cmd);
//tcp.Start();





//Console.WriteLine("Enter your command: ");
//Console.WriteLine("IMPORTANT!");
//Console.WriteLine("Valid commands are SET, GET or DELETE.");
//Console.WriteLine("Enter EXIT if you want program to finish.");