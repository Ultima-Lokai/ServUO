using System;
using Server;

namespace Server.UOC.Governments
{
    public sealed class Monarchy
    {
        public static void Initialize()
        {
            GovernmentType m_GovType = GovernmentType.Monarchy;
            TechType m_TechRequired = TechType.Monarchy;
            string m_Description = "Moderate Satisfaction and Production, low Corruption.";
            string m_Name = "Monarchy";
            int m_CitizensRequired = 32;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 3;
            int m_ProductionFactor = 3;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 2;

            UOC.Government.Register(new Government(m_GovType, m_TechRequired, m_Description, m_Name,
                m_CitizensRequired, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}

