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
using Server.Commands;
using Xanthos.Utilities;

namespace Server.Gumps
{
    public class ShowToolTwo : Gump
    {
        private PlayerMobile pm;

        public ShowToolTwo(PlayerMobile owner) : base(8, 15)
        {
            pm = owner;
            Closable = false;
            Disposable = false;
            Dragable = false;
            Resizable = true;
            AddPage(0);
            AddBackground(0x10, 0x13, 630, 0x1d, 0x2422);
            AddImageTiled(0x11, 0x17, 0x273, 0x17, 0x243a);
            AddAlphaRegion(0x11, 0x17, 0x273, 0x17);
            AddBackground(0, 13, 0x27, 0x25, 0x2422);
            AddImageTiled(1, 0x11, 0x24, 0x1f, 0x243a);
            AddAlphaRegion(1, 0x11, 0x24, 0x1f);
            AddButton(8, 0x13, 0x15a5, 0x15a2, 1, GumpButtonType.Reply, 0);
            AddButton(60, 0x19, 0x82f, 0x82e, 2, GumpButtonType.Reply, 0);
            AddLabel(0x55, 0x19, 0x40, "Ghost");
            AddButton(460, 0x19, 0x82f, 0x82e, 8, GumpButtonType.Reply, 0);
            AddLabel(0x1e5, 0x19, 0x40, "Town");
            AddButton(220, 0x19, 0x82f, 0x82e, 4, GumpButtonType.Reply, 0);
            AddLabel(0xf5, 0x19, 0x40, "House");
            AddButton(300, 0x19, 0x82f, 0x82e, 5, GumpButtonType.Reply, 0);
            AddLabel(0x145, 0x19, 0x40, "Sailing");
            AddButton(380, 0x19, 0x82f, 0x82e, 6, GumpButtonType.Reply, 0);
            AddLabel(0x195, 0x19, 0x40, "News");
            AddButton(140, 0x19, 0x82f, 0x82e, 7, GumpButtonType.Reply, 0);
            AddLabel(0xa5, 0x19, 0x40, "Pet Cmds");
            AddButton(540, 0x19, 0x82f, 0x82e, 3, GumpButtonType.Reply, 0);
            AddLabel(0x235, 0x19, 0x40, "MyStats");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            string str = CommandSystem.Prefix;
            int[] numArray = new int[1];
            switch (info.ButtonID)
            {
                case 0:
                    break;

                case 1:
                    pm.CloseGump(typeof(ShowToolTwo));
                    pm.SendGump(new ShowTool(pm));
                    return;

                case 2:
                    pm.CloseGump(typeof(ShowToolThree));
                    pm.SendGump(new ShowToolTwo(pm));
                    pm.SendGump(new ShowToolThree(pm));
                    return;

                case 3:
                    pm.CloseGump(typeof(StatsGump));
                    pm.SendGump(new ShowToolTwo(pm));
                    CommandSystem.Handle(pm, string.Format("{0}mystats", str));
                    break;

                case 4:
                    pm.CloseGump(typeof(ShowToolHouse));
                    pm.SendGump(new ShowToolTwo(pm));
                    pm.SendGump(new ShowToolHouse(pm));
                    return;

                case 5:
                    pm.CloseGump(typeof(ShowToolShip));
                    pm.SendGump(new ShowToolTwo(pm));
                    pm.SendGump(new ShowToolShip(pm));
                    return;

                case 6:
                    pm.CloseGump(typeof(NewsGump));
                    pm.SendGump(new ShowToolTwo(pm));
                    pm.DoSpeech("[motd", numArray, 0, 20);
                    return;

                case 7:
                    pm.CloseGump(typeof(ShowToolAnimal));
                    pm.SendGump(new ShowToolTwo(pm));
                    pm.SendGump(new ShowToolAnimal(pm));
                    return;

                case 8:
                    pm.CloseGump(typeof(ShowToolFour));
                    pm.SendGump(new ShowToolTwo(pm));
                    pm.SendGump(new ShowToolFour(pm));
                    return;

                default:
                    return;
            }
        }
    }
}

