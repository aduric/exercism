using System.Collections.Generic;

namespace Poker.Deck
{
    public static class Mappings
    {
        public static IDictionary<string, Rank> RankMap = new Dictionary<string, Rank>
        {
            {"A", Rank.Ace},
            {"2", Rank.Two},
            {"3", Rank.Three},
            {"4", Rank.Four},
            {"5", Rank.Five},
            {"6", Rank.Six},
            {"7", Rank.Seven},
            {"8", Rank.Eight},
            {"9", Rank.Nine},
            {"10", Rank.Ten},
            {"J", Rank.Jack},
            {"Q", Rank.Queen},
            {"K", Rank.King}
        };
        public static IDictionary<char, Suit> SuitMap = new Dictionary<char, Suit>
        {
            {'H', Suit.Heart},
            {'D', Suit.Diamond},
            {'S', Suit.Spade},
            {'C', Suit.Club}
        };
    }
}