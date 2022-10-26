using Core.Interfaces;
using Core.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Xml.Linq;
using Path = System.IO.Path;

namespace LordOfTheCards.Windows
{
    /// <summary>
    /// Interaction logic for DesignerWindow.xaml
    /// </summary>
    public partial class DesignerWindow : Window
    {
        public DesignerWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle source = e.Source as Rectangle;


            var bitMap = new BitmapImage(new Uri($"{Path.Combine(Environment.CurrentDirectory, @"Resources\Images\")}base.png", UriKind.Relative));
            var resultBrush = new ImageBrush(bitMap);
            if (source != null)
            {
                
        
                


                (e.Source as Rectangle).Fill = resultBrush;



            }

            txt1.Text = "Mouse Entered";
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle source = e.Source as Rectangle;




            if (source != null)
            {
                (e.Source as Rectangle).Fill = Brushes.Cyan;
            }
            


            txt1.Text = "Mouse Leave";
            txt2.Text = "";
            txt3.Text = "";
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Point pnt = e.GetPosition(mrRec);
            txt2.Text = "Mouse Move: " + pnt.ToString();
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle source = e.Source as Rectangle;
            Point pnt = e.GetPosition(mrRec);
            txt3.Text = "Mouse Click: " + pnt.ToString();

            if (source != null)
            {
                source.Fill = Brushes.Beige;
            }
        }
    }
}
