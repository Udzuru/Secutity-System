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
using System.Net.Http.Json;
using System.Net.Http;
using Main_api;
using System.Text.Json.Serialization;

namespace WpfApp1
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

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            double k = Convert.ToInt32(txt.Text);
            Employer emp = new Employer();
            emp.Code = k;
            var p =client.GetFromJsonAsync("http://127.0.0.1:5150/employe/reg/"+emp.Code,typeof(Employer));
            Employer em =(Employer) p.Result;
            if (em.Otdel == "Общий отдел")
            {
                WorkList wrkl = new WorkList();
                wrkl.Show();
            }
            else
            {
                MessageBox.Show("Вы ввели не правильный пароль!");
            }

        }
    }
}
