using System;

namespace Domain
{
    public class Deck
    {
        private Random _random;
        protected IList<BlackJackCard> _cards;

        public Deck() {
            this._random = new Random();
            this._cards = new List<BlackJackCard>(52);
            Array suits = Enum.GetValues(typeof(Suit));
            Array faceValues = Enum.GetValues(typeof(FaceValue));

            foreach (Suit suit in suits) {
                foreach (FaceValue faceValue in faceValues) {
                    this._cards.Add(new BlackJackCard(suit, faceValue));
                }
            }

            Shuffle();
        }

        public BlackJackCard Draw() {
            if (_cards.Count == 0)
                throw new InvalidOperationException("Cannot draw card from empty deck");

            var card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        private void Shuffle() {
            this._cards = this._cards.OrderBy(x => this._random.Next()).ToArray();

            //for (int i= _cards.Count-1; i>=1; i--)
            //{
            //    int j = _random.Next(i+1);
            //    BlackJackCard card = _cards[j];
            //    _cards[j] = _cards[i];
            //    _cards[i] = card;
            //}

            //for i from n−1 downto 1 do
            //j ← random integer such that 0 ≤ j ≤ i
            //exchange a[j] and a[i]
        }
    }
}
