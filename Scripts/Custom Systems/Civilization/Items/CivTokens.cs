using Server;
using System;
using Server.Items;

namespace Server.UOC
{
    public enum TokenType
    {
        Technology = 0, Construction = 1
    }

    public class CivTokens : Item
    {
        private TokenType m_Type;
        public TokenType TokenType { get { return m_Type; } set { m_Type = value; } }

        private int[] HueType = new int[] { 145, 355 };

        [Constructable]
        public CivTokens()
            : this(1, TokenType.Technology)
        {
        }

        [Constructable]
        public CivTokens(int amount, TokenType type)
            : base(0xEED)
        {
            Stackable = true;
            Weight = 0.0;
            m_Type = type;
            Amount = amount;
            Hue = HueType[(int)type];
            Name = string.Format("{0} Tokens", type.ToString());
            LootType = LootType.Blessed;
        }

        public CivTokens(Serial s) : base(s)
        {

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            switch (version)
            {
                case 1: m_Type = (TokenType)reader.ReadInt(); break;
                case 0: break;
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
            writer.Write((int)m_Type);
        }

    }

}