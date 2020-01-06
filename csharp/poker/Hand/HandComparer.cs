using System.Collections.Generic;
using System.Linq;
using Poker.Deck;

namespace Poker.Hand
{
    public class HandComparer : Comparer<IHand>
    {

        public override int Compare( IHand x, IHand y ) {
            if ( x.Rank.CompareTo( y.Rank ) != 0 ) {
                return x.Rank.CompareTo( y.Rank );
            }

            if ( x.PrimaryPartialHand.Rank.CompareTo( y.PrimaryPartialHand.Rank ) != 0 ) {
                return x.PrimaryPartialHand.Rank.CompareTo( y.PrimaryPartialHand.Rank );
            } else if ( x.PrimaryPartialHand.Rank != Rank.None ) {
                var compare = x.PrimaryPartialHand.Cards.First().Rank
                    .CompareTo( y.PrimaryPartialHand.Cards.First().Rank );
                if ( compare != 0 ) {
                    return compare;
                }
            }

            if ( x.SecondaryPartialHand.Rank.CompareTo( y.SecondaryPartialHand.Rank ) != 0 ) {
                return x.SecondaryPartialHand.Rank.CompareTo( y.SecondaryPartialHand.Rank );
            } else if (x.SecondaryPartialHand.Rank != Rank.None) {
                var compare = x.SecondaryPartialHand.Cards.First().Rank
                    .CompareTo(y.SecondaryPartialHand.Cards.First().Rank);
                if ( compare != 0 )
                {
                    return compare;
                }
            }

            var xCards = x.Cards.ToList();
            var yCards = y.Cards.ToList();
            for ( int i = 0; i < x.Cards.Count(); i++ ) {
                var maxX = xCards.Max( card => card.Rank );
                var maxXCard = xCards.Find( z => z.Rank == maxX );
                var maxY = yCards.Max( card => card.Rank );
                var maxYCard = xCards.Find(z => z.Rank == maxY);
                if ( maxX > maxY) {
                    return 1;
                } else if ( maxX < maxY ) {
                    return -1;
                }
                else {
                    xCards.Remove(maxXCard);
                    xCards.Remove(maxYCard);
                }
            }

            return 0;
        }

    }
}
