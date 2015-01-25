using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Calendar
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Calendar;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.SpiritSpeak };
            GovernmentType m_GovernmentRequired = GovernmentType.Theocracy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Astronomy, TechType.Writing };
            string m_Description = "Calendar temporary description.";
            string m_Name = "Calendar";
            int m_Cost = 80000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 1;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}