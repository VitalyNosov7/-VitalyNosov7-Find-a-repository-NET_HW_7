using NetMQ;
using NetMQ.Sockets;

namespace Chat.Services
{
    public class ServerNetMq
    {
        public static void StartServer()
        {
            using (var server = new ResponseSocket())
            {
                server.Bind("tcp://*:5556");
                string msg = server.ReceiveFrameString();
                Console.WriteLine("From Client: {0}", msg);
                server.SendMoreFrame("Привет от").SendFrame("Сервера");
            }
        }
    }
}