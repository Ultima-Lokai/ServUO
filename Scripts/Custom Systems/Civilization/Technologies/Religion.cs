using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Religion
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Religion;
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.Brewing };
            GovernmentType m_GovernmentRequired = GovernmentType.Oligarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Astronomy };
            string m_Description = "Religion temporary description.";
            string m_Name = "Religion";
            int m_Cost = 0;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 0;

            UOC.Technology.Register(new Technology(m_TechType, m_lSkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




