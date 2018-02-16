using System.Collections.Generic;
using Poker.Deck;

namespace Poker.Hand {
    public interface IHand
    {
        IEnumerable<Card> Cards { get; }
        IHand PrimaryPartialHand { get; }

        IHand SecondaryPartialHand { get; }

        Rank Rank { get; }
    }
}
