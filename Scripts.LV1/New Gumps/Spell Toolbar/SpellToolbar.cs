
using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Spells;
using Server.Spells.First;
using Server.Spells.Second;
using Server.Spells.Third;
using Server.Spells.Fourth;
using Server.Spells.Fifth;
using Server.Spells.Sixth;
using Server.Spells.Seventh;
using Server.Spells.Eighth;
using Server.Spells.Necromancy;
using Server.Spells.Chivalry;
using Server.Spells.Bushido;
using Server.Spells.Ninjitsu;
using Server.Spells.Spellweaving;
using Server.Spells.Mystic;
using System.Xml;
using Server.Engines.XmlSpawner2;

namespace Server.Gumps
{
    public class SpellBarGump : Gump
    {

        public static bool HasSpell(Mobile from, int spellID)
        {

            PlayerMobile pm = (PlayerMobile) from;
            if (pm != null)
            {
                Array spellArray = new Array[] {};
                SpellRegistry.Types.CopyTo(spellArray, 0);
                foreach (Type spell in spellArray)
                {

                }
            }
            Spellbook book = Spellbook.Find(from, spellID);
            return (book != null && book.HasSpell(spellID));
        }

        private Mobile caller;
        public int m_Page;
        public int page = 0;



        public SpellBarGump(Mobile from, int page) : base(0, 0)
        {
        }
    }
}
