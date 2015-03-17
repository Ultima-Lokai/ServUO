using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SpiritualityTileEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new SpiritualityTileEastAddonDeed();
            }
        }

        [ Constructable ]
        public SpiritualityTileEastAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5311 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5314 );
			AddComponent( ac, 1, 0, 0 );
			ac = new VirtueTileComponent( 5312 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5313 );
			AddComponent( ac, 1, 1, 0 );

        }

        public SpiritualityTileEastAddon( Serial serial ) : base( serial )
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

    public class SpiritualityTileEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new SpiritualityTileEastAddon();
            }
        }

        [Constructable]
        public SpiritualityTileEastAddonDeed()
        {
            Name = "SpiritualityTileEast";
        }

        public SpiritualityTileEastAddonDeed( Serial serial ) : base( serial )
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