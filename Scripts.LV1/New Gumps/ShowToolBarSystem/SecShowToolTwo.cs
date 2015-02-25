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
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
    public class SecShowToolTwo : Gump
    {
        private PlayerMobile pm;

        public SecShowToolTwo(PlayerMobile mobile)
            : base(8, 15)
        {
            pm = mobile;
            Closable = false;
            Disposable = false;
            Dragable = false;
            Resizable = true;
            AddPage(0);
            AddBackground(0x10, 0x37, 630, 0x1d, 0x2422);
            AddImageTiled(0x11, 0x3b, 0x273, 0x17, 0x243a);
            AddAlphaRegion(0x11, 0x3b, 0x273, 0x17);
            AddBackground(0, 0x31, 0x27, 0x25, 0x2422);
            AddImageTiled(1, 0x35, 0x24, 0x1f, 0x243a);
            AddAlphaRegion(1, 0x35, 0x24, 0x1f);
            AddButton(8, 0x37, 0x15a5, 0x15a2, 1, GumpButtonType.Reply, 0);
            AddButton(140, 0x3d, 0x82f, 0x82e, 2, GumpButtonType.Reply, 0);
            AddLabel(0xa5, 0x3d, 0x40, "Emote");
            AddButton(60, 0x3d, 0x82f, 0x82e, 3, GumpButtonType.Reply, 0);
            AddLabel(0x55, 0x3d, 0x40, "Chat");
            AddButton(220, 0x3d, 0x82f, 0x82e, 4, GumpButtonType.Reply, 0);
            AddLabel(0xf5, 0x3d, 0x40, "Travel");
            AddButton(300, 0x3d, 0x82f, 0x82e, 5, GumpButtonType.Reply, 0);
            AddLabel(0x145, 0x3d, 0x40, "Online");
            AddButton(380, 0x3d, 0x82f, 0x82e, 6, GumpButtonType.Reply, 0);
            AddLabel(0x195, 0x3d, 0x40, "UseTools");
            AddButton(460, 0x3d, 0x82f, 0x82e, 7, GumpButtonType.Reply, 0);
            AddLabel(0x1e5, 0x3d, 0x40, "CSkills");
            AddButton(540, 0x3d, 0x82f, 0x82e, 8, GumpButtonType.Reply, 0);
            AddLabel(0x235, 0x3d, 0x40, "CmdSet");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            string str = CommandSystem.Prefix;
            switch (info.ButtonID)
            {
                case 0:
                    break;

                case 1:
                    pm.CloseGump(typeof(SecShowToolTwo));
                    pm.SendGump(new SecShowTool(pm));
                    return;

                case 2:
                    pm.CloseGump(typeof(SecShowToolTwo));
                    pm.SendGump(new SecShowToolTwo(pm));
                    CommandSystem.Handle(pm, string.Format("{0}e", str));
                    return;

                case 3:
                    pm.CloseGump(typeof(SecShowToolTwo));
                    pm.SendGump(new SecShowToolTwo(pm));
                    CommandSystem.Handle(pm, string.Format("{0}qq", str));
                    return;

                case 4:
                    pm.CloseGump(typeof(SecShowToolTwo));
                    pm.SendGump(new SecShowToolTwo(pm));
                    if (pm.SkillsTotal < 3000)
                    {
                        pm.SendMessage("Your skills must exceed 3000 to use this feature.");
                        return;
                    }
                    if (!pm.Backpack.ConsumeTotal(typeof(Gold), 5000))
                    {
                        pm.SendMessage("You must have 5000 Gold in your pack to do this. Note: This action is not reversible!");
                        return;
                    }
                    CommandSystem.Handle(pm, string.Format("{0}Travel", str));
                    return;

                case 5:
                    pm.CloseGump(typeof(SecShowToolTwo));
                    pm.SendGump(new SecShowToolTwo(pm));
                    CommandSystem.Handle(pm, string.Format("{0}SStat", str));
                    return;

                case 6:
                    pm.CloseGump(typeof(SecShowToolTwo));
                    pm.SendGump(new SecShowToolTwo(pm));
                    pm.SendGump(new UseToolItemsGump(UseToolItemsGump.FindToolItems(pm)));
                    return;

                case 7:
                    pm.CloseGump(typeof(SecShowToolTwo));
                    pm.SendGump(new SecShowToolTwo(pm));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 8:
                    pm.CloseGump(typeof(SecShowToolTwo));
                    pm.SendGump(new SecShowToolTwo(pm));
                    pm.SendGump(new ShowToolcomm(pm));
                    break;

                default:
                    return;
            }
        }
    }
}

