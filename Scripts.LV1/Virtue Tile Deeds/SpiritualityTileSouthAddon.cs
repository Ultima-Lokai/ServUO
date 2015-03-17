using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SpiritualityTileSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new SpiritualityTileSouthAddonDeed();
            }
        }

        [ Constructable ]
        public SpiritualityTileSouthAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5315 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5316 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5317 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5318 );
			AddComponent( ac, 1, 0, 0 );

        }

        public SpiritualityTileSouthAddon( Serial serial ) : base( serial )
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

    public class SpiritualityTileSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new SpiritualityTileSouthAddon();
            }
        }

        [Constructable]
        public SpiritualityTileSouthAddonDeed()
        {
            Name = "SpiritualityTileSouth";
        }

        public SpiritualityTileSouthAddonDeed( Serial serial ) : base( serial )
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