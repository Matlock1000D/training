using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakkarainen
{
    class Program
    {
        static void Main(string[] args)
        {
            int games = 0, maxgames = 100000;
            int wins = 0;
            int losses = 0;
            int players = 2
                ;
            bool nowinflag = true;
            int cat = 0;
            int j = 0;      //montako korttia on otettu
            int vuoro = 0;  //kenen vuoro on
            int wheel = 1;
            Random rnd = new Random();
            if (args.Length > 0) players = Int32.Parse(args[0]);
            int[] positions = new int[players];
            for (int i = 0; i < players; i++)
            {
                positions[i] = 0;
            }
            int[] korttityypit = { 0, 1, 2, 3, 4, 6, 8, 9, 10, 12 };
            List<Card> deck = new List<Card>();
            for (int i = 0; i < 10; i++)
            {
                Card card = new Card(i);
                deck.Add(card);
            }

            while (games < maxgames)
            {
                nowinflag = true;
                cat = 0;
                for (int i = 0; i < players; i++)
                {
                    positions[i] = 0;
                }
                j = 0;

                //alustetaan korttipakka
                Shuffle(deck);

                //pääsilmukka
                while (nowinflag)
                {
                    wheel = rnd.Next(1, 100);
                    if (wheel < 32) positions[vuoro] += 1;
                    else if (wheel < 49) cat++;
                    else if (wheel < 54) positions[vuoro] += 3;
                    else if (wheel < 77) positions[vuoro] += 2;
                    else
                    {
                        positions[vuoro] = deck[j % 10].Whereto;
                        j++;
                    }
                    //onko voitettu tai hävitty?
                    if (positions[vuoro] >= 14)
                    {
                        wins++;
                        nowinflag = false;
                    }
                    if (cat >= 10)
                    {
                        nowinflag = false;
                        losses++;
                    }

                    vuoro++;
                    vuoro = vuoro % players;
                }
                games++;
            }
            double voittoprosentti = wins / maxgames;
            Console.WriteLine(wins + "," + losses);
            Console.ReadLine();
        }

        static void Shuffle(List<Card> deck)
        {
            Random r = new Random();
            deck.Sort((a, b) => r.Next(0, 2) == 0 ? -1 : 1);
        }
    }
    
    class Card
    {
        private int whereto;
        public int Whereto => whereto;

        public Card(int setwhereto)
        {
            this.whereto = setwhereto;
        }
    }
}
