using Newtonsoft.Json;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
namespace Chat
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public Form1()
        {
            InitializeComponent();
        }
        public class LoginData
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private bool IsValidIP(string ip)
        {
            IPAddress address;
            return IPAddress.TryParse(ip, out address);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int port = 8888;
            // Validate Client IP and Port
            if (!IsValidIP(IPTextBox.Text))
            {
                MessageBox.Show("Введите корректный IP-адрес клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                client = new TcpClient(IPTextBox.Text, port);
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



                if (response =="Успешно") 
                { 
                Form2 form2 = new Form2();
                form2.Show();
                }
                else
                {
                    MessageBox.Show("ИДИ НАХУЙ УЁБИЩЕ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
