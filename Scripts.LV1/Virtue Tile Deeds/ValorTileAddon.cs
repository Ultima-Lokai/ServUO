using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ValorTileAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new ValorTileAddonDeed();
            }
        }

        public override int LabelNumber { get { return 1012022; } } // Valor

        [ Constructable ]
        public ValorTileAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5303 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5304 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5305 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5306 );
			AddComponent( ac, 1, 0, 0 );

        }

        public ValorTileAddon( Serial serial ) : base( serial )
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

    public class ValorTileAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new ValorTileAddon();
            }
        }

        public override int LabelNumber { get { return 1080486; } } // Valor Virtue Tile Deed

        [Constructable]
        public ValorTileAddonDeed()
        {
        }

        public ValorTileAddonDeed( Serial serial ) : base( serial )
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