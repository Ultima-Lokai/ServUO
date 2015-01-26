using System;
using Server;

namespace Server.Items
{
    public class Whelk : Item
    {
        [Constructable]
        public Whelk()
            : base(0xFCB)
        {
            Weight = 0.1;
            Name = "a whelk shell";
        }

        public Whelk(Serial serial)
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