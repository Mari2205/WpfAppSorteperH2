using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class GameManager
    {
        private CardGame cardGame;
        public List<Player> players = new List<Player>();
        public event EventHandler Lostgame;
        public event EventHandler UpdatePlayerList;

        public GameManager()
        {
            players.Add(new HumanPlayer("Humen player"));
            players.Add(new BotPlayer("Bot player"));

            cardGame = new SortePer();
        }

        public void Start()
        {
            Shuffle(cardGame.Cards);
            GiveCards();
        }

        public void Shuffle<T>(IList<T> list)
        {
            Random random = new Random();

            for (int i = list.Count - 1; i > 1; i--)
            {
                int ran = random.Next(i + 1);
                T value = list[ran];
                list[ran] = list[i];
                list[i] = value;
            }
        }

        void GiveCards()
        {
            while (cardGame.Cards.Count != 0)
            {
                foreach (Player player in players)
                {
                    if (cardGame.Cards.Count == 0)
                    {
                        return;
                    }
                    player.DrawFromDeck(cardGame.Cards.First());
                    cardGame.Cards.RemoveAt(0);
                    player.CheckMatches(); // cheker om der er nogen macthes i det kortne bliver uddelt

                }
            }
        }

        public void PlayerLost(Player player)
        {
            if (player.hand.Count == 1 && player.hand.First().CardValue == 10 && player.hand.First().CardSuit == Card.Suit.Spades)
            {
                player.lost = true;
                return;
            }
        }

        public void DrawCardFromPlayer(int cardIndex, int playerIndex, int nextPlayerIndex)
        {
            PlayerLost(players[nextPlayerIndex]);

            if (players[playerIndex].lost)
            {
                Debug.WriteLine(players[playerIndex].playerName + " lost the game");
                Lostgame?.Invoke(this, EventArgs.Empty); // her vægger et envent Lostgame
                return;
            }

            players[playerIndex].DrawFromPlayer(players[nextPlayerIndex], cardIndex);
            UpdatePlayerList?.Invoke(this, EventArgs.Empty); // her vægger et envent UpdatePlayerList
        }

        public void CheckForePair(int index)
        {
            players[index].CheckMatches();
        }
    }
}
