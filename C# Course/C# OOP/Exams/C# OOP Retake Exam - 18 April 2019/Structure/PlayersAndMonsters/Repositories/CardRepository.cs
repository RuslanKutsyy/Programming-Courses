using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private IDictionary<string, ICard> data;

        public CardRepository()
        {
            this.data = new Dictionary<string, ICard>();
        }
        public int Count => this.data.Count;

        public IReadOnlyCollection<ICard> Cards
        {
            get
            {
                IReadOnlyCollection<ICard> cards = this.data.Values.ToList().AsReadOnly();
                return cards;
            }
        }

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            this.data.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            if (this.data.ContainsKey(name))
            {
                return this.data[name];
            }
            return null;
        }

        public bool Remove(ICard card)
        {
            if (this.data.ContainsKey(card.Name))
            {
                this.data.Remove(card.Name);
                return true;
            }
            return false;
        }
    }
}
