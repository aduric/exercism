using System.Collections.Generic;
using Poker.Deck;

namespace Poker.Hand {
    internal class None : IHand {

        public None( IEnumerable<Card> cards) {
            PrimaryPartialHand = this;
            SecondaryPartialHand = this;
            Cards = cards;
        }

        public IEnumerable<Card> Cards { get; }

        public IHand PrimaryPartialHand { get; }
        public IHand SecondaryPartialHand { get; }
        public Rank Rank => Rank.None;

    }
}