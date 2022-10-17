using Logic.Enums;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class GameLogic : IGameLogic
    {
        public event EventHandler FigthStart;

        public void Move(Directions direction)
        {
            throw new NotImplementedException();
        }
    }
}
