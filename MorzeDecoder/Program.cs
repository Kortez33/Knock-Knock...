using System;
using System.Collections.Generic;
using MorzeDecoder.Class;

namespace MorseCodeMenu
{
    class Program
    {
        /*  -Make a console application using .net 8.0
            -The application should translate from morze code back to normal words (bonus: both code and decode capabilities)
            -Short and Long symbols of the morze code should be configurable (by config file, or in runtime - by asking the user)
            -Application structure should follow basic OOP guidelines. We'd like to see classes, models, functions (and no spaghetti).
            -Upload source code to GitHub. Add repository link to ⁠general channel.
            (written communication at the company usually happens in English)*/
        public static char[] signals = { '.', '-' };
        //DEF MORSE
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
        //SINGAL CHANGE
        public static void ChangeSignals()
        {
            string newShortSignal;
            string newLongSignal;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("***Signal Changing***");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Current Signals:\nShort signal: {0}\nLong signal: {1}", signals[0], signals[1]);
            Console.ResetColor();
            Console.Write("Enter new Short signal: ");
            newShortSignal = Console.ReadLine();
            Console.Write("Enter new Long signal: ");
            newLongSignal = Console.ReadLine();

            if (newShortSignal.Length == 1 && newLongSignal.Length == 1 && newShortSignal != newLongSignal)
            {
                signals[0] = newShortSignal[0];
                signals[1] = newLongSignal[0];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Signals updated successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("***FAILED***\nOnly 1 character is allowed for each signal and they must be different!");
            }
            Console.ResetColor();
            Console.WriteLine("Press [ENTER] to continue...");
            Console.ReadLine();
        }

        // MANUAL
        static void ShowManual()
        {
            Console.Clear();
            Console.WriteLine("Manual:");
            Console.WriteLine("* The default operators are: . and -");
            Console.WriteLine("* You can change the signals ([3] option)");
            Console.WriteLine("* Use space '/' to separate words!");
            Console.WriteLine("* Use space ' ' to separate letters!");
            Console.WriteLine("* Only use the characters from the English alphabet!");
            Console.WriteLine("*Unknown characters are display as ?");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press [ENTER] to continue...");
            Console.ReadLine();
        }

        // ABC Show
        static void ShowDefABC()
        {
            Console.Clear();
            foreach (KeyValuePair<char, string> morse in defaultMorseAlphabet)
            {
                Console.WriteLine($"Letter: {morse.Key} Signal: {morse.Value}");
            }
            Console.WriteLine("Press [ENTER] to continue...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            int choice;
            MorseCode morseDecoder = new MorseCode(signals[0], signals[1]);

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Knock-Knock...\n***Choose an option between 0-5!***");
                Console.ResetColor();
                Console.WriteLine("Manual [0]");
                Console.WriteLine("Decode Morse [1]");
                Console.WriteLine("Encode Morse [2]");
                Console.WriteLine("Morse Signal Change [3]");
                Console.WriteLine("Default Morse ABC [4]");
                Console.WriteLine("Exit [5]");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Please enter a number between 0 and 5.");
                    Console.ResetColor();
                    Console.WriteLine("Press [ENTER] to continue...");
                    Console.ReadLine();
                    continue;
                }
                //MENU
                switch (choice)
                {
                    case 0:
                        ShowManual();
                        break;
                    case 1:
                        Console.Clear();
                        Console.Write("Enter Morse code to decode: ");
                        string decodeInput = Console.ReadLine();
                        string decodedOutput = morseDecoder.Decode(decodeInput);
                       
                        Console.Write($"Decoded Output: ");
                        Console.ForegroundColor= ConsoleColor.Magenta;
                        Console.WriteLine(decodedOutput);
                        Console.ResetColor();
                        Console.WriteLine("Press [ENTER] to continue...");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter text to encode: ");
                        string encodeInput = Console.ReadLine();
                        string encodedOutput = morseDecoder.Encode(encodeInput);
                        Console.Write($"Encoded Output: ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(encodedOutput);
                        Console.ResetColor();
                        Console.WriteLine("Press [ENTER] to continue...");
                        Console.ReadLine();
                        break;
                    case 3:
                        ChangeSignals();
                        morseDecoder = new MorseCode(signals[0], signals[1]);
                        break;
                    case 4:
                        Console.WriteLine("Morse ABC!\n");
                        ShowDefABC();
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not an option!");
                        Console.ResetColor();
                        Console.WriteLine("Press [ENTER] to continue...");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine();
            } while (choice != 5);
        }
    }
}
