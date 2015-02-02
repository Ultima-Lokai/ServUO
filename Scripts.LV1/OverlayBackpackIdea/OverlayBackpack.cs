using System;

namespace Server.Items
{

    public class OverlayBackpack : BaseTalisman
    {
        [Constructable]
        public OverlayBackpack()
            : this(0)
        {
        }

        [Constructable]
        public OverlayBackpack(int hue)
            : base(3522)
        {
            this.Weight = 1.0;
			this.Layer = Layer.Talisman;
            this.Hue = hue;
        }

        public OverlayBackpack(Serial serial)
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