using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Player
    {
        public List<Card> hand = new List<Card>();
        public string playerName;
        public bool lost = false;

        public Player(string name)
        {
            playerName = name;
        }

        public void DrawFromDeck(Card card)
        {
            hand.Add(card);
        }

        public virtual void DrawFromPlayer(Player player, int CardIndex)
        {
            //if (player.hand.Count == 0)
            //{
            //    Debug.WriteLine(playerName + " has no cards left and is out of the game \n");
            //    return;
            //}
            Debug.WriteLine(playerName + " choose a card between 1 and " + player.hand.Count() + "\n");
            hand.Add(player.hand.ElementAt(CardIndex - 1));
            player.hand.RemoveAt(CardIndex - 1);

        }

        public void CheckMatches()
        {
            for (int i = 0; i < hand.Count; i++)
            {
                foreach (Card card in hand.ToList())
                {
                    if (card.CardValue == hand[i].CardValue && card.CardSuit != hand[i].CardSuit)
                    {
                        if (card.CardColor == hand[i].CardColor)
                        {
                            Debug.WriteLine(playerName + " found a pair! \n");
                            Debug.WriteLine("They matched " + card.ToString());
                            Debug.WriteLine("with " + hand[i].ToString() + "\n");
                            hand.Remove(hand[i]);
                            hand.Remove(card);
                        }
                    }
                }
            }
        }
    }
}
