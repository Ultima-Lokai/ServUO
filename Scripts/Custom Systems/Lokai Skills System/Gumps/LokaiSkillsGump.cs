﻿/***************************************************************************
 *   Based off the RunUO Skills system. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
    public class EditLokaiSkillGump : Gump
    {
        public static readonly bool OldStyle = PropsConfig.OldStyle;

        public static readonly int GumpOffsetX = PropsConfig.GumpOffsetX;
        public static readonly int GumpOffsetY = PropsConfig.GumpOffsetY;

        public static readonly int TextHue = PropsConfig.TextHue;
        public static readonly int TextOffsetX = PropsConfig.TextOffsetX;

        public static readonly int OffsetGumpID = PropsConfig.OffsetGumpID;
        public static readonly int HeaderGumpID = PropsConfig.HeaderGumpID;
        public static readonly int EntryGumpID = PropsConfig.EntryGumpID;
        public static readonly int BackGumpID = PropsConfig.BackGumpID;
        public static readonly int SetGumpID = PropsConfig.SetGumpID;

        public static readonly int SetWidth = PropsConfig.SetWidth;
        public static readonly int SetOffsetX = PropsConfig.SetOffsetX, SetOffsetY = PropsConfig.SetOffsetY;
        public static readonly int SetButtonID1 = PropsConfig.SetButtonID1;
        public static readonly int SetButtonID2 = PropsConfig.SetButtonID2;

        public static readonly int PrevWidth = PropsConfig.PrevWidth;
        public static readonly int PrevOffsetX = PropsConfig.PrevOffsetX, PrevOffsetY = PropsConfig.PrevOffsetY;
        public static readonly int PrevButtonID1 = PropsConfig.PrevButtonID1;
        public static readonly int PrevButtonID2 = PropsConfig.PrevButtonID2;

        public static readonly int NextWidth = PropsConfig.NextWidth;
        public static readonly int NextOffsetX = PropsConfig.NextOffsetX, NextOffsetY = PropsConfig.NextOffsetY;
        public static readonly int NextButtonID1 = PropsConfig.NextButtonID1;
        public static readonly int NextButtonID2 = PropsConfig.NextButtonID2;

        public static readonly int OffsetSize = PropsConfig.OffsetSize;

        public static readonly int EntryHeight = PropsConfig.EntryHeight;
        public static readonly int BorderSize = PropsConfig.BorderSize;

        private static readonly int EntryWidth = 160;

        private static readonly int TotalWidth = OffsetSize + EntryWidth + OffsetSize + SetWidth + OffsetSize;
        private static readonly int TotalHeight = OffsetSize + (2 * (EntryHeight + OffsetSize));

        private static readonly int BackWidth = BorderSize + TotalWidth + BorderSize;
        private static readonly int BackHeight = BorderSize + TotalHeight + BorderSize;

        private Mobile m_From;
        private Mobile m_Target;
        private LokaiSkill m_LokaiSkill;

        private LokaiSkillsGumpGroup m_Selected;

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 1)
            {
                try
                {
                    if (m_From.AccessLevel >= AccessLevel.GameMaster)
                    {
                        TextRelay text = info.GetTextEntry(0);

                        if (text != null)
                        {
                            m_LokaiSkill.Base = Convert.ToDouble(text.Text);
                            CommandLogging.LogChangeProperty(m_From, m_Target, String.Format("{0}.Base", m_LokaiSkill), m_LokaiSkill.Base.ToString());
                        }
                    }
                    else
                    {
                        m_From.SendMessage("You may not change that.");
                    }

                    m_From.SendGump(new LokaiSkillsGump(m_From, m_Target, m_Selected));
                }
                catch
                {
                    m_From.SendMessage("Bad format. ###.# expected.");
                    m_From.SendGump(new EditLokaiSkillGump(m_From, m_Target, m_LokaiSkill, m_Selected));
                }
            }
            else
            {
                m_From.SendGump(new LokaiSkillsGump(m_From, m_Target, m_Selected));
            }
        }

        public EditLokaiSkillGump(Mobile from, Mobile target, LokaiSkill lokaiSkill, LokaiSkillsGumpGroup selected)
            : base(GumpOffsetX, GumpOffsetY)
        {
            m_From = from;
            m_Target = target;
            m_LokaiSkill = lokaiSkill;
            m_Selected = selected;

            string initialText = m_LokaiSkill.Base.ToString("F1");

            AddPage(0);

            AddBackground(0, 0, BackWidth, BackHeight, BackGumpID);
            AddImageTiled(BorderSize, BorderSize, TotalWidth - (OldStyle ? SetWidth + OffsetSize : 0), TotalHeight, OffsetGumpID);

            int x = BorderSize + OffsetSize;
            int y = BorderSize + OffsetSize;

            AddImageTiled(x, y, EntryWidth, EntryHeight, EntryGumpID);
            AddLabelCropped(x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, TextHue, lokaiSkill.Name);
            x += EntryWidth + OffsetSize;

            if (SetGumpID != 0)
                AddImageTiled(x, y, SetWidth, EntryHeight, SetGumpID);

            x = BorderSize + OffsetSize;
            y += EntryHeight + OffsetSize;

            AddImageTiled(x, y, EntryWidth, EntryHeight, EntryGumpID);
            AddTextEntry(x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, TextHue, 0, initialText);
            x += EntryWidth + OffsetSize;

            if (SetGumpID != 0)
                AddImageTiled(x, y, SetWidth, EntryHeight, SetGumpID);

            AddButton(x + SetOffsetX, y + SetOffsetY, SetButtonID1, SetButtonID2, 1, GumpButtonType.Reply, 0);
        }
    }

    public class LokaiSkillsGump : Gump
    {
        public static bool OldStyle = PropsConfig.OldStyle;

        public static readonly int GumpOffsetX = PropsConfig.GumpOffsetX;
        public static readonly int GumpOffsetY = PropsConfig.GumpOffsetY;

        public static readonly int TextHue = PropsConfig.TextHue;
        public static readonly int TextOffsetX = PropsConfig.TextOffsetX;

        public static readonly int OffsetGumpID = PropsConfig.OffsetGumpID;
        public static readonly int HeaderGumpID = PropsConfig.HeaderGumpID;
        public static readonly int EntryGumpID = PropsConfig.EntryGumpID;
        public static readonly int BackGumpID = PropsConfig.BackGumpID;
        public static readonly int SetGumpID = PropsConfig.SetGumpID;

        public static readonly int SetWidth = PropsConfig.SetWidth;
        public static readonly int SetOffsetX = PropsConfig.SetOffsetX, SetOffsetY = PropsConfig.SetOffsetY;
        public static readonly int SetButtonID1 = PropsConfig.SetButtonID1;
        public static readonly int SetButtonID2 = PropsConfig.SetButtonID2;

        public static readonly int PrevWidth = PropsConfig.PrevWidth;
        public static readonly int PrevOffsetX = PropsConfig.PrevOffsetX, PrevOffsetY = PropsConfig.PrevOffsetY;
        public static readonly int PrevButtonID1 = PropsConfig.PrevButtonID1;
        public static readonly int PrevButtonID2 = PropsConfig.PrevButtonID2;

        public static readonly int NextWidth = PropsConfig.NextWidth;
        public static readonly int NextOffsetX = PropsConfig.NextOffsetX, NextOffsetY = PropsConfig.NextOffsetY;
        public static readonly int NextButtonID1 = PropsConfig.NextButtonID1;
        public static readonly int NextButtonID2 = PropsConfig.NextButtonID2;

        public static readonly int OffsetSize = PropsConfig.OffsetSize;

        public static readonly int EntryHeight = PropsConfig.EntryHeight;
        public static readonly int BorderSize = PropsConfig.BorderSize;

        private static readonly int NameWidth = 107;
        private static readonly int ValueWidth = 128;

        private static readonly int EntryCount = 15;

        private static readonly int TypeWidth = NameWidth + OffsetSize + ValueWidth;

        private static readonly int TotalWidth = OffsetSize + NameWidth + OffsetSize + ValueWidth + OffsetSize + SetWidth + OffsetSize;
        private static readonly int TotalHeight = OffsetSize + ((EntryHeight + OffsetSize) * (EntryCount + 1));

        private static readonly int BackWidth = BorderSize + TotalWidth + BorderSize;
        private static readonly int BackHeight = BorderSize + TotalHeight + BorderSize;

        private static readonly int IndentWidth = 12;

        private Mobile m_From;
        private Mobile m_Target;

        private LokaiSkillsGumpGroup[] m_Groups;
        private LokaiSkillsGumpGroup m_Selected;

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonID = info.ButtonID - 1;

            int index = buttonID / 3;
            int type = buttonID % 3;

            switch (type)
            {
                case 0:
                    {
                        if (index >= 0 && index < m_Groups.Length)
                        {
                            LokaiSkillsGumpGroup newSelection = m_Groups[index];

                            if (m_Selected != newSelection)
                                m_From.SendGump(new LokaiSkillsGump(m_From, m_Target, newSelection));
                            else
                                m_From.SendGump(new LokaiSkillsGump(m_From, m_Target, null));
                        }

                        break;
                    }
                case 1:
                    {
                        if (m_Selected != null && index >= 0 && index < m_Selected.LokaiSkills.Length)
                        {
                            LokaiSkill skil = (LokaiSkillUtilities.XMLGetSkills(m_Target))[m_Selected.LokaiSkills[index]];

                            if (skil != null)
                            {
                                if (m_From.AccessLevel >= AccessLevel.GameMaster)
                                {
                                    m_From.SendGump(new EditLokaiSkillGump(m_From, m_Target, skil, m_Selected));
                                }
                                else
                                {
                                    m_From.SendMessage("You may not change that.");
                                    m_From.SendGump(new LokaiSkillsGump(m_From, m_Target, m_Selected));
                                }
                            }
                            else
                            {
                                m_From.SendGump(new LokaiSkillsGump(m_From, m_Target, m_Selected));
                            }
                        }

                        break;
                    }
                case 2:
                    {
                        if (m_Selected != null && index >= 0 && index < m_Selected.LokaiSkills.Length)
                        {
                            LokaiSkill skil = (LokaiSkillUtilities.XMLGetSkills(m_Target))[m_Selected.LokaiSkills[index]];

                            if (skil != null)
                            {
                                if (m_From.AccessLevel >= AccessLevel.GameMaster)
                                {
                                    switch (skil.Lock)
                                    {
                                        case LokaiSkillLock.Up: skil.SetLockNoRelay(LokaiSkillLock.Down); skil.Update(); break;
                                        case LokaiSkillLock.Down: skil.SetLockNoRelay(LokaiSkillLock.Locked); skil.Update(); break;
                                        case LokaiSkillLock.Locked: skil.SetLockNoRelay(LokaiSkillLock.Up); skil.Update(); break;
                                    }
                                }
                                else
                                {
                                    m_From.SendMessage("You may not change that.");
                                }

                                m_From.SendGump(new LokaiSkillsGump(m_From, m_Target, m_Selected));
                            }
                        }

                        break;
                    }
            }
        }

        public int GetButtonID(int type, int index)
        {
            return 1 + (index * 3) + type;
        }

        public LokaiSkillsGump(Mobile from, Mobile target)
            : this(from, target, null)
        {
        }

        public LokaiSkillsGump(Mobile from, Mobile target, LokaiSkillsGumpGroup selected)
            : base(GumpOffsetX, GumpOffsetY)
        {
            m_From = from;
            m_Target = target;
            
            m_Groups = LokaiSkillsGumpGroup.Groups;
            m_Selected = selected;

            int count = m_Groups.Length;

            if (selected != null)
                count += selected.LokaiSkills.Length;

            int totalHeight = OffsetSize + ((EntryHeight + OffsetSize) * (count + 1));

            AddPage(0);

            AddBackground(0, 0, BackWidth, BorderSize + totalHeight + BorderSize, BackGumpID);
            AddImageTiled(BorderSize, BorderSize, TotalWidth - (OldStyle ? SetWidth + OffsetSize : 0), totalHeight, OffsetGumpID);

            int x = BorderSize + OffsetSize;
            int y = BorderSize + OffsetSize;

            int emptyWidth = TotalWidth - PrevWidth - NextWidth - (OffsetSize * 4) - (OldStyle ? SetWidth + OffsetSize : 0);

            if (OldStyle)
                AddImageTiled(x, y, TotalWidth - (OffsetSize * 3) - SetWidth, EntryHeight, HeaderGumpID);
            else
                AddImageTiled(x, y, PrevWidth, EntryHeight, HeaderGumpID);

            x += PrevWidth + OffsetSize;

            if (!OldStyle)
                AddImageTiled(x - (OldStyle ? OffsetSize : 0), y, emptyWidth + (OldStyle ? OffsetSize * 2 : 0), EntryHeight, HeaderGumpID);

            x += emptyWidth + OffsetSize;

            if (!OldStyle)
                AddImageTiled(x, y, NextWidth, EntryHeight, HeaderGumpID);

            for (int i = 0; i < m_Groups.Length; ++i)
            {
                x = BorderSize + OffsetSize;
                y += EntryHeight + OffsetSize;

                LokaiSkillsGumpGroup group = m_Groups[i];

                AddImageTiled(x, y, PrevWidth, EntryHeight, HeaderGumpID);

                if (group == selected)
                    AddButton(x + PrevOffsetX, y + PrevOffsetY, 0x15E2, 0x15E6, GetButtonID(0, i), GumpButtonType.Reply, 0);
                else
                    AddButton(x + PrevOffsetX, y + PrevOffsetY, 0x15E1, 0x15E5, GetButtonID(0, i), GumpButtonType.Reply, 0);

                x += PrevWidth + OffsetSize;

                x -= (OldStyle ? OffsetSize : 0);

                AddImageTiled(x, y, emptyWidth + (OldStyle ? OffsetSize * 2 : 0), EntryHeight, EntryGumpID);
                AddLabel(x + TextOffsetX, y, TextHue, group.Name);

                x += emptyWidth + (OldStyle ? OffsetSize * 2 : 0);
                x += OffsetSize;

                if (SetGumpID != 0)
                    AddImageTiled(x, y, SetWidth, EntryHeight, SetGumpID);

                if (group == selected)
                {
                    int indentMaskX = BorderSize;
                    int indentMaskY = y + EntryHeight + OffsetSize;

                    for (int j = 0; j < group.LokaiSkills.Length; ++j)
                    {
                        LokaiSkill skil = (LokaiSkillUtilities.XMLGetSkills(m_Target))[group.LokaiSkills[j]];

                        x = BorderSize + OffsetSize;
                        y += EntryHeight + OffsetSize;

                        x += OffsetSize;
                        x += IndentWidth;

                        AddImageTiled(x, y, PrevWidth, EntryHeight, HeaderGumpID);

                        AddButton(x + PrevOffsetX, y + PrevOffsetY, 0x15E1, 0x15E5, GetButtonID(1, j), GumpButtonType.Reply, 0);

                        x += PrevWidth + OffsetSize;

                        x -= (OldStyle ? OffsetSize : 0);

                        AddImageTiled(x, y, emptyWidth + (OldStyle ? OffsetSize * 2 : 0) - OffsetSize - IndentWidth, EntryHeight, EntryGumpID);
                        AddLabel(x + TextOffsetX, y, TextHue, skil == null ? "(null)" : skil.Name);

                        x += emptyWidth + (OldStyle ? OffsetSize * 2 : 0) - OffsetSize - IndentWidth;
                        x += OffsetSize;

                        if (SetGumpID != 0)
                            AddImageTiled(x, y, SetWidth, EntryHeight, SetGumpID);

                        if (skil != null)
                        {
                            int buttonID1, buttonID2;
                            int xOffset, yOffset;

                            switch (skil.Lock)
                            {
                                default:
                                case LokaiSkillLock.Up: buttonID1 = 0x983; buttonID2 = 0x983; xOffset = 6; yOffset = 4; break;
                                case LokaiSkillLock.Down: buttonID1 = 0x985; buttonID2 = 0x985; xOffset = 6; yOffset = 4; break;
                                case LokaiSkillLock.Locked: buttonID1 = 0x82C; buttonID2 = 0x82C; xOffset = 5; yOffset = 2; break;
                            }

                            AddButton(x + xOffset, y + yOffset, buttonID1, buttonID2, GetButtonID(2, j), GumpButtonType.Reply, 0);

                            y += 1;
                            x -= OffsetSize;
                            x -= 1;
                            x -= 50;

                            AddImageTiled(x, y, 50, EntryHeight - 2, OffsetGumpID);

                            x += 1;
                            y += 1;

                            AddImageTiled(x, y, 48, EntryHeight - 4, EntryGumpID);

                            AddLabelCropped(x + TextOffsetX, y - 1, 48 - TextOffsetX, EntryHeight - 3, TextHue, skil.Base.ToString("F1"));

                            y -= 2;
                        }
                    }

                    AddImageTiled(indentMaskX, indentMaskY, IndentWidth + OffsetSize, (group.LokaiSkills.Length * (EntryHeight + OffsetSize)) - (i < (m_Groups.Length - 1) ? OffsetSize : 0), BackGumpID + 4);
                }
            }
        }
    }

    public class LokaiSkillsGumpGroup
    {
        private string m_Name;
        private LokaiSkillName[] m_LokaiSkills;

        public string Name { get { return m_Name; } }
        public LokaiSkillName[] LokaiSkills { get { return m_LokaiSkills; } }

        public LokaiSkillsGumpGroup(string name, LokaiSkillName[] lokaiSkills)
        {
            m_Name = name;
            m_LokaiSkills = lokaiSkills;

            Array.Sort(m_LokaiSkills, new LokaiSkillNameComparer());
        }

        private class LokaiSkillNameComparer : IComparer
        {
            public LokaiSkillNameComparer()
            {
            }

            public int Compare(object x, object y)
            {
                LokaiSkillName a = (LokaiSkillName)x;
                LokaiSkillName b = (LokaiSkillName)y;

                string aName = LokaiSkillInfo.Table[(int)a].Name;
                string bName = LokaiSkillInfo.Table[(int)b].Name;

                return aName.CompareTo(bName);
            }
        }

        private static LokaiSkillsGumpGroup[] m_Groups = new LokaiSkillsGumpGroup[]
			{
				new LokaiSkillsGumpGroup( "Naturalist", new LokaiSkillName[]
				{
					LokaiSkillName.Butchering,
					LokaiSkillName.Skinning,
					LokaiSkillName.AnimalRiding,
					LokaiSkillName.Sailing
				} ),
				new LokaiSkillsGumpGroup( "Cleric", new LokaiSkillName[]
				{
					LokaiSkillName.DetectEvil,
					LokaiSkillName.CureDisease
				} ),
				new LokaiSkillsGumpGroup( "Rogue", new LokaiSkillName[]
				{
					LokaiSkillName.PickPocket,
					LokaiSkillName.Pilfering
				} ),
				new LokaiSkillsGumpGroup( "Labor", new LokaiSkillName[]
				{
					LokaiSkillName.Framing,
					LokaiSkillName.BrickLaying,
					LokaiSkillName.Roofing,
					LokaiSkillName.StoneMasonry
				} ),
				new LokaiSkillsGumpGroup( "Illusionist", new LokaiSkillName[]
				{
					LokaiSkillName.Ventriloquism,
					LokaiSkillName.Hypnotism
				} ),
				new LokaiSkillsGumpGroup( "Ranger", new LokaiSkillName[]
				{
					LokaiSkillName.PreyTracking,
					LokaiSkillName.SpeakToAnimals
				} ),
				new LokaiSkillsGumpGroup( "Craftsman", new LokaiSkillName[]
				{
					LokaiSkillName.Woodworking,
					LokaiSkillName.Cooperage
				} ),
				new LokaiSkillsGumpGroup( "Weaver", new LokaiSkillName[]
				{
					LokaiSkillName.Spinning,
					LokaiSkillName.Weaving
				} ),
				new LokaiSkillsGumpGroup( "Merchant", new LokaiSkillName[]
				{
					LokaiSkillName.Construction,
					LokaiSkillName.Commerce
				} ),
				new LokaiSkillsGumpGroup( "Herbalist", new LokaiSkillName[]
				{
					LokaiSkillName.Brewing,
					LokaiSkillName.Herblore
				} ),
				new LokaiSkillsGumpGroup( "Tree Harvest", new LokaiSkillName[]
				{
					LokaiSkillName.TreePicking,
					LokaiSkillName.TreeSapping,
					LokaiSkillName.TreeCarving,
					LokaiSkillName.TreeDigging
				} ),
				new LokaiSkillsGumpGroup( "Scholar", new LokaiSkillName[]
				{
					LokaiSkillName.Teaching,
					LokaiSkillName.Linguistics
				} )
			};

        public static LokaiSkillsGumpGroup[] Groups
        {
            get { return m_Groups; }
        }
    }
}