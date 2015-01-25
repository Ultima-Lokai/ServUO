using System;
using System.Collections.Generic;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Engines.XmlSpawner2;
using Server.UOC.Items;
using Server.UOC.Concepts;

namespace Server.UOC
{
    public class Civilopedia : Gump
    {
        public enum Category
        {
            Buildings, Governments, Technology, Concepts, General, Production, Satisfaction, Waste, Corruption
        }

        private static Category Parse(string category)
        {
            if (Match(category, "build")) return Category.Buildings;
            if (Match(category, "gov")) return Category.Governments;
            if (Match(category, "tech")) return Category.Technology;
            if (Match(category, "conc")) return Category.Concepts;
            return Category.General;
        }

        public Civilopedia(Mobile from)
            : this(from, "General")
        {
        }

        public Civilopedia(Mobile from, string category)
            : this(from, Parse(category), 1)
        {
        }

        private Mobile m;
        private Category cat;
        private int m_Page;
        private Hashtable table = new Hashtable();

        public Civilopedia(Mobile from, Category category, int page)
            : base(50, 50)
        {
            GumpButtonType Greply = GumpButtonType.Reply;
            m = from;
            cat = category;
            int pages = 0, fpage = 0;
            m_Page = page;
            int X = 320, Y = 440;

            m.CloseGump(typeof(Civilopedia));

			AddPage( 0 );
			AddBackground( 0, 0, 476, 480, 0x13BE );

            AddLabel(10, 7, 2100, "Civilopedia");
            AddReplyEntry(Category.General.ToString(), (int)ID.General, 27, 50);
            AddReplyEntry(Category.Buildings.ToString(), (int)ID.Buildings, 27, 80);
            AddReplyEntry(Category.Governments.ToString(), (int)ID.Governments, 27, 110);
            AddReplyEntry(Category.Technology.ToString(), (int)ID.Technology, 27, 140);
            AddReplyEntry(Category.Concepts.ToString(), (int)ID.Concepts, 27, 170);
            AddReplyEntry(Category.Production.ToString(), (int)ID.Production, 37, 200);
            AddReplyEntry(Category.Satisfaction.ToString(), (int)ID.Satisfaction, 37, 230);
            AddReplyEntry(Category.Waste.ToString(), (int)ID.Waste, 37, 260);
            AddReplyEntry(Category.Corruption.ToString(), (int)ID.Corruption, 37, 290);
            if (m_Page < 100)
            {
                switch (cat)
                {
                    case Category.Buildings:
                        {
                            table = UOC.Building.Table;
                            Building[] blds = new Building[table.Count];
                            table.Values.CopyTo(blds, 0);
                            for (int i = 0; i < blds.Length; i++)
                            {
                                if (Y < 25) { Y = 440; X = 160; }
                                AddReplyEntry(blds[i].BuildingName.ToString(), 100 + (int)blds[i].BuildingName, X, Y);
                                Y -= 20;
                            }
                            break;
                        }
                    case Category.Governments:
                        {
                            table = UOC.Government.Table;
                            Government[] govs = new Government[table.Count];
                            table.Values.CopyTo(govs, 0);
                            for (int i = 0; i < govs.Length; i++)
                            {
                                if (Y < 25) { Y = 440; X = 160; }
                                AddReplyEntry(govs[i].GovType.ToString(), 200 + (int)govs[i].GovType, X, Y);
                                Y -= 20;
                            }
                            break;
                        }
                    case Category.Technology:
                        {
                            table = UOC.Technology.Table;
                            Technology[] tecs = new Technology[table.Count];
                            table.Values.CopyTo(tecs, 0);
                            for (int i = 0; i < tecs.Length; i++)
                            {
                                if (Y < 25) { Y = 440; X = 160; }
                                AddReplyEntry(tecs[i].Name, 300 + (int)tecs[i].TechName, X, Y);
                                Y -= 20;
                            }
                            break;
                        }
                    case Category.Concepts:
                    case Category.General: pages = 4; break;
                }
            }
            else
            {
                switch (cat)
                {
                    case Category.Buildings:
                        {
                            pages = 100; fpage = 101;
                            table = UOC.Building.Table;
                            Building[] blds = new Building[table.Count];
                            table.Values.CopyTo(blds, 0);
                            for (int i = 0; i < blds.Length; i++)
                            {
                                pages++;
                                if (m_Page == ((int)blds[i].BuildingName + 100))
                                {
                                    AddHtml(115, 60, 360, 340, Building.AllLabels(blds[i].BuildingName), false, true);
                                }
                            }
                            break;
                        }
                    case Category.Governments:
                        {
                            pages = 200; fpage = 201;
                            table = UOC.Government.Table;
                            Government[] govs = new Government[table.Count];
                            table.Values.CopyTo(govs, 0);
                            for (int i = 0; i < govs.Length; i++)
                            {
                                pages++;
                                if (m_Page == ((int)govs[i].GovType + 200))
                                {
                                    AddHtml(115, 60, 360, 340, Government.AllLabels(govs[i].GovType), false, true);
                                }
                            }
                            break;
                        }
                    case Category.Technology:
                        {
                            pages = 299; fpage = 300;
                            table = UOC.Technology.Table;
                            Technology[] tecs = new Technology[table.Count];
                            table.Values.CopyTo(tecs, 0);
                            for (int i = 0; i < tecs.Length; i++)
                            {
                                pages++;
                                if (m_Page == ((int)tecs[i].TechName + 300))
                                {
                                    AddHtml(115, 60, 360, 340, Technology.AllLabels(tecs[i].TechName), false, true);
                                }
                            }
                            break;
                        }
                    case Category.Concepts:
                    case Category.General: pages = 4; break;
                }
                if (m_Page < pages) AddButton(452, 417, 2224, 2224, (int)ID.Next, Greply, 0); // Next Page
                if (m_Page > fpage) AddButton(15, 417, 2223, 2223, (int)ID.Previous, Greply, 0); // Previous Page
            }

            AddButton(420, 10, 22124, 22124, (int)ID.TechChart, Greply, 0); // Chart Button, opens Tech Tree
            AddLabel(400, 35, 134, "Tech Tree");
			//AddImage( 170, 4, 0x58A ); //Castle in the clouds
        }

        private void AddReplyEntry(string name, int page, int x, int y)
        {
            int X = x, Y = y;
            AddLabel(X, Y, 2124, name);
            AddButton(X - 25, Y, 0x151A, 0x151A, page, GumpButtonType.Reply, 0);
        }

        private static bool Match(string compare, string with)
        {
            return compare.Trim().ToLower().Contains(with);
        }

        private enum ID
        {
            LastItem = 499, Next, Previous, General, Technology, Buildings, Governments,
            Concepts, Production, Satisfaction, Waste, Corruption, TechChart
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 0) return;
            switch (info.ButtonID)
            {
                case (int)ID.Next: m.SendGump(new Civilopedia(m, cat, m_Page + 1)); break;
                case (int)ID.Previous: m.SendGump(new Civilopedia(m, cat, m_Page - 1)); break;
                case (int)ID.Buildings: m.SendGump(new Civilopedia(m, Category.Buildings, 1)); break;
                case (int)ID.Governments: m.SendGump(new Civilopedia(m, Category.Governments, 1)); break;
                case (int)ID.Technology: m.SendGump(new Civilopedia(m, Category.Technology, 1)); break;
                case (int)ID.General: m.SendGump(new Civilopedia(m, Category.General, 1)); break;
                case (int)ID.Concepts: m.SendGump(new Civilopedia(m, Category.Concepts, 1)); break;
                case (int)ID.Production: m.SendGump(new Civilopedia(m, Category.Concepts, 1)); break;
                case (int)ID.Satisfaction: m.SendGump(new Civilopedia(m, Category.Concepts, 2)); break;
                case (int)ID.Waste: m.SendGump(new Civilopedia(m, Category.Concepts, 3)); break;
                case (int)ID.Corruption: m.SendGump(new Civilopedia(m, Category.Concepts, 4)); break;
                case (int)ID.TechChart: m.SendGump(new TechChartGump()); break;
            }
            if (info.ButtonID < (int)ID.LastItem) m.SendGump(new Civilopedia(m, cat, info.ButtonID));
        }
    }
}

