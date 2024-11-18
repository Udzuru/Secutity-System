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
using System.Net.Http;
using System.Net.Http.Json;
using Main_api;

namespace Десктоп
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HttpClient http = new HttpClient();
            var k = http.GetFromJsonAsync("http://localhost:5150/Types", typeof(ТипПользователя[]));
            List<ТипПользователя> типs = ((ТипПользователя[])k.Result).ToList();
            typeUser.ItemsSource=from var in типs select var.ТипПользователя1;
            

        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient http = new HttpClient();
            try
            {
                var k = http.GetFromJsonAsync("http://localhost:5150/User/" + login.Text + "/" + password.Text + "/" + secretWord.Text + "/" + (typeUser.SelectedIndex + 1), typeof(Пользователи));
                Пользователи типs = ((Пользователи)k.Result);
                if(typeUser.SelectedIndex == 0)
                {
                    Access access = new Access(типs.Фио);
                    access.Show();
                }
                if(typeUser.SelectedIndex == 1)
                {
                    slugbaxaml slugba = new slugbaxaml(типs.Фио);
                    slugba.Show();
                }
                
            }
            catch
            {
                MessageBox.Show("Введены не корректные данные!!!!!!!!!!!");
            }
            
        }
    }
}
