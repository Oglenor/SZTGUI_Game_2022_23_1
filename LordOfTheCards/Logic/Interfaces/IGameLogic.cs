using Core.Interfaces;
using Core.Models.Characters;
using Core.Models.GameElements;
using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IGameLogic
    {
        IGameModel GameModel { get; set; }
        void Move(Directions direction);
        event EventHandler FigthStart;
        void Fight(PlayerEntity entity);
        void SetCurrentCard(Card card);
    }
}
