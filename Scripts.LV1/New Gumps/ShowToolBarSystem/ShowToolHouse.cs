// ShowTool, StatsGump, and CSkills Toolbar Systems
// Written for Free Ultima Online Emulation Shards
/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
    public class ShowToolHouse : Gump
    {
        private PlayerMobile pm;

        public ShowToolHouse(PlayerMobile owner)
            : base(0, 50)
        {
            pm = owner;
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = true;
            AddPage(0);
            AddBackground(15, 0x1d, 0x98, 0x12d, 0x251c);
            AddImageTiled(0x11, 0x23, 0x94, 0x125, 0xa8e);
            AddAlphaRegion(0x11, 0x23, 0x94, 0x125);
            AddItem(0x6d, 0x26, 0x2300);
            AddLabel(0x16, 0x2c, 0x40, "Dream World");
            AddLabel(0x1f, 70, 0x40, "Housing Commands");
            AddButton(0x19, 120, 0x846, 0x845, 1, GumpButtonType.Reply, 0);
            AddButton(0x19, 150, 0x846, 0x845, 2, GumpButtonType.Reply, 0);
            AddButton(0x19, 180, 0x846, 0x845, 3, GumpButtonType.Reply, 0);
            AddButton(0x19, 210, 0x846, 0x845, 4, GumpButtonType.Reply, 0);
            AddButton(0x19, 240, 0x846, 0x845, 5, GumpButtonType.Reply, 0);
            AddButton(0x19, 270, 0x846, 0x845, 6, GumpButtonType.Reply, 0);
            AddLabel(50, 0x76, 0x40, "Lock Down");
            AddLabel(50, 0x94, 0x40, "Release");
            AddLabel(50, 0xb2, 0x40, "Set Security");
            AddLabel(50, 0xd0, 0x40, "Remove Security");
            AddLabel(50, 0xee, 0x40, "Ban");
            AddLabel(50, 0x10c, 0x40, "Place Trash Barrel");
            AddButton(0x19, 0x128, 0xfb1, 0xfb3, 7, GumpButtonType.Reply, 0);
            AddLabel(80, 0x129, 0x40, "Close");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            int[] numArray = new int[] { 0x23 };
            int[] numArray2 = new int[] { 0x24 };
            int[] numArray3 = new int[] { 0x25 };
            int[] numArray4 = new int[] { 0x26 };
            int[] numArray5 = new int[] { 0x34 };
            int[] numArray6 = new int[] { 40 };
            if (info.ButtonID == 1)
            {
                pm.CloseGump(typeof(ShowToolHouse));
                pm.SendGump(new ShowToolHouse(pm));
                pm.DoSpeech("*Select the items you wish to Lock Down*", numArray, 0, 20);
                pm.Say("i wish to lock this down");
            }
            if (info.ButtonID == 2)
            {
                pm.CloseGump(typeof(ShowToolHouse));
                pm.SendGump(new ShowToolHouse(pm));
                pm.DoSpeech("*Select the items you wish to Release*", numArray2, 0, 20);
                pm.Say("i wish to release this");
            }
            if (info.ButtonID == 3)
            {
                pm.CloseGump(typeof(ShowToolHouse));
                pm.SendGump(new ShowToolHouse(pm));
                pm.DoSpeech("*Select the items you wish to Secure*", numArray3, 0, 20);
                pm.Say("i wish to secure this");
            }
            if (info.ButtonID == 4)
            {
                pm.CloseGump(typeof(ShowToolHouse));
                pm.SendGump(new ShowToolHouse(pm));
                pm.DoSpeech("*Select the items you wish to remove Security from*", numArray4, 0, 20);
                pm.Say("i wish to unsecure this");
            }
            if (info.ButtonID == 5)
            {
                pm.CloseGump(typeof(ShowToolHouse));
                pm.SendGump(new ShowToolHouse(pm));
                pm.DoSpeech("*Select who you want to ban*", numArray5, 0, 20);
                pm.Say("i ban thee");
            }
            if (info.ButtonID == 6)
            {
                pm.CloseGump(typeof(ShowToolHouse));
                pm.SendGump(new ShowToolHouse(pm));
                pm.DoSpeech("*Select the location for a Trash Barrel*", numArray6, 0, 20);
                pm.Say("i wish to place a trash barrel");
            }
            if (info.ButtonID == 7)
            {
                pm.SendMessage("You close the Housing Command Bar.");
            }
        }
    }
}

