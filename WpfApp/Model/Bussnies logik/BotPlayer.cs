using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class BotPlayer : Player
    {
        Random random = new Random();
        public BotPlayer(string name) : base(name)
        {
            
        }

        /// <summary>
        /// her laver jeg en override fordi at en bot player skal trake et tilfældigt kort og et bruger difineret kort
        /// </summary>
        /// <param name="player"></param>
        /// <param name="index"></param>
        public override void DrawFromPlayer(Player player, int index)
        { 
            Debug.WriteLine(playerName + " choose a card between 1 and " + player.hand.Count() + "\n");

            index = random.Next(0, player.hand.Count());
            DrawFromDeck(player.hand.ElementAt(index));
            player.hand.RemoveAt(index);
        }
    }
}
