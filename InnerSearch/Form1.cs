using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InnerSearch
{ //1: бинарный поиск на упорядоченной по возрастанию последовательности
    public partial class Form1 : Form
    {
        public int[] mass;
        public int rasm = 20;
        public int searching = 0;
        public int comp = 0;
        public Form1()
        {

            InitializeComponent();
            formmass();
        }

        public void formmass()
        {
            Random rnd = new Random();
            mass = new int[rasm];
            for (int j = 0; j < rasm; j++)
            {
                mass[j] = rnd.Next(100);
            }
            Array.Sort(mass);
            label2.Text = "";
            label5.Text = "";
            for (int j = 0; j < rasm; j++)
            {
                if (mass[j] / 10 != 0) label5.Text += " ";
                label5.Text += j + "     ";
                
                label2.Text += mass[j] + "     ";
            }
        }
        // static
        public int BinarySearch(int[] d, int key, int left, int right) //бинарный поиск
        {
            int mid = left + (right - left) / 2; //находим середину вычитая из последнего элемента первый и деля на 2
            if (left >= right)//проверка условия, если левая сторона больше правой, то возвращается значение
                return -(1 + left);
            comp++;
            if (d[mid] == key) //если оказалось, что середина равна искомому значению, то возвращается это значение, и поиск завершается
                return mid;

            else if (d[mid] > key)//в противном случае если середина больше искомого значения, то возвращаемся к левой части и продолжаем там алгоритм
                return BinarySearch(d, key, left, mid);
            else
                return BinarySearch(d, key, mid + 1, right);// иначе, если середина меньше искомого значения, то продолжаем поиск в правой части, так же деля массив на две части
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                searching = int.Parse(textBox1.Text);
                int i = BinarySearch(mass, searching, 0, mass.Length); //обращение к классу BinarySearch для поиска индекса элемента
                if (i < mass.Length)
                    label4.Text = "Индекс искомого элемента: " + i;
                else
                    label4.Text = "Элемент не найден";
                label6.Text += comp + " ";
                comp = 0;
            }
            catch (Exception ex)
            { label2.Text = "Неправильный вид искомого элемента! " + ex; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { rasm = int.Parse(textBox2.Text); mass = null; formmass(); }
            catch (Exception ex)
            { label2.Text = "Неправильный вид длины массива! " + ex; }
        }
    }
}
