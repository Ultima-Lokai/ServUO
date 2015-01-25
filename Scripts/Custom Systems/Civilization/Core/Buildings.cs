using Server;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using Server.Mobiles;
using Server.Items;
using Server.Multis;

namespace Server.UOC
{
    public enum BuildingType
    {
        None, Barracks, Temple, CourtHouse, Granary, MarketPlace, Bank, Forge, Colosseum, Castle, DryDock,
        IronWorks, StoneWorks, University, TextileMill, Armory, LumberMill, Docks, Lighthouse
    }

    public enum ProductionType
    {
        Arms, Food, Gold, Goods, Order, Satisfaction, Technology
    }

    public class Building
    {
        #region Variables
        private ProductionType m_Product;
        private BuildingType m_BuildingName;
        private GovernmentType m_GovernmentRequired;
        private TechType m_TechRequired;
        private string m_Description;
        private string m_Name;
        private int m_Cost;
        private int m_CorruptionFactor;
        private int m_WasteFactor;
        private int m_SatisfactionFactor;
        private int m_ProductionFactor;
        private int m_TradeFactor;
        private int m_TechnologyFactor;

        public ProductionType Product { get { return m_Product; } set { m_Product = value; } }
        public BuildingType BuildingName { get { return m_BuildingName; } set { m_BuildingName = value; } }
        public GovernmentType GovernmentRequired { get { return m_GovernmentRequired; } set { m_GovernmentRequired = value; } }
        public TechType TechRequired { get { return m_TechRequired; } set { m_TechRequired = value; } }
        public string Description { get { return m_Description; } set { m_Description = value; } }
        public string Name { get { return m_Name; } set { m_Name = value; } }
        public int Cost { get { return m_Cost; } set { m_Cost = value; } }
        public int CorruptionFactor { get { return m_CorruptionFactor; } set { m_CorruptionFactor = value; } }
        public int WasteFactor { get { return m_WasteFactor; } set { m_WasteFactor = value; } }
        public int SatisfactionFactor { get { return m_SatisfactionFactor; } set { m_SatisfactionFactor = value; } }
        public int ProductionFactor { get { return m_ProductionFactor; } set { m_ProductionFactor = value; } }
        public int TradeFactor { get { return m_TradeFactor; } set { m_TradeFactor = value; } }
        public int TechnologyFactor { get { return m_TechnologyFactor; } set { m_TechnologyFactor = value; } }
        #endregion

        public Building(ProductionType product, BuildingType build, GovernmentType govreq, TechType techreq, string desc, string name,
            int cost, int corupt, int waste, int satis, int prod, int trad, int tech)
        {
            #region Values Initialized
            m_Product = product;
            m_BuildingName = build;
            m_GovernmentRequired = govreq;
            m_TechRequired = techreq;
            m_Description = desc;
            m_Name = name;
            m_Cost = cost;
            m_CorruptionFactor = corupt;
            m_WasteFactor = waste;
            m_SatisfactionFactor = satis;
            m_ProductionFactor = prod;
            m_TradeFactor = trad;
            m_TechnologyFactor = tech;
            #endregion
        }

        public static string AllLabels(BuildingType build)
        {
            string c = "<BASEFONT COLOR=#8B0000>";
            string w = "<BASEFONT COLOR=#FAFAD2>";
            StringBuilder sb = new StringBuilder();
            Building got = Building.GetBuilding(build);
            sb.AppendFormat("{0}\n\n" + w + "Cost: " + c + "{1}\n" + w + "CorruptionFactor: " + c + "{2}\n" + w + 
                "WasteFactor: " + c + "{3}\n" + w + "SatisfactionFactor: " + c + "{4}\n",
                got.Name, got.Cost, got.CorruptionFactor, got.WasteFactor, got.SatisfactionFactor);
            sb.AppendFormat("" + w + "ProductionFactor: " + c + "{0}\n" + w + "TradeFactor: " + c + "{1}\n" + w + 
                "TechnologyFactor: " + c + "{2}\n" + w + "Produces: " + c + "{3}\n", got.ProductionFactor,
                got.TradeFactor, got.TechnologyFactor, got.Product);
            sb.AppendFormat("" + w + "Required Government: " + c + "{0}\n" + w + "Required Technology: " + c + 
                "{1}\n", got.GovernmentRequired, got.TechRequired);
            sb.AppendFormat("" + w + "{0}", got.Description);
            return sb.ToString();
        }

        #region Table Definition
        private static Hashtable m_Table = new Hashtable();
        public static Hashtable Table { get { return m_Table; } }

        public static Building GetBuilding(BuildingType building)
        {
            return (m_Table[building] as Building);
        }

        public static void Register(Building civEntry)
        {
            if (!m_Table.ContainsKey(civEntry.BuildingName))
                m_Table[civEntry.BuildingName] = civEntry;
            else
                throw new Exception(String.Format("Building {0} exists.", civEntry.BuildingName.ToString()));
        }
        #endregion

    }

}