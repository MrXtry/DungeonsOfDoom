using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Player : Being
    {
        public Player(string name, int health, int attackStrength) : base(name, "P", health, attackStrength)
        {
            PlayerItems = new List<Item>();  
        }
        public int X { get; set; }
        public int Y { get; set; }
        public List<Item> PlayerItems { get; set; }
    }
}
