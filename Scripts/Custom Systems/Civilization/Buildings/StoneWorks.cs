using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class StoneWorks
    {
        public static void Initialize()
        {
            ProductionType m_ProdType = ProductionType.Goods;
            BuildingType m_BuildingName = BuildingType.StoneWorks;
            GovernmentType m_GovernmentRequired = GovernmentType.Communism;
            TechType m_TechRequired = TechType.Masonry;
            string m_Description = "StoneWorks temporary description.";
            string m_Name = "StoneWorks";
            int m_Cost = 60000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 4;
            int m_TradeFactor = 0;
            int m_TechnologyFactor = 0;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


