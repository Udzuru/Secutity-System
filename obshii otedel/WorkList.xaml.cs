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
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Json;
using Main_api;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WorkList.xaml
    /// </summary>
    public partial class WorkList : Window
    {
        public WorkList()
        {
            InitializeComponent();

            get_type();
            get_where();
            get_Page();
            Combo1.SelectedIndex = 0;
            Combo2.SelectedIndex = 0;



        }
        public void get_Page()
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetFromJsonAsync("http://127.0.0.1:5150/Zaivki", typeof(Zaivki[]));
            Zaivki[] fff = (Zaivki[])res.Result;

            Show(fff);

        }
        public void Show(Zaivki[] fff)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (Zaivki k in fff)
            {
                if (k.Status == "Одобрено")
                {
                    list.Add(new { Id = k.Id, Date = k.Date, Type = Combo1.Items[(int)k.Type], Where = Combo2.Items[(int)k.Where], Status = k.Status, Photo = k.Photo });
                }
            }
            suka.ItemsSource = list;
        }
        public void get_type()
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetFromJsonAsync("http://127.0.0.1:5150/Types", typeof(List<Typ>));
            List<Typ> fff = (List<Typ>)res.Result;
            List<string> typ = new List<string>();
            typ.Add("Без фильтра" +
                "" +
                "");
            foreach(Typ k in fff)
            {
                typ.Add(k.Type);
            }
            Combo1.ItemsSource = typ;

        }
    public void get_where()
    {
        HttpClient httpClient = new HttpClient();
        var res = httpClient.GetFromJsonAsync("http://127.0.0.1:5150/Employe", typeof(List<Employer>));
        List<Employer> fff = (List<Employer>)res.Result;
        List<string> typ = new List<string>();
        typ.Add("Без фильтра" +
            "" +
            "");
        foreach (Employer k in fff)
        {
            typ.Add(k.Where);
        }
        Combo2.ItemsSource = typ;

    }

    private void Button_Click(object sender, RoutedEventArgs e)
        {

                HttpClient httpClient = new HttpClient();
                var res = httpClient.GetFromJsonAsync("http://127.0.0.1:5150/Zaivki/"+Combo1.SelectedIndex+"/"+Combo2.SelectedIndex+"/0", typeof(Zaivki[]));
                Zaivki[] fff = (Zaivki[])res.Result;
            List<Zaivki> temp = new List<Zaivki>();
            foreach(var k in fff)
            {
                if(k.Date.Value.Date == Set_date.SelectedDate.Value.Date)
                {
                    temp.Add(k);
                }
            }
            
            Show(temp.ToArray());
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Combo1.SelectedIndex = 0;
            Combo2.SelectedIndex = 0;
            Set_date.SelectedDate = null;
            get_Page();
        }

        private void suka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (suka.SelectedItem == null)
            {
                Show_all.IsEnabled = false;
            }
            else
            {
                Show_all.IsEnabled = true;
            }
        }

        private void Show_all_Click(object sender, RoutedEventArgs e)
        {
            Info info = new Info((int)suka.SelectedItem.GetType().GetProperty("Id").GetValue(suka.SelectedItem),
                (string)suka.SelectedItem.GetType().GetProperty("Type").GetValue(suka.SelectedItem),
                (string)suka.SelectedItem.GetType().GetProperty("Where").GetValue(suka.SelectedItem));
            info.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetFromJsonAsync("http://127.0.0.1:5150/Find/" + Find_str, typeof(Zaivki[]));
            Show((Zaivki[])res.Result);
        }
    }
}
