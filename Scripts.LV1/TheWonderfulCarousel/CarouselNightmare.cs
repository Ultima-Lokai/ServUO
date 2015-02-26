using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a broken carousel nightmare")]
    public class CarouselNightmare : BaseCarouselMount
    {
        [Constructable]
        public CarouselNightmare()
            : this("a carousel nightmare")
        {
        }

        [Constructable]
        public CarouselNightmare(string name)
            : base(name, 0x74, 0x3EA7, AIType.AI_Animal, FightMode.None, 0, 0, 0, 0)
        {
            this.BaseSoundID = Core.AOS ? 0xA8 : 0x16A;

            switch ( Utility.Random(3) )
            {
                case 0:
                    {
                        this.BodyValue = 116;
                        this.ItemID = 16039;
                        break;
                    }
                case 1:
                    {
                        this.BodyValue = 178;
                        this.ItemID = 16041;
                        break;
                    }
                case 2:
                    {
                        this.BodyValue = 179;
                        this.ItemID = 16055;
                        break;
                    }
            }

            this.PackItem(new SulfurousAsh(Utility.RandomMinMax(3, 5)));
        }

        public CarouselNightmare(Serial serial)
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