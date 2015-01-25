using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class IronWorks
    {
        public static void Initialize()
        {
            ProductionType m_ProdType = ProductionType.Goods;
            BuildingType m_BuildingName = BuildingType.IronWorks;
            GovernmentType m_GovernmentRequired = GovernmentType.Communism;
            TechType m_TechRequired = TechType.Metalworking;
            string m_Description = "IronWorks temporary description.";
            string m_Name = "IronWorks";
            int m_Cost = 80000;
            int m_CorruptionFactor = -1;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 4;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 1;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


