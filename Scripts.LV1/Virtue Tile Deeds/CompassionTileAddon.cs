using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CompassionTileAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new CompassionTileAddonDeed();
            }
        }

        public override int LabelNumber { get { return 1012015; } } // Compassion Virtue Tile Deed

        [ Constructable ]
        public CompassionTileAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5287 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5288 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5289 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5290 );
			AddComponent( ac, 1, 0, 0 );

        }

        public CompassionTileAddon( Serial serial ) : base( serial )
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

    public class CompassionTileAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new CompassionTileAddon();
            }
        }

        public override int LabelNumber { get { return 1080481; } } // Compassion Virtue Tile Deed

        [Constructable]
        public CompassionTileAddonDeed()
        {
        }

        public CompassionTileAddonDeed( Serial serial ) : base( serial )
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