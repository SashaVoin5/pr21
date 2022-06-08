using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OpenDlg = new OpenFileDialog()) //открывает диалоговое окно
            {
                if (OpenDlg.ShowDialog() == DialogResult.OK)
                {
                    StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.Default); //считывает символы в определенной кодировке
                    richTextBox1.Text = Reader.ReadToEnd(); //считывает текстовый файл от начала до конца в необходимое местоположение
                    Reader.Close();
                }
                OpenDlg.Dispose(); //удаляет, сбрасывает неуправляемые ресурсы
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SaveDlg = new SaveFileDialog())  // запрашивает у пользователя местоположение для сохранеения файла
            {
                if (SaveDlg.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                    for (int i = 0; i < listBox2.Items.Count; i++) //показывает количество строк в компоненте
                    {
                        Writer.WriteLine((string)listBox2.Items[i]); //получает позиции элемента управления
                    }
                    Writer.Close();
                }
                SaveDlg.Dispose();

            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Информация о приложении и разработчике"); 
            Application.Exit(); 
        }

        private void button14_Click(object sender, EventArgs e) 
        {
            listBox1.Items.Clear(); 
            listBox2.Items.Clear();
            listBox1.BeginUpdate(); 
            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' }, 
            StringSplitOptions.RemoveEmptyEntries); 
            foreach (string s in Strings) 
            {
                string Str = s.Trim(); 
                if (Str == String.Empty) continue; 
                if (radioButton1.Checked) listBox1.Items.Add(Str); 
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str); 
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str); 
                }
            }
            listBox1.EndUpdate();
        }

        private void button11_Click(object sender, EventArgs e) 
        {
            listBox3.Items.Clear();
            string Find = textBox1.Text; 
            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String); 
                }
            }

            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }

        }

        private void button6_Click(object sender, EventArgs e) 
        {
            Form2 AddRec = new Form2(); 
            AddRec.Owner = this;
            AddRec.ShowDialog(); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i)) listBox1.Items.RemoveAt(i); 
            }
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i)) listBox2.Items.RemoveAt(i);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<String> list = new List<string>();
            if (comboBox1.SelectedIndex == 0)  
            {
                foreach (var item in listBox1.Items)
                {
                    list.Add(item.ToString()); 
                }
                list.Sort(); 
                listBox1.Items.Clear(); 
                foreach(var item in list) 
                {
                    listBox1.Items.Add(item); 
                }
            }
            if(comboBox1.SelectedIndex == 1)  
            {
                foreach(var item in listBox1.Items)
                {
                    list.Add(item.ToString());
                }
                list.Sort();
                list.Reverse(); 
                listBox1.Items.Clear();
                foreach(var item in list)
                {
                    listBox1.Items.Add(item);
                }
            }
            if(comboBox1.SelectedIndex == 2) 
            {
                foreach(var item in listBox1.Items)
                {
                    list.Add(item.ToString());
                }
                listBox1.Items.Clear();
                var sortResult1 = list.OrderBy(x => x.Length);
                foreach(var item in sortResult1)
                {
                    listBox1.Items.Add(item);
                }
            }
            if(comboBox1.SelectedIndex == 3) 
            {
                foreach(var item in listBox1.Items)
                {
                    list.Add(item.ToString());
                }
                listBox1.Items.Clear();
                var sortResult2 = list.OrderByDescending(x => x.Length);
                foreach(var item in sortResult2)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            richTextBox1.Clear();
            textBox1.Clear();
        }
        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Информация о приложении и разработчике");
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.BeginUpdate(); 
            foreach (object Item in listBox1.SelectedItems) 
            {
                listBox2.Items.Add(Item); 
            }
            listBox2.EndUpdate(); 
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear(); 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            List<String> list = new List<string>();
            if (comboBox2.SelectedIndex == 0)
            {
                foreach (var item in listBox2.Items)
                {
                    list.Add(item.ToString());
                }
                list.Sort();
                listBox2.Items.Clear();
                foreach (var item in list)
                {
                    listBox2.Items.Add(item);
                }
            }
            if (comboBox2.SelectedIndex == 1)
            {
                foreach (var item in listBox2.Items)
                {
                    list.Add(item.ToString());
                }
                list.Sort();
                list.Reverse();
                listBox2.Items.Clear();
                foreach (var item in list)
                {
                    listBox2.Items.Add(item);
                }
            }
            if (comboBox2.SelectedIndex == 2)
            {
                foreach (var item in listBox2.Items)
                {
                    list.Add(item.ToString());
                }
                listBox2.Items.Clear();
                var sortResult1 = list.OrderBy(x => x.Length);
                foreach (var item in sortResult1)
                {
                    listBox2.Items.Add(item);
                }
            }
            if (comboBox2.SelectedIndex == 3)
            {
                foreach (var item in listBox2.Items)
                {
                    list.Add(item.ToString());
                }
                listBox2.Items.Clear();
                var sortResult2 = list.OrderByDescending(x => x.Length);
                foreach (var item in sortResult2)
                {
                    listBox2.Items.Add(item);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();
            foreach (object Item in listBox2.SelectedItems)
            {
                listBox1.Items.Add(Item);
            }
            listBox1.EndUpdate();
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }
    }
}
