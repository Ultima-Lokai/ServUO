using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class Lighthouse
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Order;
            BuildingType m_BuildingName = BuildingType.Lighthouse;
            GovernmentType m_GovernmentRequired = GovernmentType.Monarchy;
            TechType m_TechRequired = TechType.Shipbuilding;
            string m_Description = "Lighthouse temporary description.";
            string m_Name = "Lighthouse";
            int m_Cost = 60000;
            int m_CorruptionFactor = 2;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 1;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 1;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


