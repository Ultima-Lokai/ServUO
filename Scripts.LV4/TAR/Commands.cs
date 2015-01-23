using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using Server;
using Server.Items;
using Server.Misc;
using Server.Commands;
using Server.Network;

namespace Server.TAR
{
    class Commands
    {
        public static void Initialize()
        {
            CommandSystem.Register("TARControl", AccessLevel.Administrator, new CommandEventHandler(TARControl_OnCommand));
            CommandSystem.Register("TARBegin", AccessLevel.Administrator, new CommandEventHandler(TARBegin_OnCommand));
            CommandSystem.Register("TARNew", AccessLevel.Administrator, new CommandEventHandler(TARBegin_OnCommand));
            CommandSystem.Register("TARJoin", AccessLevel.Player, new CommandEventHandler(TARJoin_OnCommand));
            CommandSystem.Register("TARInvite", AccessLevel.GameMaster, new CommandEventHandler(TARInvite_OnCommand));
            CommandSystem.Register("TARI", AccessLevel.GameMaster, new CommandEventHandler(TARInvite_OnCommand));
            CommandSystem.Register("TARMark", AccessLevel.GameMaster, new CommandEventHandler(TARMark_OnCommand));
            CommandSystem.Register("TAROpen", AccessLevel.GameMaster, new CommandEventHandler(TAROpen_OnCommand));
            CommandSystem.Register("TARMax", AccessLevel.GameMaster, new CommandEventHandler(TARMax_OnCommand));
            CommandSystem.Register("TAREnd", AccessLevel.Administrator, new CommandEventHandler(TAREnd_OnCommand));
        }

        [Usage("TARControl")]
        [Description("Gives the Admin full control of the TARace game.")]
        public static void TARControl_OnCommand(CommandEventArgs e)
        {
        }

        [Usage("TARBegin")]
        [Aliases("TARNew")]
        [Description("Begins a new TARace game.")]
        public static void TARBegin_OnCommand(CommandEventArgs e)
        {
        }

        [Usage("TARJoin")]
        [Description("Attemps to join the TARace game.")]
        public static void TARJoin_OnCommand(CommandEventArgs e)
        {
        }

        [Usage("TARInvite")]
        [Aliases("TARI")]
        [Description("Invites players to the TARace game.")]
        public static void TARInvite_OnCommand(CommandEventArgs e)
        {
        }

        [Usage("TARMark")]
        [Description("Marks the location for the TARace exit.")]
        public static void TARMark_OnCommand(CommandEventArgs e)
        {
        }

        [Usage("TAROpen")]
        [Description("Opens the TARace game for new teams.")]
        public static void TAROpen_OnCommand(CommandEventArgs e)
        {
        }

        [Usage("TARMax")]
        [Description("Sets the maximum number of teams for the TARace game.")]
        public static void TARMax_OnCommand(CommandEventArgs e)
        {
        }

        [Usage("TAREnd")]
        [Description("Ends the current TARace game.")]
        public static void TAREnd_OnCommand(CommandEventArgs e)
        {
        }
    }
}
