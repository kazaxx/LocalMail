using Newtonsoft.Json;
using System;
using System.Collections;
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
        private ComboBox sortOrderComboBox;
        public string user_ID;
        public string user_IP;
        private System.Windows.Forms.Timer timer1;
        public Form4()
        {
            user_ID = User.User_id;
            user_IP = User.User_ip;
            InitializeComponent();
            AddColumnsToListView();
            comboBox3.SelectedIndexChanged += ComboBox3_SelectedIndexChanged;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            LoadComboBoxItems();
            this.Load += new System.EventHandler(this.Form4_Load);
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 5000; // Интервал в миллисекундах (5 секунд)
            timer1.Tick += Timer1_Tick;
            timer1.Start(); // Запускаем таймер

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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Выполняем запрос на сервер для получения новых сообщений
            RequestMessagesFromServer(user_ID);
        }


        private class ListViewItemImportanceComparer : IComparer
        {
            private SortOrder sortOrder;

            public ListViewItemImportanceComparer(SortOrder order)
            {
                sortOrder = order;
            }

            public int Compare(object x, object y)
            {
                ListViewItem item1 = (ListViewItem)x;
                ListViewItem item2 = (ListViewItem)y;

                // Получаем значения важности из строк элементов ListView
                string importance1 = item1.SubItems[4].Text; // Индекс столбца "Importance"
                string importance2 = item2.SubItems[4].Text;

                // Если важность не выбрана (пустая строка), то игнорируем ее при сортировке
                if (importance1 == "" || importance2 == "")
                    return 0;

                // Определяем порядок сортировки
                int result;
                if (importance1 == "Важно" && importance2 == "Не важно")
                    result = -1;
                else if (importance1 == "Не важно" && importance2 == "Важно")
                    result = 1;
                else
                    result = 0;

                // Учитываем порядок сортировки
                if (sortOrder == SortOrder.Descending)
                    result = -result;

                return result;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortListViewByDate();
        }


        private void SortListViewByDate()
        {
            // Определяем порядок сортировки на основе выбранного элемента в comboBox1
            SortOrder sortOrder = comboBox1.SelectedIndex == 0 ? SortOrder.Ascending : SortOrder.Descending;

            // Выполняем сортировку
            allmsg_listView1.Sorting = SortOrder.None;
            allmsg_listView1.ListViewItemSorter = new ListViewItemDateComparer(sortOrder);
            allmsg_listView1.Sort();
        }


        private class ListViewItemDateComparer : IComparer
        {
            private SortOrder sortOrder;

            public ListViewItemDateComparer(SortOrder order)
            {
                sortOrder = order;
            }

            public int Compare(object x, object y)
            {
                ListViewItem item1 = (ListViewItem)x;
                ListViewItem item2 = (ListViewItem)y;

                // Получаем даты из строк элементов ListView
                DateTime date1 = DateTime.Parse(item1.SubItems[2].Text);
                DateTime date2 = DateTime.Parse(item2.SubItems[2].Text);

                // Сравниваем даты в зависимости от порядка сортировки
                int result = DateTime.Compare(date1, date2);

                // Учитываем порядок сортировки
                if (sortOrder == SortOrder.Descending)
                    result = -result;

                return result;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int port = 8888;
            DateTime date = dateTimePicker1.Value;
            string recip = recip_textBox3.Text;
            string theme = theme_textBox2.Text;
            string msg = msq_textBox1.Text;
            string importance = comboBox2.SelectedItem != null ? comboBox2.SelectedItem.ToString() : "";
            MessageData messageData = new MessageData()
            {
                Sender = user_ID, // Это должно быть имя пользователя, отправляющего сообщение
                Recipient = recip,
                Message = msg,
                Date = date,
                Theme = theme,
                Importance = importance // Используем значение из ComboBox                                        // или любой другой уровень важности, который вы хотите использовать
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


        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortListViewByImportance();
        }


        private void SortListViewByImportance()
        {
            // Определяем порядок сортировки на основе выбранного элемента в comboBox3
            SortOrder sortOrder = comboBox3.SelectedIndex == 0 ? SortOrder.Ascending : SortOrder.Descending;

            // Выполняем сортировку
            allmsg_listView1.Sorting = SortOrder.None;
            allmsg_listView1.ListViewItemSorter = new ListViewItemImportanceComparer(sortOrder);
            allmsg_listView1.Sort();
        }


        private void SaveComboBoxItems()
        {
            List<string> items = comboBox1.Items.Cast<string>().ToList(); // Получение всех элементов ComboBox
            string json = JsonConvert.SerializeObject(items); // Сериализация в JSON
            System.IO.File.WriteAllText("ComboBoxItems.json", json); // Сохранение JSON в файл
        }


        private void LoadComboBoxItems()
        {
            if (System.IO.File.Exists("ComboBoxItems.json"))
            {
                string json = System.IO.File.ReadAllText("ComboBoxItems.json"); // Чтение JSON из файла
                List<string> items = JsonConvert.DeserializeObject<List<string>>(json); // Десериализация JSON
                comboBox2.DataSource = items; // Используем List<string> без обертки
            }
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            // Вызываем метод для отправки запроса на сервер для получения сообщений текущего пользователя
            RequestMessagesFromServer(user_ID);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void allmsg_listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (allmsg_listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = allmsg_listView1.SelectedItems[0];
                string senderValue = "Отправитель: " + selectedItem.SubItems[0].Text;
                string message = "Сообщение: " + selectedItem.SubItems[1].Text;
                string date = "Дата: " + selectedItem.SubItems[2].Text;
                string theme = "Тема: " + selectedItem.SubItems[3].Text;
                string importance = "Важность: " + selectedItem.SubItems[4].Text;

                Form5 detailsForm = new Form5();
                detailsForm.SetValues(senderValue, message, date, theme, importance);
                detailsForm.Show();
            }
        }
    }
}