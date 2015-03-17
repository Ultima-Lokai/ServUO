using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ValorTileEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new ValorTileEastAddonDeed();
            }
        }

        [ Constructable ]
        public ValorTileEastAddon()
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

        public ValorTileEastAddon( Serial serial ) : base( serial )
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

    public class ValorTileEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new ValorTileEastAddon();
            }
        }

        public override int LabelNumber { get { return 1080487; } }

        [Constructable]
        public ValorTileEastAddonDeed()
        {
        }

        public ValorTileEastAddonDeed( Serial serial ) : base( serial )
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