using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Agriculture
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Agriculture;
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.Herblore };
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType[] m_TechsRequired = new TechType[] {TechType.Farming, TechType.AnimalHusbandry };
            string m_Description = "Agriculture temporary description.";
            string m_Name = "Agriculture";
            int m_Cost = 80000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 1;
            int m_SatisfactionFactor = -1;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 1;

            UOC.Technology.Register(new Technology(m_TechType, m_lSkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




