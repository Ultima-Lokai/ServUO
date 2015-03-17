using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CompassionTileSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new CompassionTileSouthAddonDeed();
            }
        }

        [ Constructable ]
        public CompassionTileSouthAddon()
        {
			VirtueTileComponent ac;
			ac = new VirtueTileComponent( 5291 );
			AddComponent( ac, 0, 0, 0 );
			ac = new VirtueTileComponent( 5292 );
			AddComponent( ac, 0, 1, 0 );
			ac = new VirtueTileComponent( 5293 );
			AddComponent( ac, 1, 1, 0 );
			ac = new VirtueTileComponent( 5294 );
			AddComponent( ac, 1, 0, 0 );

        }

        public CompassionTileSouthAddon( Serial serial ) : base( serial )
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

    public class CompassionTileSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new CompassionTileSouthAddon();
            }
        }

        [Constructable]
        public CompassionTileSouthAddonDeed()
        {
            Name = "CompassionTileSouth";
        }

        public CompassionTileSouthAddonDeed( Serial serial ) : base( serial )
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