using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class SortePer : CardGame
    {
        public SortePer()
        {
            this.CardAmount = 52;
            CreateDeck();
            foreach (Card card in Cards.ToList())
            {
                if (card.CardSuit == Card.Suit.Clubs && card.CardValue == 10)
                {
                    this.Cards.Remove(card);
                }
            }
        }
    }
}
