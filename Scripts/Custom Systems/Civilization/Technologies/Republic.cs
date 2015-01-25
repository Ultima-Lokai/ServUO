using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Republic
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Republic;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Spellweaving };
            GovernmentType m_GovernmentRequired = GovernmentType.Feudalism;
            GovernmentType m_GovernmentProvided = GovernmentType.Republic;
            TechType[] m_TechsRequired = new TechType[] { TechType.Monarchy };
            string m_Description = "Republic temporary description.";
            string m_Name = "Republic";
            int m_Cost = 0;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 0;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired, m_GovernmentProvided,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




