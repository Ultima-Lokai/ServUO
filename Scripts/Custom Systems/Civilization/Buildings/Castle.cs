using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class Castle
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Order;
            BuildingType m_BuildingName = BuildingType.Castle;
            GovernmentType m_GovernmentRequired = GovernmentType.Feudalism;
            TechType m_TechRequired = TechType.Monarchy;
            string m_Description = "Castle temporary description.";
            string m_Name = "Castle";
            int m_Cost = 150000;
            int m_CorruptionFactor = 2;
            int m_WasteFactor = -2;
            int m_SatisfactionFactor = 2;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 2;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


