using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Giant : Monster
    {
        public override void Fight(Being neutral, Being enemy)
        {
            neutral.Health -= enemy.AttackStrength;
            neutral.Health += 5;
            neutral.AttackStrength += 10;
            enemy.Health -= neutral.AttackStrength;

        }
        public Giant(string name, int health, int attackStrength) : base(name, "G", health, attackStrength)
        {
        }
    }
}
