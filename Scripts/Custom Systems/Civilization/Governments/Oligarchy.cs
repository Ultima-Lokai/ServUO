using System;
using Server;

namespace Server.UOC.Governments
{
    public sealed class Oligarchy
    {
        public static void Initialize()
        {
            GovernmentType m_GovType = GovernmentType.Oligarchy;
            TechType m_TechRequired = TechType.None;
            string m_Description = "Basically like Anarchy, but can make Laws.";
            string m_Name = "Oligarchy";
            int m_CitizensRequired = 4;
            int m_CorruptionFactor = -5;
            int m_WasteFactor = -3;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 1;
            int m_TechnologyFactor = 0;

            UOC.Government.Register(new Government(m_GovType, m_TechRequired, m_Description, m_Name,
                m_CitizensRequired, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}

