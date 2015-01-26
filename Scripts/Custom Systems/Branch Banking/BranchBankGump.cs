using System;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Network;
using Server;
using Server.Items;

namespace Server.Gumps
{
    public class BranchBankGump : Gump
    {
        private Mobile m_From;

        public BranchBankGump(Mobile from, BranchBanker banker)
            : base(40, 40)
        {
            m_From = from;
            string branch, facet;

            if (from.Region.Name == null || from.Region.Name == "")
                branch = "Worldwide";
            else
                branch = from.Region.Name;

            if (banker == null || banker.Deleted || banker.Map == Map.Internal)
                facet = from.Map.Name;
            else
                facet = banker.Map.Name;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
            AddPage(0);
            AddBackground(0, 0, 470, 225, 9250);
            AddLabel(80, 15, 0, string.Format("Welcome to the Bank of Sosaria: {0} Branch, {1}", branch, facet));
            AddLabel(38, 45, 0, "Manage Safe Deposit Boxes");
            AddLabel(38, 70, 0, "Manage Savings Account");
            AddLabel(38, 95, 0, "Manage Checking Account");
            AddLabel(38, 120, 0, "Manage Gold Account");
            AddLabel(38, 145, 0, "Manage Retirement Account");
            AddLabel(38, 170, 0, "Open a New Account");
            AddButton(16, 48, 1210, 1209, (int)Buttons.Boxes, GumpButtonType.Reply, 0);
            AddButton(16, 73, 1210, 1209, (int)Buttons.Savings, GumpButtonType.Reply, 0);
            AddButton(16, 98, 1210, 1209, (int)Buttons.Checking, GumpButtonType.Reply, 0);
            AddButton(16, 123, 1210, 1209, (int)Buttons.Gold, GumpButtonType.Reply, 0);
            AddButton(16, 148, 1210, 1209, (int)Buttons.Retirement, GumpButtonType.Reply, 0);
            AddButton(16, 173, 1210, 1209, (int)Buttons.NewAccount, GumpButtonType.Reply, 0);

        }

        private enum Buttons
        {
            Boxes = 11, Savings, Checking, Gold, Retirement, NewAccount, Restart
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                default: break;
                case (int)Buttons.Boxes: { goto case 10; }
                case (int)Buttons.Savings: { goto case 10; }
                case (int)Buttons.Checking: { goto case 10; }
                case (int)Buttons.Gold: { goto case 10; }
                case (int)Buttons.Retirement: { goto case 10; }
                case (int)Buttons.NewAccount: { goto case 10; }
                case 10: break;
            }
        }
    }
}