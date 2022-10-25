using LordOfTheCards.Logic.Implementations;
using LordOfTheCards.Logic.Interfaces;
using LordOfTheCards.Windows;
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

namespace LordOfTheCards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IGameDisplayService gameDisplayService;

        public MainWindow()
        {
            gameDisplayService = new GameDisplayService();
            InitializeComponent();
        }

        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            gameDisplayService.Display(typeof(GameWindow));
        }

        private void LevelDesignerClick(object sender, RoutedEventArgs e)
        {
            gameDisplayService.Display(typeof(DesignerWindow));
        }

        private void ContinueClick(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
