﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Ogre : Monster
    {
        public Ogre(string name, int health, int attackStrength) : base(name, "O", health, attackStrength)
        {
        }
    }
}
