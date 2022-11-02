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
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            if (e.Source is Label)
            {
                var bitMap = new BitmapImage(new Uri($"{Path.Combine(Environment.CurrentDirectory, @"Resources\Images\")}base.png", UriKind.Relative));
                var resultBrush = new ImageBrush(bitMap);
                (e.Source as Label).Background = resultBrush;                
            }
        }
    }
}
