﻿// ShowTool, StatsGump, and CSkills Toolbar Systems
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
    public class Anatomyt : Gump
    {
        private PlayerMobile pm;

        public Anatomyt(PlayerMobile mobile) : base(0, 0)
        {
            pm = mobile;
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
            AddPage(0);
            AddBackground(0x6c, 0x6c, 0x3a, 0x3a, 0x2422);
            AddButton(0x74, 0x73, 0xee49, 0xee49, 1, GumpButtonType.Reply, 0);
            AddButton(0x97, 0x67, 3, 4, 2, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 1:
                    pm.UseSkill(1);
                    pm.CloseGump(typeof (Anatomyt));
                    pm.SendGump(new Anatomyt(pm));
                    return;

                case 2:
                    pm.CloseGump(typeof (Anatomyt));
                    return;
            }
        }
    }
}

