using System;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Network;
using Server;
using Server.Items;
using Server.Gumps;
using Server.UOC.Items;
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
                    Container cont = new PreCivChest();
                    cont.Hue = 0x489;
                    cont.Name = string.Format("{0}'s Chest of pre-Civ stuff.", m.Name);
                    cont.Movable = false;
                    //cont.Visible = false;
                    foreach (Item i in items)
                        cont.DropItem(i);
                    Item chest = cont as Item;
                    BankBox bank = m.BankBox;
                    bank.DropItem(chest);
                    //chest.Location = new Point3D(15, 160, 0);
                    bank.MaxItems = 125 + items.Count;
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