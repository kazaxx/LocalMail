using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;

        }


        public void SetValues(string sender, string message, string date, string theme, string importance)
        {
            sender_label.Text = sender;
            message_label.Text = message;
            date_label.Text = date;
            theme_label.Text = theme;
            importance_label.Text = importance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
