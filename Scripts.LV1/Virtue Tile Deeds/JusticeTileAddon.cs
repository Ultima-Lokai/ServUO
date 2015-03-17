using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class JusticeTileAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new JusticeTileAddonDeed();
            }
        }

        public override int LabelNumber { get { return 1012019; } } // Justice

        [ Constructable ]
        public JusticeTileAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5295 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5296 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5297 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5298 );
			AddComponent( ac, 1, 0, 0 );

        }

        public JusticeTileAddon( Serial serial ) : base( serial )
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

    public class JusticeTileAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new JusticeTileAddon();
            }
        }

        public override int LabelNumber { get { return 1080487; } } // Justice Virtue Tile Deed

        [Constructable]
        public JusticeTileAddonDeed()
        {
        }

        public JusticeTileAddonDeed( Serial serial ) : base( serial )
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