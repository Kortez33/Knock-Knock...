using System;
using System.Collections.Generic;

namespace MorseCodeMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Knock-Knock...\n***Choose an option between 0-3!***");
                Console.ResetColor();
                Console.WriteLine("Manual [0]");
                Console.WriteLine("Decode morse [1]");
                Console.WriteLine("Encode morse [2]");
                Console.WriteLine("Morse signal change [3]");
                Console.WriteLine("Morse abc [4]");
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
                        Console.WriteLine("encode");
                        break;
                    case 3:
                        Console.WriteLine("Morse signal change");
                        break;
                    case 4:
                        Console.WriteLine("Morse ABC!");
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
        //RULES
        static void showManual()
        {
            Console.Clear();
            Console.WriteLine("Rules:");
            Console.WriteLine("*The default operators are: . -");
            Console.WriteLine("*You can change the signals ([3] option)");
            Console.WriteLine("* _ (space) must be placed between letters!");
            Console.WriteLine("* / must be placed between the words");
            Console.WriteLine("Press [ENTER] to continue...");
            Console.ReadLine();
        }
      
    }
}