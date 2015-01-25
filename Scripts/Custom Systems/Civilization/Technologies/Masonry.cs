using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Masonry
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Masonry;
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.BrickLaying, LokaiSkillName.StoneMasonry };
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Astronomy };
            string m_Description = "Masonry temporary description.";
            string m_Name = "Masonry";
            int m_Cost = 40000;
            int m_CorruptionFactor = 2;
            int m_WasteFactor = 2;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_lSkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




