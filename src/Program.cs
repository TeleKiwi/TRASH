using System;
using System.IO;

namespace src
{
    class User
    {
        public static string input;

        public static void Main() {
            Console.Title = "TRASH";

            Console.WriteLine("TRASH - Tele's Reborn Again SHell");
            Console.WriteLine("Refer to README.md for info about the avaliable commands.");
            
            while(true) {
                Console.Write(">>> ");
                input = Console.ReadLine();
                Commands.interpret(input);
            }
        }
    }

    class Commands
    {
        static string versionNo = "v0.0.1";

        public static void interpret(string input) {
            string keyword = input.Split(' ')[0];
            switch(keyword.ToLower()) {
                case "clr":
                    Console.Clear();
                    break;
                case "ver":
                    version();
                    break;
                case "tch":
                    touch();
                    break;
                case "ech":
                    echo();
                    break;
                case "lst":
                    list();
                    break;
                default:
                    Console.WriteLine("Unrecognized keyword.");
                    break;
            }
        }

        static void version() {
            Console.WriteLine($"TRASH {versionNo}");
        }

        static void touch() {
            File.Create(hlp.stringbetweenchr(User.input, '"', '"'));
        }

        static void echo() {
           Console.WriteLine(User.input.Substring(3).Substring(1));
        }

        static void list() {
            string dir = hlp.stringbetweenchr(User.input, '"', '"');
            string[] contents = File.ReadAllLines(dir);
            foreach(string line in contents) {
                Console.WriteLine(line);
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }

    class hlp
    {
        public static string stringbetweenchr(string input, char charFrom, char charTo) {
            int posFrom = input.IndexOf(charFrom);
            if (posFrom != -1) {
                int posTo = input.IndexOf(charTo, posFrom + 1);
                if (posTo != -1) {
                    return input.Substring(posFrom + 1, posTo - posFrom - 1);
                }
            }

            return string.Empty;
        }
    }
}
