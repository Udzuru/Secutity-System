using Main_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        Zaivki add_glo;
        public Add(Zaivki add)
        {
            add_glo = add;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = new DateTime(Set_Data.SelectedDate.Value.Date.Year , Set_Data.SelectedDate.Value.Date.Month, Set_Data.SelectedDate.Value.Date.Day, Convert.ToInt32(Set_hour.Text), Convert.ToInt32(Set_minute.Text),0);
            add_glo.Date = dateTime;
            add_glo.Status = "Одобрено";
            HttpClient httpClient = new HttpClient();
            httpClient.PostAsJsonAsync("http://127.0.0.1:5150/Zaivki/edit", add_glo);

            MessageBox.Show("Заявка успешно одобренно!");
        }
    }
}
