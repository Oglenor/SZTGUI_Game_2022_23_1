using LordOfTheCards.Logic.Interfaces;
using LordOfTheCards.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LordOfTheCards.Logic.Implementations
{
    public class GameDisplayService : IGameDisplayService
    {
        public void Display(Type type)
        {
            if (type == typeof( GameWindow) )
            {
                var window = new GameWindow();
                window.Show();
            }            
            else if(type == typeof(DesignerWindow))
            {
                var window = new DesignerWindow();
                window.Show();
            }
        }
    }
}
