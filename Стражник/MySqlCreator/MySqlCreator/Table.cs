using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MySqlCreator
{   
    public class Table
    {
        public string Name { get; set; }
        int Top { get; set; }
        int Left { get; set; }
        Button btn;
        public Table(string n, int top, int left)
        {
            Name= n;
            Top = top;
            Left = left;
        }
        public void Draw(Canvas canvas)
        {
            btn = new Button { Content = Name };
            btn.MouseDown += Btn_MouseDown;
            btn.PreviewMouseDown += Btn_PreviewMouseDown;
            btn.AllowDrop = true;
            Canvas.SetLeft(btn, Left);
            Canvas.SetTop(btn, Top);
            canvas.Children.Add(btn);
        }

        private void Btn_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            btn.Background = Brushes.Black;
            DragDrop.DoDragDrop((Button)sender, ((Button)sender).Content, DragDropEffects.Move);
        }

        private void Btn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            btn.Background = Brushes.Black;
            DragDrop.DoDragDrop((Button)sender, ((Button)sender).Content, DragDropEffects.Move);
        }
    }
}
