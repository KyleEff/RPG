using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public delegate void Target();

    public abstract class Fighter : IAbilities
    {
        // Attributes
        const double CRIT = 1.5; // Critical damage
        const double DEF = 0.5; // Blocked damage

        public static int
            attDmg, // Attack damage
            currHP, // Current Hit Points
            maxHP; // Maximum HP

        public static bool dead; // Alive or dead

        static Random random; // Prayers to RNJesus, Our Lord of RNG

        static Target opponent; // Target Fighter (opponent)

        // Default Constructor
        public Fighter()
        {
            random = new Random();

            maxHP = currHP = 10;
            attDmg = 2;
            dead = false;
            displayStats();

        }

        // this function runs to test other functions
        void debug() {

            while (currHP > 0)
                takeDamage(attDmg);
            death();
        }

        // Stat print
        public static void displayStats()
        {
            Console.WriteLine(

                $"Current HP: {currHP}\n" +
                $"Max HP: {maxHP}\n"
            );
        }

        public static void takeDamage(int d)
        {
            if (random.Next(5) != 1)
            {
                currHP -= d; // subtract damage from current HP

                Console.WriteLine($"You take {d} damage.");
                displayStats();
                death(); // checks for death
            }

            else
            {
                currHP -= (int)(d * DEF);

                Console.WriteLine($"You blocked half of the damage, " +
                    $"and are hit by the resulting {d * DEF} damage.");
                displayStats();
                death(); // checks for death
            }
        }

        public static void death()
        {
            if (currHP <= 0)
            {
                dead = true;

                for (var i = 0; i < 10; i++)
                    Console.WriteLine($"YOU DIED");
            }
        }


        public static void attackEnemy() {

            opponent();
        }

        

        public override string ToString()
        {
            displayStats();
            return "";
        }

        public static void Main(string[] args)
            { new Player(); }
    }

    public class Enemy : Fighter {

        public void takeAction() {

            //attackEnemy();
        }
    }

    public class Player : Fighter {

        static int potions;

        public Player() {

            potions = 2;

            try { takeAction(); }
            catch (Exception e) {

                Console.WriteLine(e.Message);
                takeAction();
            }
        }

        public static void takeAction()
        {
            int choice;

            Console.WriteLine(

                "Which action would you like to take?" +
                "\n1: Attack Enemy" +
                "\n2: Drink Potion"
            );

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    attackEnemy();
                    break;

                case 2:
                    if (potions > 0)
                        drinkPotion();
                    else Console.WriteLine("NO POTIONS");
                    break;

                default:
                    throw new Exception("Invalid Choice! Try Again");
            }

            displayStats();
        }

        public static void drinkPotion()
        {
            if (currHP == maxHP)
                maxHP = currHP += 2;
            else currHP += 3;

            potions--;
        }
    }


}
