using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyStudy
{
    public partial class Form2 : Form
    {
        public Dictionary<string, string> wordList = new();
        public void refresh()
        {
            var lines = System.IO.File.ReadAllLines("beg.txt");
            lines.Select(line => line.Split('='))
                 .Where(line => line.Length == 2)
                 .ToList()
                 .ForEach(line => wordList.Add(line[0], line[1]));
            Random rnd = new();
            int wordsCount = wordList.Count;
            int i = rnd.Next(wordsCount); //Случайное значение из словаря
            label1.Text = wordList.ElementAt(i).Key.ToString();// Прописывание значения в слово, которое нужно перевести
            int wheresRightWord = rnd.Next(4);
            int a = rnd.Next(wordsCount);

            while (a == i)
            {
                a = rnd.Next(wordsCount);
            }
            int b = rnd.Next(wordsCount);
            while (b == i || b == a)
            {
                a = rnd.Next(wordsCount);
            }
            int c = rnd.Next(wordsCount);
            while (c == i || c == a || c == b)
            {
                c = rnd.Next(wordsCount);
            }
            switch (wheresRightWord)
            {
                case 0:
                    answer1.Text = wordList.ElementAt(i).Value.ToString();
                    answer2.Text = wordList.ElementAt(a).Value.ToString();
                    answer3.Text = wordList.ElementAt(b).Value.ToString();
                    answer4.Text = wordList.ElementAt(c).Value.ToString();
                    correctAnswer = 1;
                    break;
                case 1:
                    answer1.Text = wordList.ElementAt(a).Value.ToString();
                    answer2.Text = wordList.ElementAt(b).Value.ToString();
                    answer3.Text = wordList.ElementAt(c).Value.ToString();
                    answer4.Text = wordList.ElementAt(i).Value.ToString();
                    correctAnswer = 4;
                    break;
                case 2:
                    answer1.Text = wordList.ElementAt(a).Value.ToString();
                    answer2.Text = wordList.ElementAt(b).Value.ToString();
                    answer3.Text = wordList.ElementAt(i).Value.ToString();
                    answer4.Text = wordList.ElementAt(c).Value.ToString();
                    correctAnswer = 3;
                    break;
                default:
                    answer1.Text = wordList.ElementAt(a).Value.ToString();
                    answer2.Text = wordList.ElementAt(i).Value.ToString();
                    answer3.Text = wordList.ElementAt(c).Value.ToString();
                    answer4.Text = wordList.ElementAt(b).Value.ToString();
                    correctAnswer = 2;
                    break;
            }
            answer1.BackColor = Color.White;
            answer2.BackColor = Color.White;
            answer3.BackColor = Color.White;
            answer4.BackColor = Color.White;
        }
        public int correctAnswer = 0;
        public Form2()
        {
            InitializeComponent();
            refresh();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void answer1_Click(object sender, EventArgs e)
        {
            
            switch(correctAnswer)
            {
                case 1:
                    answer1.BackColor = Color.Green;
                    break;
                case 2:
                    answer1.BackColor = Color.Red;
                    answer2.BackColor = Color.Green;
                    break;
                case 3:
                    answer1.BackColor = Color.Red;
                    answer3.BackColor = Color.Green;
                    break;
                case 4:
                    answer1.BackColor = Color.Red;
                    answer4.BackColor = Color.Green;
                    break;
            }

            wordList.Clear();
            refresh();
        }

        public void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void answer2_Click(object sender, EventArgs e)
        {
            switch (correctAnswer)
            {
                case 2:
                    answer2.BackColor = Color.Green;
                    break;
                case 1:
                    answer2.BackColor = Color.Red;
                    answer1.BackColor = Color.Green;
                    break;
                case 3:
                    answer2.BackColor = Color.Red;
                    answer3.BackColor = Color.Green;
                    break;
                case 4:
                    answer2.BackColor = Color.Red;
                    answer4.BackColor = Color.Green;
                    break;
            }

            wordList.Clear();
            refresh();
        }

        private void answer3_Click(object sender, EventArgs e)
        {
            switch (correctAnswer)
            {
                case 3:
                    answer3.BackColor = Color.Green;
                    break;
                case 2:
                    answer3.BackColor = Color.Red;
                    answer2.BackColor = Color.Green;
                    break;
                case 1:
                    answer3.BackColor = Color.Red;
                    answer1.BackColor = Color.Green;
                    break;
                case 4:
                    answer3.BackColor = Color.Red;
                    answer4.BackColor = Color.Green;
                    break;
            }

            wordList.Clear();
            refresh();
        }

        private void answer4_Click(object sender, EventArgs e)
        {
            switch (correctAnswer)
            {
                case 4:
                    answer4.BackColor = Color.Green;
                    break;
                case 2:
                    answer4.BackColor = Color.Red;
                    answer2.BackColor = Color.Green;
                    break;
                case 3:
                    answer4.BackColor = Color.Red;
                    answer3.BackColor = Color.Green;
                    break;
                case 1:
                    answer4.BackColor = Color.Red;
                    answer1.BackColor = Color.Green;
                    break;
            }

            wordList.Clear();
            refresh();
        }
    }
}
