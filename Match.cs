using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class Match
    {
        bool done;

        Player player;
        Enemy opponent;

        public Match() {
        
            player = new Player();
            //opponent = new Enemy();

            done = false;

            while (!done) {

                try { player.takeAction(); }
                catch (Exception e) { Console.WriteLine(e.Message); }
                

                //if (player.dead)
                {
                   
                }
            }
        }

        public static void Main(string[] args) { new Match(); }
    }
}
