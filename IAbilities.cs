using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public interface IAbilities
    {
        void takeDamage(int d);
        bool death();
        void takeAction();
    }
}
