using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Turing_machine
{
    public partial class Form1 : Form
    {
        int left = 0, right = 6;
        TuringMachine machine;
        public Form1()
        {
            InitializeComponent();
        }

        private void RenderMatrix(string path)
        {
            string[] a = File.ReadAllLines(path);
            for (int i = 0; i < machine.matrix.Length / 5; i++)
            {
                dgv.Rows.Add(a[i].Split(','));
            }
             
        }

        private void Render(int index)
        {
            if (index < 0 || index >= machine.arr.Length)
            {
                if (index < 0)
                    Render(0);
                else
                    Render(index - 1);
                return;
            }

            textbox_state.Text = machine.current_state;
            left = index;
            right = index + 6;
            int curr = left;
            machine.current_left = left;
            if (right > machine.arr.Length)
                right = machine.arr.Length - 1;
            int cour = machine.current_index;

            if (cour == curr)
                textBox_1.BackColor = Color.Red;
            else
                textBox_1.BackColor = Color.White;

            textBox_1.Text = Convert.ToString(machine.arr[curr++]);

            if (cour == curr)
                textBox_2.BackColor = Color.Red;
            else
                textBox_2.BackColor = Color.White;
            if (curr > right)
                textBox_2.Text = "";
            else
                textBox_2.Text = Convert.ToString(machine.arr[curr++]);

            if (cour == curr)
                textBox_3.BackColor = Color.Red;
            else
                textBox_3.BackColor = Color.White;
            if (curr > right)
                textBox_3.Text = "";
            else
                textBox_3.Text = Convert.ToString(machine.arr[curr++]);

            if (cour == curr)
                textBox_4.BackColor = Color.Red;
            else
                textBox_4.BackColor = Color.White;
            if (curr > right)
                textBox_4.Text = "";
            else
                textBox_4.Text = Convert.ToString(machine.arr[curr++]);

            if (cour == curr)
                textBox_5.BackColor = Color.Red;
            else
                textBox_5.BackColor = Color.White;
            if (curr > right)
                textBox_5.Text = "";
            else
                textBox_5.Text = Convert.ToString(machine.arr[curr++]);

            if (cour == curr)
                textBox_6.BackColor = Color.Red;
            else
                textBox_6.BackColor = Color.White;
            if (curr > right)
                textBox_6.Text = "";
            else
                textBox_6.Text = Convert.ToString(machine.arr[curr++]);


        }

        private void Iteration()
        {
            string state = machine.current_state;
            int index = machine.current_index;
            int i = 0;
            string symbol;
            if (machine.arr[index] % 2 == 0)
                symbol = "true";
            else
                symbol = "false";

            while(state != machine.matrix[i, 0] && machine.matrix[i, 1] != symbol)
            {
                i++;
            }
            
            machine.current_state = machine.matrix[i, 4];

            if (state == "q1")
                machine.arr[index]++;
            else
                machine.arr[index]--;

            if (machine.matrix[i, 3] == "L")
            {
                if (index >= 0)
                    machine.current_index = index - 1;
                Render(machine.current_left - 1);
                
            }
            else
            {
                if (index + 1 < machine.arr.Length)
                    machine.current_index = index + 1;
                Render(machine.current_left + 1);
                
            }
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            if (new_index.Text == "" || new_state.Text == "" || path_to_file.Text == "")
                return;
            
            machine = new TuringMachine(path_to_file.Text);
            RenderMatrix(path_to_file.Text);
            int index = Convert.ToInt32(new_index.Text);
            machine.current_index = index;
            machine.current_state = new_state.Text;
            machine.current_left = index;
            Render(index);
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            Iteration();
        }

        private void button_left_Click(object sender, EventArgs e)
        {
            Render(machine.current_left - 1);
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            Render(machine.current_left + 1);
        }

        private void new_index_TextChanged(object sender, EventArgs e)
        {

        }

        private void new_register_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Iteration();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
