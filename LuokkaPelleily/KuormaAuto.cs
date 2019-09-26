using System;

namespace LuokkaPelleily
{
    class KuormaAuto : Auto
    {
        //muuttujat
        private int mass;
        public int Mass
        {
            get { return mass; }
            set { mass = value;
                if (mass < 0) mass = 0;
             }
        }
        
        //ominaisuudet

        
    }
}