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
using System.Windows.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace WPF_Practice1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            writeInFileBTN.Visibility = Visibility.Collapsed;
            this.Title = "Практическая работа #1";
            pickerCB.SelectedIndex = 0;

            monthPickerCB.SelectedIndex = 0;
        }

        private void pickerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (pickerCB.SelectedIndex)
            {
                case 0:
                    titleL.Content = "Определение знака зодиака";
                    zodiacSP.Visibility = Visibility.Visible;
                    vostGorSP.Visibility = Visibility.Collapsed;
                    yearTB.Text = "";
                    dayOfBirthTB.Text = "";
                    break;
                case 1:
                    titleL.Content = "Определение восточного гороскопа";
                    zodiacSP.Visibility = Visibility.Collapsed;
                    vostGorSP.Visibility = Visibility.Visible;
                    yearTB.Text = "";
                    dayOfBirthTB.Text = "";
                    break;
            }
        }

        private string defineZZ(int a, int b, int c, int d, string sign1, string sign2, string dayT)
        {
            string res = "";
            int day = Convert.ToInt32(dayT);
            if (day >= a && day <= b)
            {
                res = sign1;
            }
            else
            {
                if (day >= c && day <= d)
                {
                    res = sign2;
                }
            }
            return res;
        }

        private void defineBTN_Click(object sender, RoutedEventArgs e)
        {
            switch (pickerCB.SelectedIndex)
            {
                case 0:
                    if (!String.IsNullOrEmpty(dayOfBirthTB.Text))
                    {
                        MessageBox.Show($"Знак зодиака - {defineZodiac(monthPickerCB.SelectedIndex, dayOfBirthTB.Text)}", "Результат");
                    }
                    else
                    {
                        MessageBox.Show("Поле для ввода пустое!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case 1:
                    if (!String.IsNullOrEmpty(yearTB.Text))
                    {
                        MessageBox.Show($"Вы - {defineEastG(yearTB.Text)}", "Результат");
                    }
                    break;
            }
        }

        string defineZodiac(int month, string day)
        {
            string res = "";

            switch (month)
            {
                case 0:
                    res = defineZZ(1, 20, 21, 31, "Козерог", "Водолей", day);
                    break;
                case 1:
                    res = defineZZ(1, 18, 19, 29, "Водолей", "Рыбы", day);
                    break;
                case 2:
                    res = defineZZ(1, 20, 21, 31, "Рыбы", "Овен", day);
                    break;
                case 3:
                    res = defineZZ(1, 20, 21, 30, "Овен", "Телец", day);
                    break;
                case 4:
                    res = defineZZ(1, 20, 21, 31, "Телец", "Близнецы", day);
                    break;
                case 5:
                    res = defineZZ(1, 21, 22, 30, "Близнецы", "Рак", day);
                    break;
                case 6:
                    res = defineZZ(1, 22, 23, 31, "Рак", "Лев", day);
                    break;
                case 7:
                    res = defineZZ(1, 22, 23, 31, "Лев", "Дева", day);
                    break;
                case 8:
                    res = defineZZ(1, 23, 24, 30, "Дева", "Весы", day);
                    break;
                case 9:
                    res = defineZZ(1, 23, 24, 31, "Весы", "Скорпион", day);
                    break;
                case 10:
                    res = defineZZ(1, 22, 23, 30, "Скорпион", "Стрелец", day);
                    break;
                case 11:
                    res = defineZZ(1, 21, 22, 31, "Стрелец", "Козерог", day);
                    break;
            }

            return res;
        }

        string defineEastG(string yearSTR)
        {
            string res = "";

            int year = Convert.ToInt32(yearSTR);
            year = year % 12;
            switch (year)
            {
                case 0:
                    res = "Обезьяна";
                    break;
                case 1:
                    res = "Петух";
                    break;
                case 2:
                    res = "Собака";
                    break;
                case 3:
                    res = "Свинья";
                    break;
                case 4:
                    res = "Крыса";
                    break;
                case 5:
                    res = "Бык";
                    break;
                case 6:
                    res = "Тигр";
                    break;
                case 7:
                    res = "Кролик";
                    break;
                case 8:
                    res = "Дракон";
                    break;
                case 9:
                    res = "Змея";
                    break;
                case 10:
                    res = "Лошадь";
                    break;
                case 11:
                    res = "Коза";
                    break;
            }

            return res;
        }

        private void dayOfBirthTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(dayOfBirthTB.Text))
            {
                if(!Regex.IsMatch(dayOfBirthTB.Text, @"^[0-9]+$"))
                {
                    dayOfBirthTB.Text = "";
                }
                int countDays = DateTime.DaysInMonth(DateTime.Now.Year, monthPickerCB.SelectedIndex + 1);
                if(Convert.ToInt32(dayOfBirthTB.Text) > countDays)
                {
                    dayOfBirthTB.Text = "";
                    MessageBox.Show("Слишком большое количество дней!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void yearTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(yearTB.Text))
            {
                if (!Regex.IsMatch(yearTB.Text, @"^[0-9]+$"))
                {
                    yearTB.Text = "";
                }
                if (yearTB.Text.Length > 4)
                {
                    yearTB.Text = yearTB.Text.Remove(yearTB.Text.Length - 1);
                    //MessageBox.Show("Введено слишком много символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void instructionBTN_Click (object sender, EventArgs e)
        {
            MessageBox.Show("Все данные, которые необходимо ввести - вводятся цифрами. \nЛюбые другие символы вводиться не будут\n\nПри использовании файла необходимо выбрать необходимый файл нажав на кнопку \"Открыть файл\", в результате чего данный файл перезапишется.\nЧтобы открыть данный файл необходимо нажать на появившуюся кнопку \"Результат\"", "Справка", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        string path;

        private void openFileBTN_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            var result = openFileDlg.ShowDialog();

            if (result == true)
            {
                path = openFileDlg.FileName;
            }
            readData();

            writeInFileBTN.Visibility = Visibility.Visible;
        }

        void readData()
        {
            var lines = File.ReadAllLines(path, Encoding.Default);
            string[] temp = new string[3];

            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);

            int j = 0;

            foreach (var line in lines)
            {
                string[] parts = line.Split(';');

                if(j == 0)
                {
                    sw.Write($"{parts[0]};{parts[1]};{parts[2]};ЗЗ;ВГ");
                    j++;
                    sw.WriteLine();
                }
                else
                {
                    sw.Write($"{parts[0]};{parts[1]};{parts[2]}");

                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (Regex.IsMatch(parts[i], @"^[0-9]+$"))
                        {
                            temp[i] = parts[i];
                        }
                        else
                        {
                            temp[i] = "";
                        }
                    }

                    if (!String.IsNullOrEmpty(temp[0]) && !String.IsNullOrEmpty(temp[1]))
                    {
                        int countDays = DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(temp[1]) - 1);
                        if (Convert.ToInt32(temp[0]) <= countDays)
                        {
                            sw.Write($";{defineZodiac(Convert.ToInt32(temp[1]) - 1, temp[0])}");
                        }
                        else
                        {
                            sw.Write($";-");
                        }
                    }
                    else
                    {
                        sw.Write($";-");
                    }
                    if (!String.IsNullOrEmpty(temp[2]))
                    {
                        sw.Write($";{defineEastG(temp[2])}");
                    }
                    sw.WriteLine();
                }
            }

            sw.Close();
        }

        private void writeInFileBTN_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(path);
        }

        private void monthPickerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dayOfBirthTB.Text = "";
        }
    }
}
