using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Player : Fighter
    {
        // Attributes
        int potions; // Number of Potions

        // Constructor
        public Player()
        {
            potions = 2; // Start out wit two potions
            displayStats(); // Show ALL stats upon construction
        }

        // Take action
        public override void takeAction()
        {
            int choice; // The Player's choice

            Console.WriteLine( // Print options to the player

                "Which action would you like to take?" +
                "\n1: Attack Enemy" +
                $"\n2: Drink Potion ({potions} remaining)"
            );

            choice = random.Next(1, 3); // choose random statement
            //choice = int.Parse(Console.ReadLine());

            switch (choice) // Switch to the choice
            {
                case 1: // choice 1 attacks the targeted enemy
                    attackEnemy(ref opponent);
                    break;

                case 2: // choice 2 drinks a potion, if there is one available
                    if (potions > 0)
                        drinkPotion();
                    else Console.WriteLine("NO POTIONS");
                    break;

                default: // throw invalid choice
                    throw new Exception("Invalid Choice! Try Again");
            }
        }

        // Take damage
        public override void takeDamage(double d)
        {
            if (random.Next(5) != 1) // If the random roll is NOT 1
            {
                currHP -= d; // subtract NORMAL damage from current HP

                Console.WriteLine( // display damage taken

                    $"You take {d} damage.\n" +
                    $"Current HP: {currHP}\n"
                );
                death(); // check for death
            }

            else
            {
                currHP -= (d * DEF); // Damage blocked

                Console.WriteLine( // Display dmage taken
                    
                    "You blocked half of the damage, " +
                    $"and are hit by the resulting {d * DEF} damage.\n" +
                    $"Current HP: {currHP}\n"
                );
                death(); // check for death
            }
        }

        // Attack enemy with Fighter reference
        public override void attackEnemy(ref Fighter o)
        {
            int tempDmg; // crit damage

            if (opponent == null) // if there is no opponent
                opponent = o; // Target the reference

            if (random.Next(6) == 5) // If the number is 5
            {
                tempDmg = (int)(attDmg * CRIT); // CRIT DAMAGE
                Console.WriteLine($"YOU CRITICAL HIT {opponent} for {tempDmg} damage!"); // Display damage
                opponent.takeDamage(tempDmg); // pass crit damage to the opponent
            }
            else // NO CRIT
            {
                Console.WriteLine($"You swing at {opponent} for {attDmg} damage."); // Display damage
                opponent.takeDamage(attDmg); // Pass normal damage to opponent
            }
        }
         // Death
        public override bool death() {

            if (currHP <= 0 && !dead) // If current HP is less than or equal to zero, AND NOT dead
            {
                if (!dead) { //  If NOT dead

                    dead = true; // die

                    for (var i = 0; i < 10; i++) // rub it in ten times
                        Console.WriteLine("YOU DIED");
                }
            }
            return dead;
        }
        
        // Allows the player to drink a potion
        public void drinkPotion()
        {
            if (currHP == maxHP) // if current HP is maxxed out
                maxHP = currHP += 2; // increase max HP by 2
            else currHP += 3; // or else add 3 HP

            potions--; // decrement potions
        }

        // To string function for printing
        public override string ToString()
            { return "Player"; }
    }
}
