using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class HandComparer : Comparer<IHand>
    {

        public override int Compare( IHand x, IHand y ) {
            // compare ranks
            var primaryComparison = x.GetPrimaryPartialHand().GetRank().CompareTo(y.GetPrimaryPartialHand().GetRank());
            if( primaryComparison == 0 ) {
                // compare actual cards

                // if cards are identical
                // compare ranks
                var secondaryComparison = x.GetSecondaryPartialHand().GetRank().CompareTo(y.GetSecondaryPartialHand().GetRank());
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
