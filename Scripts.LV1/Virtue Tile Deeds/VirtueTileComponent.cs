using System;
using Server;
using Server.Items;
using Server.Multis;

namespace Server.Items
{
    public class VirtueTileComponent : AddonComponent
    {
        [Constructable]
        public VirtueTileComponent(int itemID)
            : base(itemID)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            bool canflip = from.AccessLevel >= AccessLevel.Decorator;
            BaseHouse house = Multis.BaseHouse.FindHouseAt(from);
            if (house != null && house.Owner == from) canflip = true;
            if (canflip)
            {
                foreach (AddonComponent ac in Addon.Components)
                {
                    if (Addon is SacrificeTileAddon)
                    {
                        ac.ItemID = (ac.ItemID - 5378)%8 > 3 ? ac.ItemID - 4 : ac.ItemID + 4;
                    }
                    else
                    {
                        ac.ItemID = (ac.ItemID - 5271)%8 > 3 ? ac.ItemID - 4 : ac.ItemID + 4;
                    }
                }
            }
        }

        public VirtueTileComponent(Serial serial)
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
