using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Construction
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Construction;
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.Roofing, LokaiSkillName.Construction, LokaiSkillName.Framing };
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Alchemy,SkillName.Cartography };
            GovernmentType m_GovernmentRequired = GovernmentType.Feudalism;
            TechType[] m_TechsRequired = new TechType[] { TechType.Engineering };
            string m_Description = "Construction temporary description.";
            string m_Name = "Construction";
            int m_Cost = 160000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = -2;
            int m_ProductionFactor = 4;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 0;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_lSkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




