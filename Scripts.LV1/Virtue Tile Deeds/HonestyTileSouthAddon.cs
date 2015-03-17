using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HonestyTileSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new HonestyTileSouthAddonDeed();
            }
        }

        [ Constructable ]
        public HonestyTileSouthAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5283 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5284 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5285 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5286 );
			AddComponent( ac, 1, 0, 0 );

        }

        public HonestyTileSouthAddon( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( 0 ); // Version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }

    public class HonestyTileSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new HonestyTileSouthAddon();
            }
        }

        [Constructable]
        public HonestyTileSouthAddonDeed()
        {
            Name = "HonestyTileSouth";
        }

        public HonestyTileSouthAddonDeed( Serial serial ) : base( serial )
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