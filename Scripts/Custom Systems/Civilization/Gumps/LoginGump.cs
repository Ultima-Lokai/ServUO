using System;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Network;
using Server;
using Server.Items;
using Server.Gumps;
using Server.UOC.Items;

namespace Server.UOC
{
    public class LoginGump : Gump
    {
        bool Admin;
        int m_Page;
        string m_Civ;
        public LoginGump(Mobile from, int page)
            : base(40, 40)
        {
            from.CloseGump(typeof(LoginGump));
            if (from.AccessLevel >= AccessLevel.Administrator)
                Admin = true;

            m_Page = page;
            AddPage(0);
            AddBackground(0, 0, 476, 540, 0x13BE);
            AddImageTiled(150, 30, 316, 205, 0xA40);
            AddAlphaRegion(150, 30, 316, 205);

            AddLabel(10, 7, 2100, "Choose a Civilization");

            string description;
            if (UOC.CoreSystem.CivEntries.Count > 0)
            {
                AddImageTiled(10, 30, 101, 460, 0xA40);
                AddAlphaRegion(10, 30, 101, 460);
                int current = (int)ID.FirstCiv;
                foreach (KeyValuePair<string, CivEntry> kvp in UOC.CoreSystem.CivEntries)
                {
                    if (current == m_Page)
                    {
                        m_Civ = kvp.Value.Civ;
                        description = kvp.Value.Description;
                        AddHtml(160, 40, 296, 185, description, true, true);
                        AddLabel(160, 375, 2100, "Building Count: ");
                        AddLabel(160, 400, 2100, "Citizen Count: ");
                        AddLabel(160, 425, 2100, "Technology Count: ");
                        AddLabel(160, 450, 2100, "Government Type: ");
                        AddLabel(360, 375, 2100, kvp.Value.Buildings.Count.ToString());
                        AddLabel(360, 400, 2100, kvp.Value.Citizens.Count.ToString());
                        AddLabel(360, 425, 2100, kvp.Value.Technologies.Count.ToString());
                        AddLabel(360, 450, 2100, kvp.Value.Government.ToString());
                        if (Admin)
                        {
                            AddLabel(160, 350, 2100, "Civ Is Open: ");
                            AddCheck(360, 350, 210, 211, kvp.Value.IsOpen, (int)ID.OpenToggle);
                        }
                    }
                    int y = 30 * (current);
                    AddButton(115, y, 0xFAE, 0xFB0, current++, GumpButtonType.Reply, 0);
                    AddLabel(15, y, 2124, kvp.Value.Civ);
                }
            }

            if (UOC.CoreSystem.CivEntries.Count < (int)ID.FirstCiv || !UOC.CoreSystem.AnyCivOpen() || Admin)
            {
                if (UOC.CoreSystem.CivEntries.Count < (int)ID.LastCiv) //As long as there is room for another Civilization
                {
                    AddLabel(150, 240, 2100, "New");
                    AddButton(216, 240, 0xFB7, 0xFB9, (int)ID.New, GumpButtonType.Reply, 0);
                }
                if (UOC.CoreSystem.CivEntries.Count < (int)ID.LastCiv || Admin)
                {
                    AddTextEntry(150, 260, 90, 20, 777, (int)ID.CivName, "NewCivName");
                    AddTextEntry(150, 290, 310, 20, 777, (int)ID.Description, "Type Description Here...");
                }
            }
            if (Admin)
            {
                AddLabel(275, 240, 2100, "Edit");
                AddButton(316, 240, 0xFB7, 0xFB9, (int)ID.Edit, GumpButtonType.Reply, 0);
            }
            if (UOC.CoreSystem.CivEntries.Count > 0)
            {
                AddLabel(220, 510, 2100, "Join This Civ");
                AddButton(336, 510, 0xFB7, 0xFB9, (int)ID.Join, GumpButtonType.Reply, 0);
            }
        }

        private enum ID
        {
            FirstCiv = 1, LastCiv = 12,
            Join, Edit, New, CivName, Description, OpenToggle
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            if (!(state.Mobile is PlayerMobile))
                return;
            PlayerMobile from = state.Mobile as PlayerMobile;
            int choice = info.ButtonID;

            /////////////////////////////////////////////////////////////////
            if (Admin && choice == (int)ID.Edit) //   Edit Civilization    //
            {////////////////////////////////////////////////////////////////
                string civName = GetString(info, (int)ID.CivName);
                string descrip = GetString(info, (int)ID.Description);
                bool open = info.IsSwitched((int)ID.OpenToggle);
                if (descrip == null) descrip = "None set.";
                if (civName.Length == 0 || civName == null || !(UOC.CoreSystem.CivEntries.ContainsKey(civName)))
                {
                    from.SendMessage("Please enter a valid Civilization name.");
                    from.SendGump(new LoginGump(from, 1));
                }
                else
                {
                    UOC.CoreSystem.CivEntries[civName].IsOpen = open;
                    UOC.CoreSystem.CivEntries[civName].Description = descrip;
                    from.SendGump(new LoginGump(from, 1));
                }
            }
            ////////////////////////////////////////////////////////
            if (choice == (int)ID.Join) //   Join Civilization    //
            {///////////////////////////////////////////////////////
                if (UOC.CoreSystem.CivEntries[m_Civ].IsOpen)
                {
                    UOC.CoreSystem.CivJoin(from, m_Civ);
                }
                else
                {
                    from.SendMessage("That Civilization is temporarily closed.");
                    from.SendGump(new LoginGump(from, 1));
                }
            }
            ////////////////////////////////////////////////////////
            if (choice == (int)ID.New) // Create New Civilization //
            {///////////////////////////////////////////////////////
                string civName = GetString(info, (int)ID.CivName);
                string descrip = GetString(info, (int)ID.Description);
                if (descrip == null) descrip = "None set.";
                if (civName.Length == 0 || civName == null || UOC.CoreSystem.CivEntries.ContainsKey(civName))
                {
                    from.SendMessage("Please specify a unique name for the new Civilization.");
                    from.SendGump(new LoginGump(from, 1));
                }
                else
                {
                    UOC.CoreSystem.CivEntries.Add(civName, new CivEntry(civName));
                    UOC.CoreSystem.CivEntries[civName].Description = descrip;
                    from.SendGump(new LoginGump(from, 1));
                }
            }
            ///////////////////////////////////////////////////////////////////////////////
            if (choice <= (int)ID.LastCiv && choice >= (int)ID.FirstCiv) // Change Page  //
            {//////////////////////////////////////////////////////////////////////////////
                from.SendGump(new LoginGump(from, choice));
            }
        }

        private string GetString(RelayInfo info, int id)
        {
            TextRelay t = info.GetTextEntry(id);
            return (t == null ? null : t.Text.Trim());
        }
    }
}