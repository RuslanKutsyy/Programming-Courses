using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    class ShopQueue : List<Person>
    {
        private List<Person> queue;

        public List<Person> Queue
        {
            get { return this.queue; }
            set { this.queue = value; }
        }

        public ShopQueue()
        {
            this.queue = new List<Person>();
        }

        public void AddToQueue(string input)
        {
            var data = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int personIndex = 0; personIndex < input.Length; personIndex++)
            {
                var person = data[personIndex].Split('=', StringSplitOptions.RemoveEmptyEntries);

                string name = person[0];
                double money = double.Parse(person[1]);

                this.Queue.Add(new Person(name, money));
            }
        }
    }
}
