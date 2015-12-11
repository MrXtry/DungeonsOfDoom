using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Entity
    {
        public Entity(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
