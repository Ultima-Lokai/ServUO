/************* FullToolbar.cs *************
 * 
 *            (C) 2008, Lokai
 * 
 * v2.0
 * RunUO 2.0 RC1, SVN or RC2
 * 
 * Description: Customizable GM+ command 
 *      toolbar, with 5 commands wide and
 *      an unlimited number of rows. Bar
 *      can be 'minimized', and Stealth 
 *      mode automatically minimizes the
 *      bar each time a command is used.
 *      Customization can be turned off,
 *      locking the commands. All settings
 *      including commands, last page
 *      viewed, and X, Y position of the
 *      bar are stored in a Tag connected
 *      to the Account of the user.
 * 
 * Usage: [FullToolbar or [Fubar
 *
 *******************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/
using System;
using System.Collections;
using Server;
using Server.Spells;
using Server.Gumps;
using Server.Mobiles;
using Server.Accounting;
using Server.Commands;
using Server.Network;

namespace Server.Gumps
{
	public class FullToolbarCommand
	{
		public static void Initialize()
		{
			CommandSystem.Register( "Fubar", AccessLevel.GameMaster, new CommandEventHandler( Fubar_OnCommand ) );
			CommandSystem.Register( "FullToolbar", AccessLevel.GameMaster, new CommandEventHandler( Fubar_OnCommand ) );
		}
		
		[Usage( "FullToolbar" )]
		[Description( "Begins the Full Toolbar Gump." )]
		private static void Fubar_OnCommand( CommandEventArgs e )
		{
			Mobile m = e.Mobile;
			m.SendGump( new FullToolbar( m ) );
		}
	}
	public class FullToolbar : Gump
	{
		private Mobile m_From;
		private Account m_Account;
		private string[] m_Str;
		private int m_X, m_Y, m_W, m_H;
        private string m_Version;
		private bool m_AutoHide;
		private bool m_Locked;
		private int m_Pages;
		private int m_ThisPage;
        private const int m_PARAMS = 9; //Number of Toolbar Parameters
		
		public FullToolbar( Mobile from ) : base( 0, 0 )
		{
			m_From = from;
			
			m_From.CloseGump( typeof( FullToolbar ) );
			
			m_Account = m_From.Account as Account;

            if (m_Account.GetTag("FullToolbar") == null) m_Account.SetTag("FullToolbar", GetStartString());
            string temp = m_Account.GetTag("FullToolbar");
            if (!temp.StartsWith("v")) temp = "v2~" + temp;
            m_Str = temp.Split('~');
			
			int StrPos = 0;
            try { m_Version = m_Str[StrPos++]; } catch { m_Version = "v2"; } // Version for future use...
			try { m_X = Convert.ToInt32( m_Str[StrPos++] ); } catch { m_X = 5; }
			try { m_Y = Convert.ToInt32( m_Str[StrPos++] ); } catch { m_Y = 33; }
			try { m_W = Convert.ToInt32( m_Str[StrPos++] ); } catch { m_W = 700; } // Width not used yet...
			try { m_H = Convert.ToInt32( m_Str[StrPos++] ); } catch { m_H = 53; } // Height not used yet...
			try { if ( m_Str[StrPos++] == "Yes" ) m_AutoHide = true; else m_AutoHide = false; } catch { m_AutoHide = false; }
			try { if ( m_Str[StrPos++] == "Yes" ) m_Locked = true; else m_Locked = false; } catch { m_Locked = false; }
			try { m_Pages = Convert.ToInt32( m_Str[StrPos++] ); } catch { m_Pages = 6; }
			try { m_ThisPage = Convert.ToInt32( m_Str[StrPos++] ); } catch { m_ThisPage = 1; }
			
			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;
			AddPage(0);
            AddBackground(m_X, m_Y, m_W, m_H, 9200);
            AddLabel(m_X + 20, m_Y, 0, @"Hide");
            AddImageTiledButton(m_X + 4, m_Y + 5, 1210, 1209, 1, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 3002085); // Minimize
            if (m_Locked)
            {
                AddImage(m_X + 2, m_Y + 20, 10850);
                AddImageTiledButton(m_X + 10, m_Y + 29, 2092, 2092, 2, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 3005142);
            } // Locked
            else
            {
                AddImage(m_X + 2, m_Y + 20, 10830);
                AddImageTiledButton(m_X + 10, m_Y + 29, 2092, 2092, 3, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 3005143);
            } // Unlocked
            AddLabel(m_X + 631, m_Y + 23, 0, "Page");
            if (!m_Locked)
                AddImageTiledButton(m_X + 640, m_Y + 41, 2224, 2224, 9, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 1079279); // Add (a page)
            if (!m_Locked && m_ThisPage > 6) // Unable to remove default pages.
                AddImageTiledButton(m_X + 638, m_Y + 15, 2223, 2223, 10, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 1011403); // Remove (a page)
            if (m_ThisPage < m_Pages)
                AddImageTiledButton(m_X + 674, m_Y + 32, 5402, 5402, 4, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 1011066); // Next page
            if (m_ThisPage > 1)
                AddImageTiledButton(m_X + 604, m_Y + 32, 5401, 5401, 5, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 1011067); // Previous Page
            if (m_AutoHide)
                AddImageTiledButton(m_X + m_W - 30, m_Y + 8, 9910, 9910, 6, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 1044107); // Stealth
            else AddImageTiledButton(m_X + m_W - 30, m_Y + 8, 9903, 9903, 7, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 1044107); // Stealth
            AddImageTiledButton(m_X + 604, m_Y + 9, 22153, 22155, 8, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 1061037); // Help

            StrPos = ((m_ThisPage - 1) * 5) + m_PARAMS;
			int Xpos = 0;
			
			for ( int x = StrPos; x < StrPos + 5; x++ )
			{
                if (!m_Locked) AddTextEntry(m_X + 115 + (Xpos * 100), m_Y + 3, 70, 20, 0x769, x, m_Str[x]);
                else AddLabel(m_X + 115 + (Xpos * 100), m_Y + 3, 0, m_Str[x]);
                if (!m_Locked) AddImageTiledButton(m_X + 85 + (Xpos * 100), m_Y + 2, 4027, 4028, 100 + x,
                    GumpButtonType.Reply, 0, 1352, 0, 140, 20, 3005038); // Trigger Edit
                AddImageTiledButton(m_X + 115 + (Xpos * 100), m_Y + 27, 4006, 4007, 200 + x,
                    GumpButtonType.Reply, 0, 1352, 0, 140, 20, 1005135); // Awaiting your command...
                AddImageTiledButton(m_X + 150 + (Xpos++ * 100), m_Y + 27, 4009, 4010, 300 + x,
                    GumpButtonType.Reply, 0, 1352, 0, 140, 20, 1048176); // Makes as many as possible at once
			}
		}
		
		public override void OnResponse( NetState state, RelayInfo info )
		{
			int choice = info.ButtonID;
            if (choice == 0) { m_From.CloseGump(typeof(FullToolbar)); }
            else if (choice == 1) { SetTheTag(); m_From.SendGump(new MiniToolbar(m_From, m_X, m_Y)); }
            else if (choice == 2) { m_Str[6] = "No"; 
                SetTheTag(); RelaunchToolbar(false); }
            else if (choice == 3) { m_Str[6] = "Yes"; 
                SetTheTag(); RelaunchToolbar(false); }
            else if (choice == 4) { m_Str[8] = (m_ThisPage + 1).ToString(); 
                SetTheTag(); RelaunchToolbar(false); }
            else if (choice == 5) { m_Str[8] = (m_ThisPage - 1).ToString(); 
                SetTheTag(); RelaunchToolbar(false); }
            else if (choice == 6) { m_Str[5] = "No"; 
                SetTheTag(); RelaunchToolbar(false); }
            else if (choice == 7) { m_Str[5] = "Yes"; 
                SetTheTag(); RelaunchToolbar(false); }
            else if (choice == 8) { m_From.SendGump(new ToolbarHelpGump()); RelaunchToolbar(false); }
            else if (choice == 9) { m_Str[7] = ((int)(Convert.ToInt32(m_Str[7]) + 1)).ToString();
                m_Str[8] = m_Str[7]; SetTheTag(true, true); RelaunchToolbar(false); }
            else if (choice == 10) { m_Str[7] = ((int)(Convert.ToInt32(m_Str[7]) - 1)).ToString();
                m_Str[8] = ((int)(m_ThisPage - 1)).ToString(); 
                SetTheTag(true, false); RelaunchToolbar(false); }
                else if (choice < 200) { m_Str[choice - 100] = info.GetTextEntry(choice - 100).Text;
                SetTheTag(); RelaunchToolbar(false); }
            else if (choice < 300) { UseCommand(m_Str[choice - 200]); RelaunchToolbar(true); }
            else if (choice < 400) { UseMultiCommand(m_Str[choice - 300]); RelaunchToolbar(true); }
            else { SetTheTag(); m_From.CloseGump(typeof(FullToolbar)); }
			
		}
		
		public void RelaunchToolbar( bool cmd )
		{
            m_From.CloseGump(typeof(FullToolbar));
            if (cmd && m_AutoHide) m_From.SendGump(new MiniToolbar(m_From));
            else m_From.SendGump(new FullToolbar(m_From));
		}

        public void UseCommand(string command)
        {
            string Pfix = CommandSystem.Prefix;
            CommandSystem.Handle(m_From, String.Format("{0}{1}", Pfix, command));
        }

        public void UseMultiCommand(string command)
        {
            string Pfix = CommandSystem.Prefix;
            CommandSystem.Handle(m_From, String.Format("{0}m {1}", Pfix, command));
        }
		
		public string GetStartString()
		{
            string start = "v2~5~33~700~53~No~No~6~1~Who~Where~Bank~Move~Props~Tele~Wipe~Skills~SetAllSkills 120~PM";
            start += "~Save~Restart~Freeze~Unfreeze~Admin~Kill~Go~Kick~Restock~WipeMultis~DupeInBag~Stats";
            start += "~Decorate~Set Str 100~Set Dex 100~Set Int 100~ShaveBeard~ShaveHair~DoorGen~VendorGen";
			return start;
		}

        public void SetTheTag()
        {
            SetTheTag(false, false);
        }

        public void SetTheTag(bool page, bool add)
        {
            m_Str[1] = this.X.ToString(); m_Str[2] = this.Y.ToString();
            string tagstring = m_Str[0];
            try
            {
                if (page && !add) m_Pages--;
                for (int z = 1; z <= (m_Pages * 5) + m_PARAMS - 1; z++) tagstring += "~" + m_Str[z];
                if (page && add) tagstring += "~Go~Go~Go~Go~Go";
                m_Account.SetTag("FullToolbar", tagstring);
            }
            catch { m_Account.SetTag("FullToolbar", GetStartString()); }
        }
	}

    public class ToolbarHelpGump : Gump
    {
        public ToolbarHelpGump()
            : base(0, 0)
        {
            Closable = true;
            Disposable = true;
            Dragable = false;
            Resizable = false;
            AddPage(0);
            AddBackground(9, 93, 762, 389, 9300);
            AddBackground(37, 178, 700, 53, 9200);
            AddLabel(320, 114, 0, "Full Toolbar Help");
            AddImage(46, 182, 1210);
            AddImage(41, 198, 10830);
            AddImage(50, 206, 2092);
            AddLabel(71, 181, 0, @"Edit->");
            AddButton(710, 182, 9910, 248, 0, GumpButtonType.Reply, 0);
            AddButton(113, 182, 4027, 4028, 0, GumpButtonType.Reply, 0);
            AddButton(213, 182, 4027, 4028, 0, GumpButtonType.Reply, 0);
            AddButton(313, 182, 4027, 4028, 0, GumpButtonType.Reply, 0);
            AddButton(413, 182, 4027, 4028, 0, GumpButtonType.Reply, 0);
            AddButton(513, 182, 4027, 4028, 0, GumpButtonType.Reply, 0);
            AddTextEntry(143, 182, 70, 20, 0, 0, @"Who");
            AddTextEntry(243, 182, 70, 20, 0, 0, @"Where");
            AddTextEntry(343, 182, 70, 20, 0, 0, @"Bank");
            AddTextEntry(443, 182, 70, 20, 0, 0, @"Move");
            AddTextEntry(543, 182, 70, 20, 0, 0, @"Props");
            AddButton(147, 206, 4006, 4007, 0, GumpButtonType.Reply, 0);
            AddButton(180, 206, 4009, 4010, 0, GumpButtonType.Reply, 0);
            AddButton(247, 206, 4006, 4007, 0, GumpButtonType.Reply, 0);
            AddButton(280, 206, 4009, 4010, 0, GumpButtonType.Reply, 0);
            AddButton(347, 206, 4006, 4007, 0, GumpButtonType.Reply, 0);
            AddButton(380, 206, 4009, 4010, 0, GumpButtonType.Reply, 0);
            AddButton(447, 206, 4006, 4007, 0, GumpButtonType.Reply, 0);
            AddButton(480, 206, 4009, 4010, 0, GumpButtonType.Reply, 0);
            AddButton(547, 206, 4006, 4007, 0, GumpButtonType.Reply, 0);
            AddButton(580, 206, 4009, 4010, 0, GumpButtonType.Reply, 0);
            AddLabel(71, 202, 0, @"run/multi->");
            AddImage(712, 209, 5402);
            AddImage(643, 209, 5401);
            AddButton(643, 187, 22153, 22155, 0, GumpButtonType.Reply, 0);
            AddImage(677, 192, 2223); // remove page button
            AddLabel(670, 200, 0, @"Page");
            AddImage(679, 218, 2224); // add page button
            AddImage(44, 154, 2225);
            AddImage(119, 154, 2226);
            AddImage(173, 154, 2227);
            AddLabel(636, 160, 0, @"Help");
            AddImage(713, 154, 2228);
            AddImage(45, 232, 2229);
            AddImage(152, 232, 2230);
            AddImage(185, 232, 2231);
            AddImage(641, 232, 2232);
            AddImage(711, 232, 2232);
            AddImage(44, 265, 2225);
            AddImage(44, 290, 2226);
            AddImage(44, 315, 2227);
            AddImage(44, 340, 2228);
            AddImage(44, 365, 2229);
            AddImage(44, 390, 2230);
            AddImage(44, 415, 2231);
            AddImage(44, 440, 2232);
            AddLabel(70, 265, 0, @"Minimize Button: This button will shrink the FullToolbar, and open the MiniToolbar.");
            AddLabel(70, 290, 0, @"Edit Button: This button will change the command to whatever you have typed in the box next to it.");
            AddLabel(70, 315, 0, @"Command Box: This is where the commands are typed and stored for use in single- or multi-mode.");
            AddLabel(70, 340, 0, @"Stealth Button: When ON (pointing left) the Bar will minimize after each command.");
            AddLabel(70, 365, 0, @"Lock Button: When Locked (Red) command editing is disabled.");
            AddLabel(70, 390, 0, @"Single-Command Button: Executes the above command normally.");
            AddLabel(70, 415, 0, @"Multi-Command Button: Executes the above command in Multi-mode.");
            AddLabel(70, 440, 0, @"Page Buttons: Used to scan the saved commands.");
            AddImage(378, 442, 2223);
            AddLabel(401, 440, 0, @"Adds a new page.");
            AddImage(520, 442, 2224);
            AddLabel(547, 440, 0, @"Removes a page.");

            this.AddLabel(18, 101, 0, @"FullToolbar (Fubar) v2");
            this.AddLabel(18, 121, 0, @"(C) 2008, Lokai");
            this.AddLabel(597, 101, 0, @"RunUO 2.0 RC1, SVN, RC2");
            this.AddLabel(579, 122, 0, @"See GNU GPL for license info");

        }
    }
}