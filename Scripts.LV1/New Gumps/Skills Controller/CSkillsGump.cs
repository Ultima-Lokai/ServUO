// ShowTool, StatsGump, and CSkills Toolbar Systems
// Written for Free Ultima Online Emulation Shards
// by Dorris, Mods/English Rewrite by Lokai
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
    public class CSkillsGump : Gump
    {
        private PlayerMobile pm;

        public CSkillsGump(PlayerMobile mobile) : base(0, 0)
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
            AddLabel(0x12f, 0x57, 0x495, "Wisdom and Lore");
            AddLabel(160, 0x7d, 0x809, "Animal Lore");
            AddLabel(160, 150, 0x809, "Item ID");
            AddLabel(160, 0xaf, 0x809, "Tracking");
            AddLabel(160, 200, 0x809, "Forensics");
            AddLabel(160, 0xe1, 0x809, "Herding");
            AddLabel(160, 250, 0x809, "Arms Lore");
            AddLabel(160, 0x113, 0x809, "Taste ID");
            AddLabel(160, 300, 0x809, "Cartography");
            AddLabel(160, 0x145, 0x809, "Anatomy");
            AddLabel(160, 350, 0x809, "Veterinary");
            AddLabel(0x1a6, 0x7d, 0x809, string.Format("{0}", pm.Skills[2].Base));
            AddLabel(0x1a6, 150, 0x809, string.Format("{0}", pm.Skills[3].Base));
            AddLabel(0x1a6, 0xaf, 0x809, string.Format("{0}", pm.Skills[0x26].Base));
            AddLabel(0x1a6, 200, 0x809, string.Format("{0}", pm.Skills[0x13].Base));
            AddLabel(0x1a6, 0xe1, 0x809, string.Format("{0}", pm.Skills[20].Base));
            AddLabel(0x1a6, 250, 0x809, string.Format("{0}", pm.Skills[4].Base));
            AddLabel(0x1a6, 0x113, 0x809, string.Format("{0}", pm.Skills[0x24].Base));
            AddLabel(0x1a6, 300, 0x809, string.Format("{0}", pm.Skills[12].Base));
            AddLabel(0x1a6, 0x145, 0x809, string.Format("{0}", pm.Skills[1].Base));
            AddLabel(0x1a6, 350, 0x809, string.Format("{0}", pm.Skills[0x27].Base));
            AddButton(0x88, 0x80, 0x7538, 0x7539, 0x65, GumpButtonType.Reply, 0);
            if (pm.Skills[2].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x80, 0x983, 0x984, 0x66, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[2].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x80, 0x985, 0x986, 0x66, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[2].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x80, 0x82c, 0x82c, 0x66, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x80, 0x8b0, 0x8b0, 0x67, GumpButtonType.Reply, 0);
            AddButton(0x88, 0x99, 0x7538, 0x7539, 0x6f, GumpButtonType.Reply, 0);
            if (pm.Skills[3].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x99, 0x983, 0x984, 0x70, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[3].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x99, 0x985, 0x986, 0x70, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[3].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x99, 0x82c, 0x82c, 0x70, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x99, 0x8b0, 0x8b0, 0x71, GumpButtonType.Reply, 0);
            AddButton(0x88, 0xb2, 0x7538, 0x7539, 0x79, GumpButtonType.Reply, 0);
            if (pm.Skills[0x26].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xb2, 0x983, 0x984, 0x7a, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x26].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xb2, 0x985, 0x986, 0x7a, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x26].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xb2, 0x82c, 0x82c, 0x7a, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0xb2, 0x8b0, 0x8b0, 0x7b, GumpButtonType.Reply, 0);
            AddButton(0x88, 0xcb, 0x7538, 0x7539, 0x83, GumpButtonType.Reply, 0);
            if (pm.Skills[0x13].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xcb, 0x983, 0x984, 0x84, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x13].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xcb, 0x985, 0x986, 0x84, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x13].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xcb, 0x82c, 0x82c, 0x84, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0xcb, 0x8b0, 0x8b0, 0x85, GumpButtonType.Reply, 0);
            if (pm.Skills[20].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xe4, 0x983, 0x984, 0x8e, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[20].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xe4, 0x985, 0x986, 0x8e, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[20].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xe4, 0x82c, 0x82c, 0x8e, GumpButtonType.Reply, 0);
            }
            AddButton(0x88, 0xfd, 0x7538, 0x7539, 0x97, GumpButtonType.Reply, 0);
            if (pm.Skills[4].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0xfd, 0x983, 0x984, 0x98, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[4].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0xfd, 0x985, 0x986, 0x98, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[4].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0xfd, 0x82c, 0x82c, 0x98, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0xfd, 0x8b0, 0x8b0, 0x99, GumpButtonType.Reply, 0);
            AddButton(0x88, 0x116, 0x7538, 0x7539, 0xa1, GumpButtonType.Reply, 0);
            if (pm.Skills[0x24].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x116, 0x983, 0x984, 0xa2, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x24].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x116, 0x985, 0x986, 0xa2, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x24].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x116, 0x82c, 0x82c, 0xa2, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x116, 0x8b0, 0x8b0, 0xa3, GumpButtonType.Reply, 0);
            if (pm.Skills[12].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x12f, 0x983, 0x984, 0xac, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[12].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x12f, 0x985, 0x986, 0xac, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[12].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x12f, 0x82c, 0x82c, 0xac, GumpButtonType.Reply, 0);
            }
            AddButton(0x88, 0x148, 0x7538, 0x7539, 0xb5, GumpButtonType.Reply, 0);
            if (pm.Skills[1].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x148, 0x983, 0x984, 0xb6, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[1].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x148, 0x985, 0x986, 0xb6, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[1].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x148, 0x82c, 0x82c, 0xb6, GumpButtonType.Reply, 0);
            }
            AddButton(520, 0x148, 0x8b0, 0x8b0, 0xb7, GumpButtonType.Reply, 0);
            if (pm.Skills[0x27].Lock == SkillLock.Up)
            {
                AddButton(0x1ef, 0x161, 0x983, 0x984, 0xc0, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x27].Lock == SkillLock.Down)
            {
                AddButton(0x1ef, 0x161, 0x985, 0x986, 0xc0, GumpButtonType.Reply, 0);
            }
            else if (pm.Skills[0x27].Lock == SkillLock.Locked)
            {
                AddButton(0x1ef, 0x161, 0x82c, 0x82c, 0xc0, GumpButtonType.Reply, 0);
            }
            AddButton(120, 0x1c5, 0x15cf, 0x15d0, 0xbb9, GumpButtonType.Reply, 0);
            AddButton(0xb6, 0x1c5, 0x15cd, 0x15ce, 0xbba, GumpButtonType.Reply, 0);
            AddButton(0xf4, 0x1c4, 0x15b1, 0x15b2, 0xbbb, GumpButtonType.Reply, 0);
            AddButton(390, 0x1c5, 0x15ab, 0x15ac, 0xbbc, GumpButtonType.Reply, 0);
            AddButton(0x1c4, 0x1c5, 0x15c1, 0x15c2, 0xbbd, GumpButtonType.Reply, 0);
            AddButton(0x202, 0x1c5, 0x15bb, 0x15bc, 0xbbe, GumpButtonType.Reply, 0);
            AddLabel(0x7d, 0x1a9, 0x43c, "Original Script by Dorris. Mods by Lokai.");
            AddLabel(0x19f, 0x1a7, 0x43c, "Skill Total:");
            AddLabel(0x1f1, 0x1a7, 0x480, string.Format(" {0}", ((double) pm.Skills.Total)/10.0));
            AddButton(0x139, 0x1d2, 0x478, 0xf8, 0x7d0, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 0xbb9:
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0xbba:
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGumpb(pm));
                    return;

                case 0xbbb:
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGumpc(pm));
                    return;

                case 0xbbc:
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGumpd(pm));
                    return;

                case 0xbbd:
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGumpe(pm));
                    return;

                case 0xbbe:
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGumpf(pm));
                    return;

                case 0x7d0:
                    pm.CloseGump(typeof (CSkillsGump));
                    return;

                case 0xc0:
                    if (pm.Skills[0x27].Lock == SkillLock.Up)
                    {
                        pm.Skills[0x27].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[0x27].Update();
                    }
                    else if (pm.Skills[0x27].Lock == SkillLock.Down)
                    {
                        pm.Skills[0x27].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[0x27].Update();
                    }
                    else if (pm.Skills[0x27].Lock == SkillLock.Locked)
                    {
                        pm.Skills[0x27].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[0x27].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0xa1:
                    pm.UseSkill(0x24);
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0xa2:
                    if (pm.Skills[0x24].Lock == SkillLock.Down)
                    {
                        pm.Skills[0x24].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[0x24].Update();
                    }
                    else if (pm.Skills[0x24].Lock == SkillLock.Locked)
                    {
                        pm.Skills[0x24].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[0x24].Update();
                    }
                    else if (pm.Skills[0x24].Lock == SkillLock.Up)
                    {
                        pm.Skills[0x24].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[0x24].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0xa3:
                    pm.SendGump(new TasteIDt(pm));
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0xac:
                    if (pm.Skills[12].Lock == SkillLock.Up)
                    {
                        pm.Skills[12].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[12].Update();
                    }
                    else if (pm.Skills[12].Lock == SkillLock.Down)
                    {
                        pm.Skills[12].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[12].Update();
                    }
                    else if (pm.Skills[12].Lock == SkillLock.Locked)
                    {
                        pm.Skills[12].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[12].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0xb5:
                    pm.UseSkill(1);
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0xb6:
                    if (pm.Skills[1].Lock == SkillLock.Down)
                    {
                        pm.Skills[1].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[1].Update();
                    }
                    else if (pm.Skills[1].Lock == SkillLock.Locked)
                    {
                        pm.Skills[1].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[1].Update();
                    }
                    else if (pm.Skills[1].Lock == SkillLock.Up)
                    {
                        pm.Skills[1].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[1].Update();
                    }

                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0xb7:
                    pm.SendGump(new Anatomyt(pm));
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x83:
                    pm.UseSkill(0x13);
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x84:
                    if (pm.Skills[0x13].Lock == SkillLock.Down)
                    {
                        pm.Skills[0x13].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[0x13].Update();
                    }
                    else if (pm.Skills[0x13].Lock == SkillLock.Locked)
                    {
                        pm.Skills[0x13].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[0x13].Update();
                    }
                    else if (pm.Skills[0x13].Lock == SkillLock.Up)
                    {
                        pm.Skills[0x13].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[0x13].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x85:
                    pm.SendGump(new Forensicst(pm));
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x8e:
                    if (pm.Skills[20].Lock == SkillLock.Up)
                    {
                        pm.Skills[20].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[20].Update();
                    }
                    else if (pm.Skills[20].Lock == SkillLock.Down)
                    {
                        pm.Skills[20].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[20].Update();
                    }
                    else if (pm.Skills[20].Lock == SkillLock.Locked)
                    {
                        pm.Skills[20].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[20].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x97:
                    pm.UseSkill(4);
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x98:
                    if (pm.Skills[4].Lock == SkillLock.Down)
                    {
                        pm.Skills[4].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[4].Update();
                    }
                    else if (pm.Skills[4].Lock == SkillLock.Locked)
                    {
                        pm.Skills[4].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[4].Update();
                    }
                    else if (pm.Skills[4].Lock == SkillLock.Up)
                    {
                        pm.Skills[4].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[4].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x99:
                    pm.SendGump(new ArmsLoret(pm));
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x65:
                    pm.UseSkill(2);
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x66:
                    if (pm.Skills[2].Lock == SkillLock.Down)
                    {
                        pm.Skills[2].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[2].Update();
                    }
                    else if (pm.Skills[2].Lock == SkillLock.Locked)
                    {
                        pm.Skills[2].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[2].Update();
                    }
                    else if (pm.Skills[2].Lock == SkillLock.Up)
                    {
                        pm.Skills[2].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[2].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x67:
                    pm.SendGump(new AnimalLoret(pm));
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x6f:
                    pm.UseSkill(3);
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x70:
                    if (pm.Skills[3].Lock == SkillLock.Down)
                    {
                        pm.Skills[3].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[3].Update();
                    }
                    else if (pm.Skills[3].Lock == SkillLock.Locked)
                    {
                        pm.Skills[3].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[3].Update();
                    }
                    else if (pm.Skills[3].Lock == SkillLock.Up)
                    {
                        pm.Skills[3].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[3].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x71:
                    pm.SendGump(new ItemIDt(pm));
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x79:
                    pm.UseSkill(0x26);
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x7a:
                    if (pm.Skills[0x26].Lock == SkillLock.Down)
                    {
                        pm.Skills[0x26].SetLockNoRelay(SkillLock.Locked);
                        pm.Skills[0x26].Update();
                    }
                    else if (pm.Skills[0x26].Lock == SkillLock.Locked)
                    {
                        pm.Skills[0x26].SetLockNoRelay(SkillLock.Up);
                        pm.Skills[0x26].Update();
                    }
                    else if (pm.Skills[0x26].Lock == SkillLock.Up)
                    {
                        pm.Skills[0x26].SetLockNoRelay(SkillLock.Down);
                        pm.Skills[0x26].Update();
                    }
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                case 0x7b:
                    pm.SendGump(new Trackingt(pm));
                    pm.CloseGump(typeof (CSkillsGump));
                    pm.SendGump(new CSkillsGump(pm));
                    return;

                default:
                    return;
            }
        }
    }
}

