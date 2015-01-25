using System;
using Server;

namespace Server.UOC.Governments
{
    public sealed class Communism
    {
        public static void Initialize()
        {
            GovernmentType m_GovType = GovernmentType.Communism;
            TechType m_TechRequired = TechType.Communism;
            string m_Description = "Communism temporary description.";
            string m_Name = "Communism";
            int m_CitizensRequired = 16;
            int m_CorruptionFactor = 2;
            int m_WasteFactor = 2;
            int m_SatisfactionFactor = -4;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 2;

            UOC.Government.Register(new Government(m_GovType, m_TechRequired, m_Description, m_Name,
                m_CitizensRequired, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}

