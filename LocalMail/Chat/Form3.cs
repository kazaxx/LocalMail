using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Chat.Form1;
using static Chat.Form2;
using Newtonsoft.Json;

namespace Chat
{
    public partial class Form3 : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string IP;
        public Form3()
        {
            InitializeComponent();
            IP = DataStore.IP;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public class RegisterData
        {
            public string NewLogin { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Department { get; set; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int port = 8888;

            try
            {
                client = new TcpClient(IP, port);
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;

                string login = textBox1.Text;
                string password = textBox2.Text;
                string name = textBox3.Text;
                string surname = textBox4.Text;
                string department = textBox5.Text;

                RegisterData registerData = new RegisterData()
                {
                    NewLogin = login,
                    Password = password,
                    Name = name,
                    Surname = surname,
                    Department = department
                };

                string jsonData = JsonConvert.SerializeObject(registerData);

                STW.WriteLine(jsonData);

                string response = STR.ReadLine();

                if (response == "Успешная регистрация")
                {
                    MessageBox.Show("Регистрация прошла успешно!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                else
                {
                    MessageBox.Show("Ошибка регистрации: " + response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
        }
    }
}
