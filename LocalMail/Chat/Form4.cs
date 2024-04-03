using Newtonsoft.Json;
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
using static Chat.Form2;

namespace Chat
{
    public partial class Form4 : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string user_ID;
        public string user_IP;
        public Form4()
        {
            user_ID = User.User_id;
            user_IP = User.User_ip;
            InitializeComponent();
        }
        public class MessageData
        {
            public string Sender { get; set; }
            public string Recipient { get; set; }
            public string Message { get; set; }
            public DateTime Date { get; set; }
            public string Theme { get; set; }
            public string Importance { get; set; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int port = 8888;
            DateTime date = dateTimePicker1.Value;
            string recip = recip_textBox3.Text;
            string theme = theme_textBox2.Text;
            string msg = msq_textBox1.Text;

            MessageData messageData = new MessageData()
            {
                Sender = user_ID, // Это должно быть имя пользователя, отправляющего сообщение
                Recipient = recip,
                Message = msg,
                Date = date,
                Theme = theme,
                Importance = "Normal" // или любой другой уровень важности, который вы хотите использовать
            };

            client = new TcpClient(user_IP, port);
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;
            // Сериализация в JSON и отправка
            string jsonData = JsonConvert.SerializeObject(messageData);
            STW.WriteLine(jsonData);

            // Чтение ответа от сервера
            string response = STR.ReadLine();
            if (response == "Сообщение отправлено")
            {
                MessageBox.Show("Сообщение успешно отправлено.");
            }
            else
            {
                MessageBox.Show("Ошибка отправки сообщения: " + response);
            }
        }
    }
}
