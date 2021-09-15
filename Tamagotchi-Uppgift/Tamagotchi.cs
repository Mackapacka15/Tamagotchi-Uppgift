using System;
using System.Collections.Generic;

namespace Tamagotchi_Uppgift
{
    public class Tamagotchi
    {
        int hunger = 10;
        int boredom = 10;
        List<string> words = new List<string>();
        bool isAlive = true;
        Random generator = new Random();
        public string name;

        public void Feed()
        {
            hunger += generator.Next(0, 3);
        }
        public void Hi()
        {
            if (words.Count != 0)
            {
                Console.WriteLine(words[generator.Next(-1, words.Count)]);
            }
            else
            {
                Console.WriteLine(name + " doesn't know any words");
            }
            ReduceBoredom();
        }
        public void Teach(string w)
        {
            words.Add(w);
            ReduceBoredom();
        }
        public void Tick()
        {
            hunger--;
            boredom--;
            if (hunger <= 0 || boredom <= 0)
            {
                isAlive = false;
            }
        }
        public void PrintStats()
        {
            Console.WriteLine(name + ":");
            Console.WriteLine("Food = " + hunger);
            Console.WriteLine("Boredom = " + boredom);
            Console.WriteLine();
            if (isAlive)
            {
                Console.WriteLine("Tamagotchi is alive");
            }
            else
            {
                Console.WriteLine("Tamagotchi is dead. Sorry");
            }
        }
        public bool GetAlive()
        {
            return isAlive;
        }
        private void ReduceBoredom()
        {
            boredom++;
        }


    }
}