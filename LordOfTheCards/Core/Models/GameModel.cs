using Core.Interfaces;
using Core.Models.Characters;
using Core.Models.GameElements;
using Models.Enums;
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
<<<<<<< HEAD
        public List<Card> AllCards { get; set; }             
=======
        public List<Card> AllCards { get; set; }
        public Battlefield Battlefield { get; set; }

        //constructor with AllCards generator

        public GameModel()
        {
            AllCards = new List<Card>();
            StreamReader cardFile = new StreamReader(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Core", "Assets", "AllCards", Path.GetFileName("AllCardsData.txt")));
            cardFile.ReadLine(); //az első sor a minta
            while (!cardFile.EndOfStream)
            {
                string[] dataLine = cardFile.ReadLine().Split(',');
                AllCards.Add(new Card(dataLine));
            }
        }
>>>>>>> Martin
    }
}
