using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Communism
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Communism;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Provocation, SkillName.Discordance };
            GovernmentType m_GovernmentRequired = GovernmentType.Feudalism;
            GovernmentType m_GovernmentProvided = GovernmentType.Communism;
            TechType[] m_TechsRequired = new TechType[] { TechType.CodeOfLaws };
            string m_Description = "Communism temporary description.";
            string m_Name = "Communism";
            int m_Cost = 160000;
            int m_CorruptionFactor = 2;
            int m_WasteFactor = 2;
            int m_SatisfactionFactor = -2;
            int m_ProductionFactor = 3;
            int m_TradeFactor = -2;
            int m_TechnologyFactor = 3;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired, m_GovernmentProvided,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




