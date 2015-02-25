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
    public class CSkillsGumpd : Gump
    {
        private PlayerMobile pm;

        public CSkillsGumpd(PlayerMobile mobile) : base(0, 0)
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
            AddLabel(0x12f, 0x57, 0x495, "Combat");
            AddLabel(160, 0x7d, 0x809, "Archery");
            AddLabel(160, 150, 0x809, "Swords");
            AddLabel(160, 0xaf, 0x809, "Macing");
            AddLabel(160, 200, 0x809, "Fencing");
            AddLabel(160, 0xe1, 0x809, "Throwing");
            AddLabel(160, 250, 0x809, "Parrying");
            AddLabel(160, 0x113, 0x809, "Wrestling");
            AddLabel(160, 300, 0x809, "Bushido");
            AddLabel(160, 0x145, 0x809, "Ninjitsu");
            AddLabel(160, 350, 0x809, "Tactics");
            AddLabel(160, 0x177, 0x809, "Focus");
            AddLabel(0x1a6, 0x7d, 0x809, string.Format("{0}", pm.Skills[0x1f].Base));
            AddLabel(0x1a6, 150, 0x809, string.Format("{0}", pm.Skills[0x2a].Base));
            AddLabel(0x1a6, 0xaf, 0x809, string.Format("{0}", pm.Skills[0x29].Base));
            AddLabel(0x1a6, 200, 0x809, string.Format("{0}", pm.Skills[40].Base));
            AddLabel(0x1a6, 0xe1, 0x809, string.Format("{0}", pm.Skills[0x39].Base));
            AddLabel(0x1a6, 250, 0x809, string.Format("{0}", pm.Skills[5].Base));
            AddLabel(0x1a6, 0x113, 0x809, string.Format("{0}", pm.Skills[0x2b].Base));
            AddLabel(0x1a6, 300, 0x809, string.Format("{0}", pm.Skills[0x34].Base));
            AddLabel(0x1a6, 0x145, 0x809, string.Format("{0}", pm.Skills[0x35].Base));
            AddLabel(0x1a6, 350, 0x809, string.Format("{0}", pm.Skills[0x1b].Base));
            AddLabel(0x1a6, 0x177, 0x809, string.Format("{0}", pm.Skills[50].Base));
            if (pm.Skills[0x1f].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x80, 0x983, 0x984, 0x192, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x1f].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x80, 0x985, 0x986, 0x192, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x1f].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x80, 0x82c, 0x82c, 0x192, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x2a].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x99, 0x983, 0x984, 0x19c, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2a].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x99, 0x985, 0x986, 0x19c, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2a].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x99, 0x82c, 0x82c, 0x19c, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x29].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xb2, 0x983, 0x984, 0x1a6, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x29].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xb2, 0x985, 0x986, 0x1a6, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x29].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xb2, 0x82c, 0x82c, 0x1a6, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[40].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xcb, 0x983, 0x984, 0x1b0, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[40].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xcb, 0x985, 0x986, 0x1b0, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[40].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xcb, 0x82c, 0x82c, 0x1b0, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x39].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xe4, 0x983, 0x984, 0x1ba, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x39].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xe4, 0x985, 0x986, 0x1ba, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x39].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xe4, 0x82c, 0x82c, 0x1ba, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[5].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xfd, 0x983, 0x984, 0x1c4, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[5].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xfd, 0x985, 0x986, 0x1c4, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[5].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xfd, 0x82c, 0x82c, 0x1c4, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x2b].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x116, 0x983, 0x984, 0x1ce, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2b].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x116, 0x985, 0x986, 0x1ce, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2b].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x116, 0x82c, 0x82c, 0x1ce, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x34].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x12f, 0x983, 0x984, 0x1d8, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x34].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x12f, 0x985, 0x986, 0x1d8, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x34].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x12f, 0x82c, 0x82c, 0x1d8, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x35].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x148, 0x983, 0x984, 0x1e2, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x35].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x148, 0x985, 0x986, 0x1e2, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x35].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x148, 0x82c, 0x82c, 0x1e2, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x1b].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x161, 0x983, 0x984, 0x1ec, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x1b].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x161, 0x985, 0x986, 0x1ec, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x1b].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x161, 0x82c, 0x82c, 0x1ec, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[50].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x17a, 0x983, 0x984, 0x1f6, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[50].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x17a, 0x985, 0x986, 0x1f6, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[50].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x17a, 0x82c, 0x82c, 0x1f6, GumpButtonType.Reply, 0);
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
            if (num <= 0x1c4)
            {
                if (num > 0x1a6)
                {
                    switch (num)
                    {
                        case 0x1b0:
                            if (pm.Skills[40].Lock == SkillLock.Up)
                            {
                                pm.Skills[40].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[40].Update();
                            }
                            else if (pm.Skills[40].Lock == SkillLock.Down)
                            {
                                pm.Skills[40].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[40].Update();
                            }
                            else if (pm.Skills[40].Lock == SkillLock.Locked)
                            {
                                pm.Skills[40].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[40].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpd));
                            pm.SendGump(new CSkillsGumpd(pm));
                            return;

                        case 0x1ba:
                            if (pm.Skills[0x39].Lock == SkillLock.Up)
                            {
                                pm.Skills[0x39].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[0x39].Update();
                            }
                            else if (pm.Skills[0x39].Lock == SkillLock.Down)
                            {
                                pm.Skills[0x39].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[0x39].Update();
                            }
                            else if (pm.Skills[0x39].Lock == SkillLock.Locked)
                            {
                                pm.Skills[0x39].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[0x39].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpd));
                            pm.SendGump(new CSkillsGumpd(pm));
                            return;

                        case 0x1c4:
                            if (pm.Skills[5].Lock == SkillLock.Up)
                            {
                                pm.Skills[5].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[5].Update();
                            }
                            else if (pm.Skills[5].Lock == SkillLock.Down)
                            {
                                pm.Skills[5].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[5].Update();
                            }
                            else if (pm.Skills[5].Lock == SkillLock.Locked)
                            {
                                pm.Skills[5].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[5].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpd));
                            pm.SendGump(new CSkillsGumpd(pm));
                            return;
                    }
                }
                else
                {
                    switch (num)
                    {
                        case 0x192:
                            if (pm.Skills[0x1f].Lock == SkillLock.Up)
                            {
                                pm.Skills[0x1f].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[0x1f].Update();
                            }
                            else if (pm.Skills[0x1f].Lock == SkillLock.Down)
                            {
                                pm.Skills[0x1f].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[0x1f].Update();
                            }
                            else if (pm.Skills[0x1f].Lock == SkillLock.Locked)
                            {
                                pm.Skills[0x1f].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[0x1f].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpd));
                            pm.SendGump(new CSkillsGumpd(pm));
                            return;

                        case 0x19c:
                            if (pm.Skills[0x2a].Lock == SkillLock.Up)
                            {
                                pm.Skills[0x2a].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[0x2a].Update();
                            }
                            else if (pm.Skills[0x2a].Lock == SkillLock.Down)
                            {
                                pm.Skills[0x2a].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[0x2a].Update();
                            }
                            else if (pm.Skills[0x2a].Lock == SkillLock.Locked)
                            {
                                pm.Skills[0x2a].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[0x2a].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpd));
                            pm.SendGump(new CSkillsGumpd(pm));
                            return;
                    }
                    if (num == 0x1a6)
                    {
                        if (pm.Skills[0x29].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x29].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x29].Update();
                        }
                        else if (pm.Skills[0x29].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x29].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x29].Update();
                        }
                        else if (pm.Skills[0x29].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x29].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x29].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGumpd(pm));
                    }
                }
            }
            else if (num <= 0x1e2)
            {
                switch (num)
                {
                    case 0x1ce:
                        if (pm.Skills[0x2b].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x2b].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x2b].Update();
                        }
                        else if (pm.Skills[0x2b].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x2b].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x2b].Update();
                        }
                        else if (pm.Skills[0x2b].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x2b].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x2b].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGumpd(pm));
                        return;

                    case 0x1d8:
                        if (pm.Skills[0x34].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x34].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x34].Update();
                        }
                        else if (pm.Skills[0x34].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x34].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x34].Update();
                        }
                        else if (pm.Skills[0x34].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x34].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x34].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGumpd(pm));
                        return;
                }
                if (num == 0x1e2)
                {
                    if (pm.Skills[0x35].Lock == SkillLock.Up)
                    {
                        pm.Skills[0x35].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[0x35].Update();
                    }
                    else if (pm.Skills[0x35].Lock == SkillLock.Down)
                    {
                        pm.Skills[0x35].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[0x35].Update();
                    }
                    else if (pm.Skills[0x35].Lock == SkillLock.Locked)
                    {
                        pm.Skills[0x35].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[0x35].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGumpd));
                    pm.SendGump(new CSkillsGumpd(pm));
                }
            }
            else
            {
                switch (num)
                {
                    case 0x1ec:
                        if (pm.Skills[0x1b].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x1b].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x1b].Update();
                        }
                        else if (pm.Skills[0x1b].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x1b].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x1b].Update();
                        }
                        else if (pm.Skills[0x1b].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x1b].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x1b].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGumpd(pm));
                        return;

                    case 0x1f6:
                        if (pm.Skills[50].Lock == SkillLock.Up)
                        {
                            pm.Skills[50].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[50].Update();
                        }
                        else if (pm.Skills[50].Lock == SkillLock.Down)
                        {
                            pm.Skills[50].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[50].Update();
                        }
                        else if (pm.Skills[50].Lock == SkillLock.Locked)
                        {
                            pm.Skills[50].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[50].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGumpd(pm));
                        break;

                    case 0xbb9:
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGump(pm));
                        return;

                    case 0xbba:
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGumpb(pm));
                        return;

                    case 0xbbb:
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGumpc(pm));
                        return;

                    case 0xbbc:
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGumpd(pm));
                        return;

                    case 0xbbd:
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0xbbe:
                        pm.CloseGump(typeof (CSkillsGumpd));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x7d0:
                        pm.CloseGump(typeof (CSkillsGumpd));
                        return;
                }
            }
        }
    }
}

