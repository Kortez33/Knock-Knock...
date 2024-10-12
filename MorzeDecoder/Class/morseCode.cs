using MorseCodeMenu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MorzeDecoder.Class
{
    internal class MorseCode
    {
        private char shortSignal;
        private char longSignal;
        private Dictionary<char, string> Mcode = new Dictionary<char, string>();
        private Dictionary<string, char> reverseMcode = new Dictionary<string, char>();

        public MorseCode(char ShortSignal, char LongSignal)
        {
            this.shortSignal = ShortSignal;
            this.longSignal = LongSignal;
            this.Mcode = CustomMorse(ShortSignal, LongSignal);
            CreateReverseMorseDictionary();
        }

        private Dictionary<char, string> CustomMorse(char shortSignal, char longSignal)
        {
            Dictionary<char, string> keyValuePairs = new Dictionary<char, string>();
            foreach (KeyValuePair<char, string> kvp in Program.defaultMorseAlphabet)
            {
                string convertingValue = kvp.Value.Replace('.', shortSignal);
                convertingValue = convertingValue.Replace('-', longSignal);
                keyValuePairs.Add(kvp.Key, convertingValue);
            }
            return keyValuePairs;
        }
        private void CreateReverseMorseDictionary()
        {
            foreach (var kvp in Mcode)
            {
                if (!reverseMcode.ContainsKey(kvp.Value))
                {
                    reverseMcode.Add(kvp.Value, kvp.Key);
                }
            }
        }

        public string Decode(string input)
        {
            string output = "";
            string[] morseWords = input.Split('/');

            foreach (string morseWord in morseWords)
            {
                string[] morseLetters = morseWord.Trim().Split(' '); 
                foreach (string morseLetter in morseLetters)
                {
                    if (reverseMcode.ContainsKey(morseLetter))
                    {
                        output += reverseMcode[morseLetter];
                    }
                    else
                    {
                        output += '?'; 
                    }
                }
                output += ' '; 
            }

            return output.Trim(); 
        }

       
        public string Encode(string input)
        {
            string output = "";
            foreach (char c in input.ToUpper())
            {
                if (Mcode.ContainsKey(c))
                {
                    output += Mcode[c] + " ";
                }
                else if (c == ' ')
                {
                    output += "/ ";
                }
                else
                {
                    output += "?";
                }
            }
            return output.Trim();
        }
    }
}
