using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class Granary
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Food;
            BuildingType m_BuildingName = BuildingType.Granary;
            GovernmentType m_GovernmentRequired = GovernmentType.None;
            TechType m_TechRequired = TechType.Pottery;
            string m_Description = "Granary temporary description.";
            string m_Name = "Granary";
            int m_Cost = 10000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 1;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 1;
            int m_TradeFactor = 1;
            int m_TechnologyFactor = 0;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


