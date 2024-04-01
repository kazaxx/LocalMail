using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace ServerPrac
{
    internal class Program
    {
        public class LoginData
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
        static void Main(string[] args)
        {
            string connectionString = "Server=090LAPTOP;Database=Local;Integrated Security=True;"; // Строка подключения к БД
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            string ServerIP = "";
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ServerIP = address.ToString();
                    Console.WriteLine(ServerIP);
                }
            }
            int port = 8888;

            try
            {
                TcpClient client;
                TcpListener listener = new TcpListener(IPAddress.Parse(ServerIP), port);
                listener.Start();
                Console.WriteLine("Слушаем подключения по " + ServerIP + ":" + port);

                while (true)
                {
                    client = listener.AcceptTcpClient();
                    Console.WriteLine("Новый клиент подключился!");

                    ProcessClient(client, connectionString); // Передайте строку подключения в ProcessClient
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static void ProcessClient(TcpClient client, string connectionString)
        {
            StreamReader STR;
            StreamWriter STW;

            try
            {
                // Проверка, было ли установлено соединение
                if (!client.Connected)
                {
                    return; // Выход из метода, если соединение не установлено
                }

                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;

                Console.WriteLine("Подключено");
                Console.WriteLine(client.Client.RemoteEndPoint);

                // Получение данных от клиента
                string jsonData = STR.ReadLine();
                LoginData loginData = JsonConvert.DeserializeObject<LoginData>(jsonData);

                // Проверка логина и пароля
                using (var dbConnection = new SqlConnection(connectionString))
                {
                    dbConnection.Open();
                    string sql = "SELECT * FROM Users WHERE username = @login AND password = @password";
                    SqlCommand cmd = new SqlCommand(sql, dbConnection);
                    cmd.Parameters.AddWithValue("@login", loginData.Login);
                    cmd.Parameters.AddWithValue("@password", loginData.Password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Отправка ответа в зависимости от результата проверки
                    if (reader.HasRows)
                    {
                        STW.WriteLine("Успешно");
                    }
                    else
                    {
                        STW.WriteLine("Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

    }
}
