using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Monster : Being
    {
        public Monster(string name, string symbol, int health, int attackStrength) : base(name, symbol, health, attackStrength)
        {
        }
    }
}
