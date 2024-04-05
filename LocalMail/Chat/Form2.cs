using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Chat.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Chat
{
    public partial class Form2 : Form
    {
        public class User
        {
            public static string User_id;
            public static string User_ip;
        }
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string IP;
        public Form2()
        {
            InitializeComponent();
            IP = DataStore.IP;
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        public class LoginData
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }


        private void button2_Click(object sender, EventArgs e)
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

                LoginData loginData = new LoginData()
                {
                    Login = login,
                    Password = password
                };


                string jsonData = JsonConvert.SerializeObject(loginData);

                STW.WriteLine(jsonData);

                string response = STR.ReadLine();


                if (response == "Успешно")
                {
                    User.User_id = textBox1.Text;
                    User.User_ip = IP;
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Ошибка входа");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
        }
    }
}
