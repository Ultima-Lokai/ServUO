using System;

namespace Server.Items
{
    public class DungPile : Item
    {
        [Constructable]
        public DungPile()
            : base(0x913)
        {
            Hue = Utility.RandomList(0x0, 1161, 0x44);
            Name = "a pile of dung";
            DefaultDecayTime = TimeSpan.FromMinutes(5.0);
        }

        public DungPile(Serial serial)
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

        public override void OnSingleClick(Mobile from)
        {
            this.LabelTo(from, 1005578);
        }
    }
}



