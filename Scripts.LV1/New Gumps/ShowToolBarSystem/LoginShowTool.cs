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
using Server.Gumps;
using Server.Mobiles;

namespace Server
{
    public class LoginShowTool
    {
        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(OnLogin);
        }

        private static void OnLogin(LoginEventArgs e)
        {
            if (e.Mobile is PlayerMobile)
            {
                PlayerMobile pm = e.Mobile as PlayerMobile;
                pm.CloseGump(typeof(ShowTool));
                pm.SendGump(new ShowTool(pm));
                pm.CloseGump(typeof(SecShowTool));
                pm.SendGump(new SecShowTool(pm));
            }
        }
    }
}

