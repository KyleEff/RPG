using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public interface IAbilities
    {
        static void takeDamage(int d) { }
        static void death() { }
        static void takeAction() { }
    }
}
