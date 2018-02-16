using System.Collections.Generic;

namespace Poker.Hand
{
    public class HandComparer : Comparer<IHand>
    {

        public override int Compare( IHand x, IHand y ) {
            // compare ranks
            var primaryComparison = x.PrimaryPartialHand.Rank.CompareTo(y.PrimaryPartialHand.Rank);
            if( primaryComparison == 0 ) {
                // compare actual cards

                // if cards are identical
                // compare ranks
                var secondaryComparison = x.SecondaryPartialHand.Rank.CompareTo(y.SecondaryPartialHand.Rank);
                if(secondaryComparison == 0) {
                    // compare actual cards

                    // if cards are identical
                    return 0;
                }
                return secondaryComparison;
            }
            return primaryComparison;
        }

    }
}
