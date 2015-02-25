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
    public class CSkillsGumpc : Gump
    {
        private PlayerMobile pm;

        public CSkillsGumpc(PlayerMobile mobile) : base(0, 0)
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
            AddLabel(0x12f, 0x57, 0x495, "Bard Skills");
            AddLabel(160, 0x7d, 0x809, "Musicianship");
            AddLabel(160, 150, 0x809, "Discordance");
            AddLabel(160, 0xaf, 0x809, "Peacemaking");
            AddLabel(160, 200, 0x809, "Provocation");
            AddLabel(0x1a6, 0x7d, 0x809, string.Format("{0}", pm.Skills[0x1d].Base));
            AddLabel(0x1a6, 150, 0x809, string.Format("{0}", pm.Skills[15].Base));
            AddLabel(0x1a6, 0xaf, 0x809, string.Format("{0}", pm.Skills[9].Base));
            AddLabel(0x1a6, 200, 0x809, string.Format("{0}", pm.Skills[0x16].Base));
            if (pm.Skills[0x1d].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x80, 0x983, 0x984, 0x138, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x1d].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x80, 0x985, 0x986, 0x138, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x1d].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x80, 0x82c, 0x82c, 0x138, GumpButtonType.Reply, 0);
            }
            AddButton(0x88, 0x99, 0x7538, 0x7539, 0x141, GumpButtonType.Reply, 0);
            if (pm.Skills[15].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x99, 0x983, 0x984, 0x142, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[15].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x99, 0x985, 0x986, 0x142, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[15].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x99, 0x82c, 0x82c, 0x142, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x99, 0x8b0, 0x8b0, 0x143, GumpButtonType.Reply, 0);
            AddButton(0x88, 0xb2, 0x7538, 0x7539, 0x14b, GumpButtonType.Reply, 0);
            if (pm.Skills[9].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xb2, 0x983, 0x984, 0x14c, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[9].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xb2, 0x985, 0x986, 0x14c, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[9].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xb2, 0x82c, 0x82c, 0x14c, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0xb2, 0x8b0, 0x8b0, 0x14d, GumpButtonType.Reply, 0);
            AddButton(0x88, 0xcb, 0x7538, 0x7539, 0x155, GumpButtonType.Reply, 0);
            if (pm.Skills[0x16].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xcb, 0x983, 0x984, 0x156, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x16].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xcb, 0x985, 0x986, 0x156, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x16].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xcb, 0x82c, 0x82c, 0x156, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0xcb, 0x8b0, 0x8b0, 0x157, GumpButtonType.Reply, 0);
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
            switch (info.ButtonID)
            {
                case 0x155:
                    pm.UseSkill(0x16);
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0x156:
                    if (pm.Skills[0x16].Lock == SkillLock.Down)
                    {
                        pm.Skills[0x16].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[0x16].Update();
                    }
                    else if (pm.Skills[0x16].Lock == SkillLock.Locked)
                    {
                        pm.Skills[0x16].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[0x16].Update();
                    }
                    else if (pm.Skills[0x16].Lock == SkillLock.Up)
                    {
                        pm.Skills[0x16].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[0x16].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0x157:
                    pm.SendGump(new Provocationt(pm));
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0x7d0:
                    pm.CloseGump(typeof (CSkillsGumpc));
                    return;

                case 0xbb9:
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0xbba:
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpb(pm));
                    return;

                case 0xbbb:
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0xbbc:
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpd(pm));
                    return;

                case 0xbbd:
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpe(pm));
                    return;

                case 0xbbe:
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpf(pm));
                    return;

                case 0x141:
                    pm.UseSkill(15);
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0x142:
                    if (pm.Skills[15].Lock == SkillLock.Down)
                    {
                        pm.Skills[15].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[15].Update();
                    }
                    else if (pm.Skills[15].Lock == SkillLock.Locked)
                    {
                        pm.Skills[15].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[15].Update();
                    }
                    else if (pm.Skills[15].Lock == SkillLock.Up)
                    {
                        pm.Skills[15].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[15].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0x143:
                    pm.SendGump(new Discordancet(pm));
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0x138:
                    if (pm.Skills[0x1d].Lock == SkillLock.Up)
                    {
                        pm.Skills[0x1d].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[0x1d].Update();
                    }
                    else if (pm.Skills[0x1d].Lock == SkillLock.Down)
                    {
                        pm.Skills[0x1d].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[0x1d].Update();
                    }
                    else if (pm.Skills[0x1d].Lock == SkillLock.Locked)
                    {
                        pm.Skills[0x1d].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[0x1d].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0x14b:
                    pm.UseSkill(9);
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0x14c:
                    if (pm.Skills[9].Lock == SkillLock.Down)
                    {
                        pm.Skills[9].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[9].Update();
                    }
                    else if (pm.Skills[9].Lock == SkillLock.Locked)
                    {
                        pm.Skills[9].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[9].Update();
                    }
                    else if (pm.Skills[9].Lock == SkillLock.Up)
                    {
                        pm.Skills[9].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[9].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0x14d:
                    pm.SendGump(new Peacemakingt(pm));
                    pm.CloseGump(typeof (CSkillsGumpc));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                default:
                    return;
            }
        }
    }
}
