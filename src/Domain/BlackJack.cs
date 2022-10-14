namespace Domain
{
    public class BlackJack
    {
        public const bool FaceUp = true;

        public const bool FaceDown = false;
        public Hand DealerHand { get;}
        public Hand PlayerHand { get; }
        public GameState GameState { get; private set;}

        private Deck _deck;

        public BlackJack():this(new Deck()) {

        }

        public BlackJack(Deck deck) {
            this._deck = deck;
            this.PlayerHand = new Hand();
            this.DealerHand = new Hand();

            Deal();
        }

        private void AddCardToHand(Hand hand, bool faceUp) {
            var card = _deck.Draw();
            if (faceUp)
                card.TurnCard();
            hand.AddCard(card);
        }

        public void PassToDealer() {
            DealerHand.TurnAllCardsFaceUp();
            AdjustGameState(GameState.DealerPlays);
            LetDealerFinalize();
        }

        public void LetDealerFinalize() {
            while (GameState == GameState.DealerPlays)
            {
                AddCardToHand(DealerHand, FaceUp);
                AdjustGameState();
            }
        }

        public string GameSummary() {
            if (GameState != GameState.GameOver)
                return null;
            if (PlayerHand.Value > 21)
                return "Player burned, dealer wins";
            if (PlayerHand.Value == 21 && PlayerHand.NrOfCards == 2 && DealerHand.Value != 21)
                return "BLACKJACK";
            if (PlayerHand.Value == DealerHand.Value)
                return "Equal, dealer wins";
            if (DealerHand.Value > 21)
                return "Dealer burned, player wins";
            if (DealerHand.Value >= PlayerHand.Value)
                return "Dealer wins";
            return "Player wins";
        }

        public void GivePlayerAnotherCard() {
            if (GameState != GameState.PlayerPlays)
                throw new InvalidOperationException("You cannot take a card now...");
            AddCardToHand(PlayerHand, FaceUp);
            AdjustGameState();
        }
        private void Deal() {
            AddCardToHand(DealerHand, FaceUp);
            AddCardToHand(DealerHand, FaceDown);
            AddCardToHand(PlayerHand, FaceUp);
            AddCardToHand(PlayerHand, FaceUp);
            AdjustGameState(GameState.PlayerPlays);
        }

        private void AdjustGameState(GameState? gameState= null)
        {
            if (gameState.HasValue)
                GameState = gameState.Value;
            if (GameState == GameState.PlayerPlays && PlayerHand.Value >= 21)
                PassToDealer();
            if (GameState == GameState.DealerPlays && (PlayerHand.Value > 21 || DealerHand.Value >= 21 || DealerHand.Value >= PlayerHand.Value))
                GameState = GameState.GameOver;
        }
    }
}
