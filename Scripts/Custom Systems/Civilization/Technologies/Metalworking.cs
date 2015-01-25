using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Metalworking
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Metalworking;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Blacksmith };
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Firemaking };
            string m_Description = "Metalworking temporary description.";
            string m_Name = "Metalworking";
            int m_Cost = 40000;
            int m_CorruptionFactor = -1;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = -1;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 1;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




