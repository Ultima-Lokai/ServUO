using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class Barracks
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Arms;
            BuildingType m_BuildingName = BuildingType.Barracks;
            GovernmentType m_GovernmentRequired = GovernmentType.Oligarchy;
            TechType m_TechRequired = TechType.Hunting;
            string m_Description = "Barracks temporary description.";
            string m_Name = "Barracks";
            int m_Cost = 40000;
            int m_CorruptionFactor = -1;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 1;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 0;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


