using Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements
{
    public class Card
    {
        private int id;
        private Token token;
		private Colors color;
		private Rarities rarity;
		private Categories category;
        private string assetPath;

        //event, path
        public int ID
        {
            get { return id; }
        }
        public Token Token
        {
            get { return token; }
        }
        public Colors Color
		{
			get { return color; }
		}
        public Rarities Rarity
        {
            get { return rarity; }
        }
        public Categories Category
        {
            get { return category; }
        }
        public string AssetPath
        {
            get { return assetPath; }
            set { assetPath = value; }
        }

        public Card(string[] dataLine)
        {
            id = int.Parse(dataLine[0]);
            color = (Colors)Enum.Parse(typeof(Colors), dataLine[1]);
            rarity = (Rarities)Enum.Parse(typeof(Rarities), dataLine[2]);
            category = (Categories)Enum.Parse(typeof(Categories), dataLine[3]);
            token = new Token(Color, Category);

            assetPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "Core", "Assets", "AllCards", dataLine[4]));
        }

        public void Action(Battlefield battlefield)
        {
            switch (ID)
            {
                case 0: //comet of hope for example
                    Resolution currentTurn = battlefield.CurrentTurnResolution;
                    if (currentTurn == Resolution.PlayerLoss)
                        battlefield.PlayerTokens.Add(new Token(Colors.Blue, Categories.Alchemy));
                    else if (currentTurn == Resolution.PlayerWin)
                        battlefield.PlayerTokens.Add(new Token(Colors.Blue, Categories.Divine));
                    break;
                default:
                    break;
            }
        }
    }
}
