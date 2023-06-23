using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolonisazia_Marsa
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private int approach;
        private bool [,] life;
        private int rows;
        private int cols;
        private int Generation;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartModelirovanie()
        {
            if (timer1.Enabled)
                return;
            numDistance.Enabled = false;
            numApproach.Enabled = false;

            Generation = 0;
            Text = $"Generation {Generation} ";

            approach = (int)numApproach.Value;
            rows = pictureBox1.Height / approach;
            cols = pictureBox1.Width / approach;
            life = new bool[cols, rows];

            // Генерация рандомной начальной карты
            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    life[x, y] = random.Next((int)numDistance.Value) == 0;
                }
            }
            
            //Отрисовка
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
        }
        //ФИЗИК
        private void NewLife()
        {
            graphics.Clear(Color.Black); //черный фон
            var newLife = new bool[cols, rows]; // Переменная для поколения

            for (int x = 0; x < cols; x++)
            {
                for(int y = 0; y < rows; y++)
                {
                    var countvariables = CounVariables(x, y); // вызов математика
                    var hasPixel = life[x, y]; // переменная для отслеживания пикселя

                    //Анализ рядом стоящих для отрисовки 
                    if (!hasPixel && countvariables == 3) 
                        newLife[x, y] = true;
                    else if (hasPixel && (countvariables < 2 || countvariables > 3))
                        newLife[x, y] = false;
                    else
                        newLife[x, y] = life[x, y];

                    //Отрисовка жизни 
                    if (countvariables == 4)
                        graphics.FillRectangle(Brushes.Green, x * approach, y * approach, approach - 1, approach - 1);
                    //Отрисовка клетки
                    if (hasPixel)
                        graphics.FillRectangle(Brushes.BlueViolet, x * approach, y * approach, approach, approach);
                    

                }
            }
            life = newLife;
            pictureBox1.Refresh(); //Отчистка 
            Text = $"Generation {++Generation} "; // Счёт поколений 
        }

        //Математик.Проверка наличие рядом стоящих пиксеелй
        private int CounVariables(int x, int y)
        {
            int count = 0;

            // Проверка пикселей слева-спарва и сверху-снизу 
            for (int i = -1; i < 2; i++) // Циклы на выполения 3 раз
            {
                for (int j = -1; j < 2; j++)
                {
                    // координаты для провекри, учитывая края карты 
                    var col = (x + i + cols) % cols;
                    var row = (y + j + rows) % rows;


                    var selfChecking = col == x && row == y; //Переменная для отбороса проверки самого себя
                    var haslife = life[col, row];

                    if (haslife && !selfChecking)
                        count++;
                }
            }
            return count;
        }
        // Нажатие кнопки Stop
        private void StopLife()
        {
            if (!timer1.Enabled)
                return;
            
            numDistance.Enabled = true;
            numApproach.Enabled = true;
            timer1.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            NewLife();
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            StartModelirovanie();
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            StopLife();
        }

        // Вмешательство мышки
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled)
                return;

            // Добавление
            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / approach;
                var y = e.Location.Y / approach;
                var validate = Validater(x, y);
                if (validate)
                    life[x, y] = true;
            }
            // Стирание
            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / approach;
                var y = e.Location.Y / approach;
                var validate = Validater(x, y);
                if (validate)
                    life[x, y] = false;
            }
        }

        // Валидатор для для избежания ошибки краёв
        private bool Validater (int x, int y)
        {
            return x >= 0 && y >= 0 && x < cols && y < rows;
        }
    }
}
