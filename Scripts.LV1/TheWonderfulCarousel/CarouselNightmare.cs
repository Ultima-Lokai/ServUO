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
            : base(name, 0x74, 0x3EA7, AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.BaseSoundID = Core.AOS ? 0xA8 : 0x16A;

            this.SetStr(496, 525);
            this.SetDex(86, 105);
            this.SetInt(86, 125);

            this.SetHits(298, 315);

            this.SetDamage(16, 22);

            this.SetDamageType(ResistanceType.Physical, 40);
            this.SetDamageType(ResistanceType.Fire, 40);
            this.SetDamageType(ResistanceType.Energy, 20);

            this.SetResistance(ResistanceType.Physical, 55, 65);
            this.SetResistance(ResistanceType.Fire, 30, 40);
            this.SetResistance(ResistanceType.Cold, 30, 40);
            this.SetResistance(ResistanceType.Poison, 30, 40);
            this.SetResistance(ResistanceType.Energy, 20, 30);

            this.SetSkill(SkillName.EvalInt, 10.4, 50.0);
            this.SetSkill(SkillName.Magery, 10.4, 50.0);
            this.SetSkill(SkillName.MagicResist, 85.3, 100.0);
            this.SetSkill(SkillName.Tactics, 97.6, 100.0);
            this.SetSkill(SkillName.Wrestling, 80.5, 92.5);

            this.Fame = 14000;
            this.Karma = -14000;

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