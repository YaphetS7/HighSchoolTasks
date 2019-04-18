namespace Turing_machine
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
            this.button_stop = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.button_new = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.textbox_state = new System.Windows.Forms.TextBox();
            this.state_register = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.new_index = new System.Windows.Forms.TextBox();
            this.new_state = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_1 = new System.Windows.Forms.TextBox();
            this.textBox_2 = new System.Windows.Forms.TextBox();
            this.textBox_3 = new System.Windows.Forms.TextBox();
            this.textBox_4 = new System.Windows.Forms.TextBox();
            this.textBox_5 = new System.Windows.Forms.TextBox();
            this.textBox_6 = new System.Windows.Forms.TextBox();
            this.textBox_7 = new System.Windows.Forms.TextBox();
            this.button_left = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.path_to_file = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(12, 56);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(190, 38);
            this.button_stop.TabIndex = 0;
            this.button_stop.Text = "Остановить";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(12, 100);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(190, 38);
            this.button_next.TabIndex = 1;
            this.button_next.Text = "Следующая итерация";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_new
            // 
            this.button_new.Location = new System.Drawing.Point(12, 254);
            this.button_new.Name = "button_new";
            this.button_new.Size = new System.Drawing.Size(190, 38);
            this.button_new.TabIndex = 2;
            this.button_new.Text = "Начать новый сеанс";
            this.button_new.UseVisualStyleBackColor = true;
            this.button_new.Click += new System.EventHandler(this.button_new_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(12, 12);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(190, 38);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "Запуск";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // textbox_state
            // 
            this.textbox_state.Location = new System.Drawing.Point(59, 161);
            this.textbox_state.Name = "textbox_state";
            this.textbox_state.ReadOnly = true;
            this.textbox_state.Size = new System.Drawing.Size(143, 22);
            this.textbox_state.TabIndex = 4;
            this.textbox_state.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // state_register
            // 
            this.state_register.AutoSize = true;
            this.state_register.Location = new System.Drawing.Point(59, 141);
            this.state_register.Name = "state_register";
            this.state_register.Size = new System.Drawing.Size(143, 17);
            this.state_register.TabIndex = 5;
            this.state_register.Text = "Текущее состояние:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Новое положение указателя:";
            // 
            // new_index
            // 
            this.new_index.Location = new System.Drawing.Point(217, 309);
            this.new_index.Name = "new_index";
            this.new_index.Size = new System.Drawing.Size(79, 22);
            this.new_index.TabIndex = 7;
            this.new_index.TextChanged += new System.EventHandler(this.new_index_TextChanged);
            // 
            // new_state
            // 
            this.new_state.Location = new System.Drawing.Point(217, 338);
            this.new_state.Name = "new_state";
            this.new_state.Size = new System.Drawing.Size(79, 22);
            this.new_state.TabIndex = 8;
            this.new_state.TextChanged += new System.EventHandler(this.new_register_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Новое состояние указателя:";
            // 
            // textBox_1
            // 
            this.textBox_1.Location = new System.Drawing.Point(493, 186);
            this.textBox_1.Name = "textBox_1";
            this.textBox_1.ReadOnly = true;
            this.textBox_1.Size = new System.Drawing.Size(30, 22);
            this.textBox_1.TabIndex = 10;
            // 
            // textBox_2
            // 
            this.textBox_2.Location = new System.Drawing.Point(529, 186);
            this.textBox_2.Name = "textBox_2";
            this.textBox_2.ReadOnly = true;
            this.textBox_2.Size = new System.Drawing.Size(30, 22);
            this.textBox_2.TabIndex = 11;
            // 
            // textBox_3
            // 
            this.textBox_3.Location = new System.Drawing.Point(565, 186);
            this.textBox_3.Name = "textBox_3";
            this.textBox_3.ReadOnly = true;
            this.textBox_3.Size = new System.Drawing.Size(30, 22);
            this.textBox_3.TabIndex = 12;
            // 
            // textBox_4
            // 
            this.textBox_4.Location = new System.Drawing.Point(601, 186);
            this.textBox_4.Name = "textBox_4";
            this.textBox_4.ReadOnly = true;
            this.textBox_4.Size = new System.Drawing.Size(30, 22);
            this.textBox_4.TabIndex = 13;
            // 
            // textBox_5
            // 
            this.textBox_5.Location = new System.Drawing.Point(637, 186);
            this.textBox_5.Name = "textBox_5";
            this.textBox_5.ReadOnly = true;
            this.textBox_5.Size = new System.Drawing.Size(30, 22);
            this.textBox_5.TabIndex = 14;
            // 
            // textBox_6
            // 
            this.textBox_6.Location = new System.Drawing.Point(673, 186);
            this.textBox_6.Name = "textBox_6";
            this.textBox_6.ReadOnly = true;
            this.textBox_6.Size = new System.Drawing.Size(30, 22);
            this.textBox_6.TabIndex = 15;
            // 
            // textBox_7
            // 
            this.textBox_7.Location = new System.Drawing.Point(709, 186);
            this.textBox_7.Name = "textBox_7";
            this.textBox_7.ReadOnly = true;
            this.textBox_7.Size = new System.Drawing.Size(30, 22);
            this.textBox_7.TabIndex = 16;
            // 
            // button_left
            // 
            this.button_left.Location = new System.Drawing.Point(421, 186);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(30, 22);
            this.button_left.TabIndex = 17;
            this.button_left.Text = "L";
            this.button_left.UseVisualStyleBackColor = true;
            this.button_left.Click += new System.EventHandler(this.button_left_Click);
            // 
            // button_right
            // 
            this.button_right.Location = new System.Drawing.Point(745, 186);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(30, 22);
            this.button_right.TabIndex = 18;
            this.button_right.Text = "R";
            this.button_right.UseVisualStyleBackColor = true;
            this.button_right.Click += new System.EventHandler(this.button_right_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgv.Location = new System.Drawing.Point(352, 289);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(732, 323);
            this.dgv.TabIndex = 19;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Состояние";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Делимость на 2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Действие";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "L/R";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.Frozen = true;
            this.Column5.HeaderText = "Новое состояние";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(457, 186);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(30, 22);
            this.textBox1.TabIndex = 20;
            // 
            // path_to_file
            // 
            this.path_to_file.Location = new System.Drawing.Point(118, 366);
            this.path_to_file.Name = "path_to_file";
            this.path_to_file.Size = new System.Drawing.Size(178, 22);
            this.path_to_file.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Путь к файлу:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 681);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.path_to_file);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.textBox_7);
            this.Controls.Add(this.textBox_6);
            this.Controls.Add(this.textBox_5);
            this.Controls.Add(this.textBox_4);
            this.Controls.Add(this.textBox_3);
            this.Controls.Add(this.textBox_2);
            this.Controls.Add(this.textBox_1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.new_state);
            this.Controls.Add(this.new_index);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.state_register);
            this.Controls.Add(this.textbox_state);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_new);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_stop);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TuringMachine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TextBox textbox_state;
        private System.Windows.Forms.Label state_register;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox new_index;
        private System.Windows.Forms.TextBox new_state;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_1;
        private System.Windows.Forms.TextBox textBox_2;
        private System.Windows.Forms.TextBox textBox_3;
        private System.Windows.Forms.TextBox textBox_4;
        private System.Windows.Forms.TextBox textBox_5;
        private System.Windows.Forms.TextBox textBox_6;
        private System.Windows.Forms.TextBox textBox_7;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox path_to_file;
        private System.Windows.Forms.Label label3;
    }
}

