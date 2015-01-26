using System;
using Server;

namespace Server.UOC.Governments
{
    public sealed class Feudalism
    {
        public static void Initialize()
        {
            GovernmentType m_GovType = GovernmentType.Feudalism;
            TechType m_TechRequired = TechType.Feudalism;
            string m_Description = "Increased production, but high corruption and waste.";
            string m_Name = "Feudalism";
            int m_CitizensRequired = 0;
            int m_CorruptionFactor = -3;
            int m_WasteFactor = -2;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 4;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 0;

            UOC.Government.Register(new Government(m_GovType, m_TechRequired, m_Description, m_Name,
                m_CitizensRequired, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}

