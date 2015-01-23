using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
    public class FubarHelpGump : Gump
    {
        public FubarHelpGump(Mobile from)
            : this(from, 5, 33)
        {
        }

        public FubarHelpGump(Mobile from, int x, int y)
            : base(0, 0)
        {
            from.CloseGump(typeof(FubarHelpGump));
            //This gump no longer used. --> Help gump moved to FullToolbar.cs
        }
    }
}