using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Weaving
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Weaving;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Tailoring };
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.Weaving };
            GovernmentType m_GovernmentRequired = GovernmentType.Oligarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Pottery };
            string m_Description = "Weaving temporary description.";
            string m_Name = "Weaving";
            int m_Cost = 80000;
            int m_CorruptionFactor = 1;
            int m_WasteFactor = 1;
            int m_SatisfactionFactor = 2;
            int m_ProductionFactor = 3;
            int m_TradeFactor = 1;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_lSkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




