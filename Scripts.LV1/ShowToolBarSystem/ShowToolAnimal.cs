using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using System;

namespace Server.Gumps
{
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
            AddLabel(0x16, 0x2c, 50, "Dream World");
            AddLabel(0x1f, 70, 0x20, "Pet Commands");
            AddButton(0x19, 0x55, 0x846, 0x845, 1, GumpButtonType.Reply, 0);
            AddButton(0x19, 0x69, 0x846, 0x845, 2, GumpButtonType.Reply, 0);
            AddButton(0x19, 0x7d, 0x846, 0x845, 3, GumpButtonType.Reply, 0);
            AddButton(0x19, 0x91, 0x846, 0x845, 4, GumpButtonType.Reply, 0);
            AddButton(0x19, 0xa5, 0x846, 0x845, 5, GumpButtonType.Reply, 0);
            AddButton(0x19, 0xb9, 0x846, 0x845, 6, GumpButtonType.Reply, 0);
            AddButton(0x19, 0xcd, 0x846, 0x845, 7, GumpButtonType.Reply, 0);
            AddButton(0x19, 0xf5, 0x846, 0x845, 20, GumpButtonType.Reply, 0);
            AddButton(0x19, 0x109, 0x846, 0x845, 0x15, GumpButtonType.Reply, 0);
            AddLabel(50, 0x55, 0x40, "Guard");
            AddLabel(50, 0x69, 0x40, "Follow");
            AddLabel(50, 0x7d, 0x40, "Dismiss");
            AddLabel(50, 0x91, 0x40, "Kill");
            AddLabel(50, 0xa5, 0x40, "Stop");
            AddLabel(50, 0xb9, 0x40, "Stay");
            AddLabel(50, 0xcd, 0x40, "Come");
            AddLabel(50, 0xe1, 0x20, "Other Commands");
            AddLabel(50, 0xf5, 0x40, "Stable");
            AddLabel(50, 0x109, 0x40, "Claim");
            AddButton(0x19, 0x11d, 0xfb1, 0xfb3, 0x16, GumpButtonType.Reply, 0);
            AddLabel(80, 0x11d, 0x40, "Close");
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
                pm.DoSpeech("*Protect me, Baby..*", numArray, 0, 20);
                pm.Say("all guard me");
            }
            if (info.ButtonID == 2)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*Follow me, Babe..*", numArray2, 0, 20);
                pm.Say("all follow me");
            }
            if (info.ButtonID == 3)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*Go away..*", numArray3, 0, 20);
                pm.Say("all drop");
            }
            if (info.ButtonID == 4)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*Yo! Go punch that..*", numArray4, 0, 20);
                pm.Say("all kill");
            }
            if (info.ButtonID == 5)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*Stop, I say!!*", numArray5, 0, 20);
                pm.Say("all stop");
            }
            if (info.ButtonID == 6)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*I said STAY!*", numArray6, 0, 20);
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
                pm.DoSpeech("*Take care of my pet.*", numArray9, 0, 20);
                pm.Say("stable");
            }
            if (info.ButtonID == 0x15)
            {
                pm.CloseGump(typeof (ShowToolAnimal));
                pm.SendGump(new ShowToolAnimal(pm));
                pm.DoSpeech("*I want my pets!*", numArray8, 0, 20);
                pm.Say("claim all");
            }
            if (info.ButtonID == 0x16)
            {
                pm.SendMessage("*You close the Pet Command Bar.*");
            }
        }
    }
}

