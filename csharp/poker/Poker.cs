using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Poker {
    public static class Poker {
        public static IEnumerable<string> BestHands( IEnumerable<string> hands ) {
            var mappedHands = MapHands( hands );
            mappedHands.Sort();

            return mappedHands.Select( h => String.Join(" ", h.GetCards()) );
        }

        public static List<IHand> MapHands( IEnumerable<string> hands ) {
            // map strings to IHand types

            return new List<IHand>();
        }

    }
}