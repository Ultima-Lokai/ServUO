using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class CourtHouse
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Order;
            BuildingType m_BuildingName = BuildingType.CourtHouse;
            GovernmentType m_GovernmentRequired = GovernmentType.Oligarchy;
            TechType m_TechRequired = TechType.CodeOfLaws;
            string m_Description = "CourtHouse temporary description.";
            string m_Name = "CourtHouse";
            int m_Cost = 30000;
            int m_CorruptionFactor = 3;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 0;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}

