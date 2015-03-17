using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SacrificeTileSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new SacrificeTileSouthAddonDeed();
            }
        }

        [ Constructable ]
        public SacrificeTileSouthAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5390 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5391 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5392 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5393 );
			AddComponent( ac, 1, 0, 0 );

        }

        public SacrificeTileSouthAddon( Serial serial ) : base( serial )
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

    public class SacrificeTileSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new SacrificeTileSouthAddon();
            }
        }

        [Constructable]
        public SacrificeTileSouthAddonDeed()
        {
            Name = "SacrificeTileSouth";
        }

        public SacrificeTileSouthAddonDeed( Serial serial ) : base( serial )
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