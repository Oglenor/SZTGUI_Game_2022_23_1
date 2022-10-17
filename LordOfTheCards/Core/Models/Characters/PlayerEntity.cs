using Core.Models.GameElements;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Core.Models.Characters
{
    abstract public class PlayerEntity
    {
        private List<Card> deck;
        private List<Card> graveyard;
        private List<Card> hand;

        public List<Card> Deck
        {
            get { return deck; }
            set { deck = value; }
        }
        public List<Card> Graveyard
        {
            get { return graveyard; }
            set { graveyard = value; }
        }
        public List<Card> Hand
        {
            get { return hand; }
            set { hand = value; }
        }


        public void ShuffleDeck()
        {
            Random rng = new Random();
            int n = Deck.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card currentCard = Deck[k];
                Deck[k] = Deck[n];
                Deck[n] = currentCard;
            }
        }

        public void ReShuffleDeck()
        {
            Deck.AddRange(Graveyard);
            Graveyard = new List<Card>();
            ShuffleDeck();
        }

        public void Upkeep()
        {
            Hand.Add(Deck[0]);
        }

        abstract public Card Deploy();
    }
}
