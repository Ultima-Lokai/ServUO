using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class MiniToolbar : Gump
	{
		private Mobile m_From;
		
		public MiniToolbar( Mobile from ) : this( from, 5, 33 )
		{
		}
		
		public MiniToolbar( Mobile from, int x, int y ) : base( 0, 0 )
		{
			m_From = from;
			
			m_From.CloseGump( typeof( MiniToolbar ) );
			
			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;
			AddPage( 0 );
			AddBackground( x, y, 62, 22, 9200 );
			AddImageTiledButton( x + 4, y + 5, 1210, 1209, 1, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 3002086 ); // Maximize
			AddLabel( x + 20, y, 0, @"Show" );
		}
		
		public override void OnResponse( NetState state, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
				m_From.SendGump( new FullToolbar( m_From ) );
			m_From.CloseGump( typeof( MiniToolbar ) );
		}
	}
}