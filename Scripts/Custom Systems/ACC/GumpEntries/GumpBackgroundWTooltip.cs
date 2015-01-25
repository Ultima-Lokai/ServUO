using System;
using Server.Network;

namespace Server.Gumps
{
	public class GumpBackgroundWTooltip : GumpEntry
	{
		private int m_X, m_Y;
		private int m_Width, m_Height;
		private int m_GumpID;
		private int m_Tooltip;

		public int X
		{
			get
			{
				return m_X;
			}
			set
			{
				Delta( ref m_X, value );
			}
		}

		public int Y
		{
			get
			{
				return m_Y;
			}
			set
			{
				Delta( ref m_Y, value );
			}
		}

		public int Width
		{
			get
			{
				return m_Width;
			}
			set
			{
				Delta( ref m_Width, value );
			}
		}

		public int Height
		{
			get
			{
				return m_Height;
			}
			set
			{
				Delta( ref m_Height, value );
			}
		}

		public int GumpID
		{
			get
			{
				return m_GumpID;
			}
			set
			{
				Delta( ref m_GumpID, value );
			}
		}

		public int Tooltip
		{
			get
			{
				return m_Tooltip;
			}
			set
			{
				Delta( ref m_Tooltip, value );
			}
		}

		public GumpBackgroundWTooltip( int x, int y, int width, int height, int gumpID, int tooltip )
		{
			m_X = x;
			m_Y = y;
			m_Width = width;
			m_Height = height;
			m_GumpID = gumpID;
			m_Tooltip = tooltip;
		}

		public override string Compile()
		{
			return String.Format( "{{ resizepic {0} {1} {2} {3} {4} }}{{ tooltip {5} }}", m_X, m_Y, m_GumpID, m_Width, m_Height, m_Tooltip );
		}

		private static byte[] m_LayoutName = Gump.StringToBuffer( "resizepic" );
		private static byte[] m_LayoutTooltip = Gump.StringToBuffer( " }{ tooltip" );

		public override void AppendTo( IGumpWriter disp )
		{
			disp.AppendLayout( m_LayoutName );
			disp.AppendLayout( m_X );
			disp.AppendLayout( m_Y );
			disp.AppendLayout( m_GumpID );
			disp.AppendLayout( m_Width );
			disp.AppendLayout( m_Height );
			disp.AppendLayout( m_LayoutTooltip );
			disp.AppendLayout( m_Tooltip );
		}
	}
}