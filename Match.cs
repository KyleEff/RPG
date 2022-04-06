using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class Match
    {
        //
        public static int round = 0;
        Fighter player;
        Fighter[] fighters;
        bool done;

        // Constructor
        public Match() {

            greeting();

            fighters = new Fighter[5];
            player = fighters[0] = new Player();

            for (var i = 1; i < fighters.Length; i++) 
                fighters[i] = new Enemy();
            
            foreach (var f in fighters)
                f.acquireTarget(fighters);

            done = false;

            do {

                try
                {
                    foreach (var f in fighters)
                    {
                        if (f.opponent.death())
                            f.acquireTarget(fighters);

                        if (!f.dead)
                            f.takeAction();

                        checkForVictory();

                        round++;
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            } while (!done);


            /*
            player = new Player();
            opponents = new Enemy[5];
            player.opponent = opponents[0];

            foreach (var o in opponents)
                o.opponent = player;

            done = false;

            int i = 0; // index variable

            while (!done) {

                if (!player.dead && !opponents.dead)
                    try {
                        player.takeAction();
                        opponent.takeAction();
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                else done = true;
            }*/
        }

        //
        void greeting() {

            Console.WriteLine(
                
                "WELCOME TO THE RPG\n" + 
                "There are 5 Fighters, and you are one of them.\n" +
                "Fight to the death!\n"
            );
        }

        //
        void checkForVictory() {

            int numDead = 0;

            foreach (var f in fighters)
                if (f.dead)
                    numDead++;

            if (numDead == fighters.Length - 1) 
                victory();
            
        }

        //
        void victory() {

            done = true;

            if (player.dead)
            {
                for (int i = 0; i < 10; i++)
                    Console.WriteLine("YOU LOSE!!");

                foreach (var f in fighters)
                    if (!f.dead)
                        for (int i = 0; i < 10; i++)
                            Console.WriteLine($"{f} wins!!");
            }

            else {

                for (int i = 0; i < 10; i++)
                    Console.WriteLine("YOU WIN!!");
            }
        }


        public static void Main(string[] args) { new Match(); }
    }
}
