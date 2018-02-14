using System.Collections.Generic;

namespace Poker {
    internal class None : IHand {

        public IList<Card> GetCards() {
            throw new System.NotImplementedException();
        }

        public IHand GetPrimaryPartialHand() {
            return this;
        }

        public IHand GetSecondaryPartialHand() {
            return this;
        }

        public Rank GetRank() {
            return Rank.None;
        }

    }
}