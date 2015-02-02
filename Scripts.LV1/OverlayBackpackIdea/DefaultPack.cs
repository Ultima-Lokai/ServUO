using System;
using Server.Mobiles;
using Server.Network; 
// Script by September of ATA; Edited by Hammerhand & Safera
// Discussion at http://servuo.com/posts/14800/

namespace Server.Items
{
    public class DefaultPack : BaseContainer
    {
        public override int DefaultGumpID
        {
            get { return 0x3C; }
        } // open container popup gump id

        public override int DefaultDropSound
        {
            get { return 0x48; }
        } // you can change the onopen sound id

        public override Rectangle2D Bounds
        {
            get { return new Rectangle2D(0, 0, 300, 300); }
        }


        [Constructable]
        // public DefaultPack() : base( 0xE75 ) //0xE75 is default paperdoll gump id
        public DefaultPack() : base(0xC4F6) //paperdoll gump id
        {
            Name = "Default Pack";
            Layer = Layer.Backpack;
            Weight = 3.0;
            ItemID = 3701; //0xE75 ingame icon item id; usually same as above paperdoll gump id
        }

        public DefaultPack(Serial serial)
            : base(serial)
        {
        }

        public override bool OnEquip(Mobile from)
        {
            bool oldpack = false;
            bool oldtali = false;
            Container pack = (Container) from.FindItemOnLayer(Layer.Backpack);
            if (pack != null && !(pack is DefaultPack))
            {
                from.RemoveItem(pack);
                oldpack = true;
            }
            BaseTalisman tali = (BaseTalisman) from.FindItemOnLayer(Layer.Talisman);
            if (tali != null && !(tali is OverlayBackpack))
            {
                from.RemoveItem(tali);
                oldtali = true;
            }

            if (base.OnEquip(from))
            {
                if (oldpack) this.DropItem(pack);
                if (oldtali)
                {
                    this.DropItem(tali);
                    from.EquipItem(new OverlayBackpack());
                }
                return true;
            }
            return false;
        }

        public override void OnRemoved(object parent)
        {
            if (parent is PlayerMobile)
            {
                PlayerMobile from = parent as PlayerMobile;
                BaseTalisman tali = (BaseTalisman) from.FindItemOnLayer(Layer.Talisman);
                if (tali != null && !(tali is OverlayBackpack)) from.RemoveItem(tali);
            }
            base.OnRemoved(parent);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0); // version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

    }
}