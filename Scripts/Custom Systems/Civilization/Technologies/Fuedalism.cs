using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Feudalism
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Feudalism;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Bushido };
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            GovernmentType m_GovernmentProvided = GovernmentType.Feudalism;
            TechType[] m_TechsRequired = new TechType[] { TechType.Metalworking };
            string m_Description = "Feudalism temporary description.";
            string m_Name = "Feudalism";
            int m_Cost = 160000;
            int m_CorruptionFactor = -4;
            int m_WasteFactor = -2;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 3;
            int m_TradeFactor = 4;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired, m_GovernmentProvided,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




