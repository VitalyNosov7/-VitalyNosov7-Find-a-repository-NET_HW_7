using System.Net.Sockets;
using System.Net;
using System.Text;
using Chat.Abstraction;
using Chat.Models;

namespace Chat.Services
{
    public class UdpMessageSource : IMessageSource
    {
        private UdpClient udpClient;

        public UdpMessageSource()
        {
            udpClient = new UdpClient(12345);
        }

        public MessageUdp Receive(ref IPEndPoint ep)
        {
            byte[] receiveBytes = udpClient.Receive(ref ep);
            string receivedData = Encoding.UTF8.GetString(receiveBytes);

            return MessageUdp.MessageFromJson(receivedData);
        }

        public void Send(MessageUdp message, IPEndPoint ep)
        {
            byte[] forwardBytes = Encoding.UTF8.GetBytes(message.MessageToJson());

            udpClient.Send(forwardBytes, forwardBytes.Length, ep);
        }
    }
}