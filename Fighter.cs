using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public abstract class Fighter : IAbilities
    {
        // Attributes
        protected const double CRIT = 1.5; // Critical damage
        protected const double DEF = 0.5; // Blocked damage

        protected double
            currHP, // Current Hit Points
            maxHP, // Maximum HP
            attDmg; // Attack damage

        public bool dead; // Alive or dead
        public Fighter opponent; // Target Fighter (opponent)
        protected Random random; // Prayers to RNJesus, Our Lord of RNG

        // Default Constructor
        public Fighter()
        {
            random = new Random();

            maxHP = currHP = 10.0; // Setting Max and Current HP
            attDmg = 2; // Default FIGHTER attack damage
            dead = false; // The FIGHTER is NOT dead
        }

        // Virtual functions for override
        public virtual void takeAction() { }
        public virtual void takeDamage(double d) { }
        public virtual void attackEnemy(ref Fighter o) { }
        public virtual bool death() { return dead; }

        // this function is for testing other functions
        void debug() {

            while (currHP > 0)
                takeDamage(attDmg);
            death();
        }

        // Full stat print
        public void displayStats()
        {
            Console.WriteLine(

                $"Current HP: {currHP}\n" +
                $"Max HP: {maxHP}\n" +
                $"Attack Damage: {attDmg}\n" +
                $"Crit Multiplier: {CRIT * 100}%\n" + 
                $"Defense Multiplier: {DEF * 100}%\n"
            );
        }

        /*
         * The following functions are for aquiring targets three different ways:
         *  1. Single Fighter
         *  2. Randomly from an array of Fighters
         *  3. Selected from an array of Fighters
         */

        public void acquireTarget(Fighter f) {

            if (f != this || opponent.dead)
                opponent = f;
            else throw new Exception("CANNOT TARGET SELF");
        }

        public void acquireTarget(Fighter[] f) {

            opponent = f[random.Next(f.Length)];

            if (opponent == this || opponent.dead)
                acquireTarget(f);
        }

        public void acquireTarget(Fighter[] f, int index) {
            
            if (f[index] != this || opponent.dead)
                opponent = f[index];
            else throw new Exception("CANNOT TARGET SELF");
        }
    }
}
