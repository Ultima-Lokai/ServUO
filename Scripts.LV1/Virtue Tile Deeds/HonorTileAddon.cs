using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HonorTileAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new HonorTileAddonDeed();
            }
        }

        public override int LabelNumber { get { return 1012017; } } // Honor

        [ Constructable ]
        public HonorTileAddon()
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

        public HonorTileAddon( Serial serial ) : base( serial )
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

    public class HonorTileAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new HonorTileAddon();
            }
        }

        public override int LabelNumber { get { return 1080485; } } // Honor Virtue Tile Deed

        [Constructable]
        public HonorTileAddonDeed()
        {
        }

        public HonorTileAddonDeed( Serial serial ) : base( serial )
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