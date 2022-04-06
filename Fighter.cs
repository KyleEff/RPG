﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public abstract class Fighter : IAbilities
    {
        // Attributes
        protected const double CRIT = 1.5; // Critical damage
        protected const double DEF = 0.5; // Blocked damage

        protected int
            attDmg; // Attack damage
            
        protected double
            currHP, // Current Hit Points
            maxHP; // Maximum HP

        public bool dead; // Alive or dead
        public Fighter opponent; // Target Fighter (opponent)
        protected Random random; // Prayers to RNJesus, Our Lord of RNG

        // Default Constructor
        public Fighter()
        {
            random = new Random();

            maxHP = currHP = 10;
            attDmg = 2;
            dead = false;
        }

        // Virtual functions for override
        public virtual void takeAction() { }
        public virtual void takeDamage(int d) { }
        public virtual void attackEnemy(ref Fighter o) { }
        public virtual bool death() { return dead; }

        // this function runs to test other functions
        void debug() {

            while (currHP > 0)
                takeDamage(attDmg);
            death();
        }

        // Stat print
        public void displayStats()
        {
            Console.WriteLine(

                $"Current HP: {currHP}\n" +
                $"Max HP: {maxHP}\n" +
                $"Attack Damage: {attDmg}\n" +
                $"Crit Multiplier: {CRIT * 100}%\n" + 
                $"Defense Multiplier: {DEF * 100}%\n"
                //+$"TARGET: {opponent}\n"
            );
        }

        public void acquireTarget(Fighter f) {

            if (f != this)
                opponent = f;
            else throw new Exception("CANNOT TARGET SELF");
        }

        public void acquireTarget(Fighter[] f) {
        
            opponent = f[random.Next(4)];
            if (opponent == this)
                acquireTarget(f);
        }

        public void acquireTarget(Fighter[] f, int index) {
            
            if (f[index] != this)
                opponent = f[index];
            else throw new Exception("CANNOT TARGET SELF");
        }
    }
}