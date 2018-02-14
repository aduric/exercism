using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class FullHouse : IHand
    {

        public IList<Card> GetCards() {
            throw new NotImplementedException();
        }

        public IHand GetPrimaryPartialHand() {
            return new Triple();
        }

        public IHand GetSecondaryPartialHand() {
            return new Pair();
        }

        public Rank GetRank() {
            return Rank.FullHouse;
        }

    }
}
