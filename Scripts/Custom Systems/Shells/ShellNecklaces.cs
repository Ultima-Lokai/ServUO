using System;
using Server;

namespace Server.Items
{

    [FlipableAttribute(0xFCD, 0xFD1)]
    public class ConchNecklace : Item
    {
        [Constructable]
        public ConchNecklace()
            : base(0xFCD)
        {
            Weight = 0.1;
            Name = "a conch necklace";
        }

        public ConchNecklace(Serial serial)
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

    [FlipableAttribute(0xFCF, 0xFD3)]
    public class NautilusNecklace : Item
    {
        [Constructable]
        public NautilusNecklace()
            : base(0xFCF)
        {
            Weight = 0.1;
            Name = "a nautilus necklace";
        }

        public NautilusNecklace(Serial serial)
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

    [FlipableAttribute(0xFD0, 0xFD4)]
    public class WhelkNecklace : Item
    {
        [Constructable]
        public WhelkNecklace()
            : base(0xFD0)
        {
            Weight = 0.1;
            Name = "a whelk necklace";
        }

        public WhelkNecklace(Serial serial)
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

    [FlipableAttribute(0xFCE, 0xFD2)]
    public class StringOfShells : Item
    {
        [Constructable]
        public StringOfShells()
            : base(0xFD0)
        {
            Weight = 0.1;
            Name = "a string of shells";
        }

        public StringOfShells(Serial serial)
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