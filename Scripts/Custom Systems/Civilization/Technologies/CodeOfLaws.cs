using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class CodeOfLaws
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.CodeOfLaws;
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.PickPocket, LokaiSkillName.Pilfering };
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Stealing };
            GovernmentType m_GovernmentRequired = GovernmentType.Oligarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Philosophy };
            string m_Description = "CodeOfLaws temporary description.";
            string m_Name = "CodeOfLaws";
            int m_Cost = 80000;
            int m_CorruptionFactor = 2;
            int m_WasteFactor = 2;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = -2;
            int m_TradeFactor = -2;
            int m_TechnologyFactor = -2;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_lSkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




