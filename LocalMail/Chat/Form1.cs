using System.ComponentModel;
using System.Net;
using System.Net.Sockets;

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

        private void button1_Click(object sender, EventArgs e)
        {
            int port= 8888;

            // Validate Client IP and Port
            if (!IsValidIP(IPTextBox.Text))
            {
                MessageBox.Show("Введите корректный IP-адрес клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                client = new TcpClient(IPTextBox.Text,port);
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;
                Form2 form2 = new Form2();
                form2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidIP(string ip)
        {
            IPAddress address;
            return IPAddress.TryParse(ip, out address);
        }
    }
}
