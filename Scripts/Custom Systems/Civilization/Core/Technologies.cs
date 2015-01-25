#region Using Directives
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.Factions;
using Server.Regions;
using Server.Accounting;
using Server.Engines.Craft;
using Server.Mobiles;
#endregion

namespace Server.UOC
{
    public enum TechType
    {
        Agriculture, Alphabet, AnimalHusbandry, Archery, Astronomy,
        Banking, Calendar, Chemistry, CodeOfLaws, Communism,
        Construction, Currency, Democracy, Engineering, Farming,
        Firemaking, Fishing, Feudalism, Horsebackriding, Hunting,
        MagicArts, Masonry, Metalworking, Mining, Monarchy, Music,
        Mysticism, Philosophy, Pottery, Religion, Republic, Roadbuilding, 
        Sailing, SeigeEngines, Shipbuilding, StoryTelling, Theology,
        TheWheel, Weaving, Writing, /* If you add Techs, add them here */ None
    }

    public class Technology
    {
        #region Private Variables
        private TechType m_TechName;
        private SkillName[] m_SkillsAllowed;
        private LokaiSkillName[] m_LokaiSkillsAllowed;
        private GovernmentType m_GovernmentRequired;
        private GovernmentType m_GovernmentProvided;
        private TechType[] m_TechsRequired;
        private string m_Description;
        private string m_Name;
        private int m_Cost;
        private int m_CorruptionFactor;
        private int m_WasteFactor;
        private int m_SatisfactionFactor;
        private int m_ProductionFactor;
        private int m_TradeFactor;
        private int m_TechnologyFactor;
        #endregion

        #region Get/Set
        public TechType TechName { get { return m_TechName; } set { m_TechName = value; } }
        public SkillName[] SkillsAllowed { get { return m_SkillsAllowed; } set { m_SkillsAllowed = value; } }
        public LokaiSkillName[] LokaiSkillsAllowed { get { return m_LokaiSkillsAllowed; } set { m_LokaiSkillsAllowed = value; } }
        public GovernmentType GovernmentRequired { get { return m_GovernmentRequired; } set { m_GovernmentRequired = value; } }
        public GovernmentType GovernmentProvided { get { return m_GovernmentProvided; } set { m_GovernmentProvided = value; } }
        public TechType[] TechsRequired { get { return m_TechsRequired; } set { m_TechsRequired = value; } }
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

        public Technology(TechType techName, SkillName[] skillsAllowed, LokaiSkillName[] lskillsAllowed, GovernmentType govreq,
            TechType[] techreqs, string descr, string name, int cost, int corupt, int waste, int satis, int prod, int trad, int tech)
            : this(techName, skillsAllowed, lskillsAllowed, govreq, GovernmentType.None, techreqs, descr, name, cost, corupt, waste, satis, prod, trad, tech)
        {
        }

        public Technology(TechType techName, SkillName[] skillsAllowed, GovernmentType govreq, GovernmentType govprv, TechType[] techreqs,
            string descr, string name, int cost, int corupt, int waste, int satis, int prod, int trad, int tech)
            : this(techName, skillsAllowed, new LokaiSkillName[0], govreq, govprv, techreqs, descr, name, cost, corupt, waste, satis, prod, trad, tech)
        {
        }

        public Technology(TechType techName, LokaiSkillName[] lskillsAllowed, GovernmentType govreq, GovernmentType govprv, TechType[] techreqs,
            string descr, string name, int cost, int corupt, int waste, int satis, int prod, int trad, int tech)
            : this(techName, new SkillName[0], lskillsAllowed, govreq, govprv, techreqs, descr, name, cost, corupt, waste, satis, prod, trad, tech)
        {
        }

        public Technology(TechType techName, SkillName[] skillsAllowed, GovernmentType govreq, TechType[] techreqs,
            string descr, string name, int cost, int corupt, int waste, int satis, int prod, int trad, int tech)
            : this(techName, skillsAllowed, new LokaiSkillName[0], govreq, GovernmentType.None, techreqs, descr, name, cost, corupt, waste, satis, prod, trad, tech)
        {
        }

        public Technology(TechType techName, LokaiSkillName[] lskillsAllowed, GovernmentType govreq, TechType[] techreqs,
            string descr, string name, int cost, int corupt, int waste, int satis, int prod, int trad, int tech)
            : this(techName, new SkillName[0], lskillsAllowed, govreq, GovernmentType.None, techreqs, descr, name, cost, corupt, waste, satis, prod, trad, tech)
        {
        }

        public Technology(TechType techName, SkillName[] skillsAllowed, LokaiSkillName[] lskillsAllowed, GovernmentType govreq, GovernmentType govprv, 
            TechType[] techreqs, string descr, string name, int cost, int corupt, int waste, int satis, int prod, int trad, int tech)
        {
            #region Values Initialized
            m_TechName = techName;
            m_SkillsAllowed = skillsAllowed;
            m_LokaiSkillsAllowed = lskillsAllowed;
            m_GovernmentRequired = govreq;
            m_GovernmentProvided = govprv;
            m_TechsRequired = techreqs;
            m_Description = descr;
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

        public static string AllLabels(TechType tech)
        {
            string c = "<BASEFONT COLOR=#8B0000>";
            string w = "<BASEFONT COLOR=#FAFAD2>";
            StringBuilder sb = new StringBuilder();
            Technology got = Technology.GetTechnology(tech);
            sb.AppendFormat("{0}\n\n" + w + "Cost: " + c + "{1}\n" + w + "CorruptionFactor: " + c + "{2}\n" + w + 
                "WasteFactor: " + c + "{3}\n" + w + "SatisfactionFactor: " + c + "{4}\n",
                got.Name, got.Cost, got.CorruptionFactor, got.WasteFactor, got.SatisfactionFactor);
            sb.AppendFormat("" + w + "ProductionFactor: " + c + "{0}\n" + w + "TradeFactor: " + c + "{1}\n" + w + 
                "TechnologyFactor: " + c + "{2}\n", got.ProductionFactor, got.TradeFactor, got.TechnologyFactor);
            if (got.GovernmentRequired > GovernmentType.Anarchy)
                sb.AppendFormat("" + w + "Requires " + c + "{0} " + w + "government.\n", got.GovernmentRequired.ToString());
            if (got.GovernmentProvided > GovernmentType.Anarchy)
                sb.AppendFormat("" + w + "Provides " + c + "{0} " + w + "government.\n", got.GovernmentProvided.ToString());
            if (got.TechsRequired.Length > 0)
            {
                sb.AppendFormat("" + w + "Requires these Techs: " + c + "{0}", got.TechsRequired[0].ToString());
                if (got.TechsRequired.Length > 1) 
                    for (int x = 1; x < got.TechsRequired.Length; x++)
                        sb.AppendFormat(", {0}", got.TechsRequired[x].ToString());
            }
            if (got.SkillsAllowed.Length > 0)
            {
                sb.Append("\n" + w + "Allows these skills:");
                for (int x = 0; x < got.SkillsAllowed.Length; x++)
                    sb.AppendFormat("\n   " + c + "{0}", got.SkillsAllowed[x].ToString());
            }
            if (got.LokaiSkillsAllowed.Length > 0)
            {
                sb.Append("\n" + w + "Allows these new skills:");
                for (int x = 0; x < got.LokaiSkillsAllowed.Length; x++)
                    sb.AppendFormat("\n   " + c + "{0}", got.LokaiSkillsAllowed[x].ToString());
            }
            sb.AppendFormat("\n" + w + "{0}", got.Description);
            return sb.ToString();
        }

        #region Table Definition
        private static Hashtable m_Table = new Hashtable();
        public static Hashtable Table { get { return m_Table; } }

        public static Technology GetTechnology(TechType techName)
        {
            return (m_Table[techName] as Technology);
        }

        public static void Register(Technology techEntry)
        {
            if (!m_Table.ContainsKey(techEntry.TechName))
                m_Table[techEntry.TechName] = techEntry;
            else
                throw new Exception(String.Format("Technology {0} exists.", techEntry.TechName.ToString()));
        }
        #endregion

    }
}