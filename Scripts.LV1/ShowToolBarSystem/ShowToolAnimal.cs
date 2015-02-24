namespace Server.TimeSystem
{
    using Server.Gumps;
    using Server.Mobiles;
    using Server.Network;
    using System;

    public class ShowToolAnimal : Gump
    {
        private PlayerMobile pm;

        public ShowToolAnimal(PlayerMobile owner) : base(0, 50)
        {
            pm = owner;
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = true;
            AddPage(0);
            AddBackground(15, 0x1d, 0xb7, 290, 0x251c);
            AddImageTiled(0x11, 0x23, 0xb2, 290, 0xa8e);
            AddAlphaRegion(0x11, 0x23, 0xb2, 290);
            AddItem(0x6d, 0x26, 0x21f1);
            AddLabel(0x16, 0x2c, 50, "梦世界");
            AddLabel(0x1f, 70, 0x20, "宠物指令");
            AddButton(0x19, 0x55, 0x846, 0x845, 1, GumpButtonType.Reply, 0);
            AddButton(0x19, 0x69, 0x846, 0x845, 2, GumpButtonType.Reply, 0);
            AddButton(0x19, 0x7d, 0x846, 0x845, 3, GumpButtonType.Reply, 0);
            AddButton(0x19, 0x91, 0x846, 0x845, 4, GumpButtonType.Reply, 0);
            AddButton(0x19, 0xa5, 0x846, 0x845, 5, GumpButtonType.Reply, 0);
            AddButton(0x19, 0xb9, 0x846, 0x845, 6, GumpButtonType.Reply, 0);
            AddButton(0x19, 0xcd, 0x846, 0x845, 7, GumpButtonType.Reply, 0);
            AddButton(0x19, 0xf5, 0x846, 0x845, 20, GumpButtonType.Reply, 0);
            AddButton(0x19, 0x109, 0x846, 0x845, 0x15, GumpButtonType.Reply, 0);
            AddLabel(50, 0x55, 0x40, "守护(Guard)");
            AddLabel(50, 0x69, 0x40, "跟随(Follow)");
            AddLabel(50, 0x7d, 0x40, "卸下(Drop)");
            AddLabel(50, 0x91, 0x40, "攻击(Kill)");
            AddLabel(50, 0xa5, 0x40, "停止(Stop)");
            AddLabel(50, 0xb9, 0x40, "别动(Stay)");
            AddLabel(50, 0xcd, 0x40, "过来(Come)");
            AddLabel(50, 0xe1, 0x20, "其他指令");
            AddLabel(50, 0xf5, 0x40, "卖宠物(petsell)");
            AddLabel(50, 0x109, 0x40, "领取宠物(claim)");
            AddButton(0x19, 0x11d, 0xfb1, 0xfb3, 0x16, GumpButtonType.Reply, 0);
            AddLabel(80, 0x11d, 0x40, "关闭");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            int[] numArray = new int[] {0x16b};
            int[] numArray2 = new int[] {0x16c};
            int[] numArray3 = new int[] {0x156};
            int[] numArray4 = new int[] {360};
            int[] numArray5 = new int[] {0x167};
            int[] numArray6 = new int[] {0x170};
            int[] numArray7 = new int[] {0x164};
            int[] numArray8 = new int[] {9};
            int[] numArray9 = new int[1];
            if (info.ButtonID == 1)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*宝贝护架护架..*", numArray, 0, 20);
                pm.Say("all guard me");
            }
            if (info.ButtonID == 2)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*宝贝跟着我跟着我..*", numArray2, 0, 20);
                pm.Say("all follow me");
            }
            if (info.ButtonID == 3)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*把东西丢了..*", numArray3, 0, 20);
                pm.Say("all drop");
            }
            if (info.ButtonID == 4)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*宝贝上啊..冲..*", numArray4, 0, 20);
                pm.Say("all kill");
            }
            if (info.ButtonID == 5)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*停!停!!*", numArray5, 0, 20);
                pm.Say("all stop");
            }
            if (info.ButtonID == 6)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*别动!听见没有?叫你别动!*", numArray6, 0, 20);
                pm.Say("all stay");
            }
            if (info.ButtonID == 7)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*Come On Baby!*", numArray7, 0, 20);
                pm.Say("all come");
            }
            if (info.ButtonID == 20)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("petsell", numArray9, 0, 20);
                pm.Say("*我要卖掉它*");
            }
            if (info.ButtonID == 0x15)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("claim all", numArray8, 0, 20);
                pm.Say("*我来领取我的宝宝*");
            }
            if (info.ButtonID == 0x16)
            {
                pm.SendMessage("*你关闭了宠物指令系统.*");
            }
        }
    }
}

