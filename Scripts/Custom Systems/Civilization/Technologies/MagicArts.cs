using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class MagicArts
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.MagicArts;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Magery };
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Calendar };
            string m_Description = "MagicArts temporary description.";
            string m_Name = "MagicArts";
            int m_Cost = 160000;
            int m_CorruptionFactor = -3;
            int m_WasteFactor = -2;
            int m_SatisfactionFactor = 2;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 1;
            int m_TechnologyFactor = 3;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




