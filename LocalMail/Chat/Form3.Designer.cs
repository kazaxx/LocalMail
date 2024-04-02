namespace Chat
{
    partial class Form3
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
            button3 = new Button();
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(300, 242);
            button3.Name = "button3";
            button3.Size = new Size(100, 44);
            button3.TabIndex = 11;
            button3.Text = "Регистрация";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(300, 68);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 18;
            label3.Text = "Пароль";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 22);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 17;
            label2.Text = "Логин";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(300, 86);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 16;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(300, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(300, 110);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 20;
            label1.Text = "Имя";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(300, 128);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 19;
            // 
            // button1
            // 
            button1.Location = new Point(300, 293);
            button1.Name = "button1";
            button1.Size = new Size(100, 44);
            button1.TabIndex = 21;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(300, 154);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 23;
            label4.Text = "Фамилия";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(300, 172);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(300, 198);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 25;
            label5.Text = "Отдел";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(300, 216);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 24;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 434);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form3";
            Text = "Регистрация";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Label label3;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox3;
        private Button button1;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
    }
}