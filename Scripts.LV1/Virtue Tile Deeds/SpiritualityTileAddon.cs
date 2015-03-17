using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SpiritualityTileAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new SpiritualityTileAddonDeed();
            }
        }

        public override int LabelNumber { get { return 1012021; } } // Spirituality

        [ Constructable ]
        public SpiritualityTileAddon()
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

        public SpiritualityTileAddon( Serial serial ) : base( serial )
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

    public class SpiritualityTileAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new SpiritualityTileAddon();
            }
        }

        public override int LabelNumber { get { return 1080484; } } // Spirituality Virtue Tile Deed

        [Constructable]
        public SpiritualityTileAddonDeed()
        {
        }

        public SpiritualityTileAddonDeed( Serial serial ) : base( serial )
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