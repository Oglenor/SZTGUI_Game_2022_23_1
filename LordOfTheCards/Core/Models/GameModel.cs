using Core.Interfaces;
using Core.Models.Characters;
using Core.Models.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class GameModel : IGameModel
    {
        public Dictionary<string, Map> Maps { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Player Player { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Enemy> EnemyList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Card> AllCards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
