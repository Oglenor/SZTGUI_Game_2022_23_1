using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    internal interface IGameLogic
    {
        public void Move(Directions direction);
        public event EventHandler FigthStart;

        
    }
}
