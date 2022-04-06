using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Enemy : Fighter
    {
        // Attributes
        static int enemyCount = 0;
        int enemyNum;

        // Constructor
        public Enemy() {

            ++enemyCount;
            enemyNum = enemyCount;
            attDmg = 1;
        }

        //
        public new void displayStats()
            { Console.WriteLine($"Enemy {enemyNum}: Current HP: {currHP}\n"); }

        //
        public override void takeAction()
        {
            Console.WriteLine($"Enemy {enemyNum} swings for {opponent}!");
            attackEnemy(ref opponent);
        }

        //
        public override void takeDamage(int d)
        {
            if (random.Next(5) != 2)
            {
                currHP -= d; // subtract damage from current HP

                Console.WriteLine(

                    $"Enemy {enemyNum} takes {d} damage.\n" +
                    $"Enemy {enemyNum} HP: {currHP}"
                );
                death(); // checks for death
            }

            else
            {
                currHP -= (int)(d * DEF);

                Console.WriteLine(
                    
                    $"Enemy {enemyNum} blocked half of the damage, " +
                    $"and is hit by the resulting {d * DEF} damage.\n" +
                    $"Enemy {enemyNum} HP: {currHP}"
                );
                death(); // checks for death
            }
        }

        //
        public override void attackEnemy(ref Fighter o)
            { o.takeDamage(attDmg); }

        //
        public override bool death()
        {
            if (currHP <= 0)
            {
                dead = true;

                for (var i = 0; i < 10; i++)
                    Console.WriteLine($"ENEMY {enemyNum} DIED");
            }
            return dead;
        }

        //
        public override string ToString()
            { return $"Enemy {enemyNum}"; }
    }
}
