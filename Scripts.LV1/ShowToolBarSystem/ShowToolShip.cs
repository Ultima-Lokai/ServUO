namespace Server.TimeSystem
{
    using Server.Gumps;
    using Server.Mobiles;
    using Server.Network;
    using System;

    public class ShowToolShip : Gump
    {
        public ShowToolShip(PlayerMobile owner) : base(20, 80)
        {
            base.set_Closable(true);
            base.set_Disposable(true);
            base.set_Dragable(true);
            base.set_Resizable(true);
            base.AddPage(0);
            base.AddBackground(0, 0, 0xbd, 0x105, 0x251c);
            base.AddImageTiled(2, 6, 0xb9, 0xfd, 0xa8e);
            base.AddAlphaRegion(2, 6, 0xb9, 0xfd);
            base.AddButton(2, 0x23, 0x119b, 0x119b, 1, 1, 0);
            base.AddButton(0x3f, 0x23, 0x1194, 0x1194, 2, 1, 0);
            base.AddButton(0x7d, 0x23, 0x1195, 0x1195, 3, 1, 0);
            base.AddButton(2, 0x5f, 0x119a, 0x119a, 4, 1, 0);
            base.AddButton(0x4b, 0x69, 0x47f, 0x47f, 5, 1, 0);
            base.AddButton(0x7d, 0x5f, 0x1196, 0x1196, 6, 1, 0);
            base.AddButton(2, 0x91, 0x1199, 0x1199, 7, 1, 0);
            base.AddButton(0x3f, 0x91, 0x1198, 0x1198, 8, 1, 0);
            base.AddButton(0x7d, 0x91, 0x1197, 0x1197, 9, 1, 0);
            base.AddButton(0x23, 0xcd, 0x26b3, 0x26b4, 10, 1, 0);
            base.AddButton(0x85, 0xcd, 0x26ad, 0x26ae, 11, 1, 0);
            base.AddButton(0xa7, 9, 3, 4, 12, 1, 0);
            base.AddLabel(0x38, 13, 0x40, "开船指令");
            base.AddLabel(0x12, 0xeb, 0x40, "下锚");
            base.AddLabel(0x74, 0xeb, 0x40, "起锚");
            base.AddItem(5, 10, 0x14f4);
            base.AddItem(0x89, 10, 0x14f3);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            PlayerMobile owner = state.get_Mobile() as PlayerMobile;
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
            if (info.get_ButtonID() == 1)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*左前进*", numArray, 0, 20);
                owner.Say("left");
            }
            if (info.get_ButtonID() == 2)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*前进*", numArray2, 0, 20);
                owner.Say("forward");
            }
            if (info.get_ButtonID() == 3)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*右前进*", numArray3, 0, 20);
                owner.Say("right");
            }
            if (info.get_ButtonID() == 4)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*左转*", numArray4, 0, 20);
                owner.Say("trun left");
            }
            if (info.get_ButtonID() == 5)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*停船*", numArray5, 0, 20);
                owner.Say("stop");
            }
            if (info.get_ButtonID() == 6)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*右转*", numArray6, 0, 20);
                owner.Say("trun right");
            }
            if (info.get_ButtonID() == 7)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*左后退*", numArray7, 0, 20);
                owner.Say("backward left");
            }
            if (info.get_ButtonID() == 8)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*后退*", numArray8, 0, 20);
                owner.Say("backward");
            }
            if (info.get_ButtonID() == 9)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*右后退*", numArray9, 0, 20);
                owner.Say("backward right");
            }
            if (info.get_ButtonID() == 10)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*下锚*", numArray10, 0, 20);
                owner.Say("dropan chor");
            }
            if (info.get_ButtonID() == 11)
            {
                owner.CloseGump(typeof(ShowToolShip));
                owner.SendGump(new ShowToolShip(owner));
                owner.DoSpeech("*起锚*", numArray11, 0, 20);
                owner.Say("raise anchor");
            }
            if (info.get_ButtonID() == 12)
            {
                owner.SendMessage("你关闭了开船指令系统.");
            }
        }
    }
}

