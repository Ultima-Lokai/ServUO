namespace Server.TimeSystem
{
    using Server.Commands;
    using Server.Gumps;
    using Server.Mobiles;
    using Server.Network;
    using System;
    using Xanthos.Utilities;

    public class ShowToolTwo : Gump
    {
        public ShowToolTwo(PlayerMobile owner) : base(8, 15)
        {
            base.set_Closable(false);
            base.set_Disposable(false);
            base.set_Dragable(false);
            base.set_Resizable(true);
            base.AddPage(0);
            base.AddBackground(0x10, 0x13, 630, 0x1d, 0x2422);
            base.AddImageTiled(0x11, 0x17, 0x273, 0x17, 0x243a);
            base.AddAlphaRegion(0x11, 0x17, 0x273, 0x17);
            base.AddBackground(0, 13, 0x27, 0x25, 0x2422);
            base.AddImageTiled(1, 0x11, 0x24, 0x1f, 0x243a);
            base.AddAlphaRegion(1, 0x11, 0x24, 0x1f);
            base.AddButton(8, 0x13, 0x15a5, 0x15a2, 1, 1, 0);
            base.AddButton(60, 0x19, 0x82f, 0x82e, 2, 1, 0);
            base.AddLabel(0x55, 0x19, 0x40, "属性");
            base.AddButton(460, 0x19, 0x82f, 0x82e, 8, 1, 0);
            base.AddLabel(0x1e5, 0x19, 0x40, "回城");
            base.AddButton(220, 0x19, 0x82f, 0x82e, 4, 1, 0);
            base.AddLabel(0xf5, 0x19, 0x40, "房屋");
            base.AddButton(300, 0x19, 0x82f, 0x82e, 5, 1, 0);
            base.AddLabel(0x145, 0x19, 0x40, "开船");
            base.AddButton(380, 0x19, 0x82f, 0x82e, 6, 1, 0);
            base.AddLabel(0x195, 0x19, 0x40, "新闻");
            base.AddButton(140, 0x19, 0x82f, 0x82e, 7, 1, 0);
            base.AddLabel(0xa5, 0x19, 0x40, "宠物");
            base.AddButton(540, 0x19, 0x82f, 0x82e, 3, 1, 0);
            base.AddLabel(0x235, 0x19, 0x40, "人物统计");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            PlayerMobile owner = state.get_Mobile() as PlayerMobile;
            string str = CommandSystem.get_Prefix();
            int[] numArray = new int[1];
            switch (info.get_ButtonID())
            {
                case 0:
                    break;

                case 1:
                    owner.CloseGump(typeof(ShowToolTwo));
                    owner.SendGump(new ShowTool(owner));
                    return;

                case 2:
                    owner.CloseGump(typeof(ShowToolThree));
                    owner.SendGump(new ShowToolTwo(owner));
                    owner.SendGump(new ShowToolThree(owner));
                    return;

                case 3:
                    owner.CloseGump(typeof(StatsGump));
                    owner.SendGump(new ShowToolTwo(owner));
                    CommandSystem.Handle(owner, string.Format("{0}mystats", str));
                    break;

                case 4:
                    owner.CloseGump(typeof(ShowToolHouse));
                    owner.SendGump(new ShowToolTwo(owner));
                    owner.SendGump(new ShowToolHouse(owner));
                    return;

                case 5:
                    owner.CloseGump(typeof(ShowToolShip));
                    owner.SendGump(new ShowToolTwo(owner));
                    owner.SendGump(new ShowToolShip(owner));
                    return;

                case 6:
                    owner.CloseGump(typeof(NewsGump));
                    owner.SendGump(new ShowToolTwo(owner));
                    owner.DoSpeech("[motd", numArray, 0, 20);
                    return;

                case 7:
                    owner.CloseGump(typeof(ShowToolAnimal));
                    owner.SendGump(new ShowToolTwo(owner));
                    owner.SendGump(new ShowToolAnimal(owner));
                    return;

                case 8:
                    owner.CloseGump(typeof(ShowToolFour));
                    owner.SendGump(new ShowToolTwo(owner));
                    owner.SendGump(new ShowToolFour(owner));
                    return;

                default:
                    return;
            }
        }
    }
}

