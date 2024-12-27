using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace asd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
            button11.Visible = false;
            button9.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "Mężczyzna";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label2.Text = "Kobieta";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { label4.Text = "Księgowość"; } else if (radioButton2.Checked) { label4.Text = "HR"; } else if (radioButton3.Checked) { label4.Text = "IT"; } else { label4.Text = "Produkcja"; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int wiek))
            {
                label6.Text = wiek.ToString();
            }
            else 
            { 
                MessageBox.Show("Tylko liczby całkowite"); 
            }
        }
        bool x = false;
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text != string.Empty && label4.Text != string.Empty && label6.Text != string.Empty) 
            { 
                x = true;
                pictureBox1.BackColor = Color.Green;
            }
            else 
            { 
                x = false; 
                pictureBox1.BackColor= Color.Red;
            }
        }
        Dictionary<int, string> baza = new Dictionary<int, string>();
        int index = 1;
        private void button4_Click(object sender, EventArgs e)
        {
            if (x == true) 
            { 
                bool info = false;
                bool rev = false;
                int stat = 0;
                if (checkBox2.Checked)
                {
                    stat += 1;
                    rev = true;
                }
                if (checkBox1.Checked)
                {
                    stat += 2;
                    info = true;
                }
                switch (stat)
                {
                    case 0:
                        for (int i = 0; i < 101; i++)
                        {
                            progressBar1.Value = i;
                        }
                        baza.Add(index, $"{label2.Text}\n{label4.Text}\n{label6.Text}");
                        index++;
                        break;
                    case 1:
                        richTextBox1.Text = $"{label2.Text}\n{label4.Text}\n{label6.Text}";
                        for (int i = 0; i < 101; i++)
                        {
                            progressBar1.Value = i;
                        }
                        baza.Add(index, $"{label2.Text}\n{label4.Text}\n{label6.Text}");
                        index++;
                        break;
                    case 2:
                        for (int i = 0; i < 101; i++)
                        {
                            progressBar1.Value = i;
                            if (progressBar1.Value == 100)
                            {
                                MessageBox.Show("Rekord Dodany");
                            }
                        }
                        baza.Add(index, $"{label2.Text}\n{label4.Text}\n{label6.Text}");
                        index++;
                        break;
                    case 3:
                        richTextBox1.Text = $"{label2.Text}\n{label4.Text}\n{label6.Text}";
                        for (int i = 0; i < 101; i++)
                        {
                            progressBar1.Value = i;
                            if (progressBar1.Value == 100)
                            {
                                MessageBox.Show("Rekord Dodany");
                            }
                        }
                        baza.Add(index, $"{label2.Text}\n{label4.Text}\n{label6.Text}");
                        index++;
                        break;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (baza.Count > 0)
            {
                MessageBox.Show($"{baza[baza.Count]}");
            }
            else
            {
                MessageBox.Show("Baza jest pusta");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int numex))
            {
                if (numex == 0 || numex > baza.Count)
                {
                    MessageBox.Show("Baza nie zawiera takiego numeru");
                }
                else
                {
                    MessageBox.Show($"{baza[Convert.ToInt32(textBox2.Text)]}");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź liczbę całkowitą");
            }
        }
        bool logow = true;
        private void button10_Click(object sender, EventArgs e)
        {
            if (logow == true && textBox3.Text == "admin" && textBox4.Text == "ADMIN")
            {
                MessageBox.Show("Witamy, panel administratora odblokowany");
                button11.Visible = true;
                button9.Visible = true;
                button10.Visible = false;
                textBox4.Visible = false;
                textBox3.Visible = false;
            }
            else if (logow == false && textBox3.Text == "root" && textBox4.Text == "RESET")
            {
                logow = true;
                MessageBox.Show("Możliwość logowania odblokowana");
            }
            else
            {
                logow = false;
                MessageBox.Show("Wpisz usera który przywróci możliwość do stanu początkowego");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            baza.Remove(baza.Count);
            index--;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            baza.Clear();
            index = 0;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            for (int i = 1; i <= baza.Count; i++)
            {
                int j = i;
                richTextBox2.AppendText(j+"\n"+baza[i].ToString()+"\n\n");
            }
        }
        int modex = 0;
        private void button13_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int j))
            {
                richTextBox3.Text = baza[j].ToString();
                modex = j;
            }
            else
            {
                MessageBox.Show("Wprowadź liczbę całkowitą");
            }
        }
        string changer = "";
        private void button14_Click(object sender, EventArgs e)
        {
            string message = "Czy na pewno chcesz dokonać zmian?";
            string caption = "Potwierdzenie zamiany";


            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                changer = baza[modex].ToString();
                baza[modex] = richTextBox3.Text;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ostatnia zmiana została cofnięta");
            baza[modex] = changer;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var bazax = baza;
            string jsonString = JsonConvert.SerializeObject(baza);
            File.WriteAllText("data.json", jsonString);
            MessageBox.Show($"Zapisano rekordy: {index - 1}");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string jsonString = File.ReadAllText("data.json");
            var bazax = JsonConvert.DeserializeObject<Dictionary<int, string>>(jsonString);
            baza = bazax;
            index = 1;
            for (int i = 1; i <= baza.Count; i++)
            {
                index += 1;
            }
            MessageBox.Show($"Wczytano rekordy: {index-1}");
        }
    }
}
