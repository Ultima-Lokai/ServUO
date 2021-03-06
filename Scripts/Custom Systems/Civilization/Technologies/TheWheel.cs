using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class TheWheel
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.TheWheel;
            LokaiSkillName[] m_SkillsAllowed = new LokaiSkillName[] { LokaiSkillName.Spinning };
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.None };
            string m_Description = "TheWheel temporary description.";
            string m_Name = "TheWheel";
            int m_Cost = 0;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 0;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




