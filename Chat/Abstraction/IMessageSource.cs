using System.Net;
using Chat.Models;

namespace Chat.Abstraction
{
    public interface IMessageSource
    {
        void Send(MessageUdp message, IPEndPoint ep);
        MessageUdp Receive(ref IPEndPoint ep);
    }
}