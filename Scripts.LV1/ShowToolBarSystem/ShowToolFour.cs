namespace Server.TimeSystem
{
    using Server;
    using Server.Gumps;
    using Server.Mobiles;
    using Server.Network;
    using Server.Regions;
    using System;

    public class ShowToolFour : Gump
    {
        private PlayerMobile pm;

        public ShowToolFour(PlayerMobile owner) : base(50, 10)
        {
            pm = owner;
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = true;
            base.AddPage(0);
            base.AddBackground(0x7a, 0x70, 0x156, 0x132, 0x23f0);
            base.AddImageTiled(0x85, 0x7a, 0x13e, 0x11d, 0xa8e);
            base.AddAlphaRegion(0x85, 0x7a, 0x13e, 0x11d);
            base.AddImage(0x1b0, 70, 0x28c9);
            base.AddImage(0x48, 70, 0x28c8);
            base.AddImage(0xca, 0x42, 0x28d4);
            base.AddLabel(0xd7, 0x80, 0x40, "欢迎来到梦世界!");
            base.AddLabel(150, 0xb9, 0x40, "虽然不知道你是因为什么原因死了,");
            base.AddLabel(150, 0xd7, 0x40, "但是既然你用了999呼唤天神来救你,");
            base.AddLabel(150, 0xf5, 0x40, "怎么说我也应该助你一臂之力吧?");
            base.AddLabel(150, 0x113, 0x40, "死并没有什么可怕,怕的是回不去吧?");
            base.AddButton(0x87, 0x13b, 0xfa5, 0xfa6, 1, GumpButtonType.Reply, 0);
            base.AddLabel(0xa5, 0x13b, 0x40, "返回城市!");
            base.AddButton(0x87, 0x16d, 0xfa5, 0xfa6, 2, GumpButtonType.Reply, 0);
            base.AddLabel(0xa5, 0x16d, 0x40, "取消!");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 0:
                    break;

                case 1:
                    if (pm.Alive)
                    {
                        pm.SendMessage("你还活着呢!");
                        return;
                    }
                    if (pm.Region is Jail)
                    {
                        pm.SendMessage("在监狱你里不可以使用回城系统!");
                    }
                    if (pm.Kills >= 5)
                    {
                        pm.Map = Map.Felucca;
                        pm.Location = new Point3D(0x5cb, 0x64c, 20);
                        return;
                    }
                    pm.Map = Map.Malas;
                    pm.Location = new Point3D(0x405, 520, -55);
                    return;

                case 2:
                    pm.SendMessage("你暂时还不想做什么!");
                    break;

                default:
                    return;
            }
        }
    }
}

