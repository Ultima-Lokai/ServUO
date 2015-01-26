using System;
using Server;

namespace Server.Items
{
    public class Nautilus : Item
    {
        [Constructable]
        public Nautilus()
            : base(0xFC7)
        {
            Weight = 0.1;
            Name = "a nautilus shell";
        }

        public Nautilus(Serial serial)
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