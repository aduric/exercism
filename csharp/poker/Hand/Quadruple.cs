using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Deck;

namespace Poker.Hand
{
    internal class Quadruple : IHand {
        public Quadruple( IEnumerable<Card> hand )
        {
            var cards = hand.ToList();
            var primaryHand = new List<Card>();
            var secondaryHand = new List<Card>();
            
            var foundDupes = cards.FindAll(c => c.Rank == cards[0].Rank);
            if (foundDupes.Count == 4)
            {
                primaryHand.AddRange(foundDupes);
                secondaryHand.AddRange(cards.Where(c => c.Rank != cards[0].Rank));
            } else {
                primaryHand.AddRange( cards.FindAll(c => c.Rank == cards[1].Rank) );
                secondaryHand.Add( cards[0] );
            }

            Cards = primaryHand;
            PrimaryPartialHand = this;
            SecondaryPartialHand = new None(secondaryHand);
        }
        public IEnumerable<Card> Cards { get; }
        public IHand PrimaryPartialHand { get; }
        public IHand SecondaryPartialHand { get; }
        public Rank Rank => Rank.Quadruple;

    }
}
