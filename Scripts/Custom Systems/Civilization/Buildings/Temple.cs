using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class Temple
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Satisfaction;
            BuildingType m_BuildingName = BuildingType.Temple;
            GovernmentType m_GovernmentRequired = GovernmentType.Anarchy;
            TechType m_TechRequired = TechType.Mysticism;
            string m_Description = "Temple temporary description.";
            string m_Name = "Temple";
            int m_Cost = 20000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 2;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 0;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


