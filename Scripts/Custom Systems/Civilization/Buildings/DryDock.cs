using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class DryDock
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Goods;
            BuildingType m_BuildingName = BuildingType.DryDock;
            GovernmentType m_GovernmentRequired = GovernmentType.Oligarchy;
            TechType m_TechRequired = TechType.Construction;
            string m_Description = "DryDock temporary description.";
            string m_Name = "DryDock";
            int m_Cost = 90000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 4;
            int m_TradeFactor = 3;
            int m_TechnologyFactor = 0;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}

