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
    public enum StorageType
    {
        Gold = 0, Technology, Construction,
        Timber, Lumber, BuildingMaterials,
        MetalOre, Metals, Parts,
        Grains, Flours, Foodstuffs,
        SheepsWool, SpunWool, WoolCloths,
        RawCotton, CottonFibers, CottonCloths,
        RawFlax, SpunFlax, FlaxCloths,
        StoneOre, Stones, StoneWorks,
        ClayOre, Clay, Pottery
    }

    public class Coffer
    {
        private string m_Owner;
        private int[] m_Quantity;

        [CommandProperty(AccessLevel.GameMaster)]
        public string Owner { get { return m_Owner; } set { m_Owner = value; } }
        #region " Quantities "
        public int GoldQuantity { get { return m_Quantity[0]; } set { m_Quantity[0] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int TechnologyQuantity { get { return m_Quantity[1]; } set { m_Quantity[1] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int ConstructionQuantity { get { return m_Quantity[2]; } set { m_Quantity[2] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int TimberQuantity { get { return m_Quantity[3]; } set { m_Quantity[3] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int LumberQuantity { get { return m_Quantity[4]; } set { m_Quantity[4] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int BuildingMaterialsQuantity { get { return m_Quantity[5]; } set { m_Quantity[5] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int MetalOreQuantity { get { return m_Quantity[6]; } set { m_Quantity[6] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int MetalsQuantity { get { return m_Quantity[7]; } set { m_Quantity[7] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int PartsQuantity { get { return m_Quantity[8]; } set { m_Quantity[8] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int GrainsQuantity { get { return m_Quantity[9]; } set { m_Quantity[9] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int FloursQuantity { get { return m_Quantity[10]; } set { m_Quantity[10] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int FoodstuffsQuantity { get { return m_Quantity[11]; } set { m_Quantity[11] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int SheepsWoolQuantity { get { return m_Quantity[12]; } set { m_Quantity[12] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int SpunWoolQuantity { get { return m_Quantity[13]; } set { m_Quantity[13] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int WoolClothsQuantity { get { return m_Quantity[14]; } set { m_Quantity[14] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int RawCottonQuantity { get { return m_Quantity[15]; } set { m_Quantity[15] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int CottonFibersQuantity { get { return m_Quantity[16]; } set { m_Quantity[16] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int CottonClothsQuantity { get { return m_Quantity[17]; } set { m_Quantity[17] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int RawFlaxQuantity { get { return m_Quantity[18]; } set { m_Quantity[18] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int SpunFlaxQuantity { get { return m_Quantity[19]; } set { m_Quantity[19] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int FlaxClothsQuantity { get { return m_Quantity[20]; } set { m_Quantity[20] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int StoneOreQuantity { get { return m_Quantity[21]; } set { m_Quantity[21] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int StonesQuantity { get { return m_Quantity[22]; } set { m_Quantity[22] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int StoneWorksQuantity { get { return m_Quantity[23]; } set { m_Quantity[23] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int ClayOreQuantity { get { return m_Quantity[24]; } set { m_Quantity[24] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int ClayQuantity { get { return m_Quantity[25]; } set { m_Quantity[25] = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int PotteryQuantity { get { return m_Quantity[26]; } set { m_Quantity[26] = value; } }
        #endregion
        public int[] Quantity { get { return m_Quantity; } set { m_Quantity = value; } }

        public Coffer(string owner, int[] quantity)
        {
            m_Owner = owner;
            m_Quantity = quantity;
        }

        private static int[] m_Capacity = new int[] { 10000000,10000000,10000000,
            1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,
            1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000
        };

        public static int Capacity(StorageType store, CivEntry civ)
        {
            int capacity = m_Capacity[(int)store];

            foreach (TechType tech in civ.Technologies)
            {
                switch (store)
                {
                    case StorageType.Gold: if (tech == TechType.Currency) capacity += 10000000;
                        if (tech == TechType.Banking) capacity += 10000000; break;
                    case StorageType.Construction: if (tech == TechType.Construction) capacity += 10000000;
                        if (tech == TechType.Engineering) capacity += 10000000; break;
                    case StorageType.Grains:
                    case StorageType.Flours:
                    case StorageType.Foodstuffs: if (tech == TechType.Agriculture) capacity += 1000; break;
                    default: if (tech == TechType.Construction) capacity += 1000; 
                        if (tech == TechType.Engineering) capacity += 1000; break;
                }
            }
            foreach (BuildingType building in civ.Buildings)
            {
                switch (store)
                {
                    case StorageType.Gold: if (building == BuildingType.Bank) capacity += 10000000; break;
                    case StorageType.Technology: if (building == BuildingType.University) capacity += 10000000; break;
                    case StorageType.Timber:
                    case StorageType.Lumber:
                    case StorageType.BuildingMaterials: if (building == BuildingType.LumberMill) capacity += 1000; break;
                    case StorageType.SheepsWool:
                    case StorageType.SpunWool:
                    case StorageType.WoolCloths:
                    case StorageType.RawCotton:
                    case StorageType.CottonFibers:
                    case StorageType.CottonCloths:
                    case StorageType.RawFlax:
                    case StorageType.SpunFlax:
                    case StorageType.FlaxCloths: if (building == BuildingType.TextileMill) capacity += 1000; break;
                    case StorageType.Grains:
                    case StorageType.Flours:
                    case StorageType.Foodstuffs: if (building == BuildingType.Granary) capacity += 1000; break;
                    case StorageType.MetalOre:
                    case StorageType.Metals:
                    case StorageType.Parts: if (building == BuildingType.IronWorks) capacity += 1000; break;
                    case StorageType.StoneOre:
                    case StorageType.Stones:
                    case StorageType.StoneWorks: if (building == BuildingType.StoneWorks) capacity += 1000; break;
                    default: break;
                }
                int stor = (int)store;
                if (building == BuildingType.Castle && stor > 2) capacity += 2000;
            }
            double factor = (double)capacity;
            switch (civ.Government)
            {
                case GovernmentType.Anarchy: factor *= 0.5; break;
                case GovernmentType.Oligarchy: factor *= 0.85; break;
                case GovernmentType.Communism: factor *= 1.0; break;
                case GovernmentType.Feudalism: factor *= 1.2; break;
                case GovernmentType.Monarchy: factor *= 1.35; break;
                case GovernmentType.Theocracy: factor *= 1.5; break;
                case GovernmentType.Republic: factor *= 1.75; break;
                case GovernmentType.Democracy: factor *= 2.0; break;
                default: break;
            }
            capacity = (int)factor;
            return capacity;
        }
    }
}