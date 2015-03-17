using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HumilityTileSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new HumilityTileSouthAddonDeed();
            }
        }

        [ Constructable ]
        public HumilityTileSouthAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5331 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5332 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5333 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5334 );
			AddComponent( ac, 1, 0, 0 );

        }

        public HumilityTileSouthAddon( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( 0 ); // Version
            Components[1].ItemID += 4;
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }

    public class HumilityTileSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new HumilityTileSouthAddon();
            }
        }

        [Constructable]
        public HumilityTileSouthAddonDeed()
        {
            Name = "HumilityTileSouth";
        }

        public HumilityTileSouthAddonDeed( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( 0 ); // Version
        }

        public override void    Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }
}