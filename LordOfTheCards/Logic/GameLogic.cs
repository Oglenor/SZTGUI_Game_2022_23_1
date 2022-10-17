using Core.Interfaces;
using Core.Models.Characters;
using Logic.Enums;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GameLogic : IGameLogic
    {
        public IGameModel GameModel { get; set; }

        public event EventHandler FigthStart;

        public GameLogic(IGameModel gameModel)
        {
            GameModel = gameModel;
        }

        //Ok a gamemodellt még cizellálni kell.
        public void Fight(PlayerEntity enemy)
        {
            //TODO e player entity-t még meg kellene írni rendesen.
            

        }

        public void Move(Directions direction)
        {
            throw new NotImplementedException();
        }
    }
}
