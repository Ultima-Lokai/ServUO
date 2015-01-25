using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class Bank
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Gold;
            BuildingType m_BuildingName = BuildingType.Bank;
            GovernmentType m_GovernmentRequired = GovernmentType.Monarchy;
            TechType m_TechRequired = TechType.Banking;
            string m_Description = "Bank temporary description.";
            string m_Name = "Bank";
            int m_Cost = 70000;
            int m_CorruptionFactor = -2;
            int m_WasteFactor = 1;
            int m_SatisfactionFactor = 2;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 1;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


