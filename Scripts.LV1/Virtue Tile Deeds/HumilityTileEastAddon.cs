using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HumilityTileEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new HumilityTileEastAddonDeed();
            }
        }

        [ Constructable ]
        public HumilityTileEastAddon()
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

        public HumilityTileEastAddon( Serial serial ) : base( serial )
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

    public class HumilityTileEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new HumilityTileEastAddon();
            }
        }

        [Constructable]
        public HumilityTileEastAddonDeed()
        {
            Name = "HumilityTileEast";
        }

        public HumilityTileEastAddonDeed( Serial serial ) : base( serial )
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