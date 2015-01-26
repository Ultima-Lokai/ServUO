using System;
using Server;

namespace Server.UOC.Governments
{
    public sealed class Democracy
    {
        public static void Initialize()
        {
            GovernmentType m_GovType = GovernmentType.Democracy;
            TechType m_TechRequired = TechType.Democracy;
            string m_Description = "Very high Producion and Trade. Very low Satisfaction during War.";
            string m_Name = "Democracy";
            int m_CitizensRequired = 144;
            int m_CorruptionFactor = -2;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = -1;
            int m_ProductionFactor = 7;
            int m_TradeFactor = 7;
            int m_TechnologyFactor = 4;

            UOC.Government.Register(new Government(m_GovType, m_TechRequired, m_Description, m_Name,
                m_CitizensRequired, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}

