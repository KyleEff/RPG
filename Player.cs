﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Player : Fighter
    {
        // Attributes
        int potions;

        // Constructor
        public Player()
        {
            potions = 2;
            displayStats();
        }

        //
        public override void takeAction()
        {
            int choice;

            Console.WriteLine(

                "Which action would you like to take?" +
                "\n1: Attack Enemy" +
                $"\n2: Drink Potion ({potions} remaining)"
            );

            choice = random.Next(1, 3); // debug statement
            //choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    attackEnemy(ref opponent);
                    break;

                case 2:
                    if (potions > 0)
                        drinkPotion();
                    else Console.WriteLine("NO POTIONS");
                    break;

                default:
                    throw new Exception("Invalid Choice! Try Again");
            }
        }

        //
        public override void takeDamage(double d)
        {
            if (random.Next(5) != 1)
            {
                currHP -= d; // subtract damage from current HP

                Console.WriteLine(

                    $"You take {d} damage.\n" +
                    $"Current HP: {currHP}\n"
                );
                death(); // checks for death
            }

            else
            {
                currHP -= (d * DEF);

                Console.WriteLine(
                    
                    "You blocked half of the damage, " +
                    $"and are hit by the resulting {d * DEF} damage.\n" +
                    $"Current HP: {currHP}\n"
                );
                death(); // checks for death
            }
        }

        //
        public override void attackEnemy(ref Fighter o)
        {
            int tempDmg; // crit damage

            if (opponent == null)
                opponent = o;

            if (random.Next(6) == 5) // number LESS THAN six
            {
                tempDmg = (int)(attDmg * CRIT);
                Console.WriteLine($"YOU CRITICAL HIT {opponent} for {tempDmg} damage!");
                opponent.takeDamage(tempDmg);
            }
            else
            {
                Console.WriteLine($"You swing at {opponent} for {attDmg} damage.");
                opponent.takeDamage(attDmg);
            }
        }

        public override bool death() {

            if (currHP <= 0)
            {
                if (!dead) {

                    dead = true;

                    for (var i = 0; i < 10; i++)
                        Console.WriteLine("YOU DIED");
                }
            }
            return dead;
        }
        
        //
        public void drinkPotion()
        {
            if (currHP == maxHP)
                maxHP = currHP += 2;
            else currHP += 3;

            potions--;
        }

        public override string ToString()
            { return "Player"; }
    }
}
