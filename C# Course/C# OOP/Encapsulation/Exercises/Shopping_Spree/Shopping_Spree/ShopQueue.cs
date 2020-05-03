using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    class ShopQueue : List<Person>
    {
        private List<Person> queue { get; set; }

        public List<Person> Queue
        {
            get { return this.queue; }
            set { this.queue = value; }
        }

        public ShopQueue()
        {
            this.Queue = new List<Person>();
        }

        public void AddToQueue(string input)
        {
            var data = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int personIndex = 0; personIndex < data.Length; personIndex++)
            {
                var person = data[personIndex].Split('=', StringSplitOptions.RemoveEmptyEntries);

                string name = person[0];
                double money = double.Parse(person[1]);

                Person buyer = new Person(name, money);
                this.Queue.Add(buyer);
            }
        }
    }
}
