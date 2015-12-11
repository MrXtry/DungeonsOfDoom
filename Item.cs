using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item : Entity
    {
        public Item(string name, int value, string symbol) : base (name, symbol)
        {
            Value = value;
        }
        public int Value { get; set; }
    }
}
