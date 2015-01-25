using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class SeigeEngines
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.SeigeEngines;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Throwing };
            GovernmentType m_GovernmentRequired = GovernmentType.Oligarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Archery };
            string m_Description = "SeigeEngines temporary description.";
            string m_Name = "SeigeEngines";
            int m_Cost = 80000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 1;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 3;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}
