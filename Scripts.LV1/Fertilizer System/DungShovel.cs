using System;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
    public class DungShovel : BaseTool
    {
        [Constructable]
        public DungShovel()
            : this(50)
        {
        }

        [Constructable]
        public DungShovel(int uses)
            : base(uses, 0xF39)
        {
            this.Weight = 5.0;
            Name = "a dung shovel";
        }

        public DungShovel(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendMessage("What do you want to use this on?");
            Target target = new InternalDungTarget(this);
        }

        private class InternalDungTarget : Target
        {
            DungShovel shovel;

            public InternalDungTarget(DungShovel tool)
                : base(4, true, TargetFlags.None)
            {
                shovel = tool;
            }
            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is DungPile)
                {
                    from.SendMessage("What bucket do you want to place this in?");
                    Target target = new InternalBucketTarget(shovel, (DungPile)targeted);
                }
                else
                {
                    from.SendMessage("Use this on a pile of dung.");
                }
            }
        }

        private class InternalBucketTarget : Target
        {
            DungShovel shovel;
            DungPile dung;

            public InternalBucketTarget(DungShovel tool, DungPile resource)
                : base(4, true, TargetFlags.None)
            {
                shovel = tool;
                dung = resource;
            }
            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Bucket)
                {
                    Item bucket = targeted as Item;
                    if (bucket.Parent == from.Backpack)
                    {
                        shovel.UsesRemaining -= 1;
                        bucket.Delete();
                        dung.Delete();
                        FertileDirt dirt = new FertileDirt();
                        if (from.Backpack != null)
                            from.AddToBackpack(dirt);
                    }
                    else
                    {
                        from.SendMessage("I know it stinks, but you must have the bucket in your pack to fill it.");
                    }
                }
                else
                {
                    from.SendMessage("That is not a bucket.");
                }
            }
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