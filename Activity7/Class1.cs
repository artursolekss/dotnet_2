using System;
using CSharp.Activity.Datastore;
namespace CSharp.Activity.CardGame
{
    public abstract class CardDeck
    {
        protected ArrayStore<ICard> cards;
        public abstract void InitializeDeck();

        public CardDeck()
        {
            this.cards = new ArrayStore<ICard>();
            this.InitializeDeck();
        }

        public CardDeck(int number)
        {
            this.cards = new ArrayStore<ICard>(number);
            this.InitializeDeck();
        }

        public ICard? GetCard()
        {
            if (this.cards.Count == 0)
                return null;

            Random rnd = new Random();
            int position = rnd.Next(this.cards.Count);
            return this.cards[position];
        }
        public ICard? GetCard(ICard card)
        {
            int position = this.cards.IndexOf(card);
            if (position == ArrayStore<ICard>.NOT_IN_STRUCTURE)
                throw new ArgumentNullException();
            else
            {
                this.cards.RemoveAt(position);
                return card;
            }

        }

        public bool PutCard(ICard card)
        {
            if (card == null)
                throw new ArgumentNullException();

            this.cards.Add(card);
            return true;
        }

        public int CardCount { get { return this.cards.Count; } }

    }

    public class SimpleDeck : CardDeck
    {
        public SimpleCard[] Cards { get; set; }
        public override void InitializeDeck()
        {
            this.cards.Add(new SimpleCard());
            this.cards.Add(new SimpleCard());
            this.cards.Add(new SimpleCard());
            this.cards.Add(new SimpleCard());
            this.cards.Add(new SimpleCard());
            this.cards.Add(new SimpleCard());
            this.cards.Add(new SimpleCard());
            this.cards.Add(new SimpleCard());
            this.Cards = new SimpleCard[this.cards.Count];
        }
    }
}