using Main_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Win32;

namespace Десктоп
{
    /// <summary>
    /// Логика взаимодействия для Access.xaml
    /// </summary>
    public partial class Access : Window
    {
        public Access(string FIO)
        {
            InitializeComponent();
            mainLabel.Text = FIO;
            HttpClient http = new HttpClient();
            var k = http.GetFromJsonAsync("http://localhost:5150/Dolgnosty", typeof(Должность[]));
            List<Должность> типs = ((Должность[])k.Result).ToList();
            dolgnost.ItemsSource = from var in типs select var.Должность1;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient http = new HttpClient();
                Пользователи people = new Пользователи();
                people.Должность = dolgnost.SelectedIndex;
                people.Фио = surname.Text + " " + name.Text + " " + patronimic.Text;
                people.Пол = pol.SelectedItem.ToString();
                people.Check = false;

                http.PostAsJsonAsync("http://localhost:5150/User", people);
                MessageBox.Show("Пользователь успешно добавлен!");
                clear();
            }
            catch
            {
                MessageBox.Show("Упс что то пошло не так!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            peoplePhoto.Source =new BitmapImage(new Uri(openFileDialog.FileName));

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }
        private void clear()
        {
            surname.Text = "";
            name.Text = "";
            patronimic.Text = "";
            pol.SelectedItem = null;
            dolgnost.SelectedItem = null;
            peoplePhoto.Source = new BitmapImage(new Uri("User.png"));
        }
    }
}
