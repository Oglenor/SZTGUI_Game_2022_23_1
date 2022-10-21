<<<<<<< HEAD
﻿using Core.Interfaces;
using Core.Models.Characters;
using Logic.Enums;
=======
﻿using Logic.Enums;
>>>>>>> Martin
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Models.Enums;
using Core.Models.GameElements;
using Core.Models.Characters;

namespace Logic
{
    public class GameLogic : IGameLogic
    {
<<<<<<< HEAD
        public IGameModel GameModel { get; set; }

        public event EventHandler FigthStart;

        public GameLogic(IGameModel gameModel)
        {
            GameModel = gameModel;
        }

        //Ok a gamemodellt még cizellálni kell.
        public void Fight(PlayerEntity enemy)
        {
            //TODO e player entity-t még meg kellene írni rendesen.
            

        }
=======
        public event EventHandler FigthStart;
        public IGameModel gameModel;
>>>>>>> Martin

        public void Move(Directions direction)
        {
            throw new NotImplementedException();
        }
<<<<<<< HEAD
=======

        #region CardGameLogicRegion
        //all the logic required for the card game

        public void SetupBattlefield(Enemy enemy)
        {
            gameModel.Battlefield = new Battlefield(gameModel.Player, enemy);
            Step1_Upkeep();
        }

        public void Step1_Upkeep()
        {
            gameModel.Battlefield.CurrentPlayer.Upkeep();
            gameModel.Battlefield.CurrentEnemy.Upkeep();
            Step2_Deploy();
        }

        private void Step2_Deploy()
        {
            gameModel.Battlefield.CurrentPlayer.Deploy();
            gameModel.Battlefield.CurrentEnemy.Deploy();
            Step3_Resolution();
        }

        private void Step3_Resolution()
        {
            gameModel.Battlefield.CurrentTurnResolution = ResolutionCheck(gameModel.Battlefield.CurrentPlayerCard, gameModel.Battlefield.CurrentEnemyCard);
            gameModel.Battlefield.AwardToken();
            Step4_Actions();
        }

        private void Step4_Actions()
        {
            gameModel.Battlefield.CurrentPlayerCard.Action(gameModel.Battlefield, gameModel.Battlefield.CurrentPlayer);
            gameModel.Battlefield.CurrentEnemyCard.Action(gameModel.Battlefield, gameModel.Battlefield.CurrentEnemy);
            Step5_CheckForWinner();
        }

        private void Step5_CheckForWinner()
        {
            CheckWinner winnerThreeOfAKind = CheckForThreeOfAKind();
            CheckWinner winnerThreeOfDifferentKinds = CheckForThreeOfDifferentKinds();

            if (winnerThreeOfAKind == CheckWinner.PlayerWin || winnerThreeOfDifferentKinds == CheckWinner.PlayerWin)
            {
                PlayerWinBattle(gameModel.Battlefield.CurrentEnemy);
            }
            else if (winnerThreeOfAKind == CheckWinner.PlayerLoss || winnerThreeOfDifferentKinds == CheckWinner.PlayerLoss)
            {
                PlayerLoseBattle(gameModel.Battlefield.CurrentEnemy);
            }
            else
            {
                Step1_Upkeep();
            }
        }


        private Resolution ResolutionCheck(Card currentPlayerCard, Card currentEnemyCard)
        {
            /*
             D = 1, N = 2, A = 4, ahol a két kapott kártya kateg-ját összeadom, akkor 3*2 = 6 eredmény lehet
             2 = D+D -> Rarity, 4 = N+N -> Rarity, 8 = A+A -> Rarity
             3 = D+N -> D nyer, 5 = D+A -> A nyer, 6 = N+A -> N nyer
             */

            Resolution playerWon = Resolution.PlayerLoss;

            int eredmeny = (int)currentPlayerCard.Category + (int)currentEnemyCard.Category;
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

            int eredmeny = (int)currentPlayerCard.Rarity + (int)currentEnemyCard.Rarity;
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


        private CheckWinner CheckForThreeOfAKind()
        {
            List<Colors> colorsDivine = new List<Colors>();
            List<Colors> colorsNecromancy = new List<Colors>();
            List<Colors> colorsAlchemy = new List<Colors>();

            //player check
            foreach (var token in gameModel.Battlefield.PlayerTokens)
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
                return CheckWinner.PlayerWin;
            }

            //enemy check

            foreach (var token in gameModel.Battlefield.EnemyTokens)
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
            //to be implemented, backtracking?
            throw new NotImplementedException();
        }

        
        private void PlayerWinBattle(Enemy enemy)
        {
            //based on enemy level give loot
            //to be implemented
            throw new NotImplementedException();
        }
        private void PlayerLoseBattle(Enemy currentEnemy)
        {
            //Depending on enemy (boss or minion) los either 1 or 2 health
            throw new NotImplementedException();
        }

        #endregion

>>>>>>> Martin
    }
}
