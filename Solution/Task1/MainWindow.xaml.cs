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

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int val = 10;
            TB_INPUT.Text = "";
            TB_OUTPUT.Text = "";
            TB_MINIMAL.Text = "";
            TB_SUMMARY.Text = "";
            string a = TB_VALUE.Text; 

            //Сделали строки пустыми

            if (!int.TryParse(a, out int n))
            {
                Random rndlen = new Random(DateTime.Now.Millisecond);
                int len = rndlen.Next(1,50);
                MessageBox.Show("Так уж и быть, сам выберу длину массива.\r\nПускай это будет... "+len+"!", "Неправильно, долбаные волки, ШИРОКУЮ НА ШИРОКУЮ!!!");
                val = len;
                TB_VALUE.Text = "";
                TB_VALUE.Text += len;
            }
            else
            {
                val = int.Parse(TB_VALUE.Text);
            }

            //Проверили корректность ввода, если ввод не корректен - то сами придумываем число

            double[] numbers = new double[val];
            Random rndnum = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < numbers.Count(); i++)
            {
                numbers[i] = rndnum.NextDouble() * 100 - 50;
                if (Math.Round(numbers[i], 0) == 0 || (i%2 ==0 && numbers[i] < 1.5)) //искуственн добавляем нули, потому что при генерации их ОЧЕНЬ МАЛО
                {
                    numbers[i] = 0;
                }
                TB_INPUT.Text += Math.Round(numbers[i], 3) + " ";
            }

            //Вывели начальный массив

            int first = 0;
            int last = 0;

            //Нашли первый положительный элемент

            for (int i = 0; i < numbers.Count(); i++)
            {
                if (numbers[i] > 0)
                {
                    first = i;
                    break;
                }
            }

            //Нашли последний положительный элемент

            for (int i = numbers.Count()-1; i > 0; i--)
            {
                if (numbers[i] > 0)
                {
                    last = i;
                    break;
                }
            }

            //Считаем сумму
            
            double sum = 0;
            for (int i = first; i < last+1; i++)
            {
                sum += numbers[i];
            }

            //Сортируем методом пузырька

            for (int i = 0; i < numbers.Count(); i++)
            {
                for (int j = 0; j < numbers.Count() - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        double z = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = z;
                    }
                }
            }

            //Теперь с лёгкостью находим минимальный элемент

            double mini = numbers[0];

            //Перемещаем нолики

            double per = 0;
            int cou = 0;
            for (int i = 0; i < numbers.Count(); i++)
            {
                if (numbers[i] == 0)
                {
                    per = numbers[cou];
                    numbers[cou] = 0;
                    numbers[i] = per;
                    cou++;
                }
            }

            //Выводим массив после всех преобразований...

            for (int i = 0; i < numbers.Count(); i++)
            {
                TB_OUTPUT.Text += Math.Round(numbers[i], 3) + " ";
            }

            //...а также результаты наших вычислений

            TB_MINIMAL.Text += Math.Round(mini,3);
            TB_SUMMARY.Text += Math.Round(sum,3);
        }
    }
}
