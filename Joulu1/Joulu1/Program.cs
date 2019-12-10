using System;
using System.IO;
using System.Collections.Generic;

namespace Joulu1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string dayString;
            
            Console.WriteLine("Valitse päivä");
            dayString = Console.ReadLine();

            switch (dayString)
            {
                case "1":
                    Day1();
                    break;
                case "2":
                    Day2(@"data\Joulu2.txt");
                    break;
                case "3":
                    Day3();
                    break;
                case "4":
                    Day4();
                    break;
                case "5":
                    Day2(@"data\Joulu5.txt");
                    break;
                default:
                    Console.WriteLine("Anna kunnon päivä!");
                    break;
            }
            return;
        }

        static void Day4()                                  //nyt kakkostehtävän lisäehdolla, lisäehdoton versio pitää kaivaa gitistä
        {
            int minpass = 278384, maxpass = 824795;         //koodattu olettamalla, että kaikki tutkittavat luvut ovat kuusinumeroisia. Vaatii lisäyksiä, jos tähän ei voi luottaa.
            int[] passdigits = new int[6];
            bool okflag = false;                            //onko salasana kelvollinen
            int acceptablePws = 0;                          //hyväksyttävien salasanojen määrä
            int repnum = 0;                                //luku, jonka toistuvuutta tarkastellaan

            for (int password = minpass; password<=maxpass; password++)
            {
                okflag = false;
                int tempPass = password;
                for (int i=0;i<6;i++)                   //salakala taulukkoon, jossa luvut ovat erillisinä. Merkitsevin luku tulee suurimmalle indeksille.
                {
                    
                    passdigits[i] = tempPass % 10;
                    tempPass /= 10;
                }

                //sitten vertaillaan
                repnum = 0;

                for (int i = 5; i > 0; i--)
                {
                    if (passdigits[i] == passdigits[i - 1] ) repnum++;
                    else
                    {
                        if (repnum == 1) okflag = true;
                        repnum = 0;
                    }
                }
                if (repnum == 1) okflag = true;
                for (int i = 5; i > 0; i--)
                {
                    if (passdigits[i] > passdigits[i - 1])
                    {
                        okflag = false;
                        break;
                    }
                }
            if (okflag) acceptablePws++;
            }
            Console.WriteLine(acceptablePws);
        }

        static void Day3()          //kolmospäivän ongelma, risteävät johdot
        {
            string[] inputdatas = File.ReadAllLines(@"data\Joulu3.txt");     //luetaan data muistiin
            List<string[]> stringdiffsList = new List<string[]>();
            foreach(string inputdata in inputdatas)
            {
                string[] stringdiffs = inputdata.Split(',');
                stringdiffsList.Add(stringdiffs);
            }
            //nyt listassa pitäisi olla kaksi oliota, joissa on taulukossa L21-tyylisiä komentoja
            //muodostetaan seuraavaksi kartta tilanteesta kokonaislukutaulukkona

            int minx=0, miny=0, maxx=0, maxy=0;         //tarvittavat maksimiarvot

            foreach(string[] stringdiffs in stringdiffsList)    //katsotaan, miten iso taulukko tarvitaan
            {
                int x=0, y=0;                       //koordinaatit, aluksi 0,0
                for (int i = 0; i<stringdiffs.Length;i++)       //käydään kaikki siirtokomennot läpi
                {
                    switch(stringdiffs[i].Substring(0, 1))
                    {
                        case "R":
                            x += Int32.Parse(stringdiffs[i].Substring(1));
                            if (x > maxx) maxx = x;
                            break;
                        case "L":
                            x -= Int32.Parse(stringdiffs[i].Substring(1));
                            if (x < minx) minx = x;
                            break;
                        case "U":
                            y += Int32.Parse(stringdiffs[i].Substring(1));
                            if (y > maxy) maxy = y;
                            break;
                        case "D":
                            y -= Int32.Parse(stringdiffs[i].Substring(1));
                            if (y < miny) miny = y;
                            break;
                        default:
                            break;
                    }
                }
            }
            //taulukon koko on nyt tiedossa (maxx-minx+1, maxy-miny+1). Perustetaan se.
            int[,] wiremap = new int[(maxx - minx + 1),(maxy - miny + 1)];

            //kirjoitetaan taulukkoon, missä piuhat menevät. Origo jää nyt nollaksi, koska se on muutenkin tarkastelun ulkopuolella
            int wireindex = 1;
            foreach (string[] stringdiffs in stringdiffsList)       //käydään kaikki eli siis kumpikin stringdiffs läpi
            {
                int x = -minx, y = -miny;                           //lähdetään liikkeelle origosta, joka on koordinaateissa -minx, -miny offsetin vuoksi
                for (int i = 0; i < stringdiffs.Length; i++)       //käydään kaikki siirtokomennot läpi
                {
                    switch (stringdiffs[i].Substring(0, 1))
                    {
                        case "R":
                            for (int j=0; j<Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                x++;
                                if (wiremap[x, y] < wireindex) wiremap[x, y] += wireindex;
                            }
                            break;
                        case "L":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                x--;
                                if (wiremap[x, y] < wireindex) wiremap[x, y] += wireindex;
                            }
                            break;
                        case "U":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                y++;
                                if (wiremap[x, y] < wireindex) wiremap[x, y] += wireindex;
                            }
                            break;
                        case "D":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                y--;
                                if (wiremap[x, y] < wireindex) wiremap[x, y] += wireindex;
                            }
                            break;
                        default:
                            break;
                    }
                }
                wireindex++;
            }

            //etsitään lähin risteyskohta

            //tehtävän kakkosvaihe
            Console.WriteLine("Suoritetaanko kakkostehtävä (k/e)?");

            int steps=0, minsteps=-1;

            if (Console.ReadKey().Key == ConsoleKey.K)
            {
                for (int j = 0; j < maxy - miny; j++)
                {
                    for (int i = 0; i < maxx - minx; i++)
                    {
                        if (wiremap[i, j] == 3)
                        {
                            steps = stepGetter(wiremap, minx, miny, i, j, stringdiffsList);
                            if (minsteps == -1) minsteps = steps;
                            else if (steps < minsteps) minsteps = steps;                    //verrataan, ovatko askeleet risteyskohtaan lyhimmät mahdolliset
                            Console.WriteLine("Hei hulinaa! " + i + "," + j + "," + minsteps);
                        }
                    }
                }
                Console.WriteLine(minsteps);
                Console.ReadLine();
                return;
            }

            int range = 0;

            for (range = 1; range < maxx + maxy - minx - miny; range++)
            {
                int x = -minx, y = -miny;
                y -= range;
                for (int j = 0; j<range; j++)
                {
                    x--;
                    y++;
                    if (x>=0 && x <= maxx-minx && y >= 0 && y <= maxy - miny)
                        if (wiremap[x,y] == 3)
                        {
                            Console.WriteLine(range);
                            Console.ReadLine();
                            return;
                        }
                }
                for (int j = 0; j < range; j++)
                {
                    x++;
                    y++;
                    if (x >= 0 && x <= maxx - minx && y >= 0 && y <= maxy - miny)
                        if (wiremap[x, y] == 3)
                        {
                            Console.WriteLine(range);
                            Console.ReadLine();
                            return;
                        }
                }
                for (int j = 0; j < range; j++)
                {
                    x++;
                    y--;
                    if (x >= 0 && x <= maxx - minx && y >= 0 && y <= maxy - miny)
                        if (wiremap[x, y] == 3)
                        {
                            Console.WriteLine(range);
                            Console.ReadLine();
                            return;
                        }
                }
                for (int j = 0; j < range; j++)
                {
                    x--;
                    y--;
                    if (x >= 0 && x <= maxx - minx && y >= 0 && y <= maxy - miny)
                        if (wiremap[x, y] == 3)
                        {
                            Console.WriteLine(range);
                            Console.ReadLine();
                            return;
                        }
                }
            }
            Console.WriteLine("Joku bugi!");
            Console.ReadLine();


        }

        static void Day2(string inputfile)                      //intcode-ohjelma
        {
            int noun = 0, verb = 0;
            int[] intops = initMemory(inputfile);        //pitää tehdä tässä, että saadaan taulukolle koko
            int result = 0;
            bool stopflag = false;              //lippu, joka kertoo onko oikeat verbi ja substantiivi löydetty

            //kakkostehtävän implementaatio
            Console.WriteLine("Ajetaanko kakkostehtävä? Vastaa ”k” jos ajetaan.");
            if (Console.ReadKey().Key == ConsoleKey.K)
            {
                for (noun = 0; noun < 100; noun++)
                {
                    for (verb = 0; verb < 100; verb++)
                    {
                        intops = initMemory(inputfile);
                        intops[1] = noun;                   //noun ja verb muistipaikkoihin 1 ja 2
                        intops[2] = verb;
                        //seuraavaksi siirrä koneen toimintalogiikka omaan aliohjelmaansa
                        result = runComputer(intops);
                        if (result == 19690720) stopflag = true;
                        if (stopflag) break;
                    }
                    if (stopflag) break;
                }
                int answer = 100 * noun + verb;
                Console.WriteLine("Löytyi noun " + noun + " ja verb " + verb + ", vastaus siis " + answer);
                return;
            }
            else
            {
                result = runComputer(intops);
                Console.WriteLine(intops[0]);
            }
        }

            static void Day1()
        {
            string[] lines = File.ReadAllLines(@"data\Joulu1.txt");
            int totalfuel = 0;

            foreach (string line in lines)
            {
                int mass = Int32.Parse(line);
                int addfuel = mass;
                int modfuel = 0;
                do
                {
                    addfuel = addfuel / 3;
                    addfuel -= 2;
                    if (addfuel < 0) addfuel = 0;
                    modfuel += addfuel;
                } while (addfuel > 0);
                totalfuel += modfuel;
            }
            Console.WriteLine(totalfuel);
        }
    }
}
