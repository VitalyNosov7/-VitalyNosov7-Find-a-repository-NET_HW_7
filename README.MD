## Домашнее задание к Уроку 7. Библиотеки: Nuget и разработка собственных библиотек:

Доработайте чат, заменив UDP-сокеты на NetMQ. Для этого напишите новую библиотеку в которой имплементируются IMessageSours и IMessageSoursClient с применением указанной библиотеки.

---
## Решение:

Для решения задачи в проекте Chat(каталог Chat) были проделаны следующие действия:

1. Установлен NuGet пакет NetMQ;
2. Добавлен класс ServerNetMq:
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
                server.SendMoreFrame("Привет от").SendFrame("Сервера");
            }
        }
    }
}

```
3. Добавлен класс ClientNetMq:
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

```
---

P.S.: Считаю, что с задачей не справился. Есть понимание по отдельным фрагментам кода(по тестам, NuGet, работа с протоколами передачи данных, библиотекам и другими констукциями кода), а в общей логике программы окончательно запутался. Необходимо время, чтобы разобраться с логикой программы(общей картиной). Отдельно просматривал(с практикой в виде написания кода программ из этих уроков) дополнительные видеоуроки по клиент-серверным подключениям  (код практических занятий прилагаю в виде двух проектов(папки): 1. Chat_WCF и 2. ClientServer).