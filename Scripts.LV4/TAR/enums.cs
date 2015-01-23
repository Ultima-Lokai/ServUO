using System;
using Server;

namespace Server.TAR
{
    public enum RaceStatus
    {
        None            = -1,
        Initialize      = 0,
        LegOneWait      = 100, LegOneGo, LegOneEnd,
        LegTwoWait      = 200, LegTwoGo, LegTwoEnd,
        LegThreeWait    = 300, LegThreeGo, LegThreeEnd,
        LegFourWait     = 400, LegFourGo, LegFourEnd,
        LegFiveWait     = 500, LegFiveGo, LegFiveEnd,
        LegSixWait      = 600, LegSixGo, LegSixEnd,
        LegSevenWait    = 700, LegSevenGo, LegSevenEnd,
        LegEightWait    = 800, LegEightGo, LegEightEnd,
        LegNineWait     = 900, LegNineGo, LegNineEnd,
        LegTenWait      = 1000, LegTenGo, LegTenEnd,
        LegElevenWait   = 1100, LegElevenGo, LegElevenEnd,
        FinishLine      = 1200,
        Done            = 1300
    }

    public enum RouteInfoType
    {
        Rest,
        Travel,
        Detour,
        RoadBlock,
        FastForward,
        Pitstop
    }

    public enum TravelType
    {
        None = 0x0000,
        Foot = 0x0001,
        Animal = 0x0002,
        Ethereal = 0x0004,
        Gates = 0x0008,
        Boat = 0x0010,
        Spell = 0x0020,
        Mount = Animal | Ethereal,
        Land = Foot | Animal | Ethereal,
        NonMagic = Land | Boat,
        Magic = Gates | Spell

    }

    public enum PenaltyType
    {
        None,
        MissingClue,
        WrongTravel,
        SkipChallenge,
        MissingItem,
        MarkedForElimination,
        TimePenalty,
        LoseMoney,
        Elimination,
        OtherPenalty
    }
}
