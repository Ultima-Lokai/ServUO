using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class Music
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.Music;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.Musicianship };
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.StoryTelling };
            string m_Description = "Music temporary description.";
            string m_Name = "Music";
            int m_Cost = 40000;
            int m_CorruptionFactor = 2;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = 4;
            int m_ProductionFactor = -2;
            int m_TradeFactor = 1;
            int m_TechnologyFactor = 2;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




