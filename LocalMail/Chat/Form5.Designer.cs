namespace Chat
{
    partial class Form5
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
            sender_label = new Label();
            message_label = new Label();
            date_label = new Label();
            theme_label = new Label();
            importance_label = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // sender_label
            // 
            sender_label.AutoSize = true;
            sender_label.Font = new Font("Segoe UI", 15F);
            sender_label.Location = new Point(24, 21);
            sender_label.Name = "sender_label";
            sender_label.Size = new Size(65, 28);
            sender_label.TabIndex = 0;
            sender_label.Text = "label1";
            // 
            // message_label
            // 
            message_label.AutoSize = true;
            message_label.Font = new Font("Segoe UI", 15F);
            message_label.Location = new Point(24, 60);
            message_label.Name = "message_label";
            message_label.Size = new Size(65, 28);
            message_label.TabIndex = 1;
            message_label.Text = "label2";
            // 
            // date_label
            // 
            date_label.AutoSize = true;
            date_label.Font = new Font("Segoe UI", 15F);
            date_label.Location = new Point(24, 97);
            date_label.Name = "date_label";
            date_label.Size = new Size(65, 28);
            date_label.TabIndex = 2;
            date_label.Text = "label3";
            // 
            // theme_label
            // 
            theme_label.AutoSize = true;
            theme_label.Font = new Font("Segoe UI", 15F);
            theme_label.Location = new Point(24, 135);
            theme_label.Name = "theme_label";
            theme_label.Size = new Size(65, 28);
            theme_label.TabIndex = 3;
            theme_label.Text = "label4";
            // 
            // importance_label
            // 
            importance_label.AutoSize = true;
            importance_label.Font = new Font("Segoe UI", 15F);
            importance_label.Location = new Point(24, 176);
            importance_label.Name = "importance_label";
            importance_label.Size = new Size(65, 28);
            importance_label.TabIndex = 4;
            importance_label.Text = "label5";
            // 
            // button1
            // 
            button1.Location = new Point(24, 217);
            button1.Name = "button1";
            button1.Size = new Size(338, 23);
            button1.TabIndex = 5;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 253);
            Controls.Add(button1);
            Controls.Add(importance_label);
            Controls.Add(theme_label);
            Controls.Add(date_label);
            Controls.Add(message_label);
            Controls.Add(sender_label);
            Name = "Form5";
            Text = "Form5";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label sender_label;
        private Label message_label;
        private Label date_label;
        private Label theme_label;
        private Label importance_label;
        private Button button1;
    }
}