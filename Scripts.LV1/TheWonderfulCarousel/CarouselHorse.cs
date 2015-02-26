using System;

namespace Server.Mobiles
{
    [CorpseName("a broken carousel horse")]
    [TypeAlias("Server.Mobiles.BrownCarouselHorse", "Server.Mobiles.DirtyCarouselHorse", "Server.Mobiles.GrayCarouselHorse", "Server.Mobiles.TanCarouselHorse")]
    public class CarouselHorse : BaseCarouselMount
    {
        private static readonly int[] m_IDs = new int[]
        {
            0xC8, 0x3E9F,
            0xE2, 0x3EA0,
            0xE4, 0x3EA1,
            0xCC, 0x3EA2
        };

        [Constructable]
        public CarouselHorse()
            : this("a carousel horse")
        {
        }

        [Constructable]
        public CarouselHorse(string name)
            : base(name, 0xE2, 0x3EA0, AIType.AI_Animal, FightMode.None, 0, 0, 0, 0)
        {
            int random = Utility.Random(4);

            this.Body = m_IDs[random * 2];
            this.ItemID = m_IDs[random * 2 + 1];
            this.BaseSoundID = 0xA8;
        }

        public CarouselHorse(Serial serial)
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