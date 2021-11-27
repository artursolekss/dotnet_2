
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Activity.CardGame
{
    public class SimpleCard : ICard
    {

        public SimpleCard()
        {
        }
        public SimpleCard(int cardIndex)
        {
            this.cardIndex = cardIndex;
        }
        private int cardIndex;
        public int CardAttribute { get { return this.cardIndex; } set { this.cardIndex = value; } }

        public string GetCardAttribute()
        {
            return "Card " + this.CardAttribute;
        }

        string ICard.GetCardAttribute()
        {
            return this.CardAttribute.ToString();
        }

    }



}