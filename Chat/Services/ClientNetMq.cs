using NetMQ;
using NetMQ.Sockets;


namespace Chat.Services
{
    public class ClientNetMq
    {
        public static void StartClient()
        {
            using (var client = new RequestSocket())
            {
                client.Connect("tcp://127.0.0.1:5556");
                client.SendFrame("Привет от клиента!");

                Console.WriteLine("Отправлено");

                var msg = client.ReceiveFrameString();
                Console.WriteLine("From Server: {0}", msg);
                while (client.HasIn)
                {
                    msg = client.ReceiveFrameString();
                    Console.WriteLine("From Server: {0}", msg);
                }

            }
        }
    }
}