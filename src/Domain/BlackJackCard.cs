namespace Domain
{
    public class BlackJackCard : Card {
        public bool FaceUp {get; set;}
        public int Value => FaceUp ? Math.Min(10,  (int)FaceValue) : 0;

        public BlackJackCard( Suit suit, FaceValue faceValue) : base(suit, faceValue) {
            this.FaceUp = false;
        }

        public void TurnCard() {
            this.FaceUp = !this.FaceUp;
        }
    }
}
