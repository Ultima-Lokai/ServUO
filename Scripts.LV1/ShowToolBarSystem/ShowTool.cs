using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Commands;
using System;

namespace Server.Gumps
{
    public class ShowTool : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("ShowTool", AccessLevel.Player, OnShowTool);
        }

        [Usage("ShowTool")]
        [Description("Display the Player Command ToolBar.")]
        public static void OnShowTool(CommandEventArgs args)
        {
            Mobile mobile = args.Mobile;
            if (mobile is PlayerMobile)
            {
                PlayerMobile pm = mobile as PlayerMobile;
                pm.CloseGump(typeof(ShowTool));
                pm.SendGump(new ShowTool(pm));
            }
        }

        private PlayerMobile pm;

        public ShowTool(PlayerMobile owner) : base(8, 15)
        {
            pm = owner;
            Closable = false;
            Disposable = false;
            Dragable = false;
            Resizable = true;
            AddPage(0);
            AddBackground(0, 13, 0x27, 0x25, 0x2422);
            AddImageTiled(1, 0x11, 0x24, 0x1f, 0x243a);
            AddAlphaRegion(1, 0x11, 0x24, 0x1f);
            AddButton(8, 0x13, 0x15a5, 0x15a2, 1, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 0:
                    break;

                case 1:
                    pm.CloseGump(typeof (ShowTool));
                    pm.SendGump(new ShowToolTwo(pm));
                    break;

                default:
                    return;
            }
        }
    }
}

