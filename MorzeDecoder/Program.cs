using System;
using System.Collections.Generic;

namespace MorseCodeMenu
{
    class Program
    {
        public static char[] signals = { '.', '-' };
        public static void changeSignals()
        {
            
            string newShortSignal;
            string newLongSignal;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("***Signal changing***");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Current Signals:\nShort signal: {0}\nLong signal: {1}", signals[0], signals[1]);
            Console.ResetColor();
            Console.Write("Short signal: ");
            newShortSignal = Console.ReadLine();
            Console.Write("Long signal: ");
            newLongSignal = Console.ReadLine();
            if (newLongSignal != newShortSignal && newShortSignal.Length == 1 && newLongSignal.Length == 1)
            {
   
                signals[0] = Convert.ToChar(newShortSignal);
                signals[1] = Convert.ToChar(newLongSignal);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("***FAILED***\nOnly 1 letter / signal\n\tand\nCannot be the same!");
                Console.ResetColor();
                Console.WriteLine("Press [ENTER] to continue...");
                Console.ReadLine();
            }
        }
        //MANUAL
        static void showManual()
        {
            Console.Clear();
            Console.WriteLine("Manual:");
            Console.WriteLine("*The default operators are: . and -");
            Console.WriteLine("*You can change the signals ([3] option)");
            Console.WriteLine("* _ (space) must be placed between letters!");
            Console.WriteLine("* / must be placed between the words");
            Console.WriteLine("*Only use the letters of the English ABC!");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press [ENTER] to continue...");
            Console.ReadLine();
        }
        //ABC Show
        static void showDefABC()
        {
            Console.Clear();
            foreach (KeyValuePair<char, string> morse in defaultMorseAlphabet)
            {
                Console.WriteLine($"Letter: {morse.Key} Signal: {morse.Value}");
            }
            Console.WriteLine("Press [ENTER] to continue...");
            Console.ReadLine();
        }

        public static Dictionary<char, string> defaultMorseAlphabet = new Dictionary<char, string>()
            {
                {'A', ".-"},   {'B', "-..."}, {'C', "-.-."}, {'D', "-.."},  {'E', "."},
                {'F', "..-."}, {'G', "--."},  {'H', "...."}, {'I', ".."},   {'J', ".---"},
                {'K', "-.-"},  {'L', ".-.."}, {'M', "--"},   {'N', "-."},   {'O', "---"},
                {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."},  {'S', "..."},  {'T', "-"},
                {'U', "..-"},  {'V', "...-"}, {'W', ".--"},  {'X', "-..-"}, {'Y', "-.--"},
                {'Z', "--.."},
                {'0', "-----"},{'1', ".----"},{'2', "..---"},{'3', "...--"},{'4', "....-"},
                {'5', "....."},{'6', "-...."},{'7', "--..."},{'8', "---.."},{'9', "----."},
                {' ', "/"},
                {'.', ".-.-.-"}, {',', "--..--"}, {'?', "..--.."}, {'!', "-.-.--"}, {'/', "-..-."},
                {'@', ".--.-."}, {'&', ".-..."}, {':', "---..."}, {';', "-.-.-."}, {'=', "-...-"},
                {'+', ".-.-."}, {'-', "-....-"}, {'_', "..--.-"}, {'$', "...-..-"}, {'(', "-.--."},
                {')', "-.--.-"}, {'"', ".-..-."}, {'\'', ".----."}, {'%', ".--.-."}
            };
        
        static void Main(string[] args)
        {
            int choice;
            
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Knock-Knock...\n***Choose an option between 0-5!***");
                Console.ResetColor();
                Console.WriteLine("Manual [0]");
                Console.WriteLine("Decode morse [1]");
                Console.WriteLine("Encode morse [2]");
                Console.WriteLine("Morse signal change [3]");
                Console.WriteLine("Default morse abc [4]");
                Console.WriteLine("Exit [5]");
                
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        showManual();
                        break;
                    case 1:
                        Console.WriteLine("Decode");
                        break;
                    case 2:
                        Console.WriteLine("Encode");
                        break;
                    case 3:
                        changeSignals();  
                        break;
                    case 4:
                        Console.WriteLine("Morse ABC!\n");
                        showDefABC();
                        break;
                    case 5:
                        Console.WriteLine("Good bye!");
                        break;
                    default:
                        Console.WriteLine("Not an option!");
                        break;
                }

                Console.WriteLine();
            } while (choice != 5);
        }
    }
}