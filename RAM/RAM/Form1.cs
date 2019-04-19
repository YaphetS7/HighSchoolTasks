using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAM
{
    public partial class Form1 : Form
    {
        private int currIndexOfRow = 0;
        private string[] text;
        private RAM ram;
        public Form1()
        {
            InitializeComponent();
            button_next.Enabled = false;
            button_run.Enabled = false;
            button_stop.Enabled = false;
            timer1.Interval = 500;
            code.Enabled = false;
        }
        private void Render()
        {
            if(current_operation.Text.Contains("READ"))
            {
                ram.Read(Convert.ToInt32(textbox_input.Text));
            }
            int i = currIndexOfRow;
            current_operation.Text = text[i];

            if (text[i].Contains("WRITE"))
            {
                Write();
                currIndexOfRow++;
                return;
            }
            if (text[i].Contains("READ"))
            {
                textbox_input.Clear();
                timer1.Enabled = false;
                button_next.Enabled = true;
                button_run.Enabled = true;
                button_stop.Enabled = true;
                currIndexOfRow++;
                return;
            }
          


            if(text[i].Contains("JNZ"))
            {
                string[] str = text[i].Split(new char[] {' ', ','});
                int indexOfArray = Convert.ToInt32(str[1].Substring(1, str[1].Length - 2));
                string name = str[2].Substring(0);
                ram.Loop(text, indexOfArray, name);
                while (!text[i].Contains("HALT"))
                {
                    i++;
                }
                currIndexOfRow = i + 1;
                if (currIndexOfRow >= text.Length - 2)
                {
                    timer1.Enabled = false;
                }
                return;
            }


            ram.Parse(text[i]);
            currIndexOfRow++;
            if(currIndexOfRow >= text.Length - 1)
            {
                timer1.Enabled = false;
                button_next.Enabled = false;
                button_run.Enabled = false;
            }
        }
        private void Write()
        {
            textbox_output.Text = Convert.ToString(ram.GetFirst());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Render();
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            code.Clear();
            code.Enabled = true;
            textbox_output.Clear();
            textbox_input.Clear();
            current_operation.Clear();
            currIndexOfRow = 0;
            button_next.Enabled = true;
            button_run.Enabled = true;
            button_stop.Enabled = true;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            Render();
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            button_next.Enabled = false;
            timer1.Enabled = true;
            button_run.Enabled = false;
        }

        private void load_code_Click(object sender, EventArgs e)
        {
            text = code.Text.Split(';', ':');
            code.Enabled = false;
            button_next.Enabled = true;
            button_run.Enabled = true;
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button_run.Enabled = true;
            button_next.Enabled = true;
            code.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cnt.Text == "")
                return;
            ram = new RAM(Convert.ToInt32(cnt.Text));
            cnt.Enabled = false;
        }
    }
}
