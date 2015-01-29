using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Shipbuilding
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Shipbuilding;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Fencing };
            GovernmentType m_GovernmentRequired = GovernmentType.Communism;
            TechType[] m_TechsRequired = new TechType[] { TechType.Astronomy };
            string m_Description = "Shipbuilding temporary description.";
            string m_Name = "Shipbuilding";
            int m_Cost = 200000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = -2;
            int m_SatisfactionFactor = 2;
            int m_ProductionFactor = 3;
            int m_TradeFactor = 3;
            int m_TechnologyFactor = 3;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}



