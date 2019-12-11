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

            return opcodeParas;
        }
    }
}
