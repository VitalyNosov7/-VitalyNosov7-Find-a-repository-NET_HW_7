using System.Net.Sockets;
using System.Net;
using Chat.Models;
using Chat.Abstraction;

namespace Chat.Services;

public class Client
{
    IPEndPoint ipServer;
    UdpClient udpClient;

    private readonly string _adress;
    private readonly int _port;
    private readonly string _name;

    IMessageSource messageSource;

    public Client(IMessageSource source, string adress, int port, string name)
    {
        _adress = adress;
        _port = port;
        _name = name;
        messageSource = source;
        udpClient = new UdpClient(_port);
        ipServer = new IPEndPoint(IPAddress.Parse(_adress), _port);
    }

    public void Start()
    {
        new Thread(() => { Listener(); }).Start();
        Sender();
    }

    public void Listener()
    {
        while (true)
        {
            try
            {
                var message = messageSource.Receive(ref ipServer);
                Console.WriteLine("Получено сообщение от: " + message.FromName);
                Console.WriteLine(message.Text);

                Confirmation();
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникло исключение: " + e);
            }
        }
    }

    public void Sender()
    {

        while (true)
        {
            try
            {
                Console.WriteLine("Ожидается ввод сообщения:");
                var text = Console.ReadLine();
                Console.WriteLine("Введите имя получателя:");
                var toName = Console.ReadLine();

                MessageUdp message = new MessageUdp()
                {
                    Command = Command.Message,
                    ToName = toName,
                    FromName = _name,
                    Text = text
                };

                messageSource.Send(message, ipServer);

            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при обработке сообщения : " + e);
            }
        }
    }
    public void Register()
    {
        MessageUdp message = new MessageUdp()
        {
            Command = Command.Register,
            ToName = null,
            FromName = _name,
            Text = null
        };
        messageSource.Send(message, ipServer);
    }

    public void Confirmation()
    {
        MessageUdp message = new MessageUdp()
        {
            Command = Command.Confirmation,
            ToName = null,
            FromName = _name,
            Text = null
        };
        messageSource.Send(message, ipServer);
    }
}