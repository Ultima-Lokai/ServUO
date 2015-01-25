using System;
using Server;

namespace Server.UOC.Buildings
{
    public sealed class University
    {
        public static void Initialize()
        {
			ProductionType m_ProdType = ProductionType.Technology;
            BuildingType m_BuildingName = BuildingType.University;
            GovernmentType m_GovernmentRequired = GovernmentType.Communism;
            TechType m_TechRequired = TechType.Calendar;
            string m_Description = "University temporary description.";
            string m_Name = "University";
            int m_Cost = 100000;
            int m_CorruptionFactor = 1;
            int m_WasteFactor = -1;
            int m_SatisfactionFactor = 2;
            int m_ProductionFactor = 0;
            int m_TradeFactor = 2;
            int m_TechnologyFactor = 4;

            UOC.Building.Register(new Building(m_ProdType, m_BuildingName, m_GovernmentRequired,
                m_TechRequired, m_Description, m_Name, m_Cost, m_CorruptionFactor, m_WasteFactor, m_SatisfactionFactor,
                m_ProductionFactor, m_TradeFactor, m_TechnologyFactor));
        }
    }
}


