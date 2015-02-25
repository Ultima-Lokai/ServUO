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
            : base(name, 0x7A, 0x3EB4, AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4)
        {
            this.BaseSoundID = 0x4BC;

            this.SetStr(296, 325);
            this.SetDex(96, 115);
            this.SetInt(186, 225);

            this.SetHits(191, 210);

            this.SetDamage(16, 22);

            this.SetDamageType(ResistanceType.Physical, 75);
            this.SetDamageType(ResistanceType.Energy, 25);

            this.SetResistance(ResistanceType.Physical, 55, 65);
            this.SetResistance(ResistanceType.Fire, 25, 40);
            this.SetResistance(ResistanceType.Cold, 25, 40);
            this.SetResistance(ResistanceType.Poison, 55, 65);
            this.SetResistance(ResistanceType.Energy, 25, 40);

            this.SetSkill(SkillName.EvalInt, 80.1, 90.0);
            this.SetSkill(SkillName.Magery, 60.2, 80.0);
            this.SetSkill(SkillName.Meditation, 50.1, 60.0);
            this.SetSkill(SkillName.MagicResist, 75.3, 90.0);
            this.SetSkill(SkillName.Tactics, 20.1, 22.5);
            this.SetSkill(SkillName.Wrestling, 80.5, 92.5);

            this.Fame = 9000;
            this.Karma = 9000;
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