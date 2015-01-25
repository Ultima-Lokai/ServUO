using System;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.UOC;
using Server.Engines.XmlSpawner2;

namespace Server.UOC.Items
{
    public class CivStone : Item
    {
        private string m_CivName;

        [CommandProperty(AccessLevel.GameMaster)]
        public string CivilizationName { get { return m_CivName; } set { m_CivName = value; } }

        public override string DefaultName
        {
            get { return string.Format("a Civilization Stone: {0}", m_CivName); }
        }

        [Constructable]
        public CivStone()
            : this("Not Set")
        {
        }

        [Constructable]
        public CivStone(string name)
            : base(0xED4)
        {
            Movable = false;
            Hue = 0x480;
            m_CivName = name;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is PlayerMobile)
            {
                PlayerMobile cit = from as PlayerMobile;
                CitizenAttachment ca = XmlAttach.FindAttachment(cit, typeof(CitizenAttachment)) as CitizenAttachment;
                if (ca != null && ca.HomeCivilization.Equals(this.CivilizationName))
                {
                    cit.SendGump(new CivStoneGump(cit, ca.HomeCivilization));
                }
                else
                    cit.SendMessage("Welcome visitor!");
            }
            else
                from.SendMessage("This stone is only for Citizens of {0}.", this.CivilizationName);
        }

        public CivStone(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((string)m_CivName);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_CivName = reader.ReadString();
        }
    }
}