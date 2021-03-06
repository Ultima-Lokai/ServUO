using System;
using Server.Items;

namespace Server.UOC
{

    [Furniture]
    [Flipable(0xE43, 0xE42)]
    public class PreCivChest : WoodenChest
    {
        [Constructable]
        public PreCivChest()
            : base()
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