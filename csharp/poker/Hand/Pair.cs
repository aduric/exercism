using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Deck;

namespace Poker.Hand
{
    internal class Pair : IHand
    {

        public Pair( IEnumerable<Card> hand ) {
            var cards = hand.ToList();
            var primaryHand = new List<Card>();
            var secondaryHand = new List<Card>();
            foreach( Card card in hand ) {
                var foundDupes = cards.FindAll( c => c.Rank == card.Rank );
                if( foundDupes.Count == 2 ) {
                    primaryHand.AddRange( foundDupes );
                    secondaryHand.AddRange( cards.Where( c => c.Rank != card.Rank ) );
                    break;
                }
            }
            if( primaryHand.Count != 2 ) {
                throw new InvalidOperationException();
            }
            Cards = primaryHand;
            PrimaryPartialHand = this;
            SecondaryPartialHand = new None( secondaryHand );
        }
        public IEnumerable<Card> Cards { get; }
        public IHand PrimaryPartialHand { get; }
        public IHand SecondaryPartialHand { get; }
        public Rank Rank => Rank.Pair;

    }
}
