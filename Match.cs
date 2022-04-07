using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    delegate void Run(); // delegate that runs the match

class Match
    {
        // Attributes
        const int NUM_FIGHTERS = 5; // Number of Fighters in the round
        public static int round = 0; // Round Number (not used right now)
        static Fighter player; // player variable
        static Fighter[] fighters; // array of fighters
        static bool done; // Match is done
        Run r; // Match delegate

        // Constructor
        public Match() {

            // Delegate list
            r += greeting;
            r += buildMatch;
            r += runMatch;

            // Run Delegate
            r();
        }

        // Greeting function
        static void greeting() {

            Console.WriteLine(
                
                "WELCOME TO THE RPG\n" + 
                "There are 5 Fighters, and you are one of them.\n" +
                "Fight to the death!\n"
            );
        }

        // This function builds the match
        static void buildMatch() {

            fighters = new Fighter[NUM_FIGHTERS]; // Array with a number of Fighters
            player = fighters[0] = new Player(); // Player variable assignment for easy reference

            // This loop cycles through the rest of the array and creates enemies
            for (var i = 1; i < fighters.Length; i++)
                fighters[i] = new Enemy();

            // This loop cycles through each fighter and then randomly selects a targer from an array
            foreach (var f in fighters)
                f.acquireTarget(fighters);

            // The match is NOT done
            done = false;
        }

        // Runs the match that has been set up
        static void runMatch() {
            // Start of dowhile loop
            do
            {
                try // acquireTarget and takeAction throw Exceptions
                {
                    foreach (var f in fighters) // For each fighter in the array of fighters
                    {
                        if (f.opponent.dead) // If the current fighter's opponent is dead
                            f.acquireTarget(fighters); // Choose another random fighter

                        if (!f.dead) // If the current fighter is not dead
                            f.takeAction(); // The fighter will take action

                        round++; // Increment round number
                        checkForVictory(); // Check the round for a victory
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); } // Catch exception and read message
            } while (!done); // While the match is not done
        }

        // This function checks the round for a victory
        static void checkForVictory() {

            int numDead = 0; // Number of dead counter

            foreach (var f in fighters) // for each fighter
                if (f.dead) // if the fighter is dead
                    numDead++; // Increment counter

            if (numDead == fighters.Length - 1) // If there is only one fighter left
                victory(); // Victory is declared
            
        }

        // This function declares a victory
        static void victory() {

            done = true; // The match is done

            if (player.dead) // If the player is dead
            {
                for (int i = 0; i < 10; i++) // Rub it in
                    Console.WriteLine("YOU LOSE!!");

                foreach (var f in fighters) // For each fighter in the array
                    if (!f.dead) // If the fighter is NOT dead
                        for (int i = 0; i < 10; i++) // Print the winner
                            Console.WriteLine($"{f} wins!!");
            }

            else  // if the player is NOT dead
                for (int i = 0; i < 10; i++) // Congratulate the player
                    Console.WriteLine("YOU WIN!!");
        }

        // Driver function
        public static void Main(string[] args) { new Match(); }
    }
}
