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

        //public override void Play(List<Player> players)
        //{
        //    #region old
        //    //Gui gui = new Gui();

        //    //while (!GameOver)
        //    //{
        //    //    int nextPlayer = 1;

        //    //    foreach (Player player in players.ToList())
        //    //    {
        //    //        if (nextPlayer >= players.Count)
        //    //        {
        //    //            nextPlayer = 0;
        //    //        }

        //    //        if (players[nextPlayer].hand.Count == 0)
        //    //        {
        //    //            players.Remove(players[nextPlayer]);
        //    //        }
        //    //        if (nextPlayer >= players.Count)
        //    //        {
        //    //            nextPlayer = 0;
        //    //        }

        //    //        player.PlayerTurn(players[nextPlayer]);

        //    //        if (players.Count <= 2)
        //    //        {

        //    //            if (player.lost)
        //    //            {
        //    //                //gui.LostGame(player.playerName);
        //    //                GameOver = true;
        //    //                return;
        //    //            }
        //    //        }

        //    //        if (player.isOut)
        //    //        {
        //    //            players.Remove(player);
        //    //        }
        //    //        nextPlayer++;
        //    //    }
        //    //}
        //    #endregion

        //    int nextPlayer = 1;

        //    foreach (Player player in players.ToList())
        //    {
        //        // resetter player count igen så den forsætte med player 1 igen 
        //        if (nextPlayer >= players.Count) 
        //        {
        //            nextPlayer = 0;
        //        }
        //        //

        //        if (players[nextPlayer].hand.Count == 0)
        //        {
        //            players.Remove(players[nextPlayer]);
        //        }
        //        //if (nextPlayer >= players.Count)
        //        //{
        //        //    nextPlayer = 0;
        //        //}

        //        //giver turen til den næste player
        //        player.PlayerTurn(players[nextPlayer]);

        //        if (players.Count <= 2)
        //        {

        //            if (player.lost)
        //            {
        //                //gui.LostGame(player.playerName);
        //                GameOver = true;
        //                return;
        //            }
        //        }

        //        //if (player.isOut)
        //        //{
        //        //    players.Remove(player);
        //        //}
        //        nextPlayer++;
        //    }

        //}
    }
}
