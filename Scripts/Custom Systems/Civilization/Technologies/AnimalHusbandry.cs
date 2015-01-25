using System;
using Server;

namespace Server.UOC.Technologies
{
    public sealed class AnimalHusbandry
    {
        public static void Initialize()
        {
            TechType m_TechType = TechType.AnimalHusbandry;
            SkillName[] m_SkillsAllowed = new SkillName[] { SkillName.AnimalLore, SkillName.AnimalTaming, SkillName.Veterinary };
            GovernmentType m_GovernmentRequired = GovernmentType.Oligarchy;
            TechType[] m_TechsRequired = new TechType[] { TechType.Horsebackriding };
            string m_Description = "AnimalHusbandry temporary description.";
            string m_Name = "AnimalHusbandry";
            int m_Cost = 40000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 1;
            int m_TechnologyFactor = 1;

            UOC.Technology.Register(new Technology(m_TechType, m_SkillsAllowed, m_GovernmentRequired,
                m_TechsRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor,
                m_SatisfactionFactor, m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}




