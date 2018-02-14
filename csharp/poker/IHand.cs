using System;
using System.Collections.Generic;
using System.Text;

namespace Poker {
    public interface IHand
    {
        IList<Card> Cards { get; }
        IHand PrimaryPartialHand { get; }

        IHand SecondaryPartialHand { get; }

        Rank Rank { get; }
    }
}
