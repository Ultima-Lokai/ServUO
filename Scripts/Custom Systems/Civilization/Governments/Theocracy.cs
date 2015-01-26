using System;
using Server;

namespace Server.UOC.Governments
{
    public sealed class Theocracy
    {
        public static void Initialize()
        {
            GovernmentType m_GovType = GovernmentType.Theocracy;
            TechType m_TechRequired = TechType.Theology;
            string m_Description = "Highest corruption, but Enormous Production and Satisfaction.";
            string m_Name = "Theocracy";
            int m_CitizensRequired = 40;
            int m_CorruptionFactor = -8;
            int m_WasteFactor = -2;
            int m_SatisfactionFactor = 8;
            int m_ProductionFactor = 10;
            int m_TradeFactor = -2;
            int m_TechnologyFactor = -2;

            UOC.Government.Register(new Government(m_GovType, m_TechRequired, m_Description, m_Name,
                m_CitizensRequired, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}

