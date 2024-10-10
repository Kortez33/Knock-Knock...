using MorseCodeMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorzeDecoder.Class
{
    internal class morseCode
    {
        
        private char shortSignal;
        private char  longSignal;
        private Dictionary<char, string> Mcode = new Dictionary<char, string>();

        Dictionary<char, string> customMorse(char shortsignal,char longsignal)
        { 
            Dictionary<char,string> keyValuePairs = new Dictionary<char,string>();
            foreach (KeyValuePair<char, string> kvp in Program.defaultMorseAlphabet)
            {
                string convertingValue = kvp.Value.Replace('.',shortsignal);
                convertingValue = kvp.Value.Replace('-', longsignal);
                keyValuePairs.Add(kvp.Key, convertingValue);
            }
            return keyValuePairs;
        }

        public morseCode (char ShortSignal, char LongSignal)
        {
            
            this.shortSignal = ShortSignal;
            this.longSignal = LongSignal;
            this.Mcode = customMorse(ShortSignal,LongSignal);

        }
    }
}
