using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.Factions;
using Server.Regions;
using Server.Accounting;
using Server.Engines.Craft;
using Server.Mobiles;

namespace Server.UOC.Concepts
{
    public static class Waste
    {
        public static int TotalWaste(CivEntry civ)
        {
            Building build;
            BuildingType b;
            int total = 0;
            for (int x = 0; x < civ.Buildings.Count; x++)
            {
                b = (BuildingType)civ.Buildings[x];
                build = UOC.Building.Table[b] as Building;
                //if (!BuildingObsolete(civ, b))
                if (build != null)
                    total += build.WasteFactor;
            }

            Technology tech;
            TechType t;
            for (int x = 0; x < civ.Technologies.Count; x++)
            {
                t = (TechType)civ.Technologies[x];
                tech = UOC.Technology.Table[t] as Technology;
                //if (!TechObsolete(civ, t))
                if (tech != null)
                    total += tech.WasteFactor;
            }

            GovernmentType g = civ.Government;
            Government gov = UOC.Government.Table[g] as Government;
            if (gov != null)
                total += gov.WasteFactor;

            return total;
        }
    }
}