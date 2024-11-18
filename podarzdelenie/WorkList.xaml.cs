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
        Employer employer;
        List<string> types;
        List<string> wheres;
        public WorkList(Employer p)
        {
            InitializeComponent();
            employer = p;
            mainText.Text ="Хранитель ПРО "+employer.Where;
            get_type();
            get_where();
            get_Page();
            
         
            
        }
        public void get_Page()
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetFromJsonAsync("http://127.0.0.1:5150/Zaivki/0/" + employer.Id + "/Одобрено", typeof(Zaivki[]));
            Zaivki[] fff = (Zaivki[])res.Result;
            Show(fff);

        }
        public void Show(Zaivki[] fff)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (Zaivki k in fff)
            {
                list.Add(new { Id = k.Id, Date = k.Date, Type = types[(int)k.Type],Where = wheres[(int)k.Where], Status = k.Status,Photo =k.Photo });
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
            types = typ;

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
        wheres = typ; 

    }

    private void Find_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetFromJsonAsync("http://127.0.0.1:5150/Zaivki/0/" + employer.Id + "/Одобрено", typeof(Zaivki[]));
            Zaivki[] zaivki = (Zaivki[])res.Result;
            List<Zaivki>temp = new List<Zaivki>();
            if (Date1.SelectedDate == null)
            {
                Date1.SelectedDate = DateTime.Now;

            }
            if (Date2.SelectedDate == null)
            {
                Date2.SelectedDate = DateTime.Now;
            }
            foreach (var i in zaivki)
            {
                MessageBox.Show(Date1.SelectedDate.ToString());
               if(i.Date>Date1.SelectedDate && i.Date < Date2.SelectedDate)
                {
                    temp.Add(i);
                }
            }
            Show(temp.ToArray());
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Date1.SelectedDate = null;
            Date2.SelectedDate=null;
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
    }
}
