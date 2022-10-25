using Core.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private ImageSource _myImageSource = new BitmapImage(new Uri($"{GameSettings.Instance.ResourcesPath}floor.png", UriKind.Relative));

        public ImageSource MyImageSource
        {
            get { return _myImageSource; }
            set
            {
                _myImageSource = value;
                OnPropertyChanged("MyImageSource");
            }
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {

            string name = $"{GameSettings.Instance.ResourcesPath}floor.png";

            BitmapImage im = new BitmapImage(new Uri($"{GameSettings.Instance.ResourcesPath}floor.png", UriKind.Relative));


            this.MyImageSource = im;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
