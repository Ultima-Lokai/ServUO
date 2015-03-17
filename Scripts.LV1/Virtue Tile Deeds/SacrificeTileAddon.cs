using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SacrificeTileAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new SacrificeTileAddonDeed();
            }
        }

        public override int LabelNumber { get { return 1012020; } } // Sacrifice


        [ Constructable ]
        public SacrificeTileAddon()
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

        public SacrificeTileAddon( Serial serial ) : base( serial )
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

    public class SacrificeTileAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new SacrificeTileAddon();
            }
        }
        public override int LabelNumber { get { return 1080482; } }

        [Constructable]
        public SacrificeTileAddonDeed()
        {
        }

        public SacrificeTileAddonDeed( Serial serial ) : base( serial )
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