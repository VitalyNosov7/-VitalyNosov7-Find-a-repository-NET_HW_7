## �������� ������� � ����� 7. ����������: Nuget � ���������� ����������� ���������:

����������� ���, ������� UDP-������ �� NetMQ. ��� ����� �������� ����� ���������� � ������� ���������������� IMessageSours � IMessageSoursClient � ����������� ��������� ����������.

---
## �������:

��� ������� ������ � ������� Chat(������� Chat) ���� ��������� ��������� ��������:

1. ���������� NuGet ����� NetMQ;
2. �������� ����� ServerNetMq:
```
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
                server.SendMoreFrame("������ ��").SendFrame("�������");
            }
        }
    }
}

```
3. �������� ����� ClientNetMq:
```
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
                client.SendFrame("������ �� �������!");

                Console.WriteLine("����������");

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

```
---

P.S.: ������, ��� � ������� �� ���������. ���� ��������� �� ��������� ���������� ����(�� ������, NuGet, ������ � ����������� �������� ������, ����������� � ������� ������������ ����), � � ����� ������ ��������� ������������ ���������. ���������� �����, ����� ����������� � ������� ���������(����� ��������). �������� ������������(� ��������� � ���� ��������� ���� �������� �� ���� ������) �������������� ���������� �� ������-��������� ������������  (��� ������������ ������� �������� � ���� ���� ��������(�����): 1. Chat_WCF � 2. ClientServer).