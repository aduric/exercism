using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Deck;

namespace Poker.Hand
{
    internal class FullHouse : IHand
    {
        public FullHouse( IEnumerable<Card> hand ) {
            Cards = hand;
            var sampleCard = hand.First();
            var firstRank = hand.Where( c => sampleCard.Rank == c.Rank );
            var secondRank = hand.Where( c => sampleCard.Rank != c.Rank );
            if( firstRank.Count() == 3 && secondRank.Count() == 2) {
                PrimaryPartialHand = new Triple( firstRank );
                SecondaryPartialHand = new Pair( secondRank );
            } else if( firstRank.Count() == 2 && secondRank.Count() == 3 ) {
                PrimaryPartialHand = new Triple( secondRank );
                SecondaryPartialHand = new Pair( firstRank );
            } else {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<Card> Cards { get; }
        public IHand PrimaryPartialHand { get; }
        public IHand SecondaryPartialHand { get; }
        public Rank Rank => Rank.FullHouse;

    }
}
