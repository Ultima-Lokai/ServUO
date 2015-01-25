#region Using Directives
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.ACC;
#endregion

namespace Server.UOC
{
    /*
        NAME        REQ# PLAYERS    WHO MAKES LAWS?             BENEFITS/DISADVANTAGES
        --------------------------------------------------------------------------------------------------------------------
        Anarchy     1               Nobody				
        Oligarchy   4               one person                  Basically like Anarchy, but can make Laws
        Communism   16              1-9 leaders                 No corruption, but reduced Satisfaction
        Feudal      32              2-12 landowners             Increased production, but high corruption and waste
        Monarchy    32              the King                    Moderate Satisfaction and Production, low Corruption
        Theocracy   40              1-4 Bishops/Priests         Highest corruption, but Enormous Production and Satisfaction
        Republic    72              6+ Reps 1/ per 12 people    High Production and Trade. Moderate Satisfaction.
        Democracy   144             12+ Reps 1/ per 12 people   Very high Producion/Trade. Very low Satisfaction during War.
    */

    public enum GovernmentType
    {
        None, Anarchy, Oligarchy, Communism, Feudalism, Monarchy,
        Theocracy, Republic, Democracy
    }

    public enum LawMakers
    {
        Leader, LandOwner, Mayor, King,
        Bishop, Representative, Dictator, General
    }

    public class Government
    {
        #region Private Variables
        private GovernmentType m_GovType;
        private TechType m_TechRequired;
        private string m_Description;
        private string m_Name;
        private int m_CitizensRequired;
        private int m_CorruptionFactor;
        private int m_WasteFactor;
        private int m_SatisfactionFactor;
        private int m_ProductionFactor;
        private int m_TradeFactor;
        private int m_TechnologyFactor;
        #endregion

        #region Get/Set
        public GovernmentType GovType { get { return m_GovType; } set { m_GovType = value; } }
        public TechType TechRequired { get { return m_TechRequired; } set { m_TechRequired = value; } }
        public string Description { get { return m_Description; } set { m_Description = value; } }
        public string Name { get { return m_Name; } set { m_Name = value; } }
        public int CitizensRequired { get { return m_CitizensRequired; } set { m_CitizensRequired = value; } }
        public int CorruptionFactor { get { return m_CorruptionFactor; } set { m_CorruptionFactor = value; } }
        public int WasteFactor { get { return m_WasteFactor; } set { m_WasteFactor = value; } }
        public int SatisfactionFactor { get { return m_SatisfactionFactor; } set { m_SatisfactionFactor = value; } }
        public int ProductionFactor { get { return m_ProductionFactor; } set { m_ProductionFactor = value; } }
        public int TradeFactor { get { return m_TradeFactor; } set { m_TradeFactor = value; } }
        public int TechnologyFactor { get { return m_TechnologyFactor; } set { m_TechnologyFactor = value; } }
        #endregion

        public Government(GovernmentType type, TechType techreq, string desc, string name, int citreqs, int corupt,
            int waste, int satis, int prod, int trad, int tech)
        {
            #region Values Initialized
            m_GovType = type;
            m_TechRequired = techreq;
            m_Description = desc;
            m_Name = name;
            m_CitizensRequired = citreqs;
            m_CorruptionFactor = corupt;
            m_WasteFactor = waste;
            m_SatisfactionFactor = satis;
            m_ProductionFactor = prod;
            m_TradeFactor = trad;
            m_TechnologyFactor = tech;
            #endregion
        }

        public static string AllLabels(GovernmentType govt)
        {
            string c = "<BASEFONT COLOR=#8B0000>";
            string w = "<BASEFONT COLOR=#FAFAD2>";
            StringBuilder sb = new StringBuilder();
            Government got = Government.GetGovernment(govt);
            sb.AppendFormat("{0}\n\n" + w + "CorruptionFactor: " + c + "{1}\n" + w + "WasteFactor: " + c + "{2}\n" + w + 
                "SatisfactionFactor: " + c + "{3}\n", got.Name, got.CorruptionFactor, got.WasteFactor, got.SatisfactionFactor);
            sb.AppendFormat("" + w + "ProductionFactor: " + c + "{0}\n" + w + "TradeFactor: " + c + "{1}\n" + w + 
                "TechnologyFactor: " + c + "{2}\n", got.ProductionFactor, got.TradeFactor, got.TechnologyFactor);
            sb.AppendFormat("" + w + "Required Technology: " + c + "{0}\n", got.TechRequired);
            sb.AppendFormat("" + w + "{0}", got.Description);
            return sb.ToString();
        }

        #region Table Definition
        private static Hashtable m_Table = new Hashtable();
        public static Hashtable Table { get { return m_Table; } }

        public static Government GetGovernment(GovernmentType govType)
        {
            return (m_Table[govType] as Government);
        }

        public static void Register(Government govEntry)
        {
            if (!m_Table.ContainsKey(govEntry.GovType))
                m_Table[govEntry.GovType] = govEntry;
            else
                throw new Exception(String.Format("Government {0} exists.", govEntry.GovType.ToString()));
        }
        #endregion

    }
}