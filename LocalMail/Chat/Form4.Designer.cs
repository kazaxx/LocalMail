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
            allmsg_listView1 = new ListView();
            msq_textBox1 = new TextBox();
            theme_textBox2 = new TextBox();
            recip_textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // allmsg_listView1
            // 
            allmsg_listView1.Location = new Point(-4, 83);
            allmsg_listView1.Name = "allmsg_listView1";
            allmsg_listView1.Size = new Size(189, 330);
            allmsg_listView1.TabIndex = 0;
            allmsg_listView1.UseCompatibleStateImageBehavior = false;
            // 
            // msq_textBox1
            // 
            msq_textBox1.Location = new Point(201, 83);
            msq_textBox1.Multiline = true;
            msq_textBox1.Name = "msq_textBox1";
            msq_textBox1.Size = new Size(588, 330);
            msq_textBox1.TabIndex = 1;
            // 
            // theme_textBox2
            // 
            theme_textBox2.Location = new Point(201, 3);
            theme_textBox2.Name = "theme_textBox2";
            theme_textBox2.Size = new Size(125, 27);
            theme_textBox2.TabIndex = 2;
            // 
            // recip_textBox3
            // 
            recip_textBox3.Location = new Point(201, 36);
            recip_textBox3.Name = "recip_textBox3";
            recip_textBox3.Size = new Size(125, 27);
            recip_textBox3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 6);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 4;
            label1.Text = "Тема";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(332, 39);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 5;
            label2.Text = "Кому";
            // 
            // button1
            // 
            button1.Location = new Point(657, 419);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Отправить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 36);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(173, 27);
            dateTimePicker1.TabIndex = 7;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}