using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using System;

namespace Server.Gumps
{
    public class ShowToolShip : Gump
    {
        private PlayerMobile pm;

        public ShowToolShip(PlayerMobile owner) : base(20, 80)
        {
            pm = owner;
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = true;
            AddPage(0);
            AddBackground(0, 0, 0xbd, 0x105, 0x251c);
            AddImageTiled(2, 6, 0xb9, 0xfd, 0xa8e);
            AddAlphaRegion(2, 6, 0xb9, 0xfd);
            AddButton(2, 0x23, 0x119b, 0x119b, 1, GumpButtonType.Reply, 0);
            AddButton(0x3f, 0x23, 0x1194, 0x1194, 2, GumpButtonType.Reply, 0);
            AddButton(0x7d, 0x23, 0x1195, 0x1195, 3, GumpButtonType.Reply, 0);
            AddButton(2, 0x5f, 0x119a, 0x119a, 4, GumpButtonType.Reply, 0);
            AddButton(0x4b, 0x69, 0x47f, 0x47f, 5, GumpButtonType.Reply, 0);
            AddButton(0x7d, 0x5f, 0x1196, 0x1196, 6, GumpButtonType.Reply, 0);
            AddButton(2, 0x91, 0x1199, 0x1199, 7, GumpButtonType.Reply, 0);
            AddButton(0x3f, 0x91, 0x1198, 0x1198, 8, GumpButtonType.Reply, 0);
            AddButton(0x7d, 0x91, 0x1197, 0x1197, 9, GumpButtonType.Reply, 0);
            AddButton(0x23, 0xcd, 0x26b3, 0x26b4, 10, GumpButtonType.Reply, 0);
            AddButton(0x85, 0xcd, 0x26ad, 0x26ae, 11, GumpButtonType.Reply, 0);
            AddButton(0xa7, 9, 3, 4, 12, GumpButtonType.Reply, 0);
            AddLabel(0x38, 13, 0x40, "Sailing commands");
            AddLabel(0x12, 0xeb, 0x40, "Lower Anchor");
            AddLabel(0x74, 0xeb, 0x40, "Raise Anchor");
            AddItem(5, 10, 0x14f4);
            AddItem(0x89, 10, 0x14f3);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            int[] numArray = new int[] { 0x47 };
            int[] numArray2 = new int[] { 0x45 };
            int[] numArray3 = new int[] { 0x48 };
            int[] numArray4 = new int[] { 0x66 };
            int[] numArray5 = new int[] { 0x4f };
            int[] numArray6 = new int[] { 0x65 };
            int[] numArray7 = new int[] { 0x4d };
            int[] numArray8 = new int[] { 70 };
            int[] numArray9 = new int[] { 0x4e };
            int[] numArray10 = new int[] { 0x6a };
            int[] numArray11 = new int[] { 0x6b };
            if (info.ButtonID == 1)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Move Left*", numArray, 0, 20);
                pm.Say("left");
            }
            if (info.ButtonID == 2)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Move Forward*", numArray2, 0, 20);
                pm.Say("forward");
            }
            if (info.ButtonID == 3)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Move Right*", numArray3, 0, 20);
                pm.Say("right");
            }
            if (info.ButtonID == 4)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Turn Left*", numArray4, 0, 20);
                pm.Say("turn left");
            }
            if (info.ButtonID == 5)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Stop*", numArray5, 0, 20);
                pm.Say("stop");
            }
            if (info.ButtonID == 6)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Turn Right*", numArray6, 0, 20);
                pm.Say("turn right");
            }
            if (info.ButtonID == 7)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Back Left*", numArray7, 0, 20);
                pm.Say("backward left");
            }
            if (info.ButtonID == 8)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Go Backward*", numArray8, 0, 20);
                pm.Say("backward");
            }
            if (info.ButtonID == 9)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Back Right*", numArray9, 0, 20);
                pm.Say("backward right");
            }
            if (info.ButtonID == 10)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Drop Anchor*", numArray10, 0, 20);
                pm.Say("drop anchor");
            }
            if (info.ButtonID == 11)
            {
                pm.CloseGump(typeof(ShowToolShip));
                pm.SendGump(new ShowToolShip(pm));
                pm.DoSpeech("*Raise Anchor*", numArray11, 0, 20);
                pm.Say("raise anchor");
            }
            if (info.ButtonID == 12)
            {
                pm.SendMessage("You close the Sailing Command Bar.");
            }
        }
    }
}

