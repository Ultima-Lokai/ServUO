using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HonorTileEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new HonorTileEastAddonDeed();
            }
        }

        [ Constructable ]
        public HonorTileEastAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5319 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5320 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5321 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5322 );
			AddComponent( ac, 1, 0, 0 );

        }

        public HonorTileEastAddon( Serial serial ) : base( serial )
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

    public class HonorTileEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new HonorTileEastAddon();
            }
        }

        [Constructable]
        public HonorTileEastAddonDeed()
        {
            Name = "HonorTileEast";
        }

        public HonorTileEastAddonDeed( Serial serial ) : base( serial )
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