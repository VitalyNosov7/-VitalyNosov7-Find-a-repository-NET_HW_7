using Chat.Services;

namespace Chat
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServerNetMq.StartServer();

            ClientNetMq.StartClient();

        }
    }
}