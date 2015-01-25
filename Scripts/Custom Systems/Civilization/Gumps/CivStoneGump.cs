using System;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server;
using Server.Items;
using Server.Gumps;
using Server.UOC.Items;

namespace Server.UOC
{
    public class CivStoneGump : Gump
    {
        private PlayerMobile m_From;
        private string m_CivName;

        public CivStoneGump(PlayerMobile from, string civName)
            : base(40, 40)
        {
            m_From = from;
            m_CivName = civName;


        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
        }

        private class InternalTarget : Target
        {
            private PlayerMobile m_Citizen;
            private string m_CivName;

            public InternalTarget(PlayerMobile citizen, string civName)
                : base(3, false, TargetFlags.None)
            {
                m_Citizen = citizen;
                m_CivName = civName;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is CivTokens)
                {
                    CivTokens tokens = targeted as CivTokens;
                    //Add the tokens to the coffers.
                }
                else
                    from.SendMessage("That is not Civ Tokens!");
                from.CloseGump(typeof(CivStoneGump));
                from.SendGump(new CivStoneGump(m_Citizen, m_CivName));
            }
        }
    }
}