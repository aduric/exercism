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
            bool isQuad = false;
            bool isTrips = false;
            bool isPair1 = false;
            bool isPair2 = false;
            bool isFlush = true;
            bool noType = false;

            string[] splitHand = handStr.Split( ' ' );
            var hand = splitHand.Select( h => {
                string rank = h.Substring( 0, h.Length - 1 );
                char suit = h.Last();
                return new Card( Mappings.RankMap[rank], Mappings.SuitMap[suit] );
            } );
            IHand handObj = new None(hand);
            var handBuff = new List<Card>(hand);

            foreach ( var card in hand ) {
                var dupCount = handBuff.Count(c => c.Rank == card.Rank);
                if( dupCount == 4 ) {
                    isQuad = true;
                } else if ( dupCount == 3 ) {
                    isTrips = true;
                } else if( dupCount == 2 ) {
                    if( isPair1 ) {
                        isPair2 = true;
                    } else {
                        isPair1 = true;
                    }
                }
                handBuff.RemoveAll( c => c.Rank == card.Rank );
            }

            if ( isQuad ) {
                handObj = new Quadruple( hand );
            } else if( isTrips && isPair1 ) {
                handObj = new FullHouse(hand);
            } else if ( isTrips ) {
                handObj = new Triple( hand );
            } else if ( isPair1 && isPair2 ) {
                handObj = new TwoPair(hand);
            } else if( isPair1 ) {
                handObj = new Pair(hand);
            } else {
                noType = true;
            }

            if ( noType ) {
                var suitToMatch = hand.First().Suit;
                foreach (var card in hand)
                {
                    if ( card.Suit != suitToMatch ) {
                        isFlush = false;
                    }
                }

                if ( isFlush ) {
                    handObj = new Flush( hand );
                }
            }

            return handObj;
        }

    }
}