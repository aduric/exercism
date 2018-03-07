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
            Dictionary<IHand, string> handMap = new Dictionary<IHand, string>();
            foreach ( string hand in hands ) {
                var mappedHand = MapHand(hand);
                handMap.Add( mappedHand, hand );
            }
            List<IHand> keys = new List<IHand>(handMap.Keys);
            keys.Sort( new HandComparer() );

            List<string> result = new List<string>(){ keys.Select(h => handMap[h]).Last() };
            return result;
        }

        public static IHand MapHand( string handStr ) {           
                // map strings to IHand types
                bool isTrips = false;
                bool isPair1 = false;
                bool isPair2 = false;

                IHand handObj;
                string[] splitHand = handStr.Split( ' ' );
                var hand = splitHand.Select( h => {
                    string rank = h.Substring( 0, h.Length - 1 );
                    char suit = h.Last();
                    return new Card( Mappings.RankMap[rank], Mappings.SuitMap[suit] );
                } );

                foreach ( var card in hand ) {
                    var dupCount = hand.Count(c => c.Rank == card.Rank);
                    if( dupCount == 3 ) {
                        isTrips = true;
                    } else if( dupCount == 2 ) {
                        if( isPair1 ) {
                            isPair2 = true;
                        } else {
                            isPair1 = true;
                        }
                    }
                }

                if( isTrips && isPair1 ) {
                    handObj = new FullHouse(hand);
                } else if ( isTrips ) {
                    handObj = new Triple( hand );
                } else if ( isPair1 && isPair2 ) {
                    handObj = new TwoPair(hand);
                } else if( isPair1 ) {
                    handObj = new Pair(hand);
                } else {
                    handObj = new None(hand);
                }

            return handObj;
        }

    }
}