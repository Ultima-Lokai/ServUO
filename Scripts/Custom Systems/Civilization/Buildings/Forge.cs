using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class Forge
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Arms;
            BuildingType m_BuildingName = BuildingType.Forge;
            GovernmentType m_GovernmentRequired = GovernmentType.Feudalism;
            TechType m_TechRequired = TechType.Mining;
            string m_Description = "Forge temporary description.";
            string m_Name = "Forge";
            int m_Cost = 30000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 1;
            int m_TechnologyFactor = 0;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


