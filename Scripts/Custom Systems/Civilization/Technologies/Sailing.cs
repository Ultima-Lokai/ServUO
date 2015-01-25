using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Sailing
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Sailing;
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.Sailing };
            GovernmentType m_GovernmentRequired = GovernmentType.Oligarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Weaving };
            string m_Description = "Sailing temporary description.";
            string m_Name = "Sailing";
            int m_Cost = 60000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 1;
            int m_TradeFactor = 3;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_lSkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}
