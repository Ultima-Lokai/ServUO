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
    public enum ReadStatus
    {
        None, Closed, Open, BadFile, RaceFileError, LegsFileError, InfoFileError, IO_Error, SwitchFileError,
        RaceFileParsed, LegsFileParsed, InfoFileParsed, EOF, Finished
    }

    public class LoadTARFile
    {
        public static void Initialize()
        {
            CommandSystem.Register("TARLoad", AccessLevel.Administrator, new CommandEventHandler(TARLoad_OnCommand));
        }

        private const string m_DefaultFile = "TAR0.race";

        [Usage("TARLoad {filename}")]
        [Description("Loads a .race file.")]
        public static void TARLoad_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            Container pack = m.Backpack;
            if (pack == null)
            {
                Console.WriteLine("Why do you have a 'null' Backpack.");
                return;
            }
            Item item = pack.FindItemByType(typeof(TARaceItem));
            if (item == null)
            {
                m_Item = new TARaceItem();
                m_Item.Races = new List<TARace>();
                pack.DropItem(m_Item);
            }
            else m_Item = item as TARaceItem;
            Console.WriteLine("TARLoad Command given.");

            m_Lines = new List<string>();
            string filename = e.GetString(0);

            if (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("No text file specified, so will use '{0}'.", m_DefaultFile);
                filename = m_DefaultFile;
            }
            ReadStatus raceReader = LoadFile(filename);

            try
            {
                m_TARStream.Close();
            }
            catch { }

            switch (raceReader)
            {
                case ReadStatus.BadFile:
                    Console.WriteLine("Bad filename specified.");
                    if (m_Item != null) m_Item.Delete();
                    break;

                case ReadStatus.InfoFileParsed:
                case ReadStatus.Finished:
                    Console.WriteLine("TARace File Successfully read.");
                    break;

                case ReadStatus.IO_Error:
                    Console.WriteLine("IO Error detected.");
                    if (m_Item != null) m_Item.Delete();
                    break;

                case ReadStatus.SwitchFileError:
                    Console.WriteLine("SwitchFile Error detected.");
                    if (m_Item != null) m_Item.Delete();
                    break;

                case ReadStatus.RaceFileError:
                    Console.WriteLine("Parse Error detected in race file.");
                    if (m_Item != null) m_Item.Delete();
                    break;

                case ReadStatus.LegsFileError:
                    Console.WriteLine("Parse Error detected in legs file.");
                    if (m_Item != null) m_Item.Delete();
                    break;

                case ReadStatus.InfoFileError:
                    Console.WriteLine("Parse Error detected in info file.");
                    if (m_Item != null) m_Item.Delete();
                    break;

                case ReadStatus.Open:
                    Console.WriteLine("Read Interrupted.");
                    m_TARStream.Close();
                    if (m_Item != null) m_Item.Delete();
                    break;

                case ReadStatus.RaceFileParsed:
                case ReadStatus.LegsFileParsed:
                default:
                    Console.WriteLine("Unknown error occurred.");
                    if (m_Item != null) m_Item.Delete();
                    break;
            }
        }

        private static ReadStatus m_Read;
        private static TARaceItem m_Item;
        private static StreamReader m_TARStream;
        private static List<string> m_Lines;

        public static ReadStatus SwitchFile(string filename)
        {
            try
            {
                m_TARStream.Close();
                string switchfile = "Data/TARfiles/" + filename;
                m_TARStream = new StreamReader(switchfile, Encoding.Default, false);
            }
            catch { Console.WriteLine("SwitchFile Error on file: {0}.", filename); return ReadStatus.SwitchFileError; }
            return ReadStatus.Open;
        }

        public static ReadStatus LoadFile(string filename)
        {
            string racefile = "Data/TARfiles/" + filename;

            if (!File.Exists(racefile))
                return ReadStatus.BadFile;

            return ReadTAR(racefile);
        }

        public static ReadStatus ReadTAR(string filename)
        {
            try { m_TARStream = new StreamReader(filename, Encoding.Default, false); }
            catch { return ReadStatus.IO_Error; }

            return ParseRace(filename);
        }

        public static ReadStatus ParseRace(string filename)
        {
            string[] raceParams;
            try
            {
                string raceString = m_TARStream.ReadLine();
                raceString.TrimEnd(' ');
                raceParams = raceString.Split('|');

                m_Item.Races.Add(new TARace(m_Item.Races.Count, new List<Leg>(), new List<RaceTeam>(),
                    raceParams[1], new Point3D(Convert.ToInt32(raceParams[2]), Convert.ToInt32(raceParams[3]),
                        Convert.ToInt32(raceParams[4])), Map.Parse(raceParams[5])));
                m_Read = ReadStatus.RaceFileParsed;
            }
            catch { return ReadStatus.RaceFileError; }

            return ParseLegs(raceParams[0]);
        }

        public static ReadStatus ParseLegs(string filename)
        {
            List<string[]> Legs = new List<string[]>();
            m_Read = SwitchFile(filename);
            if (m_Read == ReadStatus.Open)
            {
                try
                {
                    string line = m_TARStream.ReadLine();
                    line.TrimEnd(' ');
                    string[] legParams = line.Split('|');
                    Legs.Add(legParams);
                    m_Item.Races[m_Item.Races.Count - 1].Legs.Add(new Leg(m_Item.Races[m_Item.Races.Count - 1].Legs.Count,
                        new List<RouteInfo>(), bool.Parse(legParams[1]), (PenaltyType)Enum.Parse(typeof(PenaltyType),
                        legParams[2]), new Point3D(Convert.ToInt32(legParams[3]), Convert.ToInt32(legParams[4]),
                            Convert.ToInt32(legParams[5])), Map.Parse(legParams[6])));

                    while (!m_TARStream.EndOfStream)
                    {
                        line = m_TARStream.ReadLine();
                        legParams = line.Split('|');
                        Legs.Add(legParams);
                        m_Item.Races[m_Item.Races.Count - 1].Legs.Add(new Leg(m_Item.Races[m_Item.Races.Count - 1].Legs.Count,
                            new List<RouteInfo>(), bool.Parse(legParams[1]), (PenaltyType)Enum.Parse(typeof(PenaltyType),
                            legParams[2]), new Point3D(Convert.ToInt32(legParams[3]), Convert.ToInt32(legParams[4]),
                                Convert.ToInt32(legParams[5])), Map.Parse(legParams[6])));
                    }
                }
                catch { return ReadStatus.LegsFileError; }
            }
            else
                return m_Read;

            for (int x = 0; x < Legs.Count; x++)
            {
                string infoFile = Legs[x][0];
                m_Read = ParseInfo(infoFile, x);
            }
            return m_Read;
        }

        public static ReadStatus ParseInfo(string filename, int legID)
        {
            m_Read = SwitchFile(filename);
            if (m_Read == ReadStatus.Open)
            {
                try
                {
                    string line = m_TARStream.ReadLine();
                    line.TrimEnd(' ');
                    string[] infoParams = line.Split('|');
                    TravelType travelType;
                    string[] travelParams = infoParams[1].Split('^');
                    travelType = (TravelType)Enum.Parse(typeof(TravelType), travelParams[0]);
                    if (travelParams.Length > 1)
                    {
                        for (int x = 1; x < travelParams.Length; x++)
                        {
                            travelType |= (TravelType)Enum.Parse(typeof(TravelType), travelParams[x]);
                        }
                    }
                    m_Item.Races[m_Item.Races.Count - 1].Legs[legID].Info.Add(
                        new RouteInfo((RouteInfoType)Enum.Parse(typeof(RouteInfoType), infoParams[0]),
                        travelType,/* infoParams[2] == "0" ? typeof(Apple) : Type.GetType(infoParams[2]),*/ infoParams[3],
                        new Point3D(Convert.ToInt32(infoParams[4]), Convert.ToInt32(infoParams[5]),
                            Convert.ToInt32(infoParams[6])), Map.Parse(infoParams[7])));

                    while (!m_TARStream.EndOfStream)
                    {
                        line = m_TARStream.ReadLine();
                        infoParams = line.Split('|');
                        travelParams = infoParams[1].Split('^');
                        travelType = (TravelType)Enum.Parse(typeof(TravelType), travelParams[0]);
                        if (travelParams.Length > 1)
                        {
                            for (int x = 1; x < travelParams.Length; x++)
                            {
                                travelType |= (TravelType)Enum.Parse(typeof(TravelType), travelParams[x]);
                            }
                        }
                        m_Item.Races[m_Item.Races.Count - 1].Legs[legID].Info.Add(
                            new RouteInfo((RouteInfoType)Enum.Parse(typeof(RouteInfoType), infoParams[0]),
                            travelType,/* infoParams[2] == "0" ? typeof(Apple) : Type.GetType(infoParams[2]),*/ infoParams[3],
                            new Point3D(Convert.ToInt32(infoParams[4]), Convert.ToInt32(infoParams[5]),
                                Convert.ToInt32(infoParams[6])), Map.Parse(infoParams[7])));
                    }
                }
                catch { return ReadStatus.InfoFileError; }
            }
            else
                return m_Read;

            return ReadStatus.InfoFileParsed;
        }
    }
}
