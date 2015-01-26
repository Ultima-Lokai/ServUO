using System;
using Server;

namespace Server.Items
{
    public class SnailShell : Item
    {
        [Constructable]
        public SnailShell()
            : base(0xFCC)
        {
            Weight = 0.1;
            Name = "a snail shell";
        }

        public SnailShell(Serial serial)
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