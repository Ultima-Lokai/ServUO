namespace Server.TimeSystem
{
    using Server.Gumps;
    using Server.Mobiles;
    using Server.Network;
    using System;

    public class ShowToolHouse : Gump
    {
        public ShowToolHouse(PlayerMobile owner) : base(0, 50)
        {
            base.set_Closable(true);
            base.set_Disposable(true);
            base.set_Dragable(true);
            base.set_Resizable(true);
            base.AddPage(0);
            base.AddBackground(15, 0x1d, 0x98, 0x12d, 0x251c);
            base.AddImageTiled(0x11, 0x23, 0x94, 0x125, 0xa8e);
            base.AddAlphaRegion(0x11, 0x23, 0x94, 0x125);
            base.AddItem(0x6d, 0x26, 0x2300);
            base.AddLabel(0x16, 0x2c, 0x40, "梦世界");
            base.AddLabel(0x1f, 70, 0x40, "房屋指令");
            base.AddButton(0x19, 120, 0x846, 0x845, 1, 1, 0);
            base.AddButton(0x19, 150, 0x846, 0x845, 2, 1, 0);
            base.AddButton(0x19, 180, 0x846, 0x845, 3, 1, 0);
            base.AddButton(0x19, 210, 0x846, 0x845, 4, 1, 0);
            base.AddButton(0x19, 240, 0x846, 0x845, 5, 1, 0);
            base.AddButton(0x19, 270, 0x846, 0x845, 6, 1, 0);
            base.AddLabel(50, 0x76, 0x40, "锁定物品");
            base.AddLabel(50, 0x94, 0x40, "解除锁定");
            base.AddLabel(50, 0xb2, 0x40, "设置保全");
            base.AddLabel(50, 0xd0, 0x40, "解除保全");
            base.AddLabel(50, 0xee, 0x40, "驱逐");
            base.AddLabel(50, 0x10c, 0x40, "放置垃圾桶");
            base.AddButton(0x19, 0x128, 0xfb1, 0xfb3, 7, 1, 0);
            base.AddLabel(80, 0x129, 0x40, "关闭");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            PlayerMobile owner = state.get_Mobile() as PlayerMobile;
            int[] numArray = new int[] { 0x23 };
            int[] numArray2 = new int[] { 0x24 };
            int[] numArray3 = new int[] { 0x25 };
            int[] numArray4 = new int[] { 0x26 };
            int[] numArray5 = new int[] { 0x34 };
            int[] numArray6 = new int[] { 40 };
            if (info.get_ButtonID() == 1)
            {
                owner.CloseGump(typeof(ShowToolHouse));
                owner.SendGump(new ShowToolHouse(owner));
                owner.DoSpeech("*选择要锁定的物品*", numArray, 0, 20);
                owner.Say("i wish to lock this down");
            }
            if (info.get_ButtonID() == 2)
            {
                owner.CloseGump(typeof(ShowToolHouse));
                owner.SendGump(new ShowToolHouse(owner));
                owner.DoSpeech("*选择要解除锁定的物品*", numArray2, 0, 20);
                owner.Say("i wish to release this");
            }
            if (info.get_ButtonID() == 3)
            {
                owner.CloseGump(typeof(ShowToolHouse));
                owner.SendGump(new ShowToolHouse(owner));
                owner.DoSpeech("*选择要设置保全的物品*", numArray3, 0, 20);
                owner.Say("i wish to secure this");
            }
            if (info.get_ButtonID() == 4)
            {
                owner.CloseGump(typeof(ShowToolHouse));
                owner.SendGump(new ShowToolHouse(owner));
                owner.DoSpeech("*选择要解除保全的物品*", numArray4, 0, 20);
                owner.Say("i wish to unsecure this");
            }
            if (info.get_ButtonID() == 5)
            {
                owner.CloseGump(typeof(ShowToolHouse));
                owner.SendGump(new ShowToolHouse(owner));
                owner.DoSpeech("*选择要驱逐的人*", numArray5, 0, 20);
                owner.Say("i ban thee");
            }
            if (info.get_ButtonID() == 6)
            {
                owner.CloseGump(typeof(ShowToolHouse));
                owner.SendGump(new ShowToolHouse(owner));
                owner.DoSpeech("*选择要放置垃圾桶的位置*", numArray6, 0, 20);
                owner.Say("i wish to place a trash barrel");
            }
            if (info.get_ButtonID() == 7)
            {
                owner.SendMessage("你关闭了房屋指令系统.");
            }
        }
    }
}

