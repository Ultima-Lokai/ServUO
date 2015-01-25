using System;
using Server.Items;

namespace Server.UOC.Items
{
    public class PreCivChest : WoodenChest
    {
        [Constructable]
        public PreCivChest()
            : base(0xe43)
        {
        }

        public PreCivChest(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}