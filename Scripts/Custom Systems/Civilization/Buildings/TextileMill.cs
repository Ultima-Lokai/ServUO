using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class TextileMill
    {
        public static void Initialize()
        {
            ProductionType m_ProdType = ProductionType.Goods;
            BuildingType m_BuildingName = BuildingType.TextileMill;
            GovernmentType m_GovernmentRequired = GovernmentType.Feudalism;
            TechType m_TechRequired = TechType.Weaving;
            string m_Description = "TextileMill temporary description.";
            string m_Name = "TextileMill";
            int m_Cost = 50000;
            int m_CorruptionFactor = 0;
            int m_WasteFactor = 0;
            int m_SatisfactionFactor = 0;
            int m_ProductionFactor = 2;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 0;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


