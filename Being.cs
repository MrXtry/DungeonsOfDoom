using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Being : Entity
    {
        public virtual void Fight(Being neutral, Being enemy)
        {
            neutral.Health -= enemy.AttackStrength;
            enemy.Health -= neutral.AttackStrength;
        }

        public Being(string name, string symbol, int health, int attackStrength) : base(name, symbol)
        {
            Health = health;
            AttackStrength = attackStrength;
        }
        public int Health { get; set; }
        public int AttackStrength { get; set; }
    }
}
