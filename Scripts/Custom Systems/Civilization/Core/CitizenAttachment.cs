using System;
using System.Collections.Generic;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Engines.XmlSpawner2;
using Server.UOC.Items;
using Server.UOC.Concepts;

namespace Server.UOC
{
    public class CitizenAttachment : XmlAttachment
    {
        private string m_HomeCivilization;

        [CommandProperty(AccessLevel.GameMaster)]
        public string HomeCivilization { get { return m_HomeCivilization; } set { m_HomeCivilization = value; } }

        public CitizenAttachment(string home)
        {
            m_HomeCivilization = home;
        }

        public CitizenAttachment(string home, ASerial s)
            : base(s)
        {
            m_HomeCivilization = home;
        }

        public CitizenAttachment(ASerial s)
            : base(s)
        {
        }

        public CivEntry MyCiv { get { return UOC.CoreSystem.CivEntries[HomeCivilization]; } }

        public override void GetPlayerMobileProperties(ObjectPropertyList list)
        {
            if (Owner is Mobile)
            {
                list.Add("Citizen of {0}", m_HomeCivilization);
            }
            base.GetPlayerMobileProperties(list);
        }

        public override void OnSkillChange(int skill, int skillType, double oldBase)
        {
            PlayerMobile m = Owner as PlayerMobile;
            if (m == null || skillType == 0) return;
            TokenType currentTokenType = MyCiv.GetSkillTokenType(m, (LokaiSkillName)skill);
            int toGive = MyCiv.GenerateCivTokens((LokaiSkillName)skill, m, currentTokenType);
            m.AddToBackpack(new CivTokens(toGive, currentTokenType));
            m.SendMessage("You have earned {0} {1} Tokens.", toGive, currentTokenType.ToString());
        }

        public override void OnSkillChange(SkillName skill, double oldBase)
        {
            PlayerMobile m = Owner as PlayerMobile;
            if (m == null) return;
            TokenType currentTokenType = MyCiv.GetSkillTokenType(m, skill);
            int toGive = MyCiv.GenerateCivTokens(skill, m, currentTokenType);
            m.AddToBackpack(new CivTokens(toGive, currentTokenType));
            m.SendMessage("You have earned {0} {1} Tokens.", toGive, currentTokenType.ToString());
        }

        public override bool AllowSkillUse(int skill, int skillType)
        {
            if (UOC.CoreSystem.Running)
            {
                PlayerMobile m = Owner as PlayerMobile;
                if (m == null || skillType == 0) return false;
                if (MyCiv.AllowSkillUse(m, (LokaiSkillName)skill))
                {
                    return base.AllowSkillUse(skill, skillType);
                }
                else
                {
                    m.SendMessage("That skill has not yet been discovered by your civilization.");
                    return false;
                }
            }
            else return base.AllowSkillUse(skill, skillType);
        }

        public override bool AllowSkillUse(SkillName skill)
        {
            if (UOC.CoreSystem.Running)
            {
                PlayerMobile m = Owner as PlayerMobile;
                if (m == null) return false;
                if (MyCiv.AllowSkillUse(m, skill))
                {
                    return base.AllowSkillUse(skill);
                }
                else
                {
                    m.SendMessage("That skill has not yet been discovered by your civilization.");
                    return false;
                }
            }
            else return base.AllowSkillUse(skill);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((string)m_HomeCivilization);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    m_HomeCivilization = reader.ReadString();
                    break;
            }
        }
    }
}