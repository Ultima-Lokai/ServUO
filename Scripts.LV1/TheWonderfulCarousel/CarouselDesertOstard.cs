using System;

namespace Server.Mobiles
{
    [CorpseName("a broken carousel ostard")]
    public class CarouselDesertOstard : BaseCarouselMount
    {
        [Constructable]
        public CarouselDesertOstard()
            : this("a carousel ostard")
        {
        }

        [Constructable]
        public CarouselDesertOstard(string name)
            : base(name, 0xD2, 0x3EA3, AIType.AI_Animal, FightMode.None, 0, 0, 0, 0)
        {
            this.BaseSoundID = 0x270;
        }

        public CarouselDesertOstard(Serial serial)
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