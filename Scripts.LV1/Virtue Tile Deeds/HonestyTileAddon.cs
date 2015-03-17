using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HonestyTileAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new HonestyTileAddonDeed();
            }
        }

        public override int LabelNumber { get { return 1012016; } } // Honesty

        [ Constructable ]
        public HonestyTileAddon()
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

        public HonestyTileAddon( Serial serial ) : base( serial )
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

    public class HonestyTileAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new HonestyTileAddon();
            }
        }

        public override int LabelNumber { get { return 1080488; } } // Honesty Virtue Tile Deed

        [Constructable]
        public HonestyTileAddonDeed()
        {
        }

        public HonestyTileAddonDeed( Serial serial ) : base( serial )
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