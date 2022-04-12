using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Enemy : Fighter
    {
        // Attributes
        static int enemyCount = 0; // Number of enemies spawned
        int enemyNum; // Unique enemy number

        // Constructor
        public Enemy() {

            ++enemyCount; // Pre-Increment enemy count
            enemyNum = enemyCount; // Assign enemy number equal to the count
            attDmg = 1; // default enemy damage
        }

        // Override for the enemy class stat display
        public new void displayStats()
            { Console.WriteLine($"Enemy {enemyNum} HP: {currHP}\n"); }

        // Take Action
        public override void takeAction()
        {
            Console.WriteLine($"Enemy {enemyNum} swings for {opponent}!"); // Display action
            attackEnemy(ref opponent); // The enemy automatically just attacks
        }

        // Take damage with damage parameter
        public override void takeDamage(double d)
        {
            if (random.Next(5) != 2) // If random number is NOT 2
            {
                currHP -= d; // subtract base damage from current HP

                // Display damage
                Console.WriteLine($"Enemy {enemyNum} takes {d} damage.");
                displayStats(); // display enemy stats
                death(); // check for death
            }

            else // any other number but 2
            {
                currHP -= (d * DEF); // DAMAGE BLOCKED

                Console.WriteLine( // Display damage
                    
                    $"Enemy {enemyNum} blocked half of the damage, " +
                    $"and is hit by the resulting {d * DEF} damage."
                );
                displayStats(); // display enemy stats
                death(); // check for death
            }
        }

        // Attack Enemy
        public override void attackEnemy(ref Fighter o)
            { o.takeDamage(attDmg); } // Opponent takes damage (ENEMIES DO NOT CRIT ATTACK)

        // Death
        public override bool death()
        {
            if (currHP <= 0 && !dead) // If current HP is less than or equal to zero, AND NOT dead
            {
                dead = true; // die
                for (var i = 0; i < 10; i++) // Display death
                        Console.WriteLine($"ENEMY {enemyNum} DIED");
            }
            return dead;
        }

        // To string override for printing
        public override string ToString()
            { return $"Enemy {enemyNum}"; }
    }
}
