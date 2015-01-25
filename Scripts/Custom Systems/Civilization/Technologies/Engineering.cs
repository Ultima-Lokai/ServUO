using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Engineering
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Engineering;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Tactics };
            GovernmentType m_GovernmentRequired = GovernmentType.Theocracy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Metalworking };
            string m_Description = "Engineering temporary description.";
            string m_Name = "Engineering";
            int m_Cost = 80000;
            int m_CorruptionFactor = -1;
            int m_WasteFactor = 1;
            int m_SatisfactionFactor = -1;
            int m_ProductionFactor = 3;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




