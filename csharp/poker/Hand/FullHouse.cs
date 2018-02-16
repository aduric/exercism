using System.Collections.Generic;
using System.Linq;
using Poker.Deck;

namespace Poker.Hand
{
    internal class FullHouse : IHand
    {
        public FullHouse( IEnumerable<Card> triple, IEnumerable<Card> pair ) {
            PrimaryPartialHand = new Triple( triple, new List<Card>() );
            SecondaryPartialHand = new Pair( pair, new List<Card>() );
            Cards = triple.Concat( pair );
        }

        public IEnumerable<Card> Cards { get; }
        public IHand PrimaryPartialHand { get; }
        public IHand SecondaryPartialHand { get; }
        public Rank Rank => Rank.FullHouse;

    }
}
