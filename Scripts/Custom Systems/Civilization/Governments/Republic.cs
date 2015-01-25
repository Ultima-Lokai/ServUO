using System;
using Server;

namespace Server.UOC.Governments
{
    public sealed class Republic
    {
        public static void Initialize()
        {
            GovernmentType m_GovType = GovernmentType.Republic;
            TechType m_TechRequired = TechType.Republic;
            string m_Description = "Republic temporary description.";
            string m_Name = "Republic";
            int m_CitizensRequired = 72;
            int m_CorruptionFactor = -2;
            int m_WasteFactor = -2;
            int m_SatisfactionFactor = 4;
            int m_ProductionFactor = 5;
            int m_TradeFactor = 5;
            int m_TechnologyFactor = 3;

            UOC.Government.Register(new Government(m_GovType, m_TechRequired, m_Description, m_Name,
                m_CitizensRequired, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}

