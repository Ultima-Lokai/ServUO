using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class Colosseum
    {
        public static void Initialize()
        {
            ProductionType m_ProdType = ProductionType.Satisfaction;
            BuildingType m_BuildingName = BuildingType.Colosseum;
            GovernmentType m_GovernmentRequired = GovernmentType.Feudalism;
            TechType m_TechRequired = TechType.Masonry;
            string m_Description = "Colosseum temporary description.";
            string m_Name = "Colosseum";
            int m_Cost = 60000;
            int m_CorruptionFactor = -1;
            int m_WasteFactor = -2;
            int m_SatisfactionFactor = 2;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 3;
            int m_TechnologyFactor = 0;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


