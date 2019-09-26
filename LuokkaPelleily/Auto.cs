using System;

namespace LuokkaPelleily
{
    class Auto
    {
        //kentät
        private int currentSpeed;

        //ominaisuuksia

        public string Color { get; set; }
        public int EnginePower { get; set; }
        public int TopSpeed { get; set; }
        public int Acceleration { get; set; }
        public int DoorNumber { get; set; }
        public bool EngineOn { get; set; }
        public string CarName { get; set; }
        private string carName;

        //metodeja
        public int CurrentSpeed
        {
            get
            {
                return currentSpeed;
            }
            set
            {
                currentSpeed = value;
                if (currentSpeed > TopSpeed)
                {
                    currentSpeed = TopSpeed;
                }
                if (currentSpeed < 0)
                {
                    currentSpeed = 0;
                }
            }
        }
        public void TurnOn()
        {
            EngineOn = true;
        }
        public void TurnOff()
        {
            EngineOn = false;
        }
        public void Accelerate()
        {
            if (!EngineOn) return;
            CurrentSpeed += Acceleration;
        }
        public void Decelerate()
        {
            CurrentSpeed -= Acceleration;
            if (CurrentSpeed < 0) CurrentSpeed = 0;
        }

        public int GetSpeed()
        {
            return CurrentSpeed;
        }

                public Auto()
        {



            Console.WriteLine("Autolla ajetaan!");
        }
    }
}
