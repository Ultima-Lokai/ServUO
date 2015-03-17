using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HonorTileSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new HonorTileSouthAddonDeed();
            }
        }

        [ Constructable ]
        public HonorTileSouthAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5323 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5326 );
			AddComponent( ac, 1, 0, 0 );
			ac = new VirtueTileComponent( 5324 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5325 );
			AddComponent( ac, 1, 1, 0 );

        }

        public HonorTileSouthAddon( Serial serial ) : base( serial )
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

    public class HonorTileSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new HonorTileSouthAddon();
            }
        }

        [Constructable]
        public HonorTileSouthAddonDeed()
        {
            Name = "HonorTileSouth";
        }

        public HonorTileSouthAddonDeed( Serial serial ) : base( serial )
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