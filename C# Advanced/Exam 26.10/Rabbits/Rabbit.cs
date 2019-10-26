using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    class Rabbit
    {
        public string name { get; set; }
        public string species { get; set; }
        public bool available { get; set; }

        public Rabbit(string name, string species)
        {
            this.name = name;
            this.species = species;
        }

        public override string ToString()
        {
            return $"Rabbit ({this.species}): {this.name}";
        }

        public static implicit operator Rabbit(Rabbit v)
        {
            throw new NotImplementedException();
        }
    }
}
