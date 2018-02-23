using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Poker.Deck;
using Poker.Hand;
using Rank = Poker.Deck.Rank;

namespace Poker {
    public static class Poker {
        public static IEnumerable<string> BestHands( IEnumerable<string> hands ) {
            var mappedHands = MapHands( hands );
            mappedHands.Sort();

            return mappedHands.Select( h => String.Join(" ", h.Cards) );
        }

        public static List<IHand> MapHands( IEnumerable<string> hands ) {
            // map strings to IHand types
            bool isTrips = false;
            bool isPair1 = false;
            bool isPair2 = false;

            var handObjs = new List<IHand>();

            foreach( var hand in hands ) {
                IHand handObj;
                var handBuff = new List<Card>();
                foreach( var cardStr in hand ) {
                    var currCard = new Card( Rank.Ace, Suit.Spade );

                    var dupCount = handBuff.Count(c => c.Rank == currCard.Rank);
                    if( dupCount == 2 ) {
                        isTrips = true;
                    } else if( dupCount == 1 ) {
                        if( isPair1 ) {
                            isPair2 = true;
                        } else {
                            isPair1 = true;
                        }
                    }

                    handBuff.Add( currCard );
                }

                if( isTrips && isPair1 ) {
                    handObj = new FullHouse( handBuff );
                } else if( isTrips ) {
                    handObj = new Triple( handBuff );
                } else if( isPair1 ) {
                    handObj = new Pair( handBuff );
                } else {
                    handObj = new None( handBuff );
                }

                handObjs.Add( handObj );
            }

            return handObjs;
        }

    }
}