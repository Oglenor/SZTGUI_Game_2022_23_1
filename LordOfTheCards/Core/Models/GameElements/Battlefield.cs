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

        public void AwardToken()
        {
            if (CurrentTurnResolution == Resolution.PlayerWin)
            {
                PlayerTokens.Add(CurrentPlayerCard.Token);
            }
            else if(CurrentTurnResolution == Resolution.PlayerLoss)
            {
                playerTokens.Add(CurrentEnemyCard.Token);
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
