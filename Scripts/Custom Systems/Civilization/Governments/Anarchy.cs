using System;
using Server;

namespace Server.UOC.Governments
{
    public sealed class Anarchy
    {
        public static void Initialize()
        {
            GovernmentType m_GovType = GovernmentType.Anarchy;
            TechType m_TechRequired = TechType.None;
            string m_Description = "Anarchy happens when switching from one Gov to another - called revolution. It basically means you have no government at all.";
            string m_Name = "Anarchy";
            int m_CitizensRequired = 0;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 0;

            UOC.Government.Register(new Government(m_GovType, m_TechRequired, m_Description, m_Name,
                m_CitizensRequired, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}

