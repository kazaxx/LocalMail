using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System;

namespace ServerPrac
{
    internal class Program
    {
        public class LoginData
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }


        public class RegisterData
        {
            public string NewLogin { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Department { get; set; }
        }


        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-2H544EL;Database=Local;Integrated Security=True;";
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

                    ProcessClient(client, connectionString);
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
                if (!client.Connected)
                {
                    return;
                }

                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;


                string jsonData = STR.ReadLine();
                LoginData loginData = JsonConvert.DeserializeObject<LoginData>(jsonData);


                if (jsonData.StartsWith("{\"NewLogin\":"))
                {
                   
                    RegisterData registerData = JsonConvert.DeserializeObject<RegisterData>(jsonData);

                    
                    using (var dbConnection = new SqlConnection(connectionString))
                    {
                        dbConnection.Open();

                       
                        string checkExistingUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @login";
                        SqlCommand checkExistingUserCmd = new SqlCommand(checkExistingUserQuery, dbConnection);
                        checkExistingUserCmd.Parameters.AddWithValue("@login", registerData.NewLogin);
                        int existingUserCount = (int)checkExistingUserCmd.ExecuteScalar();

                        if (existingUserCount > 0)
                        {
                           
                            STW.WriteLine("Логин уже занят");
                            return; 
                        }

                        string sql = "INSERT INTO Users (Username, Password, Name, Surname, Role, Department) VALUES (@login, @password, @name, @surname, 'User', @department);";

                        // Создание команды и параметров
                        SqlCommand cmd = new SqlCommand(sql, dbConnection);
                        cmd.Parameters.AddWithValue("@login", registerData.NewLogin);
                        cmd.Parameters.AddWithValue("@password", registerData.Password);
                        cmd.Parameters.AddWithValue("@name", registerData.Name);
                        cmd.Parameters.AddWithValue("@surname", registerData.Surname);
                        cmd.Parameters.AddWithValue("@department", registerData.Department);

                        cmd.ExecuteNonQuery();
                        STW.WriteLine("Успешная регистрация");

                        Console.WriteLine("Новый пользователь зарегистрировался: Логин: " + registerData.NewLogin + ", Пароль: " + registerData.Password + ", Имя: " + registerData.Name + ", Фамилия: " + registerData.Surname + ", Отдел: " + registerData.Department);
                    }
                }
                else
                {
                    using (var dbConnection = new SqlConnection(connectionString))
                    {
                        dbConnection.Open();
                        string sql = "SELECT * FROM Users WHERE username = @login AND password = @password";
                        SqlCommand cmd = new SqlCommand(sql, dbConnection);
                        cmd.Parameters.AddWithValue("@login", loginData.Login);
                        cmd.Parameters.AddWithValue("@password", loginData.Password);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            STW.WriteLine("Успешно");

                            while (reader.Read())
                            {
                                string username = reader["Username"].ToString();
                                string name = reader["Name"].ToString();
                                string surname = reader["Surname"].ToString();
                                string department = reader["Department"].ToString();

                                Console.WriteLine("Пользователь авторизован: Логин: " + username + ", Имя: " + name + ", Фамилия: " + surname + ", Отдел: " + department);
                            }
                        }
                        else
                        {
                            STW.WriteLine("Ошибка");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}