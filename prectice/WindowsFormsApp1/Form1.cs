using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public string TextToSennd;
        public Form1()
        {
            InitializeComponent();
            IPAddress[]  localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress  address  in localIP)
            {
                if(address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ServerIPtextBox.Text = address.ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            int port;

            // Validate Server IP and Port
            if (!IsValidIP(ServerIPtextBox.Text))
            {
                MessageBox.Show("Введите корректный IP-адрес сервера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(ServerPorttextBox.Text, out port))
            {
                MessageBox.Show("Введите корректный номер порта сервера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                TcpListener listener = new TcpListener(IPAddress.Parse(ServerIPtextBox.Text), port);
                listener.Start();
                client = listener.AcceptTcpClient();
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int port;

            // Validate Client IP and Port
            if (!IsValidIP(CleenttextBox.Text))
            {
                MessageBox.Show("Введите корректный IP-адрес клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(ClientPorrttextBox.Text, out port))
            {
                MessageBox.Show("Введите корректный номер порта клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                client = new TcpClient(CleenttextBox.Text, port);
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.WorkerSupportsCancellation = true;
                ChatScreentexttBox.AppendText("\nПодключено к серверу\n");
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    recieve = STR.ReadLine();
                    this.ChatScreentexttBox.Invoke(new MethodInvoker(delegate ()
                    {
                        ChatScreentexttBox.AppendText("\nYou: " + recieve + "\n");
                    }));
                    recieve = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(TextToSennd);
                this.ChatScreentexttBox.Invoke(new MethodInvoker(delegate ()
                {
                    ChatScreentexttBox.AppendText("\nMe: " + TextToSennd + "\n");
                }));
            }
            else
            {
                MessageBox.Show("Ошибка");
            }

            backgroundWorker2.CancelAsync();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(MessagetextBox.Text!="")
            {
                TextToSennd = MessagetextBox.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            MessagetextBox.Text = "";
        }
    }
}
