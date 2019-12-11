using System;
using System.Collections.Generic;
using System.Text;

namespace Joulu1
{
    static public class OpcodeParas
    {
        public static Dictionary<int,int> initOpcodes()
        {
            Dictionary<int, int>  opcodeParas = new Dictionary<int, int>();
            opcodeParas.Add(1, 3);  //1, yhteenlasku, 3 parametria
            opcodeParas.Add(2, 3);  //2, kertolasku, 3 parametria
            opcodeParas.Add(3, 1);  //3, syöte, 1 parametri
            opcodeParas.Add(4, 1);  //4, tuloste, 1 parametri
            opcodeParas.Add(5, 2);  //5, hyppää jos tosi, 2 parametria
            opcodeParas.Add(6, 2);  //6, hyppää jos tosi, 2 parametria
            opcodeParas.Add(7, 3);  //7, vähemmän kuin, 3 parametria
            opcodeParas.Add(8, 3);  //8, yhtä suuri, 3 parametria

            return opcodeParas;
        }
    }
}
