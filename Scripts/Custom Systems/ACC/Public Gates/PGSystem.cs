using System;
using System.IO;
using System.Collections;
using Server.Gumps;
using Server.Network;
using Server.Commands;

namespace Server.ACC.PG
{
	public class PGSystem : ACCSystem
	{
/**I made a big booboo with the de/serialization of this system.
 **I didn't use versioning and therefore it made it a bit more difficult to add new things.
 **As such, I've done this work around.  Load the shard up and save it.
 **After doing that, set this to true.                   **/
/**/	public static bool UseVersioning = true;        /**/
/***********************************************************/

		private static ArrayList m_Entries = new ArrayList();
		public  static ArrayList Entries{ get{ return m_Entries; } set{ m_Entries = value; } }

		public override string Name(){ return "Public Gates"; }

		public static void Configure()
		{
			ACC.RegisterSystem( "Server.ACC.PG.PGSystem" );
		}

		public static bool Running
		{
			get{ return ACC.SysEnabled( "Server.ACC.PG.PGSystem" ); }
		}

		public override void Enable()
		{
			Console.WriteLine( "{0} has just been enabled!", Name() );
			GenGates();
		}

		public override void Disable()
		{
			Console.WriteLine( "{0} has just been disabled!", Name() );
			RemGates();
		}

		public static void Initialize()
		{
			CommandSystem.Register( "GenGates", AccessLevel.GameMaster, new CommandEventHandler( OnGenGates ) );
			CommandSystem.Register( "RemGates", AccessLevel.GameMaster, new CommandEventHandler( OnRemGates ) );
		}

		[Usage( "GenGates" )]
		[Description( "Generates a gate at each location of the control stone." )]
		private static void OnGenGates( CommandEventArgs e )
		{
			if( Running )
				GenGates();
			else
				e.Mobile.SendMessage( "The Public Gate System is not active." );
		}

		[Usage( "RemGates" )]
		[Description( "Removes all Public Gates from the world." )]
		private static void OnRemGates( CommandEventArgs e )
		{
			if( Running )
				RemGates();
			else
				e.Mobile.SendMessage( "The Public Gate System is not active." );
		}

		public static void GenGates()
		{
			RemGates();

			if( m_Entries == null )
				m_Entries = new ArrayList();

			int count = 0;
			foreach( PGCategory PGC in m_Entries )
			{
				if( PGC.GetFlag( EntryFlag.Generate ) )
				{
					foreach( PGLocation PGL in PGC.Locations )
					{
						if( PGL.GetFlag( EntryFlag.Generate ) )
						{
							PublicGate gate = new PublicGate();

							gate.MoveToWorld( PGL.Location, PGL.Map );
							gate.Name = "Public Gate: " + PGL.Name;
							gate.Hue = PGL.Hue;
							count++;
						}
					}
				}
			}

			World.Broadcast( 6, true, "{0} public gates generated.", count );
		}

		public static void RemGates()
		{
			ArrayList list = new ArrayList();

			foreach( Item item in World.Items.Values )
			{
				if( item is PublicGate && item.Parent == null )
					list.Add( item );
			}

			foreach( Item item in list )
				item.Delete();

			if( list.Count > 0 )
				World.Broadcast( 6, true, "{0} public gates removed.", list.Count );
		}

		public override void Save( GenericWriter idx, GenericWriter tdb, GenericWriter writer )
		{
			writer.Write( (int)0 ); //version

			writer.Write( m_Entries.Count );
			for( int i = 0; i < m_Entries.Count; i++ )
			{
				((PGCategory)m_Entries[i]).Serialize( writer );
			}
		}

		public override void Load( BinaryReader idx, BinaryReader tdb, BinaryFileReader reader )
		{
			int version = reader.ReadInt();

			m_Entries = new ArrayList();
			int count = reader.ReadInt();
			for( int i = 0; i < count; i++ )
			{
				m_Entries.Add( new PGCategory( reader ) );
			}
		}

		private object[] Params;
		private PGCategory SelC = null;
		private PGLocation SelL = null;
		private string[] Dirs = null;

		public override void Gump( Mobile from, Gump gump, object[] subParams )
		{
			gump.AddButton( 195, 40, 2445, 2445, 101, GumpButtonType.Reply, 0 );
			gump.AddLabel(  200, 41, 1153, "Manage System" );
			gump.AddButton( 310, 40, 2445, 2445, 102, GumpButtonType.Reply, 0 );
			gump.AddLabel(  342, 41, 1153, "Import" );

			if( subParams == null )
			{
				gump.AddHtml( 215, 65, 300,  25, "<basefont size=7 color=white><center>Public Gates</center></font>", false, false );
				gump.AddHtml( 140, 95, 450, 250, "<basefont color=white><center>Welcome to the Public Gate Admin Gump!</center><br>With this gump, you can manage the entire system and import and export locations or full categories.  Please choose an option from the top bar.<br><br>Manage System allows you to add/change/delete locations and categories from anywhere in the world.<br><br>Im/Ex port allows you to import or export categories and locations to files that you can distribute to other servers that use this system.</font>", false, false );
				return;
			}

			switch( (int)subParams[0] )
			{
				case 1:
				{//Manage

					gump.AddBackground( 640, 0, 160, 400, 5120 );
					gump.AddButton( 425, 40, 2445, 2445, 123, GumpButtonType.Reply, 0 );
					gump.AddLabel(  456, 41, 1153, "Export" );

					int sC = -1;
					if( subParams.Length >= 2 )
						sC = (int)subParams[1];

					for( int i = 0; i < m_Entries.Count; i++ )
					{
						PGCategory PGC = (PGCategory)m_Entries[i];
						if( PGC != null )
						{
							gump.AddButton( 650, 10+i*30, 2501, 2501, 150+i, GumpButtonType.Reply, 0 );
							gump.AddButton( 655, 12+i*30, (sC==i?5401:5402), (sC==i?5402:5401), 150+i, GumpButtonType.Reply, 0 );
							gump.AddLabel(  675, 10+i*30, 1153, PGC.Name );
							if( sC == i )
								SelC = PGC;
						}
					}

					if( SelC != null )
					{
						Params = subParams;

						gump.AddBackground( 425, 75, 170, 285, 5120 );
						gump.AddButton( 195, 65, 2445, 2445, 121, GumpButtonType.Reply, 0 );
						gump.AddLabel(  206, 66, 1153, "Add Category" );
						gump.AddButton( 310, 65, 2445, 2445, 122, GumpButtonType.Reply, 0 );
						gump.AddLabel(  322, 66, 1153, "Add Location" );

						int sL = -1;
						if( subParams.Length >= 3 )
							sL = (int)subParams[2];

						for( int i = 0, c = 0, r = 0; i < SelC.Locations.Count; i++ )
						{
							PGLocation PGL = (PGLocation)SelC.Locations[i];
							if( PGL != null )
							{
								gump.AddButton( 120+c*150, 100+r*30, 2501, 2501, 200+i, GumpButtonType.Reply, 0 );
								gump.AddButton( 125+c*150, 102+r*30, (sL==i?5401:5402), (sL==i?5402:5401), 200+i, GumpButtonType.Reply, 0 );
								gump.AddLabel(  145+c*150, 100+r*30, 1153, PGL.Name );
								r += (c==1?1:0);
								c += (c==1?-1:1);
								if( sL == i )
									SelL = PGL;
							}
						}

						if( SelL != null )
						{
							gump.AddButton( 550, 265, 2642, 2643, 103, GumpButtonType.Reply, 0 );

							gump.AddImage(     440, 85, 2501 );
							gump.AddTextEntry( 446, 85, 130, 20, 0, 105, SelL.Name );

							gump.AddImage( 445, 110, 2443 );
							gump.AddImage( 513, 110, 2443 );
							gump.AddImage( 445, 135, 2443 );
							gump.AddImage( 513, 135, 2443 );
							gump.AddImage( 445, 160, 2443 );

							gump.AddTextEntry( 450, 110, 53, 20, 0, 106, SelL.Location.X.ToString() );
							gump.AddTextEntry( 518, 110, 53, 20, 0, 107, SelL.Location.Y.ToString() );
							gump.AddTextEntry( 450, 135, 53, 20, 0, 108, SelL.Location.Z.ToString() );
							gump.AddTextEntry( 518, 135, 53, 20, 0, 109, SelL.Hue.ToString() );
							gump.AddTextEntry( 450, 160, 53, 20, 0, 110, SelL.Cost.ToString() );

							gump.AddLabel( 435, 112, 1153, "X" );
							gump.AddLabel( 578, 112, 1153, "Y" );
							gump.AddLabel( 435, 137, 1153, "Z" );
							gump.AddLabel( 578, 137, 1153, "H" );
							gump.AddLabel( 435, 162, 1153, "C" );

							gump.AddRadio( 435, 190, 208, 209, (SelL.Map==Map.Trammel), 111 );
							gump.AddRadio( 570, 190, 208, 209, (SelL.Map==Map.Malas), 112 );
							gump.AddRadio( 435, 215, 208, 209, (SelL.Map==Map.Felucca), 113 );
							gump.AddRadio( 570, 215, 208, 209, (SelL.Map==Map.Ilshenar), 114 );
							gump.AddRadio( 435, 240, 208, 209, (SelL.Map==Map.Tokuno), 115 );

							gump.AddLabel( 460, 192, 1153, "Tram" );
							gump.AddLabel( 530, 192, 1153, "Malas" );
							gump.AddLabel( 460, 217, 1153, "Fel" );
							gump.AddLabel( 542, 217, 1153, "Ilsh" );
							gump.AddLabel( 460, 242, 1153, "Tokuno" );

							gump.AddLabel( 465, 282, 1153, "Young?" );
							gump.AddCheck( 440, 280, 210, 211, SelL.GetFlag( EntryFlag.Young ), 120 );
							gump.AddLabel( 465, 307, 1153, "Gen?" );
							gump.AddCheck( 440, 305, 210, 211, SelL.GetFlag( EntryFlag.Generate ), 116 );
							gump.AddLabel( 515, 307, 1153, "Staff?" );
							gump.AddCheck( 565, 305, 210, 211, SelL.GetFlag( EntryFlag.StaffOnly ), 117 );
							gump.AddLabel( 465, 332, 1153, "Reds?" );
							gump.AddCheck( 440, 330, 210, 211, SelL.GetFlag( EntryFlag.Reds ), 118 );
							gump.AddLabel( 522, 332, 1153, "Chrg?" );
							gump.AddCheck( 565, 330, 210, 211, SelL.GetFlag( EntryFlag.Charge ), 119 );
						}

						else
						{
							gump.AddButton( 550, 265, 2642, 2643, 104, GumpButtonType.Reply, 0 );

							gump.AddImage(     440, 110, 2501 );
							gump.AddTextEntry( 446, 110, 130, 20, 0, 105, SelC.Name );

							gump.AddImage( 445, 160, 2443 );
							gump.AddTextEntry( 450, 160, 53, 20, 0, 110, SelC.Cost.ToString() );
							gump.AddLabel( 435, 162, 1153, "C" );

							gump.AddLabel( 465, 282, 1153, "Young?" );
							gump.AddCheck( 440, 280, 210, 211, SelC.GetFlag( EntryFlag.Young ), 120 );
							gump.AddLabel( 465, 307, 1153, "Gen?" );
							gump.AddCheck( 440, 305, 210, 211, SelC.GetFlag( EntryFlag.Generate ), 116 );
							gump.AddLabel( 515, 307, 1153, "Staff?" );
							gump.AddCheck( 565, 305, 210, 211, SelC.GetFlag( EntryFlag.StaffOnly ), 117 );
							gump.AddLabel( 465, 332, 1153, "Reds?" );
							gump.AddCheck( 440, 330, 210, 211, SelC.GetFlag( EntryFlag.Reds ), 118 );
							gump.AddLabel( 522, 332, 1153, "Chrg?" );
							gump.AddCheck( 565, 330, 210, 211, SelC.GetFlag( EntryFlag.Charge ), 119 );
						}
					}
					break;
				}

				case 2:
				{//Import
					if( !Directory.Exists( "ACC Exports" ) )
					{
						from.SendMessage( "There are no files to import!" );
						return;
					}

					gump.AddButton( 195, 65, 2445, 2445, 124, GumpButtonType.Reply, 0 );
					gump.AddLabel(  220, 66, 1153, "Systems" );

					gump.AddButton( 310, 65, 2445, 2445, 125, GumpButtonType.Reply, 0 );
					gump.AddLabel(  328, 66, 1153, "Categories" );

					gump.AddButton( 425, 65, 2445, 2445, 126, GumpButtonType.Reply, 0 );
					gump.AddLabel(  447, 66, 1153, "Locations" );

					int Sel = -1;
					if( subParams.Length >= 2 )
						Sel = (int)subParams[1];

					switch( Sel )
					{
						case 0:{ Dirs = Directory.GetFiles( "ACC Exports/", "*.pgs" ); break; }
						case 1:{ Dirs = Directory.GetFiles( "ACC Exports/", "*.pgc" ); break; }
						case 2:{ Dirs = Directory.GetFiles( "ACC Exports/", "*.pgl" ); break; }
						default: return;
					}

					if( Dirs == null || Dirs.Length == 0 )
					{
						from.SendMessage( "There are no files of that type!" );
						return;
					}

					for( int i = 0, r = 0, c = 0; i < Dirs.Length && c < 3; i++ )
					{
						string s = Dirs[i];
						s = s.Remove( 0, 12 );
						s = s.Remove( s.Length-4, 4 );
						if( Sel == 0 )
							s = s.Remove( 0, 9 );

						gump.AddButton( 120+c*150, 100+r*30, 2501, 2501, 300+i, GumpButtonType.Reply, 0 );
						gump.AddLabelCropped( 125+c*150, 101+r*30, 140, 30, 1153, s );

						c += (r==7?1:0);
						r += (r==7?-7:1);
					}
					break;
				}
			}
		}

		public override void Help( Mobile from, Gump gump )
		{
		}
/* ID's:
 101 = Button Manage System
 102 = Button Import Page
 103 = Button Apply Location
 104 = Button Apply Category
 105 = Text   Name
 106 = Text   X
 107 = Text   Y
 108 = Text   Z
 109 = Text   Hue
 110 = Text   Cost
 111 = Radio  Trammel
 112 = Radio  Malas
 113 = Radio  Felucca
 114 = Radio  Ilshenar
 115 = Radio  Tokuno
 116 = Check  Generate
 117 = Check  StaffOnly
 118 = Check  Reds
 119 = Check  Charge
 120 = Check  Young
 121 = Button Add Category
 122 = Button Add Location
 123 = Button Export
 124 = Button Import Systems
 125 = Button Import Categories
 126 = Button Import Locations
  */
		public override void OnResponse( NetState state, RelayInfo info, object[] subParams )
		{
			if( state.Mobile.AccessLevel == AccessLevel.Player )
				return;
			if( info.ButtonID == 0 )
				return;

			if( info.ButtonID == 101 )
				subParams = new object[1]{1};

			else if( info.ButtonID == 102 )
				subParams = new object[1]{2};

			else if( info.ButtonID == 103 || info.ButtonID == 104 || info.ButtonID == 121 || info.ButtonID == 122 )
			{
				SetFlag( EntryFlag.Generate,  info.IsSwitched( 116 ) );
				SetFlag( EntryFlag.StaffOnly, info.IsSwitched( 117 ) );
				SetFlag( EntryFlag.Reds,      info.IsSwitched( 118 ) );
				SetFlag( EntryFlag.Charge,    info.IsSwitched( 119 ) );

				Map Map = info.IsSwitched(111)?Map.Trammel:info.IsSwitched(112)?Map.Malas:info.IsSwitched(113)?Map.Felucca:info.IsSwitched(114)?Map.Ilshenar:info.IsSwitched(115)?Map.Tokuno:Map.Trammel;

				string Name = GetString( info, 105 );
				string X    = GetString( info, 106 );
				string Y    = GetString( info, 107 );
				string Z    = GetString( info, 108 );
				string H    = GetString( info, 109 );
				string C    = GetString( info, 110 );

				if( Name == null || Name.Length == 0 )
				{
					try
					{
						state.Mobile.SendMessage( "Removed the entry" );
						if( info.ButtonID == 103 )
							SelC.Locations.RemoveAt( (int)Params[2] );
						else
							m_Entries.RemoveAt( (int)Params[1] );
					}
					catch
					{
						Console.WriteLine( "Exception caught removing entry" );
					}
				}

				else
				{
					if( info.ButtonID == 103 || info.ButtonID == 122 )
					{
						int x, y, z, h, c = 0;
						Point3D Loc;
						int Hue;
						int Cost;
						PGLocation PGL;

						if( X == null || X.Length == 0 ||
				    		Y == null || Y.Length == 0 ||
				    		Z == null || Z.Length == 0 ||
				    		H == null || H.Length == 0 ||
							C == null || C.Length == 0 )
						{
							if( info.ButtonID == 122 )
							{
								Hue = 0;
								Loc = new Point3D( 0, 0, 0 );
								Cost = 0;

								PGL = new PGLocation( Name, Flags, Loc, Map, Hue, Cost );
								if( PGL == null )
								{
									state.Mobile.SendMessage( "Error adding Location." );
									return;
								}

								SelC.Locations.Add( PGL );
							}

							state.Mobile.SendMessage( "Please fill in each field." );
							state.Mobile.SendGump( new ACCGump( state.Mobile, this.ToString(), subParams ) );
							return;
						}

						try
						{
							x = Int32.Parse( X );
							y = Int32.Parse( Y );
							z = Int32.Parse( Z );
							h = Int32.Parse( H );
							c = Int32.Parse( C );
							Loc = new Point3D( x, y, z );
							Hue = h;
							Cost = c;
						}
						catch
						{
							state.Mobile.SendMessage( "Please enter an integer in each of the info fields. (X, Y, Z, H, Cost)" );
							state.Mobile.SendGump( new ACCGump( state.Mobile, this.ToString(), subParams ) );
							return;
						}

						PGL = new PGLocation( Name, Flags, Loc, Map, Hue, Cost );
						if( PGL == null )
						{
							state.Mobile.SendMessage( "Bad Location information, can't add!" );
						}
						else
						{
							try
							{
								if( info.ButtonID == 122 )
								{
									SelC.Locations.Add( PGL );
									state.Mobile.SendMessage( "Added the Location." );
								}
								else
								{
									state.Mobile.SendMessage( "Changed the Location." );
									SelC.Locations[(int)Params[2]] = PGL;
								}
							}
							catch
							{
								Console.WriteLine( "Problem adding/changing Location!" );
							}
						}
					}

					else
					{
						if( C == null || C.Length == 0 )
						{
							state.Mobile.SendMessage( "Please fill in each field." );
							state.Mobile.SendGump( new ACCGump( state.Mobile, this.ToString(), subParams ) );
							return;
						}

						int c = 0;
						int Cost;
						try
						{
							c = Int32.Parse( C );
							Cost = c;
						}
						catch
						{
							state.Mobile.SendMessage( "Please enter an integer for the Cost" );
							state.Mobile.SendGump( new ACCGump( state.Mobile, this.ToString(), subParams ) );
							return;
						}

						try
						{
							if( info.ButtonID == 121 )
							{
								PGSystem.Entries.Add( new PGCategory( Name, Flags, Cost ) );
								state.Mobile.SendMessage( "Added the Category." );
							}
							else
							{
								((PGCategory)m_Entries[(int)Params[1]]).Name  = Name;
								((PGCategory)m_Entries[(int)Params[1]]).Flags = Flags;
								((PGCategory)m_Entries[(int)Params[1]]).Cost  = Cost;
								state.Mobile.SendMessage( "Changed the Category." );
							}
						}
						catch
						{
							Console.WriteLine( "Problems adding/changing Category!" );
						}
					}
				}
			}

			else if( info.ButtonID == 123 )
			{
				if( !Directory.Exists( "ACC Exports" ) )
					Directory.CreateDirectory( "ACC Exports" );

				string fileName;
				string Path = "ACC Exports/";

				if( SelL != null )
					fileName = SelL.Name + ".pgl";
				else if( SelC != null )
					fileName = SelC.Name + ".pgc";
				else
					fileName = String.Format( "System - {0:yyMMdd-HHmmss}.pgs", DateTime.Now );

				try
				{
					using( FileStream m_FileStream = new FileStream( Path+fileName, FileMode.Create, FileAccess.Write ) )
					{
						GenericWriter writer = new BinaryFileWriter( m_FileStream, true );

						if( SelL != null )
						{
							SelL.Serialize( writer );
							state.Mobile.SendMessage( "Exported the Location to {0}{1}", Path, fileName );
						}
						else if( SelC != null )
						{
							SelC.Serialize( writer );
							state.Mobile.SendMessage( "Exported the Category (and all Locations contained within) to {0}{1}", Path, fileName );
						}
						else
						{
							writer.Write( (int)0 ); //version

							writer.Write( m_Entries.Count );
							for( int i = 0; i < m_Entries.Count; i++ )
							{
								((PGCategory)m_Entries[i]).Serialize( writer );
							}
							state.Mobile.SendMessage( "Exported the entire Public Gates System to {0}{1}", Path, fileName );
						}

						writer.Close();
						m_FileStream.Close();
					}
				}
				catch( Exception e )
				{
					state.Mobile.SendMessage( "Problem exporting the selection.  Please contact the admin." );
					Console.WriteLine( "Error exporting PGSystem : {0}", e );
				}
			}

			else if( info.ButtonID == 124 || info.ButtonID == 125 || info.ButtonID == 126 )
			{
				subParams = new object[2]{2,info.ButtonID-124};
			}

			else if( info.ButtonID >= 300 && Dirs != null && Dirs.Length > 0 )
			{
				if( !Directory.Exists( "ACC Exports" ) )
					Directory.CreateDirectory( "ACC Exports" );

				string Path = null;
				try
				{
					Path = Dirs[info.ButtonID-300];

					if( File.Exists( Path ) )
					{
						using( FileStream m_FileStream = new FileStream( Path, FileMode.Open, FileAccess.Read, FileShare.Read ) )
						{
							BinaryFileReader reader = new BinaryFileReader( new BinaryReader( m_FileStream ) );

							int Sel = -1;
							if( subParams.Length >= 2 )
								Sel = (int)subParams[1];

							switch( Sel )
							{
								case 0:
								{//Systems
									int version = reader.ReadInt();
									int count = reader.ReadInt();
									ArrayList list = new ArrayList();
									for( int i = 0; i < count; i++ )
										list.Add( new PGCategory( reader ) );

									state.Mobile.CloseGump( typeof( SysChoiceGump ) );
									state.Mobile.SendGump( new SysChoiceGump( this.ToString(), subParams, list ) );
									break;
								}
								case 1:
								{//Categories
									if( m_Entries == null )
										m_Entries = new ArrayList();

									m_Entries.Add( new PGCategory( reader ) );
									state.Mobile.SendMessage( "Added the Category." );
									break;
								}
								case 2:
								{//Locations
									state.Mobile.CloseGump( typeof( CatSelGump ) );
									state.Mobile.SendMessage( "Please choose a Category to put this Location in." );
									state.Mobile.SendGump( new CatSelGump( this.ToString(), subParams, new PGLocation( reader ) ) );
									break;
								}
							}

							reader.Close();

							if( Sel == 0 || Sel == 2 )
								return;
						}
					}
				}
				catch
				{
				}
			}

			else if( info.ButtonID >= 150 && info.ButtonID < m_Entries.Count+150 )
				subParams = new object[2]{1,info.ButtonID-150};

			else if( info.ButtonID >= 200 && info.ButtonID < 200+((PGCategory)m_Entries[(int)Params[1]]).Locations.Count )
				subParams = new object[3]{1,(int)Params[1],info.ButtonID-200};

			state.Mobile.SendGump( new ACCGump( state.Mobile, this.ToString(), subParams ) );
		}

		private string GetString( RelayInfo info, int id )
		{
			TextRelay t = info.GetTextEntry( id );
			return (t == null ? null : t.Text.Trim());
		}

		private EntryFlag Flags;
		private void SetFlag( EntryFlag flag, bool value )
		{
			if( value )
				Flags |= flag;
			else Flags &= ~flag;
		}

		private class SysChoiceGump : Gump
		{
			private string Sys = null;
			private object[] Params;
			private ArrayList List;
			public SysChoiceGump( string sys, object[] subParams, ArrayList list ) : base( 0, 0 )
			{
				Sys = sys;
				Params = subParams;
				List = list;
				AddPage(0);
				AddBackground( 250, 245, 300, 90, 5120 );
				AddLabel( 282, 260, 1153, "Overwrite or Add To current system?" );
				AddButton( 280, 290, 2445, 2445, 1, GumpButtonType.Reply, 0 );
				AddButton( 410, 290, 2445, 2445, 2, GumpButtonType.Reply, 0 );
				AddLabel( 300, 291, 1153, "Overwrite" );
				AddLabel( 442, 291, 1153, "Add To" );
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				if( info.ButtonID == 0 )
					return;

				if( info.ButtonID == 1 )
					PGSystem.Entries = new ArrayList();

				for( int i = 0; i < List.Count; i++ )
					PGSystem.Entries.Add( (PGCategory)List[i] );

				state.Mobile.SendGump( new ACCGump( state.Mobile, Sys, Params ) );
				state.Mobile.SendMessage( "Import successful." );
			}
		}

		private class CatSelGump : Gump
		{
			private string Sys = null;
			private object[] Params;
			private PGLocation Loc = null;
			public CatSelGump( string sys, object[] subParams, PGLocation loc ) : base( 0, 0 )
			{
				if( sys == null || subParams == null || loc == null || PGSystem.Entries == null )
					return;

				Sys = sys;
				Params = subParams;
				Loc = loc;

				AddPage(0);
				AddBackground( 640, 0, 160, 400, 5120 );

				for( int i = 0; i < PGSystem.Entries.Count; i++ )
				{
					PGCategory PGC = (PGCategory)PGSystem.Entries[i];
					if( PGC != null )
					{
						AddButton( 650, 10+i*30, 2501, 2501, 1+i, GumpButtonType.Reply, 0 );
						AddLabel(  675, 10+i*30, 1153, PGC.Name );
					}
				}
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				if( info.ButtonID == 0 )
					return;

				((PGCategory)PGSystem.Entries[info.ButtonID-1]).Locations.Add( Loc );
				state.Mobile.SendGump( new ACCGump( state.Mobile, Sys, Params ) );
				state.Mobile.SendMessage( "Location added to {0}.", ((PGCategory)PGSystem.Entries[info.ButtonID-1]).Name );
			}
		}
	}
}