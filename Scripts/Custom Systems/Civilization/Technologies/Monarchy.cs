using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Monarchy
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Monarchy;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Chivalry };
            GovernmentType m_GovernmentRequired = GovernmentType.Feudalism;
            GovernmentType m_GovernmentProvided = GovernmentType.Monarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Feudalism };
            string m_Description = "Monarchy temporary description.";
            string m_Name = "Monarchy";
            int m_Cost = 160000;
            int m_CorruptionFactor = -6;
            int m_WasteFactor = 4;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 4;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired, m_GovernmentProvided,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




