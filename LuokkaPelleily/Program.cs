using System;
using System.Collections.Generic;

namespace LuokkaPelleily
{
    class Program
    {
        static Auto myCar = new Auto();
        static Auto neighbourCar = new Auto();
        static KuormaAuto myTruck = new KuormaAuto();
        static List<Auto> autoLista = new List<Auto>();
        static void Main(string[] args)
        {
            CarInit();

            string command;

            while (true)
            {
                foreach (Auto thisAuto in autoLista)
                {
                    while (true)
                    {
                        Console.WriteLine("Autonasi on " + thisAuto.CarName + ".");
                        Console.WriteLine("Auton vauhti on " + thisAuto.CurrentSpeed + " km/h.");
                        Console.Write("Mitäs tehdään: ");
                        command = Console.ReadLine();


                        /*if (command == "speed")
                        {
                            Console.WriteLine("Auton vauhti on " + myCar.GetSpeed() + "km/h.");
                        }
                        else*/
                        if (command == "+")
                        {
                            thisAuto.Accelerate();
                        }
                        else if (command == "-")
                        {
                            thisAuto.Decelerate();
                        }
                        else if (command == "on")
                        {
                            thisAuto.TurnOn();
                        }
                        else if (command == "off")
                        {
                            thisAuto.TurnOff();
                        }
                        else if (command == "exit")
                        {
                            return;
                        }
                        else if (command == "change") break;
                    }
                }
            }
        }
        static void CarInit()
        {
            myCar.EngineOn = true;
            myCar.Color = "vihreä";
            myCar.TopSpeed = 220;
            myCar.Acceleration = 10;
            myCar.CurrentSpeed = 0;
            myCar.TurnOn();
            myCar.CarName = "mun auto";
            autoLista.Add(myCar);

            neighbourCar.EngineOn = false;
            neighbourCar.Color = "harmaa";
            neighbourCar.TopSpeed = 170;
            neighbourCar.Acceleration = 5;
            neighbourCar.CurrentSpeed = 0;
            neighbourCar.TurnOn();
            neighbourCar.CarName = "naapurin auto";
            autoLista.Add(neighbourCar);

            myTruck.EngineOn = false;
            myTruck.Color = "harmaa";
            myTruck.TopSpeed = 170;
            myTruck.Acceleration = 5;
            myTruck.CurrentSpeed = 0;
            myTruck.TurnOn();
            myTruck.Mass = 10000;
            myTruck.CarName = "mun rekka";
            autoLista.Add(myTruck);
        }
    }
}
