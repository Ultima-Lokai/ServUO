using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Multis;
using Server.Network;
using Server.Gumps;
using Server.ACC.YS;

namespace Server.Commands
{
    public class YardItem2Static
    {
        public static void Initialize()
        {
            CommandSystem.Register("YardItem2Static", AccessLevel.Owner, new CommandEventHandler(YardItem2Static_OnCommand));
            CommandSystem.Register("Y2S", AccessLevel.Owner, new CommandEventHandler(YardItem2Static_OnCommand));
        }

        [Usage("YardItem2Static")]
        [Aliases("Y2S")]
        [Description("Statify a Yard structure")]
        private static void YardItem2Static_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendMessage("Please select the House Sign of the Yard you want to statify");
            e.Mobile.SendMessage("or target yourself to execute the command globally.");
            e.Mobile.Target = new YardSelector();
        }

        public static void Convert2Static(YardItem item)
        {
            Static equivalent = new Static(item.HuedItemID);
            equivalent.Location = item.Location;
            equivalent.Map = item.Map;
            equivalent.Hue = item.Hue;
            item.Delete();
        }

        private class YardSelector : Target
        {
            public YardSelector()
                : base(-1, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is HouseSign)
                {
                    BaseHouse house = ((HouseSign)targeted).Owner;
                    if (house != null && (house.Owner == from || from.AccessLevel >= AccessLevel.Administrator))
                    {
                        IPooledEnumerable eable = house.GetItemsInRange(50);
                        if (eable != null)
                        {
                            List<YardItem> yardItems = new List<YardItem>();
                            foreach (object o in eable)
                            {
                                if (o is YardItem && (o as YardItem).House == house) yardItems.Add(o as YardItem);
                            }
                            for (int i = 0; i < yardItems.Count; i++)
                                Convert2Static(yardItems[i]);
                            from.SendMessage("{0} YardItems processed, and converted to Statics.",
                                yardItems.Count);
                        }
                    }
                    else
                    {
                    }
                }
                else if (targeted == from)
                {
                    from.SendGump(new Yard2StaticGump(from));
                }
                else
                {
                    from.SendMessage("You may only target the House Sign of the Yard you want to statify");
                    from.SendMessage("or target yourself to execute the command globally.");
                }
            }
        }
    }

    public class Yard2StaticGump : Gump
    {
        public Mobile m_From;
        public List<YardItem> feluccaYardItems = new List<YardItem>();
        public List<YardItem> trammelYardItems = new List<YardItem>();
        public List<YardItem> malasYardItems = new List<YardItem>();
        public List<YardItem> ilshenarYardItems = new List<YardItem>();
        public List<YardItem> tokunoYardItems = new List<YardItem>();
        public List<YardItem> termurYardItems = new List<YardItem>();
        public int yardItemsFel = 0;
        public int yardItemsTra = 0;
        public int yardItemsMal = 0;
        public int yardItemsIls = 0;
        public int yardItemsTok = 0;
        public int yardItemsTer = 0;

        public Yard2StaticGump(Mobile from)
            : base(0, 0)
        {

            m_From = from;
            Closable = true;
            Dragable = true;

            AddPage(1);

            AddBackground(0, 0, 455, 260, 5054);
            AddLabel(30, 2, 200, "Select Facets to Convert");

            AddImageTiled(10, 20, 425, 210, 3004);

            foreach (object o in World.Items.Values)
            {
                if (o is YardItem)
                {
                    YardItem item = ((YardItem)o);
                    if (item.Deleted || item.Map == null) continue;

                    if (item.Map == Map.Felucca)
                    {
                        feluccaYardItems.Add(item);
                        yardItemsFel++;
                    }
                    else if (item.Map == Map.Trammel)
                    {
                        trammelYardItems.Add(item);
                        yardItemsTra++;
                    }
                    else if (item.Map == Map.Malas)
                    {
                        malasYardItems.Add(item);
                        yardItemsMal++;
                    }
                    else if (item.Map == Map.Ilshenar)
                    {
                        ilshenarYardItems.Add(item);
                        yardItemsIls++;
                    }
                    else if (item.Map == Map.Tokuno)
                    {
                        tokunoYardItems.Add(item);
                        yardItemsTok++;
                    }
                    else if (item.Map == Map.TerMur)
                    {
                        termurYardItems.Add(item);
                        yardItemsTer++;
                    }
                }
            }

            AddLabel(40, 26, 200, String.Format("Felucca - {0} YardItems to process.", yardItemsFel));
            AddLabel(40, 51, 200, String.Format("Trammel - {0} YardItems to process.", yardItemsTra));
            AddLabel(40, 76, 200, String.Format("Malas - {0} YardItems to process.", yardItemsMal));
            AddLabel(40, 101, 200, String.Format("Ilshenar - {0} YardItems to process.", yardItemsIls));
            AddLabel(40, 126, 200, String.Format("Tokuno - {0} YardItems to process.", yardItemsTok));
            AddLabel(40, 151, 200, String.Format("TerMur - {0} YardItems to process.", yardItemsTer));

            AddCheck(20, 23, 210, 211, true, 101);
            AddCheck(20, 48, 210, 211, true, 102);
            AddCheck(20, 73, 210, 211, true, 103);
            AddCheck(20, 98, 210, 211, true, 104);
            AddCheck(20, 123, 210, 211, true, 105);
            AddCheck(20, 148, 210, 211, true, 106);

            AddButton(30, 234, 247, 249, 1, GumpButtonType.Reply, 0);
            AddButton(100, 234, 241, 243, 0, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            bool felCheck = info.IsSwitched(101);
            bool traCheck = info.IsSwitched(102);
            bool malCheck = info.IsSwitched(103);
            bool ilsCheck = info.IsSwitched(104);
            bool tokCheck = info.IsSwitched(105);
            bool terCheck = info.IsSwitched(106);
            int localCount = 0;
            switch (info.ButtonID)
            {
                case 1:
                    {
                        if (felCheck && yardItemsFel > 0)
                        {
                            for (int i = 0; i < yardItemsFel; i++)
                                YardItem2Static.Convert2Static(feluccaYardItems[i]);
                            m_From.SendMessage("{0} YardItems in Felucca processed, and converted to Statics.",
                                yardItemsFel);
                            localCount += yardItemsFel;
                        }
                        if (traCheck && yardItemsTra > 0)
                        {
                            for (int i = 0; i < yardItemsTra; i++)
                                YardItem2Static.Convert2Static(trammelYardItems[i]);
                            m_From.SendMessage("{0} YardItems in Trammel processed, and converted to Statics.",
                                yardItemsTra);
                            localCount += yardItemsTra;
                        }
                        if (malCheck && yardItemsMal > 0)
                        {
                            for (int i = 0; i < yardItemsMal; i++)
                                YardItem2Static.Convert2Static(malasYardItems[i]);
                            m_From.SendMessage("{0} YardItems in Malas processed, and converted to Statics.",
                                yardItemsMal);
                            localCount += yardItemsMal;
                        }
                        if (ilsCheck && yardItemsIls > 0)
                        {
                            for (int i = 0; i < yardItemsIls; i++)
                                YardItem2Static.Convert2Static(ilshenarYardItems[i]);
                            m_From.SendMessage("{0} YardItems in Ilshenar processed, and converted to Statics.",
                                yardItemsIls);
                            localCount += yardItemsIls;
                        }
                        if (tokCheck && yardItemsTok > 0)
                        {
                            for (int i = 0; i < yardItemsTok; i++)
                                YardItem2Static.Convert2Static(tokunoYardItems[i]);
                            m_From.SendMessage("{0} YardItems in Tokuno processed, and converted to Statics.",
                                yardItemsTok);
                            localCount += yardItemsTok;
                        }
                        if (terCheck && yardItemsTer > 0)
                        {
                            for (int i = 0; i < yardItemsTer; i++)
                                YardItem2Static.Convert2Static(termurYardItems[i]);
                            m_From.SendMessage("{0} YardItems in TerMur processed, and converted to Statics.",
                                yardItemsTer);
                            localCount += yardItemsTer;
                        }
                        if (localCount > 0) m_From.SendMessage("{0} total YardItems converted.", localCount);
                        else m_From.SendMessage("No YardItems were converted.");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}