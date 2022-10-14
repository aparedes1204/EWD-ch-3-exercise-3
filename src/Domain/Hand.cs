namespace Domain
{
    public class Hand
    {
        private IList<BlackJackCard> _card;

        public IEnumerable<BlackJackCard> Cards => _card;

        public int NrOfCards => _card.Count;

        public int Value => CalculateValue();

        public Hand() { 
            this._card = new List<BlackJackCard>();
        }

        public void AddCard(BlackJackCard card) { 
            this._card.Add(card);
        }

        public void TurnAllCardsFaceUp() { 
            foreach (var card in this._card)
            {
                if (!card.FaceUp) { 
                    card.TurnCard();
                }
            }
        }

        private int CalculateValue() {
            int sum = 0;
            bool isAce = false;
            foreach (var card in this._card)
            {
                sum += card.Value;
                if (card.FaceUp && card.FaceValue == FaceValue.Ace)
                {
                    isAce = true;
                }
            }
            if (isAce && sum <= 11)
            {
                sum += 10;
            }
            
            return sum;
        }
    }
}
