using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Triple : IHand {

        public Triple( IList<Card> cards ) {
            Cards = cards;
        }
        public IList<Card> Cards { get; }
        public IHand PrimaryPartialHand => this;
        public IHand SecondaryPartialHand => new None( Cards );
        public Rank Rank => Rank.Triple;

    }
}
