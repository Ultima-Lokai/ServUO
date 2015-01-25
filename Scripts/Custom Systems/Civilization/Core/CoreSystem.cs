using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Engines.XmlSpawner2;
using Server.Accounting;
using Server.Mobiles;
using Server.Commands;
using Server.Gumps;
using Server.Network;
using Server.ACC;
using Server.UOC.Concepts;

namespace Server.UOC
{
    public class CoreSystem : ACCSystem
    {

        public static void Initialize()
        {
            CommandSystem.Register("CivAdd", AccessLevel.Administrator, new CommandEventHandler(CivAdd));
            CommandSystem.Register("CivJoin", AccessLevel.Player, new CommandEventHandler(CivJoin));
            CommandSystem.Register("CivHelp", AccessLevel.Player, new CommandEventHandler(CivHelp));
            CommandSystem.Register("CivLogin", AccessLevel.Administrator, new CommandEventHandler(CivLogin));
        }

        [Usage("CivLogin")]
        [Description("Displays the Civilization Login Gump.")]
        private static void CivLogin(CommandEventArgs e)
        {
            e.Mobile.SendGump(new LoginGump(e.Mobile, 1));
        }

        [Usage("CivHelp {Concept}")]
        [Description("Displays the Civilopedia Help guide.")]
        private static void CivHelp(CommandEventArgs e)
        {
            e.Mobile.SendGump(new Civilopedia(e.Mobile, e.ArgString));
        }

        [Usage("CivJoin {CivName}")]
        [Description("Joins the Citizen to the Civilization named.")]
        private static void CivJoin(CommandEventArgs e)
        {
            CitizenAttachment ca = XmlAttach.FindAttachment(e.Mobile, typeof(CitizenAttachment)) as CitizenAttachment;
            if (!(e.Mobile is PlayerMobile) || ca != null)
            {
                e.Mobile.SendMessage("You may not change Civilizations.");
                return;
            }
            PlayerMobile mobile = e.Mobile as PlayerMobile;

            string[] Args = e.ArgString.Split(' ');
            string CivName = Args[0];
            if (Args[0] != null)
            {
                if (Running)
                {
                    if (m_CivEntries.Count < 1)
                    {
                        CivAdd(e);
                    }

                    CivJoin(mobile, CivName);
                }
                else
                    mobile.SendMessage("The UO Civilization System is not active!");
            }
            else
                mobile.SendMessage("Usage: CivJoin {CivName}");
        }

        public static bool AnyCivOpen()
        {
            bool found = false;
            foreach (KeyValuePair<string, CivEntry> kvp in m_CivEntries)
            {
                if (kvp.Value.IsOpen)
                    found = true;
            }
            return found;
        }

        public static void CivJoin(PlayerMobile mobile, string CivName)
        {
            CivEntry civ;
            try
            {
                civ = m_CivEntries[CivName];
            }
            catch
            {
                mobile.SendMessage("No such Civilization found.");
                return;
            }
            if (civ != null)
            {
                civ.Citizens.Add(mobile);
                XmlAttach.AttachTo(mobile, new CitizenAttachment(CivName));
            }
            else
                mobile.SendMessage("Civilization is invalid.");
        }

        [Usage("CivAdd {CivName}")]
        [Description("Adds a Civilization with the name given.")]
        private static void CivAdd(CommandEventArgs e)
        {
            if (Running)
            {
                try
                {
                    m_CivEntries.Add(e.ArgString, new CivEntry(e.ArgString));
                    e.Mobile.SendMessage("Successfully created new Civilization.");
                }
                catch (ArgumentException ae)
                {
                    e.Mobile.SendMessage("Civilization already exists.");
                    Console.WriteLine("{0}",ae.Message);
                }
            }
            else
                e.Mobile.SendMessage("The UO Civilization System is not active!");
        }

        private static Dictionary<string, CivEntry> m_CivEntries = new Dictionary<string, CivEntry>();
        public static Dictionary<string, CivEntry> CivEntries { get { return m_CivEntries; } set { m_CivEntries = value; } }

        public override string Name() { return "UO Civilizations"; }
        public override void Save(GenericWriter idx, GenericWriter tdb, GenericWriter writer)
        {
            writer.Write((int)0); //version

            writer.Write((int)m_CivEntries.Count);
            if (m_CivEntries.Count > 0)
            {
                foreach (KeyValuePair<string, CivEntry> kvp in m_CivEntries)
                {
                    if (kvp.Key == null || kvp.Key == "")
                    {
                        Console.WriteLine("Null or blank kvp.Key detected - skipping Civ.");
                        continue;
                    }
                    writer.Write((string)kvp.Key);
                    ((CivEntry)m_CivEntries[kvp.Key]).Serialize(writer);
                }
            }
            else writer.Write((int)0);
        }
        public override void Load(BinaryReader idx, BinaryReader tdb, BinaryFileReader reader)
        {
            int version = reader.ReadInt();
            string key;
            m_CivEntries = new Dictionary<string, CivEntry>();
            int count = reader.ReadInt();
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        key = reader.ReadString();
                        if (key == null || key == "")
                        {
                            Console.WriteLine("How did we write a blank or null key to the Writer??");
                            key = string.Format("Civ{0}", count.ToString());
                        }
                        m_CivEntries.Add(key, new CivEntry(reader));
                    }
                    catch
                    {
                        Console.WriteLine("Caught exception reading CivEntries.");
                        continue;
                    }
                }
            }
        }

        private object[] Params;
        private CivEntry CivE = null;
        private string[] Dirs = null;
        private List<CivEntry> civList;

        public override void Gump(Mobile from, Gump gump, object[] subParams)
        {
            gump.AddButton(195, 40, 2445, 2445, 101, GumpButtonType.Reply, 0);
            gump.AddLabel(200, 41, 1153, "Manage System");
            gump.AddButton(310, 40, 2445, 2445, 102, GumpButtonType.Reply, 0);
            gump.AddLabel(342, 41, 1153, "Import");

            if (subParams == null)
            {
                gump.AddHtml(215, 65, 300, 25, "<basefont size=7 color=white><center>UO Civilizations</center></font>", false, false);
                gump.AddHtml(140, 95, 450, 250, "<basefont color=white><center>Welcome to the UO Civilization Admin Gump!</center><br>With this gump, you can view and manage the entire system.  Please choose an option from the top bar.<br><br>Manage System allows you to add/change/delete Civilizations.<br><br>Im/Ex port allows you to import or export Civilizations to files that you can distribute to other servers that use this system.</font>", false, false);
                return;
            }

            switch ((int)subParams[0])
            {
                case 1:
                    {//Manage

                        gump.AddBackground(640, 0, 160, 400, 5120);
                        gump.AddButton(425, 40, 2445, 2445, 123, GumpButtonType.Reply, 0);
                        gump.AddLabel(456, 41, 1153, "Export");

                        int sC = -1;
                        if (subParams.Length >= 2)
                            sC = (int)subParams[1];
                        int i = 0;

                        civList = new List<CivEntry>();

                        foreach (KeyValuePair<string,CivEntry> kvp in m_CivEntries)
                        {
                            CivEntry CIV = (CivEntry)m_CivEntries[kvp.Key];
                            if (CIV != null)
                            {
                                gump.AddButton(650, 10 + i * 30, 2501, 2501, 150 + i, GumpButtonType.Reply, 0);
                                gump.AddButton(655, 12 + i * 30, (sC == i ? 5401 : 5402), (sC == i ? 5402 : 5401), 150 + i, GumpButtonType.Reply, 0);
                                gump.AddLabel(675, 10 + i * 30, 1153, CIV.Civ);
                                civList.Add(CIV);
                                if (sC == i)
                                    CivE = CIV;
                            }
                            i++;
                        }

                        if (CivE != null)
                        {

                        }
                        break;
                    }

                case 2:
                    {//Import
                        if (!Directory.Exists("ACC Exports"))
                        {
                            from.SendMessage("There are no files to import!");
                            return;
                        }

                        gump.AddButton(195, 65, 2445, 2445, 124, GumpButtonType.Reply, 0);
                        gump.AddLabel(220, 66, 1153, "Systems");


                        int Sel = -1;
                        if (subParams.Length >= 2)
                            Sel = (int)subParams[1];

                        switch (Sel)
                        {
                            case 0: { Dirs = Directory.GetFiles("ACC Exports/", "*.civ"); break; }
                            default: return;
                        }

                        if (Dirs == null || Dirs.Length == 0)
                        {
                            from.SendMessage("There are no files of that type!");
                            return;
                        }

                        for (int i = 0, r = 0, c = 0; i < Dirs.Length && c < 3; i++)
                        {
                            string s = Dirs[i];
                            s = s.Remove(0, 12);
                            s = s.Remove(s.Length - 4, 4);
                            if (Sel == 0)
                                s = s.Remove(0, 9);

                            gump.AddButton(120 + c * 150, 100 + r * 30, 2501, 2501, 300 + i, GumpButtonType.Reply, 0);
                            gump.AddLabelCropped(125 + c * 150, 101 + r * 30, 140, 30, 1153, s);

                            c += (r == 7 ? 1 : 0);
                            r += (r == 7 ? -7 : 1);
                        }
                        break;
                    }
            }
        }
        public override void Help(Mobile from, Gump gump) { from.SendGump(new Civilopedia(from)); }
        public override void OnResponse(NetState state, RelayInfo info, object[] subParams)
        {
            if (state.Mobile.AccessLevel < AccessLevel.Administrator)
                return;
            if (info.ButtonID == 0)
                return;

            if (info.ButtonID == 101)
                subParams = new object[1] { 1 };

            else if (info.ButtonID == 102)
                subParams = new object[1] { 2 };

            else if (info.ButtonID == 124 || info.ButtonID == 125 || info.ButtonID == 126)
            {
                subParams = new object[2] { 2, info.ButtonID - 124 };
            }

            else if (info.ButtonID >= 150)
            {
                state.Mobile.SendGump(new XmlPropertiesGump(state.Mobile, civList[info.ButtonID - 150]));
                return;
            }

            state.Mobile.SendGump(new ACCGump(state.Mobile, this.ToString(), subParams));
        }

        public static void Configure()
        {
            ACC.ACC.RegisterSystem("Server.UOC.CoreSystem");
        }

        public static bool Running
        {
            get { return ACC.ACC.SysEnabled("Server.UOC.CoreSystem"); }
        }

        public override void Enable()
        {
            Console.WriteLine("{0} has just been enabled!", Name());
        }

        public override void Disable()
        {
            Console.WriteLine("{0} has just been disabled!", Name());
        }
    }
}