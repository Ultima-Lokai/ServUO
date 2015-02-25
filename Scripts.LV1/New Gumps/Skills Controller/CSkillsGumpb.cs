// ShowTool, StatsGump, and CSkills Toolbar Systems
// Written for Free Ultima Online Emulation Shards
/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
    public class CSkillsGumpb : Gump
    {
        private PlayerMobile pm;

        public CSkillsGumpb(PlayerMobile mobile) : base(0, 0)
        {
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
            pm = mobile;
            AddPage(0);
            AddBackground(0x57, 0x36, 0x202, 0x1e6, 0x141e);
            AddImage(0x36, 0x12, 0x28a0, 0x80e);
            AddImage(0x36, 170, 0x28a1, 0x80e);
            AddImage(0x36, 0x14c, 0x28a2, 0x80e);
            AddImage(0x84, 110, 0x23f1, 5);
            AddImage(0x84, 0x1bd, 0x23f1, 0x57);
            AddLabel(0x12f, 0x57, 0x495, "Trade Skills");
            AddLabel(160, 0x7d, 0x809, "Fishing");
            AddLabel(160, 150, 0x809, "Lumberjacking");
            AddLabel(160, 0xaf, 0x809, "Mining");
            AddLabel(160, 200, 0x809, "Smithing");
            AddLabel(160, 0xe1, 0x809, "Bowcraft");
            AddLabel(160, 250, 0x809, "Carpentry");
            AddLabel(160, 0x113, 0x809, "Cooking");
            AddLabel(160, 300, 0x809, "Tailoring");
            AddLabel(160, 0x145, 0x809, "Tinkering");
            AddLabel(160, 350, 0x809, "Inscription");
            AddLabel(160, 0x177, 0x809, "Alchemy");
            AddLabel(0x1a6, 0x7d, 0x809, string.Format("{0}", pm.Skills[0x12].Base));
            AddLabel(0x1a6, 150, 0x809, string.Format("{0}", pm.Skills[0x2c].Base));
            AddLabel(0x1a6, 0xaf, 0x809, string.Format("{0}", pm.Skills[0x2d].Base));
            AddLabel(0x1a6, 200, 0x809, string.Format("{0}", pm.Skills[7].Base));
            AddLabel(0x1a6, 0xe1, 0x809, string.Format("{0}", pm.Skills[8].Base));
            AddLabel(0x1a6, 250, 0x809, string.Format("{0}", pm.Skills[11].Base));
            AddLabel(0x1a6, 0x113, 0x809, string.Format("{0}", pm.Skills[13].Base));
            AddLabel(0x1a6, 300, 0x809, string.Format("{0}", pm.Skills[0x22].Base));
            AddLabel(0x1a6, 0x145, 0x809, string.Format("{0}", pm.Skills[0x25].Base));
            AddLabel(0x1a6, 350, 0x809, string.Format("{0}", pm.Skills[0x17].Base));
            AddLabel(0x1a6, 0x177, 0x809, string.Format("{0}", pm.Skills[0].Base));
            if (pm.Skills[0x12].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x80, 0x983, 0x984, 0xca, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x12].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x80, 0x985, 0x986, 0xca, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x12].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x80, 0x82c, 0x82c, 0xca, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x2c].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x99, 0x983, 0x984, 0xd4, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2c].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x99, 0x985, 0x986, 0xd4, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2c].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x99, 0x82c, 0x82c, 0xd4, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x2d].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xb2, 0x983, 0x984, 0xde, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2d].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xb2, 0x985, 0x986, 0xde, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2d].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xb2, 0x82c, 0x82c, 0xde, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[7].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xcb, 0x983, 0x984, 0xe8, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[7].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xcb, 0x985, 0x986, 0xe8, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[7].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xcb, 0x82c, 0x82c, 0xe8, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[8].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xe4, 0x983, 0x984, 0xf2, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[8].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xe4, 0x985, 0x986, 0xf2, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[8].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xe4, 0x82c, 0x82c, 0xf2, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[11].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xfd, 0x983, 0x984, 0xfc, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[11].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xfd, 0x985, 0x986, 0xfc, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[11].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xfd, 0x82c, 0x82c, 0xfc, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[13].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x116, 0x983, 0x984, 0x106, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[13].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x116, 0x985, 0x986, 0x106, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[13].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x116, 0x82c, 0x82c, 0x106, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x22].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x12f, 0x983, 0x984, 0x110, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x22].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x12f, 0x985, 0x986, 0x110, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x22].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x12f, 0x82c, 0x82c, 0x110, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x25].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x148, 0x983, 0x984, 0x11a, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x25].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x148, 0x985, 0x986, 0x11a, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x25].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x148, 0x82c, 0x82c, 0x11a, GumpButtonType.Reply, 0);
            }
            AddButton(0x88, 0x161, 0x7538, 0x7539, 0x123, GumpButtonType.Reply, 0);
            if (pm.Skills[0x17].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x161, 0x983, 0x984, 0x124, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x17].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x161, 0x985, 0x986, 0x124, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x17].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x161, 0x82c, 0x82c, 0x124, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x161, 0x8b0, 0x8b0, 0x125, GumpButtonType.Reply, 0);
            if (pm.Skills[0].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x17a, 0x983, 0x984, 0x12e, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x17a, 0x985, 0x986, 0x12e, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x17a, 0x82c, 0x82c, 0x12e, GumpButtonType.Reply, 0);
            }
            AddButton(120, 0x1c5, 0x15cf, 0x15d0, 0xbb9, GumpButtonType.Reply, 0);
            AddButton(0xb6, 0x1c5, 0x15cd, 0x15ce, 0xbba, GumpButtonType.Reply, 0);
            AddButton(0xf4, 0x1c4, 0x15b1, 0x15b2, 0xbbb, GumpButtonType.Reply, 0);
            AddButton(390, 0x1c5, 0x15ab, 0x15ac, 0xbbc, GumpButtonType.Reply, 0);
            AddButton(0x1c4, 0x1c5, 0x15c1, 0x15c2, 0xbbd, GumpButtonType.Reply, 0);
            AddButton(0x202, 0x1c5, 0x15bb, 0x15bc, 0xbbe, GumpButtonType.Reply, 0);
            AddLabel(0x19f, 0x1a7, 0x43c, "Skill Total:");
            AddLabel(0x1f1, 0x1a7, 0x480, string.Format(" {0}", pm.Skills.Total/10));
            AddButton(0x139, 0x1d2, 0x478, 0xf8, 0x7d0, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int num = info.ButtonID;
            if (num <= 0xfc)
            {
                if (num > 0xde)
                {
                    switch (num)
                    {
                        case 0xe8:
                            if (pm.Skills[7].Lock == SkillLock.Up)
                            {
                                pm.Skills[7].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[7].Update();
                            }
                            else if (pm.Skills[7].Lock == SkillLock.Down)
                            {
                                pm.Skills[7].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[7].Update();
                            }
                            else if (pm.Skills[7].Lock == SkillLock.Locked)
                            {
                                pm.Skills[7].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[7].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpb));
                            pm.SendGump(new CSkillsGumpb(pm));
                            return;

                        case 0xf2:
                            if (pm.Skills[8].Lock == SkillLock.Up)
                            {
                                pm.Skills[8].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[8].Update();
                            }
                            else if (pm.Skills[8].Lock == SkillLock.Down)
                            {
                                pm.Skills[8].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[8].Update();
                            }
                            else if (pm.Skills[8].Lock == SkillLock.Locked)
                            {
                                pm.Skills[8].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[8].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpb));
                            pm.SendGump(new CSkillsGumpb(pm));
                            return;

                        case 0xfc:
                            if (pm.Skills[11].Lock == SkillLock.Up)
                            {
                                pm.Skills[11].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[11].Update();
                            }
                            else if (pm.Skills[11].Lock == SkillLock.Down)
                            {
                                pm.Skills[11].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[11].Update();
                            }
                            else if (pm.Skills[11].Lock == SkillLock.Locked)
                            {
                                pm.Skills[11].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[11].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpb));
                            pm.SendGump(new CSkillsGumpb(pm));
                            return;
                    }
                }
                else
                {
                    switch (num)
                    {
                        case 0xca:
                            if (pm.Skills[0x12].Lock == SkillLock.Up)
                            {
                                pm.Skills[0x12].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[0x12].Update();
                            }
                            else if (pm.Skills[0x12].Lock == SkillLock.Down)
                            {
                                pm.Skills[0x12].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[0x12].Update();
                            }
                            else if (pm.Skills[0x12].Lock == SkillLock.Locked)
                            {
                                pm.Skills[0x12].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[0x12].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpb));
                            pm.SendGump(new CSkillsGumpb(pm));
                            return;

                        case 0xd4:
                            if (pm.Skills[0x2c].Lock == SkillLock.Up)
                            {
                                pm.Skills[0x2c].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[0x2c].Update();
                            }
                            else if (pm.Skills[0x2c].Lock == SkillLock.Down)
                            {
                                pm.Skills[0x2c].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[0x2c].Update();
                            }
                            else if (pm.Skills[0x2c].Lock == SkillLock.Locked)
                            {
                                pm.Skills[0x2c].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[0x2c].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpb));
                            pm.SendGump(new CSkillsGumpb(pm));
                            return;
                    }
                    if (num == 0xde)
                    {
                        if (pm.Skills[0x2d].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x2d].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x2d].Update();
                        }
                        else if (pm.Skills[0x2d].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x2d].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x2d].Update();
                        }
                        else if (pm.Skills[0x2d].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x2d].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x2d].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpb(pm));
                    }
                }
            }
            else if (num <= 0x11a)
            {
                switch (num)
                {
                    case 0x106:
                        if (pm.Skills[13].Lock == SkillLock.Up)
                        {
                            pm.Skills[13].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[13].Update();
                        }
                        else if (pm.Skills[13].Lock == SkillLock.Down)
                        {
                            pm.Skills[13].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[13].Update();
                        }
                        else if (pm.Skills[13].Lock == SkillLock.Locked)
                        {
                            pm.Skills[13].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[13].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpb(pm));
                        return;

                    case 0x110:
                        if (pm.Skills[0x22].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x22].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x22].Update();
                        }
                        else if (pm.Skills[0x22].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x22].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x22].Update();
                        }
                        else if (pm.Skills[0x22].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x22].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x22].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpb(pm));
                        return;
                }
                if (num == 0x11a)
                {
                    if (pm.Skills[0x25].Lock == SkillLock.Up)
                    {
                        pm.Skills[0x25].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[0x25].Update();
                    }
                    else if (pm.Skills[0x25].Lock == SkillLock.Down)
                    {
                        pm.Skills[0x25].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[0x25].Update();
                    }
                    else if (pm.Skills[0x25].Lock == SkillLock.Locked)
                    {
                        pm.Skills[0x25].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[0x25].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGumpb));
                    pm.SendGump(new CSkillsGumpb(pm));
                }
            }
            else
            {
                switch (num)
                {
                    case 0xbb9:
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGump(pm));
                        return;

                    case 0xbba:
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpb(pm));
                        return;

                    case 0xbbb:
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpc(pm));
                        return;

                    case 0xbbc:
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpd(pm));
                        return;

                    case 0xbbd:
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0xbbe:
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x7d0:
                        pm.CloseGump(typeof (CSkillsGumpb));
                        return;

                    case 0x123:
                        pm.UseSkill(0x17);
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpb(pm));
                        return;

                    case 0x124:
                        if (pm.Skills[0x17].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x17].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x17].Update();
                        }
                        else if (pm.Skills[0x17].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x17].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x17].Update();
                        }
                        else if (pm.Skills[0x17].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x17].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x17].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpb(pm));
                        return;

                    case 0x125:
                        pm.SendGump(new Inscribet(pm));
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpb(pm));
                        return;

                    case 0x12e:
                        if (pm.Skills[0].Lock == SkillLock.Up)
                        {
                            pm.Skills[0].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0].Update();
                        }
                        else if (pm.Skills[0].Lock == SkillLock.Down)
                        {
                            pm.Skills[0].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0].Update();
                        }
                        else if (pm.Skills[0].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpb));
                        pm.SendGump(new CSkillsGumpb(pm));
                        return;

                    default:
                        return;
                }
            }
        }
    }
}

