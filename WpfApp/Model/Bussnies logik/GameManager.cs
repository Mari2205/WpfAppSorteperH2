﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSortePer
{
    public class GameManager
    {
        private CardGame cardGame;
        private List<Player> players = new List<Player>();

        public GameManager(int humanPlayerCount, int botCount)
        {
            for (int i = 1; i < humanPlayerCount + 1; i++)
            {
                players.Add(new HumanPlayer("Player " + i));
            }
            for (int i = 0; i < botCount; i++)
            {
                players.Add(new CpuPlayer("Bot " + i));
            }
            cardGame = new SortePer();
        }

        public GameManager(int botCount)
        {

            for (int i = 0; i < botCount; i++)
            {
                players.Add(new CpuPlayer("Bot " + i));
            }
            cardGame = new SortePer();
        }

        public void Start()
        {
            Shuffle(cardGame.Cards);
            GiveCards();
            cardGame.Play(players);
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
                    player.CheckMatches();

                }
            }
        }
    }
}
