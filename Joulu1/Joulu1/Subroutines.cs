using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Joulu1
{
    partial class Program
    {
        static int stepGetter(int[,] wiremap, int minx, int miny, int goalx, int goaly, List<string[]> stringdiffsList)     //laskee piuhojen stepit niin, että orgio on -minx, -miny:ssä, tarkastelupiste goalx,goaly:ssä 
        {
            //VARO, EI MITÄÄN VIRHEENTARKISTUSTA!

            int steps = 0;  //montako askelta on otettu?

            foreach (string[] stringdiffs in stringdiffsList)    //katsotaan, miten iso taulukko tarvitaan
            {
                int x = -minx, y = -miny;
                for (int i = 0; i < stringdiffs.Length; i++)       //käydään kaikki siirtokomennot läpi
                {
                    switch (stringdiffs[i].Substring(0, 1))
                    {
                        case "R":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                x++;
                                steps++;
                                if (x == goalx && y == goaly) break;
                            }
                            break;
                        case "L":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                x--;
                                steps++;
                                if (x == goalx && y == goaly) break;
                            }
                            break;
                        case "U":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                y++;
                                steps++;
                                if (x == goalx && y == goaly) break;
                            }
                            break;
                        case "D":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                y--;
                                steps++;
                                if (x == goalx && y == goaly) break;
                            }
                            break;
                        default:
                            break;
                    }
                    if (x == goalx && y == goaly) break;
                }

            }

            return steps;
        }
        static void intcodeOutput(int outputvalue)
        {
            Console.WriteLine(outputvalue);

            return;
        }
        static int getInput()                       //kokonaislukusyöte konsolilta. EI MITÄÄN VIRHEENTARKASTUSTA!
        {
            int input;

            Console.WriteLine("Annapa ID-numero kokonaislukuna");
            input = Int32.Parse(Console.ReadLine());

            return input;
        }

        

        static int[] getParas(int[] intops, int commandpointer)
        {
            Dictionary<int,int> opcodeParas = OpcodeParas.initOpcodes();
            int command = intops[commandpointer] % 100;
            int paranumber = opcodeParas[command];
            int[] paras = new int[paranumber];
            int mode;                                       //tarkastellun parametrin moodi

            int rawModes = intops[commandpointer] / 100;

            for (int i=0;i<paranumber;i++)                  //iteroidaan moodit taulukkoon
            {
                mode = rawModes % 10;
                switch (mode)
                {
                    case 0:                                     //paikkatila
                        paras[i] = intops[intops[commandpointer + 1 + i]];
                        break;
                    case 1:                                     //välitön tila
                        paras[i] = intops[commandpointer + 1 + i];
                        break;
                    default:                                    //oletuksena käytetään samaa käyttäytymistä kuin paikkatilassa
                        paras[i] = intops[intops[commandpointer + 1 + i]];
                        break;
                }
                rawModes /= 10;                             //siirrytään seuraavaan lukuun
            }

            return paras;
        }
        static int runComputer(int[] intops)
        {
            int commandpointer = 0;
            Dictionary<int, int> opcodeParas = OpcodeParas.initOpcodes();
            int command = intops[commandpointer] % 100;
            bool jumpflag = false;      //lippu joka kertoo, onko komento-osoitinta siirretty

            while (command != 99)
            {
                int[] paras = getParas(intops, commandpointer);
                switch (command)
                {
                    case 1:                                                         //yhteenlasku
                        intops[intops[commandpointer + 3]] = paras[0] + paras[1];
                        break;
                    case 2:                                                         //kertolasku
                        intops[intops[commandpointer + 3]] = paras[0] * paras[1];
                        break;
                    case 3:                                                         //syötteen vastaanotto
                        intops[intops[commandpointer + 1]] = getInput();
                        break;
                    case 4:                                                         //tulosteen anto
                        intcodeOutput(intops[intops[commandpointer + 1]]);
                        break;
                    case 5:                                                         //hyppää jos tosi
                        if (paras[0] != 0)
                        {
                            commandpointer = paras[1];
                            jumpflag = true;
                        }
                        break;
                    case 6:                                                         //hyppää jos epätosi
                        if (paras[0] == 0)
                        {
                            commandpointer = paras[1];
                            jumpflag = true;
                        }
                        break;
                    case 7:                                                         //pienempi kuin
                        if (paras[0] < paras[1]) intops[intops[commandpointer + 3]] = 1;
                        else intops[intops[commandpointer + 3]] = 0;
                        break;
                    case 8:                                                         //yhtä suuri
                        if (paras[0] == paras[1]) intops[intops[commandpointer + 3]] = 1;
                        else intops[intops[commandpointer + 3]] = 0;
                        break;
                    default:                                                        //virheilmo, jos tulee vastaan tuntematon komentokoodi
                        Console.WriteLine("Määrittelemättömiä käskyjä komennoissa!");
                        return -1;
                        break;
                }
                if (!jumpflag) commandpointer += opcodeParas[command] + 1;          //lisätään komento-osoitinta 1 + ko. komennon parametrien määrä, jos jumpflag on epätosi eli osoitinta ei ole siirretty aiemmin
                jumpflag = false;
                command = intops[commandpointer] % 100;                              //luetaan uusi komento
            }

            return intops[0];
        }

        static int[] initMemory(string inputfile)
        {
            string inputdata = File.ReadAllText(inputfile);
            string[] intopStrings = inputdata.Split(',');
            List<int> intopsList = new List<int>();
            

            foreach (string intopString in intopStrings)
            {
                intopsList.Add(Int32.Parse(intopString));
            }
            return intopsList.ToArray();
        }
    }
}
