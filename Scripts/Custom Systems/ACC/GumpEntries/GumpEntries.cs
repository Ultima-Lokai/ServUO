namespace Server.Gumps
{
	public class GumpEntries
	{
		public static void AddButtonWTooltip( Gump gump, int x, int y, int normalID, int pressedID, int buttonID, GumpButtonType type, int param, int number )
		{
			gump.Add( new GumpButtonWTooltip( x, y, normalID, pressedID, buttonID, type, param, number ) );
		}

		public static void AddBackgroundWTooltip( Gump gump, int x, int y, int w, int h, int gumpID, int tooltip )
		{
			gump.Add( new GumpBackgroundWTooltip( x, y, w, h, gumpID, tooltip ) );
		}

		public static void AddAlphaRegionWTooltip( Gump gump, int x, int y, int w, int h, int tooltip )
		{
			gump.Add( new GumpAlphaRegionWTooltip( x, y, w, h, tooltip ) );
		}

		public static void AddCheckWTooltip( Gump gump, int x, int y, int inactiveID, int activeID, bool initialState, int switchID, int tooltip )
		{
			gump.Add( new GumpCheckWTooltip( x, y, inactiveID, activeID, initialState, switchID, tooltip ) );
		}
	}
}