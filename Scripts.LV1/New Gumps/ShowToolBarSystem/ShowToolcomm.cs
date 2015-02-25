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
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

public class ShowToolcomm : Gump
{
    private PlayerMobile pm;

    public ShowToolcomm(PlayerMobile owner)
        : base(0, 50)
    {
        pm = owner;
        Closable = true;
        Disposable = true;
        Dragable = true;
        Resizable = true;
        AddPage(0);
        AddBackground(15, 0x1d, 0xb7, 140, 0x251c);
        AddImageTiled(0x11, 0x23, 0xb2, 140, 0xa8e);
        AddAlphaRegion(0x11, 0x23, 0xb2, 140);
        AddItem(0x6d, 0x26, 0x2234);
        AddLabel(0x16, 0x2c, 50, "Dream World");
        AddLabel(0x1f, 70, 0x20, "Command Set");
        AddButton(0x19, 90, 0x846, 0x845, 5, GumpButtonType.Reply, 0);
        AddLabel(50, 90, 0x40, "Player Government Help");
        AddButton(0x19, 130, 0xfb1, 0xfb3, 6, GumpButtonType.Reply, 0);
        AddLabel(80, 130, 0x40, "Close");
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        int[] numArray = new int[1];
        if (info.ButtonID == 5)
        {
            pm.CloseGump(typeof(ShowToolcomm));
            pm.SendGump(new ShowToolcomm(pm));
            pm.DoSpeech("Player Government Help", numArray, 0, 20);
            CommandSystem.Handle(pm,"[GovHelp");
        }
        if (info.ButtonID == 6)
        {
            pm.CloseGump(typeof(ShowToolcomm));
            pm.Say("Closed.");
        }
    }
}