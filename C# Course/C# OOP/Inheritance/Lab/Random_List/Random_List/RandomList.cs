using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        public void RandomString()
        {
            Random num = new Random();
            int element = num.Next(this.Count);
            Console.WriteLine(this[element]);
            this.RemoveAt(element);            
        }
    }
}
