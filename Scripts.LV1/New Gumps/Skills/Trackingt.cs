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
using System;

namespace Server.Gumps
{
    public class Trackingt : Gump
    {
        public Trackingt(PlayerMobile pm) : base(0, 0)
        {
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = true;
            AddPage(0);
            AddBackground(0x6c, 0x6c, 0x3a, 0x3a, 0x2422);
            AddButton(0x74, 0x73, 0xee50, 0xee50, 1, GumpButtonType.Reply, 0);
            AddButton(0x97, 0x67, 3, 4, 2, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            PlayerMobile pm = sender.Mobile as PlayerMobile;
            switch (info.ButtonID)
            {
                case 1:
                    pm.UseSkill(0x26);
                    pm.CloseGump(typeof(Trackingt));
                    pm.SendGump(new Trackingt(pm));
                    return;

                case 2:
                    pm.CloseGump(typeof(Trackingt));
                    return;
            }
        }
    }
}

