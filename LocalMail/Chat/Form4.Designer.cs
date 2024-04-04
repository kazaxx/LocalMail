namespace Chat
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            allmsg_listView1 = new ListView();
            msq_textBox1 = new TextBox();
            theme_textBox2 = new TextBox();
            recip_textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox3 = new ComboBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // allmsg_listView1
            // 
            allmsg_listView1.FullRowSelect = true;
            allmsg_listView1.GridLines = true;
            allmsg_listView1.Location = new Point(6, 124);
            allmsg_listView1.Name = "allmsg_listView1";
            allmsg_listView1.Size = new Size(189, 330);
            allmsg_listView1.TabIndex = 0;
            allmsg_listView1.UseCompatibleStateImageBehavior = false;
            allmsg_listView1.View = View.Details;
            // 
            // msq_textBox1
            // 
            msq_textBox1.Location = new Point(201, 124);
            msq_textBox1.Multiline = true;
            msq_textBox1.Name = "msq_textBox1";
            msq_textBox1.Size = new Size(588, 330);
            msq_textBox1.TabIndex = 1;
            // 
            // theme_textBox2
            // 
            theme_textBox2.Location = new Point(201, 24);
            theme_textBox2.Name = "theme_textBox2";
            theme_textBox2.Size = new Size(125, 27);
            theme_textBox2.TabIndex = 2;
            // 
            // recip_textBox3
            // 
            recip_textBox3.Location = new Point(201, 57);
            recip_textBox3.Name = "recip_textBox3";
            recip_textBox3.Size = new Size(125, 27);
            recip_textBox3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 27);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 4;
            label1.Text = "Тема";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(331, 60);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 5;
            label2.Text = "Кому";
            // 
            // button1
            // 
            button1.Location = new Point(695, 460);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Отправить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(600, 88);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(189, 27);
            dateTimePicker1.TabIndex = 7;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Старые", "Новые" });
            comboBox1.Location = new Point(6, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 8;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Не важно", "Важно" });
            comboBox2.Location = new Point(201, 90);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(125, 28);
            comboBox2.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(332, 98);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 10;
            label3.Text = "Тип важности";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 13);
            label4.Name = "label4";
            label4.Size = new Size(151, 20);
            label4.TabIndex = 11;
            label4.Text = "По дате добавления";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 67);
            label5.Name = "label5";
            label5.Size = new Size(135, 20);
            label5.TabIndex = 13;
            label5.Text = "По типу важности";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Важно", "Не важно" });
            comboBox3.Location = new Point(6, 90);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 12;
            // 
            // button2
            // 
            button2.Location = new Point(595, 460);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 14;
            button2.Text = "Назад";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 500);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(comboBox3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(recip_textBox3);
            Controls.Add(theme_textBox2);
            Controls.Add(msq_textBox1);
            Controls.Add(allmsg_listView1);
            Name = "Form4";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView allmsg_listView1;
        private TextBox msq_textBox1;
        private TextBox theme_textBox2;
        private TextBox recip_textBox3;
        private Label label1;
        private Label label2;
        private Button button1;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox3;
        private Button button2;
    }
}