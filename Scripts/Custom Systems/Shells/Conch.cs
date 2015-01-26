using System;
using Server;

namespace Server.Items
{
    public class Conch : Item
    {
        [Constructable]
        public Conch()
            : base(0xFC4)
        {
            Weight = 0.1;
            Name = "a conch shell";
        }

        public Conch(Serial serial)
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