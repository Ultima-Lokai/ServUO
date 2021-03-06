using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a broken carousel unicorn")]
    public class CarouselUnicorn : BaseCarouselMount
    {
        [Constructable]
        public CarouselUnicorn()
            : this("a carousel unicorn")
        {
        }

        [Constructable]
        public CarouselUnicorn(string name)
            : base(name, 0x7A, 0x3EB4, AIType.AI_Animal, FightMode.None, 0, 0, 0, 0)
        {
            this.BaseSoundID = 0x4BC;
        }

        public CarouselUnicorn(Serial serial)
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