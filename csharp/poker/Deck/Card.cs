using System.Linq;

namespace Poker.Deck {
    public class Card {

        public Card( Rank rank, Suit suit ) {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString() {
            string rankStr = Mappings.RankMap.FirstOrDefault( x => x.Value == Rank ).Key;
            char suitStr = Mappings.SuitMap.FirstOrDefault(x => x.Value == Suit).Key;

            return rankStr + suitStr;
        }

        public Rank Rank { get; }

        public Suit Suit { get; }

    }
}
