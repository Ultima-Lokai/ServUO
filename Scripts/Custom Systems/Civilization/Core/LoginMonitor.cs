using System;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Network;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Engines.XmlSpawner2;

namespace Server.UOC
{
    public class LoginMonitor
    {
        public static void Initialize()
        {
            // Register our event handlers
            EventSink.Login += new LoginEventHandler(EventSink_Login);
        }

        private static void EventSink_Login(LoginEventArgs args)
        {
            CitizenAttachment ca = XmlAttach.FindAttachment(args.Mobile, typeof(CitizenAttachment)) as CitizenAttachment;
            if (UOC.CoreSystem.Running)
            {
                if (args.Mobile is PlayerMobile && (ca == null))
                {
                    ArrayList items = new ArrayList();
                    PlayerMobile m = args.Mobile as PlayerMobile;
                    Point3D oldloc = m.Location;
                    Map oldmap = m.Map;
                    m.Location = new Point3D(5140, 1767, 0);
                    m.Map = Map.Trammel;
                    m.Send(Network.PlayMusic.GetInstance(MusicName.Minoc));
                    foreach (Item item in m.Items)
                        if (item.Layer != Layer.Shirt && item.Layer != Layer.Pants)
                            items.Add(item);
                    Container bank = m.BankBox;
                    if (bank != null)
                    {
                        PreCivChest cont;
                        cont = bank.FindItemByType(typeof(PreCivChest)) as PreCivChest;
                        if (cont == null) cont = new PreCivChest();
                        cont.Hue = 0x489;
                        cont.Name = string.Format("{0}'s Chest of pre-Civ stuff.", m.Name);
                        cont.Movable = false;
                        cont.Visible = false;
                        foreach (Item item in bank.Items)
                            if (item.Parent != cont)
                                items.Add(item);
                        foreach (Item i in items)
                            cont.DropItem(i);
                        bank.DropItem(cont);
                        //chest.Location = new Point3D(15, 160, 0);
                        bank.MaxItems = bank.MaxItems + items.Count;
                    }
                    Container pack = m.Backpack;
                    if (pack == null)
                    {
                        pack = new Backpack();
                        pack.Movable = false;
                        m.AddItem(pack);
                    }
                    pack.DropItem(new RecallStone(oldloc, oldmap));
                    m.SendGump(new LoginGump(m, 1));
                }
            }
            else
            {
                if (ca != null)
                {
                    PlayerMobile cit = args.Mobile as PlayerMobile;
                    BankBox bank = cit.BankBox;
                    foreach (Item item in bank.Items)
                    {
                        if (item is PreCivChest)
                        {
                            item.Visible = true;
                            item.Movable = true;
                        }
                    }
                    bank.MaxItems = 125;
                }
            }
        }
    }
}