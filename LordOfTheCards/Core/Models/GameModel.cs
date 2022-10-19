using Core.Interfaces;
using Core.Models.Characters;
using Core.Models.GameElements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class GameModel : IGameModel
    {
        public Dictionary<string, Map> Maps { get; set; }
        public Player Player { get; set; }
        public List<Enemy> EnemyList { get; set; }
        public List<Card> AllCards { get; set; }
        public Battlefield Battlefield { get; set; }

        //constructor with AllCards generator

        public GameModel()
        {
            AllCards = new List<Card>();
            StreamReader cardFile = new StreamReader(Path.Combine("Core", "Assets", "AllCardsData.txt"));
            while (!cardFile.EndOfStream)
            {
                string[] dataLine = cardFile.ReadLine().Split('/');
                AllCards.Add(new Card(dataLine));
            }
        }
    }
}
