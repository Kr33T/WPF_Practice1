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

namespace WPF_Practice1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
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
                    zodiacC.Visibility = Visibility.Visible;
                    vostGorC.Visibility = Visibility.Hidden;
                    Canvas.SetZIndex(zodiacC, 0);
                    zodiacC.Margin = new Thickness(0);
                    break;
                case 1:
                    titleL.Content = "Определение восточного гороскопа";
                    zodiacC.Visibility = Visibility.Hidden;
                    vostGorC.Visibility = Visibility.Visible;
                    Canvas.SetZIndex(vostGorC, 0);
                    vostGorC.Margin = new Thickness(0);
                    break;
            }
        }

        private void defineZZ(int a, int b, int c, int d, string sign1, string sign2)
        {
            int day = Convert.ToInt32(dayOfBirthTB.Text);
            if (day >= a && day <= b)
            {
                MessageBox.Show($"Знак зодиака - {sign1}", "Результат");
            }
            else
            {
                if (day >= c && day <= d)
                {
                    MessageBox.Show($"Знак зодиака - {sign2}", "Результат");
                }
                else
                {
                    MessageBox.Show("Введено неверное значение!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void defineBTN_Click(object sender, RoutedEventArgs e)
        {
            switch (pickerCB.SelectedIndex)
            {
                case 0:
                    if (!String.IsNullOrEmpty(dayOfBirthTB.Text))
                    {
                        switch (monthPickerCB.SelectedIndex)
                        {
                            case 0:
                                defineZZ(1, 20, 21, 31, "Козерог", "Водолей");
                                break;
                            case 1:
                                defineZZ(1, 18, 19, 29, "Водолей", "Рыбы");
                                break;
                            case 2:
                                defineZZ(1, 20, 21, 31, "Рыбы", "Овен");
                                break;
                            case 3:
                                defineZZ(1, 20, 21, 30, "Овен", "Телец");
                                break;
                            case 4:
                                defineZZ(1, 20, 21, 31, "Телец", "Близнецы");
                                break;
                            case 5:
                                defineZZ(1, 21, 22, 30, "Близнецы", "Рак");
                                break;
                            case 6:
                                defineZZ(1, 22, 23, 31, "Рак", "Лев");
                                break;
                            case 7:
                                defineZZ(1, 22, 23, 31, "Лев", "Дева");
                                break;
                            case 8:
                                defineZZ(1, 23, 24, 30, "Дева", "Весы");
                                break;
                            case 9:
                                defineZZ(1, 23, 24, 31, "Весы", "Скорпион");
                                break;
                            case 10:
                                defineZZ(1, 22, 23, 30, "Скорпион", "Стрелец");
                                break;
                            case 11:
                                defineZZ(1, 21, 22, 31, "Стрелец", "Козерог");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Поле для ввода пустое!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case 1:
                    int year = Convert.ToInt32(yearTB.Text);
                    year = year % 12;
                    switch (year)
                    {
                        case 0:
                            MessageBox.Show("Вы - Обезьяна", "Результат");
                            break;
                        case 1:
                            MessageBox.Show("Вы - Петух", "Результат");
                            break;
                        case 2:
                            MessageBox.Show("Вы - Собака", "Результат");
                            break;
                        case 3:
                            MessageBox.Show("Вы - Свинья", "Результат");
                            break;
                        case 4:
                            MessageBox.Show("Вы - Крыса", "Результат");
                            break;
                        case 5:
                            MessageBox.Show("Вы - Бык", "Результат");
                            break;
                        case 6:
                            MessageBox.Show("Вы - Тигр", "Результат");
                            break;
                        case 7:
                            MessageBox.Show("Вы - Кролик", "Результат");
                            break;
                        case 8:
                            MessageBox.Show("Вы - Дракон", "Результат");
                            break;
                        case 9:
                            MessageBox.Show("Вы - Змея", "Результат");
                            break;
                        case 10:
                            MessageBox.Show("Вы - Лошадь", "Результат");
                            break;
                        case 11:
                            MessageBox.Show("Вы - Коза", "Результат");
                            break;
                    }
                    break;
            }
        }

        private void dayOfBirthTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(dayOfBirthTB.Text))
            {
                if(!Regex.IsMatch(dayOfBirthTB.Text, @"[0-9]"))
                {
                    dayOfBirthTB.Text = "";
                }
                if(dayOfBirthTB.Text.Length > 2)
                {
                    MessageBox.Show("Введено слишком много символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void yearTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(yearTB.Text))
            {
                if (!Regex.IsMatch(yearTB.Text, @"[0-9]"))
                {
                    yearTB.Text = "";
                }
                if (yearTB.Text.Length > 4)
                {
                    MessageBox.Show("Введено слишком много символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
