using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Card
    {
        public FaceValue FaceValue { get; }
        public Suit Suit { get; }

        public Card(Suit suit, FaceValue faceValue)
        {
            this.FaceValue = faceValue;
            this.Suit = suit;
        }
    }
}
