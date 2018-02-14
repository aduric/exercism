using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Triple : IHand {
        public IList<Card> GetCards() {
            throw new NotImplementedException();
        }

        public IHand GetPrimaryPartialHand() {
            return this;
        }

        public IHand GetSecondaryPartialHand() {
            return new None();
        }

        public Rank GetRank() {
            throw new NotImplementedException();
        }

    }
}
