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

namespace Десктоп
{
    /// <summary>
    /// Логика взаимодействия для slugbaxaml.xaml
    /// </summary>
    public partial class slugbaxaml : Window
    {
        string FIO;
        public slugbaxaml(string Fio)
        {
            InitializeComponent();
            FIO = Fio;
            Update();
            
        }
        private void Update()
        {
            HttpClient http = new HttpClient();
            var k = http.GetFromJsonAsync("http://localhost:5150/Types", typeof(ТипПользователя[]));
            List<ТипПользователя> типs = ((ТипПользователя[])k.Result).ToList();
            String[] Items = (from var in типs select var.ТипПользователя1).ToArray();

            mainLabel.Text = FIO;
            HttpClient httpClient = new HttpClient();
            var dataRes = httpClient.GetFromJsonAsync("http://localhost:5150/User/Check", typeof(Пользователи[]));
            Пользователи[] data = (Пользователи[])dataRes.Result;
            List<dynamic> list = new List<dynamic>();
            List<dynamic> list1 = new List<dynamic>();
            foreach (var i in data)
            {
                if (i.Check == false)
                {
                    list.Add(new ShowData { id = i.Id, SNP = i.Фио, Dolgn = i.Должность, Items = Items, logi = i.Логин, Password = i.Пароль, SecretWord = i.СекретноеСлово, Check = i.Check, SelectedItem = i.ТипПользователя });
                }
                else
                {
                    list1.Add(new ShowData{ id = i.Id, SNP = i.Фио, Dolgn = i.Должность, Prava = i.Добавление, Pravb = i.Просмотр, Pravc = i.Отчеты });
                }
            }
            Grd.ItemsSource = list;
            Grd1.ItemsSource = list1;

        }

        private async void cool_Click(object sender, RoutedEventArgs e)
        {   
            List<Пользователи> peoples = new List<Пользователи> ();
            foreach(ShowData item in Grd.Items)
            {
                if (item.Check==true)
                {
                    peoples.Add(new Пользователи { Id=item.id,Check = item.Check, ТипПользователя=item.SelectedItem+1, Логин=item.logi, Пароль=item.Password, СекретноеСлово=item.SecretWord});
                }
            }
            HttpClient http = new HttpClient();
            SendData sendData = new SendData {pep=peoples.ToArray() };
            var k = http.PostAsJsonAsync("http://localhost:5150/Users",sendData);
            var p = k.Result;
            Update();

        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            List<Пользователи> peoples = new List<Пользователи>();
            foreach (ShowData item in Grd.Items)
            {
                if (item.Check == true)
                {
                    peoples.Add(new Пользователи { Id = item.id, Добавление = item.Prava, Просмотр = item.Pravb, Отчеты = item.Pravc });
                }
            }
            HttpClient http = new HttpClient();
            SendData sendData = new SendData { pep = peoples.ToArray() };
            var k = http.PostAsJsonAsync("http://localhost:5150/Users", sendData);
            var p = k.Result;
            Update();
        }
    }
    class SendData
    {
        public Пользователи[] pep { get; set; }
    }
    public partial class ShowData
    {
        public int id { get; set; }
        public string? SNP { get; set; }
        public int? Dolgn { get; set; }
        public string[] Items { get; set; }

        public string logi { get; set; }
        public string? Password { get; set; }
        public string? SecretWord { get; set; }
        public bool? Check { get; set; }
        public int? SelectedItem { get; set; }
        public bool? Prava { get; set; }
        public bool? Pravb { get; set; }
        public bool? Pravc { get; set; }
        

        
    }
}
