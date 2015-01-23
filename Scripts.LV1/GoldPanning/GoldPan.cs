/* Original script created by Hammerhand & Milva */
/* Extensive modifications by Lokai */

using System;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Network;
using Server.Engines.Harvest;

namespace Server.Items
{

    public class GoldPan : BaseHarvestTool, IUsesRemaining
    {
        public override HarvestSystem HarvestSystem { get { return GoldPanning.System; } }

        [Constructable]
        public GoldPan(): this(50)
        {
            Name = "a gold pan";
        }
        [Constructable]
        public GoldPan(int uses): base(0x9D7)
        {
            Name = "a Gold Pan";
            Weight = 2.0;
            Hue = 0;
            Movable = true;
            UsesRemaining = uses;
            ShowUsesRemaining = true;
        }

        public GoldPan(Serial serial): base(serial)
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

    public class FullSmallGoldPan : Item
    {
        private int m_Uses;

        [Constructable]
        public FullSmallGoldPan(int uses)
            : base(0x9D8)
        {
            Name = "a full gold pan";
            Weight = 6.0;
            Hue = 0;
            Movable = true;
            m_Uses = uses;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from != null && from is PlayerMobile)
            {
                if (((PlayerMobile)from).Alive)
                {
                    from.SendMessage("You sift through the rocks and find a small gold nugget.");
                    from.AddToBackpack(new SmallGoldNugget());

                    if (m_Uses < 2)
                        from.SendMessage("You wore out your gold pan.");
                    else
                        from.AddToBackpack(new GoldPan(m_Uses - 1));
                    this.Delete();
                }
                else
                    from.SendMessage("You must be alive to search your gold pan!");
            }
        }

        public FullSmallGoldPan(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((int)m_Uses);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Uses = reader.ReadInt();
        }
    }

    public class FullMediumGoldPan : Item
    {
        private int m_Uses;

        [Constructable]
        public FullMediumGoldPan(int uses)
            : base(0x9D8)
        {
            Name = "a full gold pan";
            Weight = 6.0;
            Hue = 0;
            Movable = true;
            m_Uses = uses;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from != null && from is PlayerMobile)
            {
                if (((PlayerMobile)from).Alive)
                {
                    from.SendMessage("You sift through the rocks and find a medium gold nugget.");
                    from.AddToBackpack(new MediumGoldNugget());

                    if (m_Uses < 2)
                        from.SendMessage("You wore out your gold pan.");
                    else
                        from.AddToBackpack(new GoldPan(m_Uses - 1));
                    this.Delete();
                }
                else
                    from.SendMessage("You must be alive to search your gold pan!");
            }
        }

        public FullMediumGoldPan(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((int)m_Uses);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Uses = reader.ReadInt();
        }
    }

    public class FullLargeGoldPan : Item
    {
        private int m_Uses;

        [Constructable]
        public FullLargeGoldPan(int uses)
            : base(0x9D8)
        {
            Name = "a full gold pan";
            Weight = 6.0;
            Hue = 0;
            Movable = true;
            m_Uses = uses;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from != null && from is PlayerMobile)
            {
                if (((PlayerMobile)from).Alive)
                {
                    from.SendMessage("You sift through the rocks and find a large gold nugget.");
                    from.AddToBackpack(new LargeGoldNugget());

                    if (m_Uses < 2)
                        from.SendMessage("You wore out your gold pan.");
                    else
                        from.AddToBackpack(new GoldPan(m_Uses - 1));
                    this.Delete();
                }
                else
                    from.SendMessage("You must be alive to search your gold pan!");
            }
        }

        public FullLargeGoldPan(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((int)m_Uses);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Uses = reader.ReadInt();
        }
    }
}