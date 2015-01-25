using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Alphabet
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Alphabet;
            LokaiSkillName[] m_lSkillsAllowed = new LokaiSkillName[] { LokaiSkillName.Linguistics };
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.ItemID };
            GovernmentType m_GovernmentRequired = GovernmentType.Feudalism;
            TechType[] m_TechsRequired = new TechType[] { TechType.Writing };
            string m_Description = "Alphabet temporary description.";
            string m_Name = "Alphabet";
            int m_Cost = 80000;
            int m_CorruptionFactor = 1;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 1;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_lSkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




