using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Writing
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Writing;
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.Teaching };
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Inscribe };
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.StoryTelling };
            string m_Description = "Writing temporary description.";
            string m_Name = "Writing";
            int m_Cost = 40000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 1;
            int m_TechnologyFactor = 3;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




