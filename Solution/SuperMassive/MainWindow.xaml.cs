using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperMassive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB_OUT.Text = "";
            TB_OUT_SUM.Text = "";
            TB_OUT_STRISTLB.Text = "";

            int height;
            int width;

            string a = TB_IN_HEIGHT.Text;
            string b = TB_IN_WIDTH.Text;

            //Чекаем правильность ввода, и если не правильно - сами исправляем
            if (!int.TryParse(a, out int n) || !int.TryParse(b, out n))
            {
                Random rndlen = new Random(DateTime.Now.Millisecond);
                height = rndlen.Next(1, 25);
                width = rndlen.Next(1, 25);
                MessageBox.Show("Так уж и быть, сам выберу размеры массива.\r\nПускай массив будет... " + height + " на " + width +"!", "Неправильно, долбаные волки, ШИРОКУЮ НА ШИРОКУЮ!!!");
                TB_IN_HEIGHT.Text = "";
                TB_IN_HEIGHT.Text += height;
                TB_IN_WIDTH.Text = "";
                TB_IN_WIDTH.Text += width;

            }
            else if (int.Parse(a) <= 0 || int.Parse(b) <= 0)
            {
                Random rndlen = new Random(DateTime.Now.Millisecond);
                height = rndlen.Next(1, 25);
                width = rndlen.Next(1, 25);
                MessageBox.Show("Так уж и быть, сам выберу размеры массива.\r\nПускай массив будет... " + height + " на " + width + "!", "Отрицательные числа это КРИНЖ!!!");
                TB_IN_HEIGHT.Text = "";
                TB_IN_HEIGHT.Text += height;
                TB_IN_WIDTH.Text = "";
                TB_IN_WIDTH.Text += width;
            }
            else
            {
                width = int.Parse(TB_IN_HEIGHT.Text);
                height = int.Parse(TB_IN_WIDTH.Text);
            }

            Random rndnum = new Random(DateTime.Now.Millisecond);

            //рандомим массив

            int[,] matrix = new int[width, height];

            for (int i = 0; i < height; i++) for (int j = 0; j < width; j++)
                {
                    matrix[j, i] = rndnum.Next(-100,100);
                }

            int[] numer = new int[height];

            for (int i = 0; i < height; i++) for (int j = 0; j < width; j++) //вывод
                {
                    if (matrix[j,i] < 0)
                    {
                        numer[i] = 1; //чекаем в каких строчках есть отрицательные элементы
                    }    

                    TB_OUT.Text += matrix[j, i] + " ";
                    if (j == width-1)
                    {
                        TB_OUT.Text += "\r\n";
                    }
                }

            int summary;

            for (int i=0; i < height; i++) //выводи суммы
            {
                if (numer[i] != 0)
                {
                    summary = 0;
                    for (int j = 0; j < width; j++)
                    {
                        summary += matrix[j, i];
                    }
                    TB_OUT_SUM.Text += "Сумма элементов в " + (i+1) + "-ой строке равна: " + summary+"\r\n"; 
                }
            }

            int[] numer2 = new int[width]; //новый массив для столбцовых минимумов

            for (int i = 0; i < height; i++)
            {
                numer[i] = matrix[0, i];
                for (int j = 0; j < width; j++)
                {
                    if (matrix[j,i] < numer[i])
                    {
                        numer[i] = matrix[j, i]; //строковые минимумы
                    }
                }
            }

            for (int i = 0; i < width; i++) //столбцовые минимумы
            {
                numer2[i] = matrix[i, 0];
                for (int j = 0; j < height; j++)
                {
                    if (matrix[i,j] < numer2[i])
                    {
                        numer2[i] = matrix[i, j];
                    }
                }
            }

            for (int i = 0; i < height; i++) for (int j = 0; j < width; j++) //если минимумы совпадают то это седловая точка, её и выводим
                {
                    if (numer[i] == numer2[j])
                    {
                        TB_OUT_STRISTLB.Text += "Строка: " + (i + 1) + " Столбец: " + (j + 1) + "\r\n";
                    }
                }
        }

        private void TB_IN_HEIGHT_GotFocus(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(TB_IN_HEIGHT.Text, out int n))
            {
                TB_IN_HEIGHT.Clear();
            }
        }

        private void TB_IN_WIDTH_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(TB_IN_WIDTH.Text, out int n))
            {
                TB_IN_WIDTH.Clear();
            }
        }
    }
}
