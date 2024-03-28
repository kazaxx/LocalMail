using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerPrac
{
    internal class Program 
    { 

        static void Main(string[] args)
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            string ServerIP="";
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                     ServerIP = address.ToString();
                     Console.WriteLine(ServerIP);
                }
            }
            int port = 8888;

            // Validate Server IP and Port


            try
            {
                TcpClient client;
                TcpListener listener = new TcpListener(IPAddress.Parse(ServerIP), port);
                listener.Start();
                Console.WriteLine("Слушаем подключения по " + ServerIP + ":" + port);

                while (true) // Бесконечный цикл для прослушивания новых подключений
                {
                    client = listener.AcceptTcpClient();
                    Console.WriteLine("Новый клиент подключился!");

                    // Обработка подключения клиента
                    ProcessClient(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static void ProcessClient(TcpClient client)
        {
            StreamReader STR = new StreamReader(client.GetStream());
            StreamWriter STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;

            Console.WriteLine("Подключено");
            Console.WriteLine(client.Client.RemoteEndPoint);

            // Ваш код для обработки подключения клиента
            // ...
        }
    }
    
}
