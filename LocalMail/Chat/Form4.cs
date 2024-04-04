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
            AddColumnsToListView();
            this.Load += new System.EventHandler(this.Form4_Load);
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

        private void AddColumnsToListView()
        {
            // Создание столбцов для ListView
            allmsg_listView1.Columns.Add("Sender", 100, HorizontalAlignment.Left);
            allmsg_listView1.Columns.Add("Message", 200, HorizontalAlignment.Left);
            allmsg_listView1.Columns.Add("Date", 120, HorizontalAlignment.Left);
            allmsg_listView1.Columns.Add("Theme", 150, HorizontalAlignment.Left);
            allmsg_listView1.Columns.Add("Importance", 80, HorizontalAlignment.Left);
        }
        private void RequestMessagesFromServer(string userID)
        {
            int port = 8888;
            client = new TcpClient(user_IP, port);
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;

            // Отправка запроса на сервер для получения сообщений пользователя с указанным ID
            STW.WriteLine("{\"GetMessages\": \"" + userID + "\"}");

            // Ожидание ответа от сервера
            string jsonResponse = STR.ReadLine();

            // Десериализация JSON-ответа в список сообщений
            List<MessageData> messages = JsonConvert.DeserializeObject<List<MessageData>>(jsonResponse);

            // Очищаем ListView перед добавлением новых данных
            allmsg_listView1.Items.Clear();

            // Добавление полученных сообщений в ListView
            foreach (var message in messages)
            {
                ListViewItem item = new ListViewItem(message.Sender);
                item.SubItems.Add(message.Message);
                item.SubItems.Add(message.Date.ToString());
                item.SubItems.Add(message.Theme);
                item.SubItems.Add(message.Importance);
                allmsg_listView1.Items.Add(item);
            }
        }


        // Обработчик события загрузки формы
        private void Form4_Load(object sender, EventArgs e)
        {
            // Вызываем метод для отправки запроса на сервер для получения сообщений текущего пользователя
            RequestMessagesFromServer(user_ID);
        }

    }
}