using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class StoryTelling
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.StoryTelling;
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.Hypnotism };
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.None };
            string m_Description = "StoryTelling temporary description.";
            string m_Name = "StoryTelling";
            int m_Cost = 20000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 1;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_lSkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}