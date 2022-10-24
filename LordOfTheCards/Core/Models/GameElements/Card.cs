using Core.Models.Characters;
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

        //txt beolvasásra volt, lehet most már törölhető
        public Card(string[] dataLine)
        {
            id = int.Parse(dataLine[0]);
            color = (Colors)Enum.Parse(typeof(Colors), dataLine[1]);
            rarity = (Rarities)Enum.Parse(typeof(Rarities), dataLine[2]);
            category = (Categories)Enum.Parse(typeof(Categories), dataLine[3]);
            token = new Token(Color, Category);

            assetPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Core", "Assets", "AllCards", dataLine[4]));
        }

        //szerializálható
        public Card(int id, Colors color, Rarities rarity, Categories category, string path)
        {
            this.id = id;
            this.color = color;
            this.rarity = rarity;
            this.category = category;
            token = new Token(color, category);

            assetPath = path;
        }

        public Card()
        {
        }

        public void Action(Battlefield battlefield, PlayerEntity entity)
        {
            switch (ID)
            {
                case 2:
                    break; //ancient warlord
                case 6:
                    if (entity is Player)
                    {
                        Card capturedCard = battlefield.CurrentEnemyCard;
                        battlefield.CurrentPlayer.Hand.Add(capturedCard);
                    }
                    else
                    {
                        Card capturedCard = battlefield.CurrentPlayerCard;
                        battlefield.CurrentEnemy.Hand.Add(capturedCard);
                    }     
                    break; //bor the jailor
                case 10:
                    if (entity is Player)
                    {
                        Resolution currentTurn = battlefield.CurrentTurnResolution;
                        if (currentTurn == Resolution.PlayerLoss)
                            battlefield.PlayerTokens.Add(new Token(Colors.Blue, Categories.Alchemy));
                        else if (currentTurn == Resolution.PlayerWin)
                            battlefield.PlayerTokens.Add(new Token(Colors.Blue, Categories.Divine));
                    }
                    else
                    {
                        Resolution currentTurn = battlefield.CurrentTurnResolution;
                        if (currentTurn == Resolution.PlayerWin)
                            battlefield.EnemyTokens.Add(new Token(Colors.Blue, Categories.Alchemy));
                        else if (currentTurn == Resolution.PlayerLoss)
                            battlefield.EnemyTokens.Add(new Token(Colors.Blue, Categories.Divine));
                    }
                    break; //comet of hope
                case 12:
                    break; //cryptic vision
                case 23:   
                    if (entity is Player && battlefield.CurrentTurnResolution == Resolution.PlayerLoss && battlefield.CurrentEnemyCard.Category == Categories.Alchemy)
                        battlefield.PlayerTokens.Add(new Token(Colors.Grey, Categories.Necromancy));
                    else if (entity is Enemy && battlefield.CurrentTurnResolution == Resolution.PlayerWin && battlefield.CurrentPlayerCard.Category == Categories.Alchemy)
                        battlefield.EnemyTokens.Add(new Token(Colors.Grey, Categories.Necromancy));
                    break; // gates of oblivion
                case 30:
                    battlefield.PlayerTokens.Clear();
                    battlefield.EnemyTokens.Clear();
                    break; // judgement day
                case 36:
                    break; // meeting the creator
                case 41:
                    break; // mystery tunnel
                case 47:
                    break; //seagod's champion triburon
                case 48:
                    break; // Seagod's trident
                case 51:
                    break; // starfall
                case 53:
                    break; // the almighty eye
                case 54:
                    break; // the ego collector
                case 56:
                    break; // Timetraveller's hourglass
                case 60:
                    break; // Wormhole
                default:
                    break;
            }
        }   
    }
}
