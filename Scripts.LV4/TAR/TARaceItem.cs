using System;
using System.Text;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.TAR
{
    public class TARaceItem : Item
    {
        private List<TARace> m_Races;

        public List<TARace> Races { get { return m_Races; } set { m_Races = value; } }

        [Constructable]
        public TARaceItem()
            : base(0x23C) //Green Ball Image
        {
            Name = "'The Amazing Race' Control Item";
            m_Races = new List<TARace>();
        }

        public TARaceItem(Serial s)
            : base(s)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); //version

            writer.Write((int)m_Races.Count);
            foreach (TARace race in m_Races)
            {
                race.Serialize(writer);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        int count = reader.ReadInt();
                        m_Races = new List<TARace>();
                        if (count > 0)
                        {
                            for (int x = 0; x < count; x++)
                            {
                                m_Races.Add(new TARace(x, reader));
                            }
                        }
                        break;
                    }
            }
        }
    }
}
