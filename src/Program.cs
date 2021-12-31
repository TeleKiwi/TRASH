using System;
using System.IO;

namespace src
{
    class User
    {
        public static string[] input;

        public static void Main() {
            Console.Title = "TRASH";

            Console.WriteLine("TRASH - Tele's Reborn Again SHell");
            Console.WriteLine("Refer to README.md for info about the avaliable commands.");
            
            while(true) {
                Console.Write(">>> ");
                input = Console.ReadLine().Split(' ');
                Commands.interpret(input);
            }
        }
    }

    class Commands
    {
        static string versionNo = "v0.0.1";

        public static void interpret(string[] input) {
            string keyword = input[0];
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
                case "del":
                case "dst":
                    destroy();
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
            File.Create(User.input[1]);
        }

        static void destroy() {
            Console.Write("Are you sure you want to delete this file/folder? (y/n)");
            string tempInput = Console.ReadLine();
            if(tempInput == "y") {File.Delete(User.input[1]);}
        }

        static void echo() {
           string tempInput = String.Join(" ", User.input);
           tempInput = tempInput.Substring(3); 
           Console.WriteLine(tempInput.Substring(0));
        }

        static void list() {
            string[] contents = File.ReadAllLines(User.input[1]);
            foreach(string line in contents) {
                Console.WriteLine(line);
            }
        }
    }
}
