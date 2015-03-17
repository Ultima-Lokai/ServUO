using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ValorTileSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new ValorTileSouthAddonDeed();
            }
        }

        [ Constructable ]
        public ValorTileSouthAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5307 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5308 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5309 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5310 );
			AddComponent( ac, 1, 0, 0 );

        }

        public ValorTileSouthAddon( Serial serial ) : base( serial )
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

    public class ValorTileSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new ValorTileSouthAddon();
            }
        }

        public override int LabelNumber { get { return 1080487; } }

        [Constructable]
        public ValorTileSouthAddonDeed()
        {
        }

        public ValorTileSouthAddonDeed( Serial serial ) : base( serial )
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