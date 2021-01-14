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

        public override void DrawFromPlayer(Player player, int index)
        {
            //if (hand.Count == 0)
            //{
            //    Debug.WriteLine(playerName + " has no cards left and is out of the game \n");
            //    isOut = true;
            //    return;
            //}
            Debug.WriteLine(playerName + " choose a card between 1 and " + player.hand.Count() + "\n");

            index = random.Next(0, player.hand.Count());
            DrawFromDeck(player.hand.ElementAt(index));
            player.hand.RemoveAt(index);
        }
    }
}
