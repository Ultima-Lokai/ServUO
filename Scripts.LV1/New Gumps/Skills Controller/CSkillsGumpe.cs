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
    public class CSkillsGumpe : Gump
    {
        private PlayerMobile pm;

        public CSkillsGumpe(PlayerMobile mobile) : base(0, 0)
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
            AddLabel(0x12f, 0x57, 0x495, "Mystic Arts");
            AddLabel(160, 0x7d, 0x809, "Magery");
            AddLabel(160, 150, 0x809, "Necromancy");
            AddLabel(160, 0xaf, 0x809, "Mysticism");
            AddLabel(160, 200, 0x809, "Spellweaving");
            AddLabel(160, 0xe1, 0x809, "Chivalry");
            AddLabel(160, 250, 0x809, "Magic Resist");
            AddLabel(160, 0x113, 0x809, "Evaluate Int");
            AddLabel(160, 300, 0x809, "Spirit Speak");
            AddLabel(160, 0x145, 0x809, "Meditation");
            AddLabel(160, 350, 0x809, "Imbuing(Dev)");
            AddLabel(0x1a6, 0x7d, 0x809, string.Format("{0}", pm.Skills[0x19].Base));
            AddLabel(0x1a6, 150, 0x809, string.Format("{0}", pm.Skills[0x31].Base));
            AddLabel(0x1a6, 0xaf, 0x809, string.Format("{0}", pm.Skills[0x37].Base));
            AddLabel(0x1a6, 200, 0x809, string.Format("{0}", pm.Skills[0x36].Base));
            AddLabel(0x1a6, 0xe1, 0x809, string.Format("{0}", pm.Skills[0x33].Base));
            AddLabel(0x1a6, 250, 0x809, string.Format("{0}", pm.Skills[0x1a].Base));
            AddLabel(0x1a6, 0x113, 0x809, string.Format("{0}", pm.Skills[0x10].Base));
            AddLabel(0x1a6, 300, 0x809, string.Format("{0}", pm.Skills[0x20].Base));
            AddLabel(0x1a6, 0x145, 0x809, string.Format("{0}", pm.Skills[0x2e].Base));
            AddLabel(0x1a6, 350, 0x809, string.Format("{0}", pm.Skills[0x38].Base));
            if (pm.Skills[0x19].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x80, 0x983, 0x984, 0x25a, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x19].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x80, 0x985, 0x986, 0x25a, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x19].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x80, 0x82c, 0x82c, 0x25a, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x31].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x99, 0x983, 0x984, 0x264, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x31].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x99, 0x985, 0x986, 0x264, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x31].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x99, 0x82c, 0x82c, 0x264, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x37].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xb2, 0x983, 0x984, 0x26e, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x37].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xb2, 0x985, 0x986, 0x26e, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x37].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xb2, 0x82c, 0x82c, 0x26e, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x36].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xcb, 0x983, 0x984, 0x278, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x36].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xcb, 0x985, 0x986, 0x278, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x36].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xcb, 0x82c, 0x82c, 0x278, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x33].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xe4, 0x983, 0x984, 0x282, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x33].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xe4, 0x985, 0x986, 0x282, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x33].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xe4, 0x82c, 0x82c, 0x282, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x1a].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xfd, 0x983, 0x984, 0x28c, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x1a].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xfd, 0x985, 0x986, 0x28c, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x1a].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xfd, 0x82c, 0x82c, 0x28c, GumpButtonType.Reply, 0);
            }
            AddButton(0x88, 0x116, 0x7538, 0x7539, 0x295, GumpButtonType.Reply, 0);
            if (pm.Skills[0x10].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x116, 0x983, 0x984, 0x296, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x10].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x116, 0x985, 0x986, 0x296, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x10].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x116, 0x82c, 0x82c, 0x296, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x116, 0x8b0, 0x8b0, 0x297, GumpButtonType.Reply, 0);
            AddButton(0x88, 0x12f, 0x7538, 0x7539, 0x29f, GumpButtonType.Reply, 0);
            if (pm.Skills[0x20].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x12f, 0x983, 0x984, 0x2a0, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x20].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x12f, 0x985, 0x986, 0x2a0, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x20].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x12f, 0x82c, 0x82c, 0x2a0, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x12f, 0x8b0, 0x8b0, 0x2a1, GumpButtonType.Reply, 0);
            AddButton(0x88, 0x148, 0x7538, 0x7539, 0x2a9, GumpButtonType.Reply, 0);
            if (pm.Skills[0x2e].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x148, 0x983, 0x984, 0x2aa, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2e].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x148, 0x985, 0x986, 0x2aa, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2e].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x148, 0x82c, 0x82c, 0x2aa, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x148, 0x8b0, 0x8b0, 0x2ab, GumpButtonType.Reply, 0);
            AddButton(0x88, 0x161, 0x7538, 0x7539, 0x2b3, GumpButtonType.Reply, 0);
            if (pm.Skills[0x38].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x161, 0x983, 0x984, 0x2b4, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x38].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x161, 0x985, 0x986, 0x2b4, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x38].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x161, 0x82c, 0x82c, 0x2b4, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x161, 0x8b0, 0x8b0, 0x2b5, GumpButtonType.Reply, 0);
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
            if (num <= 0x28c)
            {
                if (num > 0x26e)
                {
                    switch (num)
                    {
                        case 0x278:
                            if (pm.Skills[0x36].Lock == SkillLock.Up)
                            {
                                pm.Skills[0x36].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[0x36].Update();
                            }
                            else if (pm.Skills[0x36].Lock == SkillLock.Down)
                            {
                                pm.Skills[0x36].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[0x36].Update();
                            }
                            else if (pm.Skills[0x36].Lock == SkillLock.Locked)
                            {
                                pm.Skills[0x36].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[0x36].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpe));
                            pm.SendGump(new CSkillsGumpe(pm));
                            return;

                        case 0x282:
                            if (pm.Skills[0x33].Lock == SkillLock.Up)
                            {
                                pm.Skills[0x33].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[0x33].Update();
                            }
                            else if (pm.Skills[0x33].Lock == SkillLock.Down)
                            {
                                pm.Skills[0x33].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[0x33].Update();
                            }
                            else if (pm.Skills[0x33].Lock == SkillLock.Locked)
                            {
                                pm.Skills[0x33].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[0x33].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpe));
                            pm.SendGump(new CSkillsGumpe(pm));
                            return;

                        case 0x28c:
                            if (pm.Skills[0x1a].Lock == SkillLock.Up)
                            {
                                pm.Skills[0x1a].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[0x1a].Update();
                            }
                            else if (pm.Skills[0x1a].Lock == SkillLock.Down)
                            {
                                pm.Skills[0x1a].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[0x1a].Update();
                            }
                            else if (pm.Skills[0x1a].Lock == SkillLock.Locked)
                            {
                                pm.Skills[0x1a].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[0x1a].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpe));
                            pm.SendGump(new CSkillsGumpe(pm));
                            return;
                    }
                }
                else
                {
                    switch (num)
                    {
                        case 0x25a:
                            if (pm.Skills[0x19].Lock == SkillLock.Up)
                            {
                                pm.Skills[0x19].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[0x19].Update();
                            }
                            else if (pm.Skills[0x19].Lock == SkillLock.Down)
                            {
                                pm.Skills[0x19].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[0x19].Update();
                            }
                            else if (pm.Skills[0x19].Lock == SkillLock.Locked)
                            {
                                pm.Skills[0x19].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[0x19].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpe));
                            pm.SendGump(new CSkillsGumpe(pm));
                            return;

                        case 0x264:
                            if (pm.Skills[0x31].Lock == SkillLock.Up)
                            {
                                pm.Skills[0x31].SetLockNoRelay(SkillLock.Down);
                                pm.Skills[0x31].Update();
                            }
                            else if (pm.Skills[0x31].Lock == SkillLock.Down)
                            {
                                pm.Skills[0x31].SetLockNoRelay(SkillLock.Locked);
                                pm.Skills[0x31].Update();
                            }
                            else if (pm.Skills[0x31].Lock == SkillLock.Locked)
                            {
                                pm.Skills[0x31].SetLockNoRelay(SkillLock.Up);
                                pm.Skills[0x31].Update();
                            }
                            pm.CloseGump(typeof (CSkillsGumpe));
                            pm.SendGump(new CSkillsGumpe(pm));
                            return;
                    }
                    if (num == 0x26e)
                    {
                        if (pm.Skills[0x37].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x37].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x37].Update();
                        }
                        else if (pm.Skills[0x37].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x37].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x37].Update();
                        }
                        else if (pm.Skills[0x37].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x37].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x37].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                    }
                }
            }
            else
            {
                switch (num)
                {
                    case 0x2b3:
                        pm.UseSkill(0x38);
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x2b4:
                        if (pm.Skills[0x38].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x38].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x38].Update();
                        }
                        else if (pm.Skills[0x38].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x38].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x38].Update();
                        }
                        else if (pm.Skills[0x38].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x38].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x38].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x2b5:
                        pm.SendGump(new Imbuingt(pm));
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x7d0:
                        pm.CloseGump(typeof (CSkillsGumpe));
                        return;

                    case 0xbb9:
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGump(pm));
                        return;

                    case 0xbba:
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpb(pm));
                        return;

                    case 0xbbb:
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpc(pm));
                        return;

                    case 0xbbc:
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpd(pm));
                        return;

                    case 0xbbd:
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0xbbe:
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x295:
                        pm.UseSkill(0x10);
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x296:
                        if (pm.Skills[0x10].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x10].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x10].Update();
                        }
                        else if (pm.Skills[0x10].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x10].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x10].Update();
                        }
                        else if (pm.Skills[0x10].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x10].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x10].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x297:
                        pm.SendGump(new EvalIntt(pm));
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x29f:
                        pm.UseSkill(0x20);
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x2a0:
                        if (pm.Skills[0x20].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x20].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x20].Update();
                        }
                        else if (pm.Skills[0x20].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x20].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x20].Update();
                        }
                        else if (pm.Skills[0x20].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x20].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x20].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x2a1:
                        pm.SendGump(new SpiritSpeakt(pm));
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x2a9:
                        pm.UseSkill(0x2e);
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x2aa:
                        if (pm.Skills[0x2e].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x2e].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x2e].Update();
                        }
                        else if (pm.Skills[0x2e].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x2e].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x2e].Update();
                        }
                        else if (pm.Skills[0x2e].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x2e].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x2e].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    case 0x2ab:
                        pm.SendGump(new Meditationt(pm));
                        pm.CloseGump(typeof (CSkillsGumpe));
                        pm.SendGump(new CSkillsGumpe(pm));
                        return;

                    default:
                        return;
                }
            }
        }
    }
}

