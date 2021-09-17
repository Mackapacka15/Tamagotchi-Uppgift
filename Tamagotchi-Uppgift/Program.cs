using System.Net;
using System.Collections.Generic;
using System;

namespace Tamagotchi_Uppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            string svar = "";
            bool startNew = false;
            bool playing = true;
            List<Tamagotchi> players = new List<Tamagotchi>();
            players = New(players);

            while (playing)
            {
                for (int i = players.Count - 1; i >= 0 && startNew == true; i--)
                {

                    if (players[i].GetAlive())
                    {
                        players[i].PrintStats();
                        Console.WriteLine("What do you want to do width " + players[i].name + "?");
                        Console.WriteLine("1) Teach a new word ");
                        Console.WriteLine("2) Greet it");
                        Console.WriteLine("3) Feed it");
                        Console.WriteLine("4) Nothing ");
                        Console.WriteLine("5) Start another Tamagotchi");
                        svar = Console.ReadLine();

                        if (svar == "1" || svar == "Teach a new word")
                        {
                            Console.WriteLine("What word do you want to teach " + players[i].name);
                            string word = Console.ReadLine();
                            players[i].Teach(word);
                        }
                        else if (svar == "2" || svar == "Greet it")
                        {
                            players[i].Hi();
                        }
                        else if (svar == "3" || svar == "Feed it")
                        {
                            players[i].Feed();
                        }
                        else if (svar == "4" || svar == "Nothing")
                        {
                        }
                        else if (svar == "5" || svar == "Start another Tamagotchi")
                        {
                            startNew = true;
                            players[i].Tick();
                        }

                        players[i].Tick();
                    }
                    else
                    {
                        Console.WriteLine(players[i].name + " just died");
                        Console.WriteLine("Do you want to start another tamagotchi?");
                        svar = Console.ReadLine();
                        if (svar == "Yes")
                        {
                            startNew = true;
                        }

                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                players.RemoveAll(t => !t.GetAlive());
                if (players.Count == 0 && !startNew)
                {
                    Console.WriteLine("All tamagotchis are dead do you want to stop playing?");
                    svar = Console.ReadLine().ToLower();
                    if (svar == "yes")
                    {
                        playing = false;
                    }
                    else
                    {
                        Console.WriteLine("Do you want to start another tamagotchi?");
                        svar = Console.ReadLine().ToLower();
                        if (svar == "yes")
                        {
                            startNew = true;
                        }
                    }
                }

                if (startNew)
                {
                    players = New(players);
                    startNew = false;
                }
            }
        }

        static List<Tamagotchi> New(List<Tamagotchi> tamagotchis)
        {
            Tamagotchi tamagotchi = new Tamagotchi();
            Console.WriteLine("What is your new tamagotchis name?");
            tamagotchi.name = Console.ReadLine();
            tamagotchis.Add(tamagotchi);
            return tamagotchis;
        }



    }
}
