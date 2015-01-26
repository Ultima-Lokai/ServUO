using System;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.UOC;
using Server.ContextMenus;
using Server.Engines.XmlSpawner2;

namespace Server.UOC.Items
{
    public class CivStone : Item
    {

        public override string DefaultName { get { return string.Format("a Civilization Stone"); } }

        [Constructable]
        public CivStone()
            : base(0xED4)
        {
            Movable = false;
            Hue = 0x480;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is PlayerMobile)
            {
                PlayerMobile cit = from as PlayerMobile;
                CitizenAttachment ca = XmlAttach.FindAttachment(cit, typeof(CitizenAttachment)) as CitizenAttachment;
                if (ca != null)
                {
                    cit.SendGump(new CivStoneGump(cit, ca.HomeCivilization));
                }
                else
                    from.SendMessage("This stone is only for Citizens of UO.");
            }
            else
                Console.WriteLine("The Civ Stone was used by {0}?", from.Name);
        }

        public CivStone(Serial serial)
            : base(serial)
        {
        }

        private delegate void CivStoneCallback(Mobile from);

        private class CallbackEntry : ContextMenuEntry
        {
            private readonly CivStoneCallback m_Callback;

            public CallbackEntry(int number, CivStoneCallback callback)
                : this(number, 5, callback)
            { }

            public CallbackEntry(int number, int range, CivStoneCallback callback)
                : base(number, range)
            {
                m_Callback = callback;
            }

            public override void OnClick()
            {
                if (m_Callback != null)
                {
                    Mobile from = Owner.From;
                    m_Callback(from);
                }
            }
        }

        private void AddToCivStone(Mobile from)
        {
            if (from is PlayerMobile)
                from.Target = new AddTokensTarget(this);
        }

        private class AddTokensTarget : Target
        {
            CivStone m_Stone;
            public AddTokensTarget(CivStone stone) : base(-1, false, TargetFlags.None) { m_Stone = stone; }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is CivTokens)
                {
                    CivTokens tokens = targeted as CivTokens;
                    StorageType stor = ((int)tokens.TokenType) == 0 ? StorageType.Technology : StorageType.Construction;

                    if (from is PlayerMobile)
                    {
                        PlayerMobile pm = from as PlayerMobile;
                        CitizenAttachment cit = (CitizenAttachment)XmlAttach.FindAttachment(from, typeof(CitizenAttachment));
                        if (cit != null)
                        {
                            int consumed = cit.MyCiv.AddToCoffer(stor, tokens.Amount);
							Console.WriteLine("{0} tokens should have been added to the Coffers.", consumed);
                            if (consumed > 0)
                            {
                                from.SendMessage("{0} {1} Tokens were added to your Civ's Coffers.", tokens.Amount, tokens.TokenType.ToString());
                                m_Stone.InvalidateProperties();
                                tokens.Consume(tokens.Amount);
                                if (tokens != null && tokens.Amount <= 0) tokens.Delete();
                            }
                            else
                                from.SendMessage("There was a problem adding the Tokens.");
                        }
                    }
                }
                else
                    from.SendMessage("Only Civ Tokens can be added using the Civ Stone.");
            }
        }

        public override void GetContextMenuEntries(Mobile from, System.Collections.Generic.List<ContextMenus.ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            if (from is PlayerMobile)
                list.Add(new CallbackEntry(175, AddToCivStone));
        }

        public override void SendPropertiesTo(Mobile from)
        {
            ObjectPropertyList opl = new ObjectPropertyList(this);
            if (from is PlayerMobile)
            {
                PlayerMobile pm = from as PlayerMobile;
                CitizenAttachment cit = (CitizenAttachment)XmlAttach.FindAttachment(pm, typeof(CitizenAttachment));
                if (cit != null)
                {
                    opl.Add("Technology Tokens in Coffers: {0}", cit.MyCiv.Coffers.TechnologyQuantity.ToString());
                    opl.Add("Construction Tokens in Coffers: {0}", cit.MyCiv.Coffers.ConstructionQuantity.ToString());
                }
            }
            from.Send(opl);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}