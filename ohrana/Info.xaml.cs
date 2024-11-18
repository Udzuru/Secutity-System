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
using Main_api;
using System.Net.Http.Json;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window
    {   
        public Zaivki fff;
        public Info(int Id,string Type,string Where)
        {
            InitializeComponent();
            init(Id,Type,Where);
        }
        public void init(int Id,string Type,string Where)
        {
            bool blacklist = false;
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetFromJsonAsync("http://127.0.0.1:5150/Zaivki/"+Id, typeof(Zaivki));
            fff = (Zaivki)res.Result; 
            res = httpClient.GetFromJsonAsync("http://127.0.0.1:5150/Clients/" + fff.People, typeof(Person));
            Person person = (Person)res.Result;
            image.Source = ByteArrayToBitmapImageConverter.ConvertByteArrayToBitMapImage(fff.Photo);
            main_info.Text =
                "Дата подачи"+fff.ToDate+"\n"+
                "ФИО:"+ person.Patronimic + " " + person.Name + " " + person.Surname + "\n" +
                "День рождения:"+person.DateOfBirth+"\n"+
                "Серия и номер паспорта"+person.PassportSeria.ToString() + " " + person.PassportNumber +"\n"+
                "Организация"+person.Organization +"\n"+
                "Контакты"+person.EMail + " " + person.PhoneNumber + "\n"
                + "\n"+
                "Пропуск с "+fff.FromDate+"до"+fff.ToDate+"\n"+
                Type+" "+Where
                ;

                
        }

        private void NoPass_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.PostAsJsonAsync("http://127.0.0.1:5150/Zaivki/edit",fff);
            MessageBox.Show("Заявка успешно отказано!");

        }

        private void Pass_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add(fff);
            add.Show();
        }
    }
}
