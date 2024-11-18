using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace MySqlCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {   List<Table> tables = new List<Table>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   Random r= new Random();
            Table table = new Table("Таблица", r.Next(1,300),r.Next(1,300));
            table.Draw(canvas);
            
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {   

             //= (string)e.Data.GetData(DataFormats.Text);
        }
    }
}
