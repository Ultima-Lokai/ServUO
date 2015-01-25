using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Democracy
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Democracy;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Begging };
            GovernmentType m_GovernmentRequired = GovernmentType.Monarchy;
            GovernmentType m_GovernmentProvided = GovernmentType.Democracy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Republic };
            string m_Description = "Democracy temporary description.";
            string m_Name = "Democracy";
            int m_Cost = 1280000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 2;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 4;
            int m_TradeFactor = 5;
            int m_TechnologyFactor = 3;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired, m_GovernmentProvided,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




