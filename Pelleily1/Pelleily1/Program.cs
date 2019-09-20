using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelleily1
{
    class Program
    {
        static void Main(string[] args)
        {
            President president = new President();
            president.Greet();
            Mugabe mugabe = new Mugabe();
            mugabe.Greet();
            

            /*
            string hepunnimi, syote;
            int a=0, b=0;
            bool inputokflag = false;

            Console.WriteLine("Annapa nimesi!");
            hepunnimi = Console.ReadLine();
            Console.WriteLine("Moi " + hepunnimi);

            Console.WriteLine();
            Console.WriteLine("Anna kaksi lukua");
          
            while (inputokflag == false)
            {
                try
                {
                    syote = Console.ReadLine();
                    a = Int32.Parse(syote);
                    inputokflag = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Anna numero!");
                }
            }

            inputokflag = false;

            while (inputokflag == false)        //Antaako käyttäjä numeron?
            {
                try
                {
                    syote = Console.ReadLine();
                    b = Int32.Parse(syote);
                    inputokflag = true;         //syöte ok
                }
                catch (FormatException)
                {
                    Console.WriteLine("Anna numero!");  //Kehote antaa järkevää syötettä
                    
                }
            }
            int c = a + b;
            Console.WriteLine(a + " + " + b + " = " + c) ;


            State state;                                //leikitään erillisillä luokilla
            state = new State("Zimbabwe", "Zimbabwen", "Harare");
            Console.WriteLine(state.TellCapital());

            state = new State("Suomi");
            Console.WriteLine(state.TellCapital());

            Console.ReadLine();
            */
        }
    }

    class State
    {
        private string capital, name, genname;

        
        public State(string name)
        {
            this.name = name;
            genname = name + "n";
            capital = "olematon";
        }
        public State(string name, string genname, string capital) : this(name)
        {
            this.name = name;
            this.genname = genname;
        }
        /*public State(string genname)
        {
            this.genname = genname;
        }*/
        public string TellCapital()
        {
            return Genname + " pääkaupunki on " + Capital + "." ;
        }
        public string Genname
        {
            get { return genname;  }
            set { genname = value; }
        }
        public string Capital
        {
            get { return capital; }
            set { capital = value; }
        }

        ~State()
        {
            Console.WriteLine("Imhotep Maailmojentuhoaja saapuu!");
        }
    }
    public class President
    {
        public virtual void Greet()
        {
            Console.WriteLine("Hei, olen joku presidentti.");
        }
    }

    public class Mugabe : President
    {
        public override void Greet()
        {
            base.Greet();
            Console.WriteLine("Hei, olen Robert Mugabe!");
        }
    }
}
