using System;
using System.Collections.Generic;
using System.Text;

namespace Poker {
    public interface IHand
    {
        IList<Card> GetCards();
        IHand GetPrimaryPartialHand();

        IHand GetSecondaryPartialHand();

        Rank GetRank();
    }
}
