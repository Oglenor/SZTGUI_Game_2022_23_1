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
        private Resolution currentTurnResolution;

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
        public Resolution CurrentTurnResolution
        {
            get { return currentTurnResolution; }
            set { currentTurnResolution = value; }
        }

        public Battlefield()
        {
            PlayerTokens = new List<Token>();
            EnemyTokens = new List<Token>();
            CurrentPlayerCard = null;
            CurrentEnemyCard = null;
            CurrentTurnResolution = new Resolution();
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
            CurrentTurnResolution = ResolutionCheck(CurrentPlayerCard, CurrentEnemyCard);
            AwardToken(CurrentPlayerCard, CurrentEnemyCard, CurrentTurnResolution);

            Step4_Actions(player, enemy);
        }

        private void Step4_Actions(Player player, Enemy enemy)
        {
            //itt kéne az akciókat meghívni. Hogyan? Minden kártyának más az akciója
            //CurrentPlayerCard.Action();
            //CurrentEnemyCard.Action();
            Step5_CheckForWinner(player, enemy);
        }

        private void Step5_CheckForWinner(Player player, Enemy enemy)
        {
            CheckWinner winnerThreeOfAKind = CheckForThreeOfAKind();
            CheckWinner winnerThreeOfDifferentKinds = CheckForThreeOfDifferentKinds();
        }
        private CheckWinner CheckForThreeOfAKind()
        {
            throw new NotImplementedException();
        }
        private CheckWinner CheckForThreeOfDifferentKinds()
        {
            throw new NotImplementedException();
        }

        private Resolution ResolutionCheck(Card CurrentPlayerCard, Card CurrentEnemyCard)
        {
            /*
             D = 1, N = 2, A = 4, ahol a két kapott kártya kateg-ját összeadom, akkor 3*2 = 6 eredmény lehet
             2 = D+D -> Rarity, 4 = N+N -> Rarity, 8 = A+A -> Rarity
             3 = D+N -> D nyer, 5 = D+A -> A nyer, 6 = N+A -> N nyer
             */

            Resolution playerWon = Resolution.PlayerLoss;

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
                    if (currentPlayerCard.Category == Categories.Divine)
                        playerWon = Resolution.PlayerWin;
                    break;
                case 5:
                    if (currentPlayerCard.Category == Categories.Alchemy)
                        playerWon = Resolution.PlayerWin;
                    break;
                case 6:
                    if (currentPlayerCard.Category == Categories.Necromancy)
                        playerWon = Resolution.PlayerWin;
                    break;

                default:
                    break;            
            }

            return playerWon;
        }

        private Resolution RarityCheck(Card currentPlayerCard, Card currentEnemyCard)
        {
            /*
             S = 1, B = 2, G = 4, ahol a két kapott kártya rarity-jét összeadom, akkor 3*2 = 6 eredmény lehet
             2 = S+S -> Tie, 4 = B+B -> Tie, 8 = G+G -> Tie
             3 = S+B -> B nyer, 5 = S+G -> G nyer, 6 = B+G -> G nyer
             */

            Resolution playerWon = Resolution.PlayerLoss;

            int eredmeny = (int)CurrentPlayerCard.Rarity + (int)CurrentEnemyCard.Rarity;
            switch (eredmeny)
            {
                case 2:
                    playerWon = Resolution.Tie;
                    break;
                case 4:
                    playerWon = Resolution.Tie;
                    break;
                case 8:
                    playerWon = Resolution.Tie;
                    break;

                case 3:
                    if (currentPlayerCard.Rarity == Rarities.Bronze)
                        playerWon = Resolution.Tie;
                    break;
                case 5:
                    if (currentPlayerCard.Rarity == Rarities.Golden)
                        playerWon = Resolution.Tie;
                    break;
                case 6:
                    if (currentPlayerCard.Rarity == Rarities.Golden)
                        playerWon = Resolution.Tie;
                    break;
                default:
                    break;
            }
            return playerWon;


        }

        private void AwardToken(Card currentPlayerCard, Card currentEnemyCard, Resolution playerWon)
        {
            if (playerWon == Resolution.PlayerWin)
            {
                PlayerTokens.Add(currentPlayerCard.Token);
            }
            else if(playerWon == Resolution.PlayerLoss)
            {
                playerTokens.Add(currentEnemyCard.Token);
            }
            else
            {
                //animáció?
            }
        }

        //current deployed cards - 
        //token lists - 

        //upkeep meghívása -
        //deploy meghívása -
        //resolution -
        //action meghívása a két kártyán 
        //check for winner


    }
}
