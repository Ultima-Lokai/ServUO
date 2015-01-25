using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Farming
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Farming;
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.TreeCarving, LokaiSkillName.TreeDigging, LokaiSkillName.TreePicking, LokaiSkillName.TreeSapping };
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.TasteID };
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Fishing };
            string m_Description = "Farming temporary description.";
            string m_Name = "Farming";
            int m_Cost = 40000;
            int m_CorruptionFactor = 1;
            int m_WasteFactor = 1;
            int m_SatisfactionFactor = 2;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_lSkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}








