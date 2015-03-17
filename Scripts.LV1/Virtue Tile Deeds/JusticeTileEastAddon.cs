using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class JusticeTileEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new JusticeTileEastAddonDeed();
            }
        }

        [ Constructable ]
        public JusticeTileEastAddon()
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

        public JusticeTileEastAddon( Serial serial ) : base( serial )
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

    public class JusticeTileEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new JusticeTileEastAddon();
            }
        }

        [Constructable]
        public JusticeTileEastAddonDeed()
        {
            Name = "JusticeTileEast";
        }

        public JusticeTileEastAddonDeed( Serial serial ) : base( serial )
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