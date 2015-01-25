using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class Docks
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Arms;
            BuildingType m_BuildingName = BuildingType.Docks;
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType m_TechRequired = TechType.Fishing;
            string m_Description = "Docks temporary description.";
            string m_Name = "Docks";
            int m_Cost = 20000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
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


