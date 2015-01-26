using System;
using Server.Network;
using Server.Prompts;
using Server.Guilds;
using Server.Multis;
using Server.Regions;
using Server.Items;

namespace Server.UOC
{
    public class RecallStone : Item
    {
        private Point3D m_Point;
        private Map m_Map;

        public override int LabelNumber { get { return 1048042; } } // Recall Icon

        [Constructable]
        public RecallStone()
            : this(new Point3D(1496, 1628, 10), Map.Trammel) //Britain, Sweet Dreams Inn
        {
        }

        public RecallStone(Point3D point, Map map)
            : base(0x1869)
        {
            LootType = LootType.Blessed;
            m_Point = point;
            m_Map = map;
        }

        public RecallStone(Serial serial)
            : base(serial)
        {
        }

        public override bool DisplayLootType { get { return false; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((Point3D)m_Point);
            writer.Write((Map)m_Map);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            LootType = LootType.Blessed;

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_Point = reader.ReadPoint3D();
                        m_Map = reader.ReadMap();

                        break;
                    }
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (UOC.CoreSystem.Running)
                return;
            from.MoveToWorld(m_Point, m_Map);
            Container bank = from.BankBox;
            if (bank != null)
            {
                PreCivChest cont;
                cont = bank.FindItemByType(typeof(PreCivChest)) as PreCivChest;
                if (cont != null)
                {
                    cont.Visible = true;
                    cont.Movable = true;
                    bank.MaxItems = bank.MaxItems - cont.Items.Count;
                }
            }
            Delete();

        }
    }
}