using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SacrificeTileEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new SacrificeTileEastAddonDeed();
            }
        }

        [ Constructable ]
        public SacrificeTileEastAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5386 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5387 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5388 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5389 );
			AddComponent( ac, 1, 0, 0 );

        }

        public SacrificeTileEastAddon( Serial serial ) : base( serial )
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

    public class SacrificeTileEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new SacrificeTileEastAddon();
            }
        }

        [Constructable]
        public SacrificeTileEastAddonDeed()
        {
            Name = "SacrificeTileEast";
        }

        public SacrificeTileEastAddonDeed( Serial serial ) : base( serial )
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