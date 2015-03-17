using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HonestyTileEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new HonestyTileEastAddonDeed();
            }
        }

        [ Constructable ]
        public HonestyTileEastAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5279 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5280 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5281 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5282 );
			AddComponent( ac, 1, 0, 0 );

        }

        public HonestyTileEastAddon( Serial serial ) : base( serial )
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

    public class HonestyTileEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new HonestyTileEastAddon();
            }
        }

        [Constructable]
        public HonestyTileEastAddonDeed()
        {
            Name = "HonestyTileSouth";
        }

        public HonestyTileEastAddonDeed( Serial serial ) : base( serial )
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