using LordOfTheCards.Logic.Interfaces;
using LordOfTheCards.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordOfTheCards.Logic.Implementations
{
    public class GameDisplayService : IGameDisplayService
    {
        public void Display()
        {
            var window = new GameWindow();
            window.Show();
        }
    }
}
