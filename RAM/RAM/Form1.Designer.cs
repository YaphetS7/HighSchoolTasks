namespace RAM
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textbox_output = new System.Windows.Forms.TextBox();
            this.textbox_input = new System.Windows.Forms.TextBox();
            this.current_operation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_new = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.button_run = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.load_code = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cnt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textbox_output
            // 
            this.textbox_output.Location = new System.Drawing.Point(627, 152);
            this.textbox_output.Name = "textbox_output";
            this.textbox_output.ReadOnly = true;
            this.textbox_output.Size = new System.Drawing.Size(100, 22);
            this.textbox_output.TabIndex = 1;
            // 
            // textbox_input
            // 
            this.textbox_input.Location = new System.Drawing.Point(671, 243);
            this.textbox_input.Name = "textbox_input";
            this.textbox_input.Size = new System.Drawing.Size(56, 22);
            this.textbox_input.TabIndex = 2;
            // 
            // current_operation
            // 
            this.current_operation.Location = new System.Drawing.Point(484, 420);
            this.current_operation.Name = "current_operation";
            this.current_operation.ReadOnly = true;
            this.current_operation.Size = new System.Drawing.Size(243, 22);
            this.current_operation.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Последняя выполненная операция:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введите число:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(624, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Результат:";
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(37, 48);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(289, 394);
            this.code.TabIndex = 7;
            this.code.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Напишите здесь Ваш код:";
            // 
            // button_new
            // 
            this.button_new.Location = new System.Drawing.Point(911, 48);
            this.button_new.Name = "button_new";
            this.button_new.Size = new System.Drawing.Size(75, 23);
            this.button_new.TabIndex = 9;
            this.button_new.Text = "new";
            this.button_new.UseVisualStyleBackColor = true;
            this.button_new.Click += new System.EventHandler(this.button_new_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(911, 77);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 10;
            this.button_next.Text = "step";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_run
            // 
            this.button_run.Location = new System.Drawing.Point(911, 106);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(75, 23);
            this.button_run.TabIndex = 11;
            this.button_run.Text = "run";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(911, 135);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 12;
            this.button_stop.Text = "stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // load_code
            // 
            this.load_code.Location = new System.Drawing.Point(37, 448);
            this.load_code.Name = "load_code";
            this.load_code.Size = new System.Drawing.Size(289, 23);
            this.load_code.TabIndex = 13;
            this.load_code.Text = "Загрузить код";
            this.load_code.UseVisualStyleBackColor = true;
            this.load_code.Click += new System.EventHandler(this.load_code_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(410, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "Сгенерировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cnt
            // 
            this.cnt.Location = new System.Drawing.Point(394, 82);
            this.cnt.Name = "cnt";
            this.cnt.Size = new System.Drawing.Size(152, 22);
            this.cnt.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Введите длину ленты:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 626);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cnt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.load_code);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_run);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_new);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.code);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.current_operation);
            this.Controls.Add(this.textbox_input);
            this.Controls.Add(this.textbox_output);
            this.Name = "Form1";
            this.Text = "RAM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textbox_output;
        private System.Windows.Forms.TextBox textbox_input;
        private System.Windows.Forms.TextBox current_operation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button load_code;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox cnt;
        private System.Windows.Forms.Label label5;
    }
}

