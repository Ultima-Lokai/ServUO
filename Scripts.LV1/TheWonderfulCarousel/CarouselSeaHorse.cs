using System;

namespace Server.Mobiles
{
    [CorpseName("a broken carousel sea horse")]
    public class CarouselSeaHorse : BaseCarouselMount
    {
        [Constructable]
        public CarouselSeaHorse()
            : this("a carousel sea horse")
        {
        }

        [Constructable]
        public CarouselSeaHorse(string name)
            : base(name, 0x90, 0x3EB3, AIType.AI_Animal, FightMode.None, 0, 0, 0, 0)
        {
        }

        public CarouselSeaHorse(Serial serial)
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