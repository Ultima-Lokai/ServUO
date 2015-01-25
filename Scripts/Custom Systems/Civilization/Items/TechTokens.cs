using Server;
using System;
using Server.Items;

namespace Server.UOC
{

    public class TechTokens : CivTokens
    {

        public TechTokens()
        {

        }

        public TechTokens(Serial s)
            : base(s)
        {

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            switch (version)
            {
                case 0: break;
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

    }

}