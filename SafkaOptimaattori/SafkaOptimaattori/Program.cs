using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafkaOptimaattori
{
    static class Constants
    {
        public const int DEFAULTRECIPES = 10;   //tulostettavien reseptien oletusmäärä
    }
    class Program
    {
        static void Main(string[] args)
        {
            UI();                                     //kutsutaan käyttöliittymä
            GenerateRecipeList(Constants.DEFAULTRECIPES);       //generoidaan reseptit, listataan DEFAULTRECIPES (=10) parasta
        }
        static void UI()   //käyttöliittymä, tässä vaiheessa hyvin minimaalinen
        {
            Console.WriteLine("Arvotaan päivän reseptit.");     //pientä viestintää käyttäjän kanssa
            Console.WriteLine("Paina Enter!");
            Console.ReadLine();
            return;
        }
        static void GenerateRecipeList(int maxrecipes)          //reseptilistan generointi, maxrecipes reseptiä listataan
        {
            //tiukkaa SQL-koodia tänne
			
			//määritellään hakuehdot
				//katsotaan Ruokavarasto-tietokannasta mikä menee ensimmäisenä vanhaksi
				//haetaan resepteistä ko. ruoka-ainetta käyttävät
				//jos tämä optio on valittu, heitetään pois reseptit joihin jäljellä oleva aine ei riitä. Soft-optiolla ne jätetään jäljelle, mutta rullataan listan loppuun
				//järjestetetään sen mukaan, montaako muuta ruokalajia tarvitaan (tai hinta, tie breakerinä koska viimeksi on tehty)
				//katsotaan, onko saatu *maxrecipes* reseptiä
				//jos on => eteenpäin ELSE etsitään toisena vanhaksi menevä ja iteroidaan, kunnes on saatu *maxrecipes* reseptiä tai ruuat loppuvat
				
            return;
        }
    }
}
