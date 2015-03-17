using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HumilityTileAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new HumilityTileAddonDeed();
            }
        }

        public override int LabelNumber { get { return 1012018; } } // Humility

        [ Constructable ]
        public HumilityTileAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5327 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5328 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5329 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5330 );
			AddComponent( ac, 1, 0, 0 );

        }

        public HumilityTileAddon( Serial serial ) : base( serial )
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

    public class HumilityTileAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new HumilityTileAddon();
            }
        }

        public override int LabelNumber { get { return 1080483; } } // Humility Virtue Tile Deed

        [Constructable]
        public HumilityTileAddonDeed()
        {
        }

        public HumilityTileAddonDeed( Serial serial ) : base( serial )
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