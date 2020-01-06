using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Deck;

namespace Poker.Hand
{
    internal class TwoPair : IHand
    {
        public TwoPair(IEnumerable<Card> hand)
        {
            var cards = hand.ToList();
            var primaryHand = new List<Card>();
            var secondaryHand = new List<Card>();
            var tertiaryHand = new List<Card>();
            foreach (Card card in hand)
            {
                var foundDupes = cards.FindAll(c => c.Rank == card.Rank);
                if (foundDupes.Count == 2)
                {
                    if ( primaryHand.Count == 0 ) {
                        primaryHand.AddRange( foundDupes );
                    } else {
                        secondaryHand.AddRange(foundDupes);
                    }
                    foreach (Card dupeCard in foundDupes)
                    {
                        cards.Remove(dupeCard);
                    }
                } else if( foundDupes.Count == 1 ) {
                    tertiaryHand.Add( card );
                    TertiaryPartialHand = new None( tertiaryHand );
                }
            }
            Cards = primaryHand;
            PrimaryPartialHand = this;
            SecondaryPartialHand = new None(secondaryHand);
        }
        public IEnumerable<Card> Cards { get; }
        public IHand PrimaryPartialHand { get; }
        public IHand SecondaryPartialHand { get; }
        public IHand TertiaryPartialHand { get; }
        public Rank Rank => Rank.TwoPair;

    }
}
