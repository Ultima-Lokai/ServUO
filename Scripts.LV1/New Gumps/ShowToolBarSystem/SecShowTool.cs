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
    public class SecShowTool : Gump
    {
        private PlayerMobile pm;

        public SecShowTool(PlayerMobile mobile) : base(8, 15)
        {
            pm = mobile;
            Closable = false;
            Disposable = false;
            Dragable = false;
            Resizable = true;
            AddPage(0);
            AddBackground(0, 0x31, 0x27, 0x25, 0x2422);
            AddImageTiled(1, 0x35, 0x24, 0x1f, 0x243a);
            AddAlphaRegion(1, 0x35, 0x24, 0x1f);
            AddButton(8, 0x37, 0x15a5, 0x15a2, 1, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 0:
                    break;

                case 1:
                    pm.CloseGump(typeof(SecShowTool));
                    pm.SendGump(new SecShowToolTwo(pm));
                    break;

                default:
                    return;
            }
        }
    }
}

