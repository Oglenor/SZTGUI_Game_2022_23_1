using Core.Models.Characters;
using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements
{
    internal class Battlefield
    {
        private List<Token> playerTokens;
        private List<Token> enemyTokens;
        private Card currentPlayerCard;
        private Card currentEnemyCard;

        public List<Token> PlayerTokens
        {
            get { return playerTokens; }
            set { playerTokens = value; }
        }
        public List<Token> EnemyTokens
        {
            get { return enemyTokens; }
            set { enemyTokens = value; }
        }
        public Card CurrentPlayerCard
        {
            get { return currentPlayerCard; }
            set { currentPlayerCard = value; }
        }
        public Card CurrentEnemyCard
        {
            get { return currentEnemyCard; }
            set { currentEnemyCard = value; }
        }

        public Battlefield()
        {
            PlayerTokens = new List<Token>();
            EnemyTokens = new List<Token>();
            CurrentPlayerCard = null;
            CurrentEnemyCard = null;
        }

        public void Step1_Upkeep(Player player, Enemy enemy)
        {
            player.Upkeep();
            enemy.Upkeep();
            Step2_Deploy(player, enemy);
        }

        private void Step2_Deploy(Player player, Enemy enemy)
        {
            CurrentPlayerCard = player.Deploy();
            CurrentEnemyCard = enemy.Deploy();
            Step3_Resolution(player, enemy);
        }

        private void Step3_Resolution(Player player, Enemy enemy)
        {
            /*
             D = 1, N = 2, A = 4, ahol a két kapott kártya kateg-ját összeadom, akkor 3*2 = 6 eredmény lehet
             2 = D+D -> Rarity, 4 = N+N -> Rarity, 8 = A+A -> Rarity
             3 = D+N -> D nyer, 5 = D+A -> A nyer, 6 = N+A -> N nyer
             */

            Resolution playerWon = (Resolution)Enum.Parse(typeof(Resolution), "PlayerLoss");

            int eredmeny = (int)CurrentPlayerCard.Category + (int)CurrentEnemyCard.Category;
            switch (eredmeny)
            {
                case 2:
                    playerWon = RarityCheck(currentPlayerCard, currentEnemyCard);
                    break;
                case 4:
                    playerWon = RarityCheck(currentPlayerCard, currentEnemyCard);
                    break;
                case 8:
                    playerWon = RarityCheck(currentPlayerCard, currentEnemyCard);
                    break;

                case 3:
                    if (currentPlayerCard.Category == (Categories)Enum.Parse(typeof(Categories), "Divine"))
                        playerWon = (Resolution)Enum.Parse(typeof(Resolution), "PlayerWin");
                    break;
                case 5:
                    if (currentPlayerCard.Category == (Categories)Enum.Parse(typeof(Categories), "Alchemy"))
                        playerWon = (Resolution)Enum.Parse(typeof(Resolution), "PlayerWin");
                    break;
                case 6:
                    if (currentPlayerCard.Category == (Categories)Enum.Parse(typeof(Categories), "Necromancy"))
                        playerWon = (Resolution)Enum.Parse(typeof(Resolution), "PlayerWin");
                    break;

                default:
                    break;
            }

        }

        //need to implement
        private Resolution RarityCheck(Card currentPlayerCard, Card currentEnemyCard)
        {
            throw new NotImplementedException();
        }

        //current deployed cards - 
        //token lists - 

        //upkeep meghívása
        //deploy meghívása
        //resolution
        //action meghívása a két kártyán
        //check for winner


    }
}
