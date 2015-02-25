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
    public class CSkillsGumpf : Gump
    {
        private PlayerMobile pm;

        public CSkillsGumpf(PlayerMobile mobile) : base(0, 0)
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
            AddLabel(0x12f, 0x57, 0x495, "Survival Skills");
            AddLabel(160, 0x7d, 0x809, "Taming");
            AddLabel(160, 150, 0x809, "Healing");
            AddLabel(160, 0xaf, 0x809, "Hiding");
            AddLabel(160, 200, 0x809, "Stealth");
            AddLabel(160, 0xe1, 0x809, "Stealing");
            AddLabel(160, 250, 0x809, "Snooping");
            AddLabel(160, 0x113, 0x809, "Poisoning");
            AddLabel(160, 300, 0x809, "Detect Hidden");
            AddLabel(160, 0x145, 0x809, "Disarm Trap");
            AddLabel(160, 350, 0x809, "Begging");
            AddLabel(160, 0x177, 0x809, "Camping");
            AddLabel(160, 400, 0x809, "Lockpicking");
            AddLabel(0x1a6, 0x7d, 0x809, string.Format("{0}", pm.Skills[0x23].Base));
            AddLabel(0x1a6, 150, 0x809, string.Format("{0}", pm.Skills[0x11].Base));
            AddLabel(0x1a6, 0xaf, 0x809, string.Format("{0}", pm.Skills[0x15].Base));
            AddLabel(0x1a6, 200, 0x809, string.Format("{0}", pm.Skills[0x2f].Base));
            AddLabel(0x1a6, 0xe1, 0x809, string.Format("{0}", pm.Skills[0x21].Base));
            AddLabel(0x1a6, 250, 0x809, string.Format("{0}", pm.Skills[0x1c].Base));
            AddLabel(0x1a6, 0x113, 0x809, string.Format("{0}", pm.Skills[30].Base));
            AddLabel(0x1a6, 300, 0x809, string.Format("{0}", pm.Skills[14].Base));
            AddLabel(0x1a6, 0x145, 0x809, string.Format("{0}", pm.Skills[0x30].Base));
            AddLabel(0x1a6, 350, 0x809, string.Format("{0}", pm.Skills[6].Base));
            AddLabel(0x1a6, 0x177, 0x809, string.Format("{0}", pm.Skills[10].Base));
            AddLabel(0x1a6, 400, 0x809, string.Format("{0}", pm.Skills[0x18].Base));
            AddButton(0x88, 0x80, 0x7538, 0x7539, 0x2bd, GumpButtonType.Reply, 0);
            if (pm.Skills[0x23].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x80, 0x983, 0x984, 0x2be, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x23].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x80, 0x985, 0x986, 0x2be, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x23].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x80, 0x82c, 0x82c, 0x2be, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x80, 0x8b0, 0x8b0, 0x2bf, GumpButtonType.Reply, 0);
            if (pm.Skills[0x11].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x99, 0x983, 0x984, 0x2c8, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x11].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x99, 0x985, 0x986, 0x2c8, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x11].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x99, 0x82c, 0x82c, 0x2c8, GumpButtonType.Reply, 0);
            }
            AddButton(0x88, 0xb2, 0x7538, 0x7539, 0x2d1, GumpButtonType.Reply, 0);
            if (pm.Skills[0x15].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xb2, 0x983, 0x984, 0x2d2, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x15].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xb2, 0x985, 0x986, 0x2d2, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x15].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xb2, 0x82c, 0x82c, 0x2d2, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0xb2, 0x8b0, 0x8b0, 0x2d3, GumpButtonType.Reply, 0);
            AddButton(0x88, 0xcb, 0x7538, 0x7539, 0x2db, GumpButtonType.Reply, 0);
            if (pm.Skills[0x2f].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xcb, 0x983, 0x984, 0x2dc, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2f].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xcb, 0x985, 0x986, 0x2dc, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x2f].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xcb, 0x82c, 0x82c, 0x2dc, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0xcb, 0x8b0, 0x8b0, 0x2dd, GumpButtonType.Reply, 0);
            AddButton(0x88, 0xe4, 0x7538, 0x7539, 0x2e5, GumpButtonType.Reply, 0);
            if (pm.Skills[0x21].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xe4, 0x983, 0x984, 0x2e6, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x21].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xe4, 0x985, 0x986, 0x2e6, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x21].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xe4, 0x82c, 0x82c, 0x2e6, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0xe4, 0x8b0, 0x8b0, 0x2e7, GumpButtonType.Reply, 0);
            if (pm.Skills[0x1c].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xfd, 0x983, 0x984, 0x2f0, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x1c].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xfd, 0x985, 0x986, 0x2f0, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x1c].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xfd, 0x82c, 0x82c, 0x2f0, GumpButtonType.Reply, 0);
            }
            AddButton(0x88, 0x116, 0x7538, 0x7539, 0x2f9, GumpButtonType.Reply, 0);
            if (pm.Skills[30].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x116, 0x983, 0x984, 0x2fa, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[30].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x116, 0x985, 0x986, 0x2fa, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[30].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x116, 0x82c, 0x82c, 0x2fa, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x116, 0x8b0, 0x8b0, 0x2fb, GumpButtonType.Reply, 0);
            AddButton(0x88, 0x12f, 0x7538, 0x7539, 0x303, GumpButtonType.Reply, 0);
            if (pm.Skills[14].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x12f, 0x983, 0x984, 0x304, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[14].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x12f, 0x985, 0x986, 0x304, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[14].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x12f, 0x82c, 0x82c, 0x304, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x12f, 0x8b0, 0x8b0, 0x305, GumpButtonType.Reply, 0);
            AddButton(0x88, 0x148, 0x7538, 0x7539, 0x30d, GumpButtonType.Reply, 0);
            if (pm.Skills[0x30].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x148, 0x983, 0x984, 0x30e, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x30].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x148, 0x985, 0x986, 0x30e, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x30].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x148, 0x82c, 0x82c, 0x30e, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x148, 0x8b0, 0x8b0, 0x30f, GumpButtonType.Reply, 0);
            AddButton(0x88, 0x161, 0x7538, 0x7539, 0x317, GumpButtonType.Reply, 0);
            if (pm.Skills[6].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x161, 0x983, 0x984, 0x318, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[6].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x161, 0x985, 0x986, 0x318, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[6].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x161, 0x82c, 0x82c, 0x318, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x161, 0x8b0, 0x8b0, 0x319, GumpButtonType.Reply, 0);
            if (pm.Skills[10].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x17a, 0x983, 0x984, 0x322, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[10].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x17a, 0x985, 0x986, 0x322, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[10].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x17a, 0x82c, 0x82c, 0x322, GumpButtonType.Reply, 0);
            }
            if (pm.Skills[0x18].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x193, 0x983, 0x984, 0x32c, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x18].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x193, 0x985, 0x986, 0x32c, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x18].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x193, 0x82c, 0x82c, 0x32c, GumpButtonType.Reply, 0);
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
            if (num <= 0x2fb)
            {
                switch (num)
                {
                    case 0x2f9:
                        pm.UseSkill(30);
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2fa:
                        if (pm.Skills[30].Lock == SkillLock.Down)
                        {
                            pm.Skills[30].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[30].Update();
                        }
                        else if (pm.Skills[30].Lock == SkillLock.Locked)
                        {
                            pm.Skills[30].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[30].Update();
                        }
                        else if (pm.Skills[30].Lock == SkillLock.Up)
                        {
                            pm.Skills[30].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[30].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2fb:
                        pm.SendGump(new Poisoningt(pm));
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2f0:
                        if (pm.Skills[0x1c].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x1c].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x1c].Update();
                        }
                        else if (pm.Skills[0x1c].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x1c].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x1c].Update();
                        }
                        else if (pm.Skills[0x1c].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x1c].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x1c].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2db:
                        pm.UseSkill(0x2f);
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2dc:
                        if (pm.Skills[0x2f].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x2f].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x2f].Update();
                        }
                        else if (pm.Skills[0x2f].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x2f].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x2f].Update();
                        }
                        else if (pm.Skills[0x2f].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x2f].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x2f].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2dd:
                        pm.SendGump(new Stealtht(pm));
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2e5:
                        pm.UseSkill(0x21);
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2e6:
                        if (pm.Skills[0x21].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x21].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x21].Update();
                        }
                        else if (pm.Skills[0x21].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x21].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x21].Update();
                        }
                        else if (pm.Skills[0x21].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x21].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x21].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2e7:
                        pm.SendGump(new Stealingt(pm));
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2bd:
                        pm.UseSkill(0x23);
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2be:
                        if (pm.Skills[0x23].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x23].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x23].Update();
                        }
                        else if (pm.Skills[0x23].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x23].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x23].Update();
                        }
                        else if (pm.Skills[0x23].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x23].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x23].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2bf:
                        pm.SendGump(new AnimalTamingt(pm));
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2c8:
                        if (pm.Skills[0x11].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x11].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x11].Update();
                        }
                        else if (pm.Skills[0x11].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x11].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x11].Update();
                        }
                        else if (pm.Skills[0x11].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x11].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x11].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2d1:
                        pm.UseSkill(0x15);
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2d2:
                        if (pm.Skills[0x15].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x15].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x15].Update();
                        }
                        else if (pm.Skills[0x15].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x15].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x15].Update();
                        }
                        else if (pm.Skills[0x15].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x15].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x15].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x2d3:
                        pm.SendGump(new Hidingt(pm));
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;
                }
                return;
            }
            if (num <= 0x319)
            {
                switch (num)
                {
                    case 0x303:
                        pm.UseSkill(14);
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x304:
                        if (pm.Skills[14].Lock == SkillLock.Down)
                        {
                            pm.Skills[14].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[14].Update();
                        }
                        else if (pm.Skills[14].Lock == SkillLock.Locked)
                        {
                            pm.Skills[14].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[14].Update();
                        }
                        else if (pm.Skills[14].Lock == SkillLock.Up)
                        {
                            pm.Skills[14].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[14].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x305:
                        pm.SendGump(new DetectHiddent(pm));
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x30d:
                        pm.UseSkill(0x30);
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x30e:
                        if (pm.Skills[0x30].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x30].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x30].Update();
                        }
                        else if (pm.Skills[0x30].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x30].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x30].Update();
                        }
                        else if (pm.Skills[0x30].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x30].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x30].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x30f:
                        pm.SendGump(new RemoveTrapt(pm));
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x317:
                        pm.UseSkill(6);
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x318:
                        if (pm.Skills[6].Lock == SkillLock.Down)
                        {
                            pm.Skills[6].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[6].Update();
                        }
                        else if (pm.Skills[6].Lock == SkillLock.Locked)
                        {
                            pm.Skills[6].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[6].Update();
                        }
                        else if (pm.Skills[6].Lock == SkillLock.Up)
                        {
                            pm.Skills[6].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[6].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x319:
                        pm.SendGump(new Beggingt(pm));
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;
                }
                return;
            }
            if (num <= 0x32c)
            {
                switch (num)
                {
                    case 0x322:
                        if (pm.Skills[10].Lock == SkillLock.Up)
                        {
                            pm.Skills[10].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[10].Update();
                        }
                        else if (pm.Skills[10].Lock == SkillLock.Down)
                        {
                            pm.Skills[10].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[10].Update();
                        }
                        else if (pm.Skills[10].Lock == SkillLock.Locked)
                        {
                            pm.Skills[10].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[10].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        return;

                    case 0x32c:
                        if (pm.Skills[0x18].Lock == SkillLock.Up)
                        {
                            pm.Skills[0x18].SetLockNoRelay(SkillLock.Down);
                            pm.Skills[0x18].Update();
                        }
                        else if (pm.Skills[0x18].Lock == SkillLock.Down)
                        {
                            pm.Skills[0x18].SetLockNoRelay(SkillLock.Locked);
                            pm.Skills[0x18].Update();
                        }
                        else if (pm.Skills[0x18].Lock == SkillLock.Locked)
                        {
                            pm.Skills[0x18].SetLockNoRelay(SkillLock.Up);
                            pm.Skills[0x18].Update();
                        }
                        pm.CloseGump(typeof (CSkillsGumpf));
                        pm.SendGump(new CSkillsGumpf(pm));
                        break;
                }
                return;
            }
            switch (num)
            {
                case 0xbb9:
                    pm.CloseGump(typeof (CSkillsGumpf));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0xbba:
                    pm.CloseGump(typeof (CSkillsGumpf));
                    pm.SendGump(new CSkillsGumpb(pm));
                    return;

                case 0xbbb:
                    pm.CloseGump(typeof (CSkillsGumpf));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0xbbc:
                    pm.CloseGump(typeof (CSkillsGumpf));
                    pm.SendGump(new CSkillsGumpd(pm));
                    return;

                case 0xbbd:
                    pm.CloseGump(typeof (CSkillsGumpf));
                    pm.SendGump(new CSkillsGumpe(pm));
                    return;

                case 0xbbe:
                    pm.CloseGump(typeof (CSkillsGumpf));
                    pm.SendGump(new CSkillsGumpf(pm));
                    return;

                case 0x7d0:
                    pm.CloseGump(typeof (CSkillsGumpf));
                    return;

                default:
                    return;
            }
        }
    }
}

