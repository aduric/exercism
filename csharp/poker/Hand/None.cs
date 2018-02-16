using System.Collections.Generic;
using Poker.Deck;

namespace Poker.Hand {
    internal class None : IHand {

        public None( IList<Card> cards) {
            Cards = cards;
        }

        public IList<Card> Cards { get; }

        public IHand PrimaryPartialHand => this;
        public IHand SecondaryPartialHand => this;
        public Rank Rank => Rank.None;

    }
}