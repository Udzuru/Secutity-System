﻿using System;
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
using System.Net;

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

        private async void enter_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            double k = Convert.ToInt32(txt.Text);
            Employer emp = new Employer();
            emp.Code = k;
            try
            {
                var p = client.GetFromJsonAsync("http://127.0.0.1:5150/Otdel/" + emp.Code, typeof(Employer));
                WorkList workList = new WorkList((Employer)p.Result);
                workList.Show();

                
            }
            catch {
                MessageBox.Show("Не правильный код попробуйте еще раз!!!!!!!!!!");
            }
            
            

        }
    }
}
