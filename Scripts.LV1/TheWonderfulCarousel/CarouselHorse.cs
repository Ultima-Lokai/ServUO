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
            : base(name, 0xE2, 0x3EA0, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            int random = Utility.Random(4);

            this.Body = m_IDs[random * 2];
            this.ItemID = m_IDs[random * 2 + 1];
            this.BaseSoundID = 0xA8;

            this.SetStr(22, 98);
            this.SetDex(56, 75);
            this.SetInt(6, 10);

            this.SetHits(28, 45);
            this.SetMana(0);

            this.SetDamage(3, 4);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 15, 20);

            this.SetSkill(SkillName.MagicResist, 25.1, 30.0);
            this.SetSkill(SkillName.Tactics, 29.3, 44.0);
            this.SetSkill(SkillName.Wrestling, 29.3, 44.0);

            this.Fame = 300;
            this.Karma = 300;
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