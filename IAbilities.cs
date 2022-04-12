using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    // This interface is for four methods
    public interface IAbilities {

        // This function is for the character taking an action
        void takeAction();

        // Take Damage, the parameter is the damgage taken
        void takeDamage(double d);

        // This function attacks the Fighter reference passed as a parameter
        void attackEnemy(ref Fighter o);

        // This function runs an algorithm and checks for the death of the character
        bool death();
    }
}
