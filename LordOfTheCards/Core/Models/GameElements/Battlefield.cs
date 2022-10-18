using Core.Models.Characters;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements
{
    public class Battlefield
    {
        private List<Token> playerTokens;
        private List<Token> enemyTokens;
        private Card currentPlayerCard;
        private Card currentEnemyCard;
        private Resolution currentTurnResolution;
        private Player currentPlayer;
        private Enemy currentEnemy;

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
        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        public Enemy CurrentEnemy
        {
            get { return currentEnemy; }
            set { currentEnemy = value; }
        }

        public Battlefield(Player currentPlayer, Enemy currentEnemy)
        {
            PlayerTokens = new List<Token>();
            EnemyTokens = new List<Token>();
            CurrentPlayerCard = null;
            CurrentEnemyCard = null;
            CurrentTurnResolution = new Resolution();
            CurrentPlayer = currentPlayer;
            CurrentEnemy = currentEnemy;
        }

        public void Step1_Upkeep()
        {
            currentPlayer.Upkeep();
            currentEnemy.Upkeep();

            Step2_Deploy(currentPlayer, currentEnemy);
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
            List<Colors> colorsDivine = new List<Colors>();
            List<Colors> colorsNecromancy = new List<Colors>();
            List<Colors> colorsAlchemy = new List<Colors>();

            //player check
            foreach (var token in playerTokens)
            {
                switch (token.Category)
                {
                    case Categories.Divine:
                        if(!colorsDivine.Contains(token.Color))
                            colorsDivine.Add(token.Color);
                        break;
                    case Categories.Necromancy:
                        if (!colorsNecromancy.Contains(token.Color))
                            colorsNecromancy.Add(token.Color);
                        break;
                    case Categories.Alchemy:
                        if (!colorsAlchemy.Contains(token.Color))
                            colorsAlchemy.Add(token.Color);
                        break;
                    default:
                        break;
                }
            }
            if (colorsDivine.Count >= 3 || colorsNecromancy.Count >= 3 || colorsAlchemy.Count >= 3)
            {
                return CheckWinner.PlayerWin;
            }

            //enemy check

            foreach (var token in enemyTokens)
            {
                switch (token.Category)
                {
                    case Categories.Divine:
                        if (!colorsDivine.Contains(token.Color))
                            colorsDivine.Add(token.Color);
                        break;
                    case Categories.Necromancy:
                        if (!colorsNecromancy.Contains(token.Color))
                            colorsNecromancy.Add(token.Color);
                        break;
                    case Categories.Alchemy:
                        if (!colorsAlchemy.Contains(token.Color))
                            colorsAlchemy.Add(token.Color);
                        break;
                    default:
                        break;
                }
            }
            if (colorsDivine.Count >= 3 || colorsNecromancy.Count >= 3 || colorsAlchemy.Count >= 3)
            {
                return CheckWinner.PlayerLoss;
            }

            return CheckForThreeOfDifferentKinds();
        }
        private CheckWinner CheckForThreeOfDifferentKinds()
        {

            throw new NotImplementedException();
        }

        /*boolean findSolutions(n, other params) :
            if (found a solution) :
                displaySolution();
                return true;

            for (val = first to last) :
                if (isValid(val, n)) :
                applyValue(val, n);
                    if (findSolutions(n+1, other params))
                        return true;
                removeValue(val, n);
            return false;*/

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
