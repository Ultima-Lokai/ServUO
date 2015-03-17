using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CompassionTileEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new CompassionTileEastAddonDeed();
            }
        }

        [ Constructable ]
        public CompassionTileEastAddon()
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

        public CompassionTileEastAddon( Serial serial ) : base( serial )
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

    public class CompassionTileEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new CompassionTileEastAddon();
            }
        }

        [Constructable]
        public CompassionTileEastAddonDeed()
        {
            Name = "CompassionTileEast";
        }

        public CompassionTileEastAddonDeed( Serial serial ) : base( serial )
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