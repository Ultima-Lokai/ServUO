using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Engines.XmlSpawner2;
using Server.Accounting;
using Server.Mobiles;
using Server.Commands;
using Server.Gumps;
using Server.Network;
using Server.ACC;
using Server.UOC.Concepts;

namespace Server.UOC
{
    public class CivEntry
    {
        private Coffer m_Coffers;
        [CommandProperty(AccessLevel.GameMaster)]
        public Coffer Coffers { get { return m_Coffers; } set { m_Coffers = value; } }
        private string m_Description;
        [CommandProperty(AccessLevel.GameMaster)]
        public string Description { get { return m_Description; } set { m_Description = value; } }
        private Point3D m_StartLocation;
        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D StartLocation { get { return m_StartLocation; } set { m_StartLocation = value; } }
        private Map m_StartMap;
        [CommandProperty(AccessLevel.GameMaster)]
        public Map StartMap { get { return m_StartMap; } set { m_StartMap = value; } }
        private bool m_IsOpen;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsOpen { get { return m_IsOpen; } set { m_IsOpen = value; } }
        private string m_CivName;
        [CommandProperty(AccessLevel.GameMaster)]
        public string Civ { get { return m_CivName; } set { m_CivName = value; } }
        private GovernmentType m_Government;
        [CommandProperty(AccessLevel.GameMaster)]
        public GovernmentType Government { get { return m_Government; } set { m_Government = value; } }
        private ArrayList m_Technologies;
        [CommandProperty(AccessLevel.GameMaster)]
        public ArrayList Technologies { get { return m_Technologies; } set { m_Technologies = value; } }
        private ArrayList m_Buildings;
        [CommandProperty(AccessLevel.GameMaster)]
        public ArrayList Buildings { get { return m_Buildings; } set { m_Buildings = value; } }
        private List<PlayerMobile> m_Citizens;
        public List<PlayerMobile> Citizens { get { return m_Citizens; } set { m_Citizens = value; } }

        public CivEntry(string civ)
        {
            int y = Enum.GetNames(typeof(StorageType)).Length;
            m_Coffers = new Coffer(m_CivName, new int[y]);
            for (int x = 0; x < y; x++) m_Coffers.Quantity[x] = 0;
            m_Description = "No description yet.";
            m_StartLocation = new Point3D(1496, 1628, 10); //Britain, Sweet Dreams Inn
            m_StartMap = Map.Trammel;
            m_IsOpen = true;
            m_CivName = civ;
            m_Government = GovernmentType.Anarchy;
            m_Technologies = new ArrayList();
            m_Technologies.Add(TechType.None);
            m_Buildings = new ArrayList();
            m_Buildings.Add(BuildingType.None);
            m_Citizens = new List<PlayerMobile>();
        }

        public CivEntry(GenericReader reader)
        {
            Deserialize(reader);
        }

        public int AddToCoffer(StorageType store, int quantity)
        {
            int TotalAdded;
            double Added = ((double)quantity * ((double)(Production.TotalProduction(this) + 100.0) / 100.0)
                * ((double)(Corruption.TotalCorruption(this) + 100.0) / 100.0));
			Console.WriteLine("Added = {0} after factoring Production and Corruption.", Added);
            double Extra, Wasted = 0.0;
            int OnHand = m_Coffers.Quantity[(int)store];
			Console.WriteLine("OnHand = {0} ... This is how much the coffer currently holds.", OnHand);
            int Max = Coffer.Capacity(store, this);
			Console.WriteLine("Max = {0} ... This is how much the coffer can hold.", Max);
            if (OnHand + quantity > Max)
            {
                Extra = (double)(OnHand + quantity - Max);
                Wasted = Extra * 0.5 / ((double)(Waste.TotalWaste(this) + 100.0) / 100.0);
            }
            Wasted += Added * ((double)(Waste.TotalWaste(this)) / 100.0);
			Console.WriteLine("Wasted = {0} ... This is how much was wasted.", Wasted);
            double newAdded = Added - Wasted;
			Console.WriteLine("newAdded = Added - Wasted ... {0} = {1} - {2}.", newAdded, Added, Wasted);
            TotalAdded = (int)newAdded;
			Console.WriteLine("TotalAdded = {0} after factoring Waste.", TotalAdded);
            m_Coffers.Quantity[(int)store] += TotalAdded;
            return TotalAdded;
        }

        public bool AllowSkillUse(PlayerMobile from, LokaiSkillName lskill)
        {
            if (StartingSkill(lskill)) return true;
            if (m_Technologies.Contains(TechType.None)) return false;
            for (int x = 0; x < m_Technologies.Count; x++)
            {
                TechType t = (TechType)m_Technologies[x];
                if (Technology.GetTechnology(t).LokaiSkillsAllowed.Length > 0)
                {
                    for (int y = 0; y < Technology.GetTechnology(t).LokaiSkillsAllowed.Length; y++)
                        if (lskill == Technology.GetTechnology(t).LokaiSkillsAllowed[y])
                            return true;
                }
            }
            from.SendMessage("Your civilization has not yet discovered that skill.");
            return false;
        }

        public bool AllowSkillUse(PlayerMobile from, SkillName skill)
        {
            if (StartingSkill(skill)) return true;
            if (m_Technologies.Contains(TechType.None)) return false;
            for (int x = 0; x < m_Technologies.Count; x++)
            {
                TechType t = (TechType)m_Technologies[x];
                if (Technology.GetTechnology(t).SkillsAllowed.Length > 0)
                    for (int y = 0; y < Technology.GetTechnology(t).SkillsAllowed.Length; y++)
                        if (skill == Technology.GetTechnology(t).SkillsAllowed[y]) return true;
            }
            from.SendMessage("Your civilization has not yet discovered that skill.");
            return false;
        }

        public TokenType GetSkillTokenType(PlayerMobile from, LokaiSkillName skill)
        {
            if (skill == LokaiSkillName.AnimalRiding || skill == LokaiSkillName.Butchering || skill == LokaiSkillName.Herblore ||
                skill == LokaiSkillName.PickPocket || skill == LokaiSkillName.Pilfering || skill == LokaiSkillName.Sailing ||
                skill == LokaiSkillName.Skinning || skill == LokaiSkillName.Ventriloquism)
            {
                if (LokaiSkillUtilities.XMLGetSkills(from)[skill].Value >
                    Utility.RandomMinMax(0, (int)LokaiSkillUtilities.XMLGetSkills(from)[skill].Cap))
                    return TokenType.Construction;
                else return TokenType.Technology;
            }

            if (skill == LokaiSkillName.Brewing || skill == LokaiSkillName.BrickLaying || skill == LokaiSkillName.Construction ||
                skill == LokaiSkillName.Cooperage || skill == LokaiSkillName.Framing || skill == LokaiSkillName.Roofing ||
                skill == LokaiSkillName.Spinning || skill == LokaiSkillName.StoneMasonry || skill == LokaiSkillName.TreeCarving ||
                skill == LokaiSkillName.TreeDigging || skill == LokaiSkillName.TreePicking || skill == LokaiSkillName.TreeSapping ||
                skill == LokaiSkillName.Weaving || skill == LokaiSkillName.Woodworking)
                return TokenType.Construction;

            return TokenType.Technology;
        }

        public TokenType GetSkillTokenType(PlayerMobile from, SkillName skill)
        {
            if (skill == SkillName.Tracking || skill == SkillName.Cooking || skill == SkillName.Fishing ||
                skill == SkillName.Healing || skill == SkillName.Camping || skill == SkillName.Alchemy ||
                skill == SkillName.Tinkering || skill == SkillName.Cartography || skill == SkillName.DetectHidden ||
                skill == SkillName.Forensics || skill == SkillName.Herding || skill == SkillName.Magery ||
                skill == SkillName.TasteID || skill == SkillName.Snooping || skill == SkillName.Musicianship ||
                skill == SkillName.Necromancy || skill == SkillName.Chivalry || skill == SkillName.Bushido ||
                skill == SkillName.Ninjitsu || skill == SkillName.Spellweaving)
            {
                if (from.Skills[skill].Value > Utility.RandomMinMax(0, (int)from.Skills[skill].Cap))
                    return TokenType.Construction;
                else return TokenType.Technology;
            }

            if (skill == SkillName.Focus || skill == SkillName.Snooping || skill == SkillName.Begging ||
                skill == SkillName.SpiritSpeak || skill == SkillName.RemoveTrap || skill == SkillName.Lockpicking ||
                skill == SkillName.Anatomy || skill == SkillName.AnimalLore || skill == SkillName.ItemID ||
                skill == SkillName.ArmsLore || skill == SkillName.Peacemaking || skill == SkillName.Parry ||
                skill == SkillName.Discordance || skill == SkillName.EvalInt || skill == SkillName.Provocation ||
                skill == SkillName.MagicResist || skill == SkillName.Tactics || skill == SkillName.Hiding ||
                skill == SkillName.Meditation || skill == SkillName.Stealth)
                return TokenType.Technology;

            if (skill == SkillName.Wrestling || skill == SkillName.Macing || skill == SkillName.Mining ||
                skill == SkillName.Blacksmith || skill == SkillName.Fletching || skill == SkillName.Carpentry ||
                skill == SkillName.Archery || skill == SkillName.Stealing || skill == SkillName.Tailoring ||
                skill == SkillName.Swords || skill == SkillName.Fencing || skill == SkillName.Lumberjacking ||
                skill == SkillName.Mining || skill == SkillName.Inscribe || skill == SkillName.Poisoning ||
                skill == SkillName.AnimalTaming || skill == SkillName.Veterinary)
                return TokenType.Construction;
            return TokenType.Construction;
        }

        public bool StartingSkill(LokaiSkillName skill)
        {
            return false;
        }

        public bool StartingSkill(SkillName skill)
        {
            if (skill == SkillName.Tracking || skill == SkillName.Cooking || skill == SkillName.Fishing ||
                skill == SkillName.Healing || skill == SkillName.Camping || skill == SkillName.Focus ||
                skill == SkillName.Snooping || skill == SkillName.Begging || skill == SkillName.SpiritSpeak ||
                skill == SkillName.RemoveTrap || skill == SkillName.Lockpicking || skill == SkillName.Wrestling ||
                skill == SkillName.Macing || skill == SkillName.Mining)
                return true;
            return false;
        }

        public int GenerateCivTokens(LokaiSkillName skill, PlayerMobile from, TokenType tokenType)
        {
            LokaiSkills skills = LokaiSkillUtilities.XMLGetSkills(from);
            int sk = (int)Math.Ceiling((double)(skills[skill].Value));
            int cap = (int)Math.Ceiling((double)(skills[skill].Cap * 0.66));
            int toGive = 0;
            if (tokenType == TokenType.Construction)
            {
                toGive = (int)Math.Ceiling((double)((sk + sk - cap) / 10));
                if (toGive < 1) toGive = 1;
                toGive += (int)Math.Ceiling((double)(toGive * (from.Str + from.Dex) / Utility.RandomMinMax(50, 80)));
            }
            if (tokenType == TokenType.Technology)
            {
                toGive = (int)Math.Ceiling((double)((cap - sk) / 10));
                if (toGive < 1) toGive = 1;
                toGive += from.Luck < 100 ? 0 : from.Luck < 300 ? 2 : from.Luck < 500 ? 4 : from.Luck < 700 ? 6 : 8;
                toGive = (int)Math.Ceiling((double)(toGive * (from.Int + from.Dex) / Utility.RandomMinMax(80, 130)));
            }
            return toGive;
        }

        public int GenerateCivTokens(SkillName skill, PlayerMobile from, TokenType tokenType)
        {
            int sk = (int)Math.Ceiling((double)(from.Skills[skill].Value));
            int cap = (int)Math.Ceiling((double)(from.Skills[skill].Cap * 0.66));
            int toGive = 0;
            if (tokenType == TokenType.Construction)
            {
                toGive = (int)Math.Ceiling((double)((sk + sk - cap) / 10));
                if (toGive < 1) toGive = 1;
                toGive = (int)Math.Ceiling((double)(toGive * (from.Str + from.Dex) / Utility.RandomMinMax(50, 80)));
            }
            if (tokenType == TokenType.Technology)
            {
                toGive = (int)Math.Ceiling((double)((cap - sk) / 10));
                if (toGive < 1) toGive = 1;
                toGive += from.Luck < 100 ? 0 : from.Luck < 300 ? 2 : from.Luck < 500 ? 4 : from.Luck < 700 ? 6 : 8;
                toGive = (int)Math.Ceiling((double)(toGive * (from.Int + from.Dex) / Utility.RandomMinMax(80, 130)));
            }
            return toGive;
        }

        public bool HasBuilding(BuildingType building)
        {
            return (m_Buildings.Contains(building));
        }

        public void RemoveBuilding(BuildingType building)
        {
            if (m_Buildings.Contains(building)) m_Buildings.Remove(building);
            if (m_Buildings.Count < 1) m_Buildings.Add(BuildingType.None);
        }

        public void AddBuilding(BuildingType building)
        {
            if (m_Buildings.Contains(BuildingType.None))
                m_Buildings.Remove(BuildingType.None);
            m_Buildings.Add(building);
        }

        public void RemoveTechnology(TechType tech)
        {
            if (m_Technologies.Contains(tech)) m_Technologies.Remove(tech);
            if (m_Technologies.Count < 1) m_Technologies.Add(TechType.None);
        }

        public void AddTechnology(TechType tech)
        {
            if (m_Technologies.Contains(TechType.None))
                m_Technologies.Remove(TechType.None);
            m_Technologies.Add(tech);
        }

        public bool HasTechnology(TechType tech)
        {
            return (m_Technologies.Contains(tech));
        }

        public bool HasPrerequisitesFor(GovernmentType gov)
        {
            TechType tech = UOC.Government.GetGovernment(gov).TechRequired;
            if (tech != TechType.None)
            {
                if (!HasTechnology(tech))
                    return false;
            }
            int needed = UOC.Government.GetGovernment(gov).CitizensRequired;
            if (needed > 0)
                if (Citizens.Count < needed)
                    return false;
            return true;
        }

        public bool HasPrerequisitesFor(BuildingType building)
        {
            TechType tech = UOC.Building.GetBuilding(building).TechRequired;
            if (tech != TechType.None)
            {
                if (!HasTechnology(tech))
                    return false;
            }
            GovernmentType govt = UOC.Building.GetBuilding(building).GovernmentRequired;
            if (govt != GovernmentType.Anarchy)
            {
                if (this.Government < govt)
                    return false;
            }
            return true;
        }

        public bool HasPrerequisitesFor(TechType tech)
        {
            GovernmentType govt = UOC.Technology.GetTechnology(tech).GovernmentRequired;
            if (govt != GovernmentType.Anarchy)
            {
                if (this.Government < govt)
                    return false;
            }
            int count = UOC.Technology.GetTechnology(tech).TechsRequired.Length;
            if (UOC.Technology.GetTechnology(tech).TechsRequired[0] != TechType.None)
            {
                for (int x = 0; x < count; x++)
                {
                    if (!HasTechnology(UOC.Technology.GetTechnology(tech).TechsRequired[x]))
                        return false;
                }
            }
            return true;
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); //version

            int y = Enum.GetNames(typeof(StorageType)).Length;
            for (int x = 0; x < y; x++) writer.Write((int)m_Coffers.Quantity[x]);
            writer.Write((string)m_Description);
            writer.Write((Point3D)m_StartLocation);
            writer.Write((Map)m_StartMap);
            writer.Write((bool)m_IsOpen);
            writer.Write((string)m_CivName);
            writer.Write((int)m_Government);
            writer.Write((int)m_Technologies.Count);
            if (m_Technologies.Count > 0)
            {
                for (int x = 0; x < m_Technologies.Count; x++)
                {
                    writer.Write((int)m_Technologies[x]);
                }
            }
            writer.Write((int)m_Buildings.Count);
            if (m_Buildings.Count > 0)
            {
                for (int x = 0; x < m_Buildings.Count; x++)
                {
                    writer.Write((int)m_Buildings[x]);
                }
            }
            writer.Write((int)m_Citizens.Count);
            if (m_Citizens.Count > 0)
            {
                for (int x = 0; x < m_Citizens.Count; x++)
                {
                    writer.WriteMobile<PlayerMobile>(m_Citizens[x]);
                }
            }
        }

        public void Deserialize(GenericReader reader)
        {
            int version = reader.ReadInt();

            int y = Enum.GetNames(typeof(StorageType)).Length;
            m_Coffers = new Coffer(m_CivName, new int[y]);
            for (int x = 0; x < y; x++) m_Coffers.Quantity[x] = reader.ReadInt();
            m_Description = reader.ReadString();
            m_StartLocation = reader.ReadPoint3D();
            m_StartMap = reader.ReadMap();
            m_IsOpen = reader.ReadBool();
            m_CivName = reader.ReadString();
            m_Government = (GovernmentType)reader.ReadInt();

            int count = reader.ReadInt();
            m_Technologies = new ArrayList();
            if (count > 0)
            {
                for (int x = 0; x < count; x++)
                {
                    m_Technologies.Add((TechType)reader.ReadInt());
                }
            }

            count = reader.ReadInt();
            m_Buildings = new ArrayList();
            if (count > 0)
            {
                for (int x = 0; x < count; x++)
                {
                    m_Buildings.Add((BuildingType)reader.ReadInt());
                }
            }
            count = reader.ReadInt();
            m_Citizens = new List<PlayerMobile>();
            if (count > 0)
            {
                for (int x = 0; x < count; x++)
                {
                    m_Citizens.Add((PlayerMobile)reader.ReadMobile<PlayerMobile>());
                }
            }
        }
    }
}