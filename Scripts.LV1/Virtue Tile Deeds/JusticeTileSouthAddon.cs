using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class JusticeTileSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new JusticeTileSouthAddonDeed();
            }
        }

        [ Constructable ]
        public JusticeTileSouthAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5299 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5300 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5301 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5302 );
			AddComponent( ac, 1, 0, 0 );

        }

        public JusticeTileSouthAddon( Serial serial ) : base( serial )
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

    public class JusticeTileSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new JusticeTileSouthAddon();
            }
        }

        [Constructable]
        public JusticeTileSouthAddonDeed()
        {
            Name = "JusticeTileSouth";
        }

        public JusticeTileSouthAddonDeed( Serial serial ) : base( serial )
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