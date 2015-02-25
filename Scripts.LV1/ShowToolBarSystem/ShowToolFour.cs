using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using System;

namespace Server.Gumps
{
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
            base.AddLabel(0xd7, 0x80, 0x40, "Welcome to the Dream World!");
            base.AddLabel(150, 0xb9, 0x40, "Even though I am not sure why you are dead,");
            base.AddLabel(150, 0xd7, 0x40, "you placed a 911 call, so God will save you.");
            base.AddLabel(150, 0xf5, 0x40, "Say the word, and I can help.");
            base.AddLabel(150, 0x113, 0x40, "Although you are dead, don't be afraid to return.");
            base.AddButton(0x87, 0x13b, 0xfa5, 0xfa6, 1, GumpButtonType.Reply, 0);
            base.AddLabel(0xa5, 0x13b, 0x40, "Return to town!");
            base.AddButton(0x87, 0x16d, 0xfa5, 0xfa6, 2, GumpButtonType.Reply, 0);
            base.AddLabel(0xa5, 0x16d, 0x40, "Cancel!");
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
                        pm.SendMessage("You are already alive!");
                        return;
                    }
                    if (pm.Region is Jail)
                    {
                        pm.SendMessage("You cannot use this command from Jail!");
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
                    pm.SendMessage("You can't do that yet!");
                    break;

                default:
                    return;
            }
        }
    }
}

