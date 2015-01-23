/* Original script created by Hammerhand & Milva */
/* Extensive modifications by Lokai */

using System;
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections;
using System.Collections.Generic;

namespace Server.Engines.Harvest
{
	public class GoldPanning : HarvestSystem
	{
		private static GoldPanning m_System;

		public static GoldPanning System
		{
			get
			{
				if ( m_System == null )
					m_System = new GoldPanning();

				return m_System;
			}
		}

		private HarvestDefinition m_Definition;

		public HarvestDefinition Definition
		{
			get{ return m_Definition; }
		}

        private GoldPanning()
		{
			HarvestResource[] res;
			HarvestVein[] veins;

            #region GoldPanning
            HarvestDefinition nugget = new HarvestDefinition();

			// Resource banks are every 6x6 tiles
            nugget.BankWidth = 6;
            nugget.BankHeight = 6;

			// Every bank holds from 4 to 8 nuggets
            nugget.MinTotal = 4;
            nugget.MaxTotal = 8;

			// A resource bank will respawn its content every 10 to 20 minutes
            nugget.MinRespawn = TimeSpan.FromMinutes(10.0);
            nugget.MaxRespawn = TimeSpan.FromMinutes(20.0);

			// Skill checking is done on the Fishing skill
            nugget.Skill = SkillName.Fishing;

			// Set the list of harvestable tiles
            nugget.Tiles = m_WaterTiles;
            nugget.RangedTiles = true;

			// Players must be within 2 tiles to harvest
            nugget.MaxRange = 2;

			// One nugget per harvest action
            nugget.ConsumedPerHarvest = 1;
            nugget.ConsumedPerFeluccaHarvest = 1;

			// The panning
            nugget.EffectActions = new int[] { 32 };
            nugget.EffectSounds = new int[0];
            nugget.EffectCounts = new int[] { 1 };
            nugget.EffectDelay = TimeSpan.Zero;
            nugget.EffectSoundDelay = TimeSpan.FromSeconds(8.0);

            nugget.NoResourcesMessage = "There don't seem to be any nuggets left here."; // There don't seem to be any nuggets left here.
            nugget.FailMessage = "You pan for a while, but fail to find any nuggets."; // You pan for a while, but fail to find any nuggets.
            nugget.TimedOutOfRangeMessage = "You need to be closer to the water for panning!"; // You need to be closer to the water for panning!
            nugget.OutOfRangeMessage = "You need to be closer to the water for panning!"; // You need to be closer to the water for panning!
            nugget.PackFullMessage = "You dont have room in your pack for another nugget."; // You dont have room in your pack for another nugget.
            nugget.ToolBrokeMessage = "Your pan is either full, missing, or just plain worn out."; // Your pan is either full, missing, or just plain worn out.

			res = new HarvestResource[]
				{
					new HarvestResource( 0.0, 0.0, 100.0, "You pan around until your pan is full.", typeof( FullSmallGoldPan ) ),
                    new HarvestResource( 70.0, 45.0, 150.0, "You pan around until your pan is full.", typeof( FullMediumGoldPan ) ),
                    new HarvestResource( 95.0, 70.0, 200.0, "You pan around until your pan is full.", typeof( FullLargeGoldPan ) )
				};

			veins = new HarvestVein[]
				{
					new HarvestVein( 75.0, 0.0, res[0], null ),
                    new HarvestVein( 15.0, 0.5, res[1], res[0] ),
                    new HarvestVein( 10.0, 0.5, res[2], res[0] )
				};

            nugget.Resources = res;
            nugget.Veins = veins;

            if (Core.ML)
            {
                nugget.BonusResources = new BonusHarvestResource[]
				{
					new BonusHarvestResource( 0, 75.0, null, null ),	//Nothing
                    new BonusHarvestResource( 0, 4.0, "You find a self-replicating puzzle box!", typeof( SelfReplicatingPuzzleBox ) ),
                    new BonusHarvestResource( 0, 3.0, "You find some footwear.", footTypes[Utility.Random(footTypes.Length)] ),
                    new BonusHarvestResource( 40, 2.0, 1072597, typeof( WhitePearl ) ),
                    new BonusHarvestResource( 40, 2.0, 1072569, typeof( BrilliantAmber ) ),
					new BonusHarvestResource( 40, 2.0, 1072567, typeof( DarkSapphire ) ),
					new BonusHarvestResource( 40, 2.0, 1072570, typeof( EcruCitrine ) ),
					new BonusHarvestResource( 50, 2.0, 1072562, typeof( BlueDiamond ) ),
					new BonusHarvestResource( 60, 2.0, 1072564, typeof( FireRuby ) ),
					new BonusHarvestResource( 70, 2.0, 1072566, typeof( PerfectEmerald ) ),
					new BonusHarvestResource( 70, 2.0, 1072568, typeof( Turquoise ) ),
                    new BonusHarvestResource( 90, 2.0, "You find a bottle with a note inside.", typeof( MessageInABottle ) )
				};
            }

            m_Definition = nugget;
            Definitions.Add(nugget);
			#endregion
		}

        private Type[] footTypes = new Type[] { typeof(Boots), typeof(ThighBoots), typeof(FurBoots), typeof(Shoes) };

		public override void OnConcurrentHarvest( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
            from.SendMessage("You are already panning."); // You are already panning.
		}

		private static Map SafeMap( Map map )
		{
			if ( map == null || map == Map.Internal )
				return Map.Trammel;

			return map;
		}

        public override bool CheckTool(Mobile from, Item tool)
        {
            bool wornOut = (tool == null || tool.Deleted || (tool is IUsesRemaining && ((IUsesRemaining)tool).UsesRemaining <= 0));

            if (wornOut)
                from.SendMessage((string)Definition.ToolBrokeMessage); // Your pan is either full, missing, or just plain worn out.

            return !wornOut;
        }

        public override void OnBadHarvestTarget(Mobile from, Item tool, object toHarvest)
        {
            from.SendMessage("You can't pan for gold there!");
        }

        public override bool CheckResources(Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, bool timed)
        {
            HarvestBank bank = def.GetBank(map, loc.X, loc.Y);
            bool available = (bank != null && bank.Current >= def.ConsumedPerHarvest);

            if (!available)
            {
                bank = new HarvestBank(def, def.GetVeinFrom(Utility.RandomDouble()));
                def.SendMessageTo(from, timed ? def.DoubleHarvestMessage : def.NoResourcesMessage);
            }

            return available;
        }

        public override void FinishHarvesting(Mobile from, Item tool, HarvestDefinition def, object toHarvest, object locked)
        {
            from.EndAction(locked);

            if (!CheckHarvest(from, tool))
                return;

            int tileID;
            Map map;
            Point3D loc;

            if (!GetHarvestDetails(from, tool, toHarvest, out tileID, out map, out loc))
            {
                OnBadHarvestTarget(from, tool, toHarvest);
                return;
            }
            else if (!def.Validate(tileID))
            {
                OnBadHarvestTarget(from, tool, toHarvest);
                return;
            }

            if (!CheckRange(from, tool, def, map, loc, true))
                return;
            else if (!CheckResources(from, tool, def, map, loc, true))
                return;
            else if (!CheckHarvest(from, tool, def, toHarvest))
                return;

            if (SpecialHarvest(from, tool, def, map, loc))
                return;

            HarvestBank bank = def.GetBank(map, loc.X, loc.Y);

            if (bank == null)
                return;

            HarvestVein vein = bank.Vein;

            if (vein == null)
                return;

            HarvestResource primary = vein.PrimaryResource;
            HarvestResource fallback = vein.FallbackResource;
            HarvestResource resource = MutateResource(from, tool, def, map, loc, vein, primary, fallback);

            double skillBase = from.Skills[def.Skill].Base;
            double skillValue = from.Skills[def.Skill].Value;

            Type type = null;

            if (skillBase >= resource.ReqSkill && from.CheckSkill(def.Skill, resource.MinSkill, resource.MaxSkill))
            {
                type = GetResourceType(from, tool, def, map, loc, resource);

                if (type != null)
                    type = MutateType(type, from, tool, def, map, loc, resource);

                if (type != null)
                {
                    Item item = null;
                    int uses = ((IUsesRemaining)tool).UsesRemaining;
                    try { item = Activator.CreateInstance(type, uses) as Item; tool.Delete(); }
                    catch { from.SendMessage("Failed to create item."); }

                    if (item == null)
                    {
                        type = null;
                    }
                    else
                    {
                        //The whole harvest system is kludgy and I'm sure this is just adding to it.
                        if (item.Stackable)
                        {
                            int amount = def.ConsumedPerHarvest;
                            int feluccaAmount = def.ConsumedPerFeluccaHarvest;

                            int racialAmount = (int)Math.Ceiling(amount * 1.1);
                            int feluccaRacialAmount = (int)Math.Ceiling(feluccaAmount * 1.1);

                            bool eligableForRacialBonus = (def.RaceBonus && from.Race == Race.Human);
                            bool inFelucca = (map == Map.Felucca);

                            if (eligableForRacialBonus && inFelucca && bank.Current >= feluccaRacialAmount && 0.1 > Utility.RandomDouble())
                                item.Amount = feluccaRacialAmount;
                            else if (inFelucca && bank.Current >= feluccaAmount)
                                item.Amount = feluccaAmount;
                            else if (eligableForRacialBonus && bank.Current >= racialAmount && 0.1 > Utility.RandomDouble())
                                item.Amount = racialAmount;
                            else
                                item.Amount = amount;
                        }

                        bank.Consume(item.Amount, from);

                        if (Give(from, item, def.PlaceAtFeetIfFull))
                        {
                            SendSuccessTo(from, item, resource);
                        }
                        else
                        {
                            SendPackFullTo(from, item, def, resource);
                            item.Delete();
                        }

                        BonusHarvestResource bonus = null;

                        double randomValue = Utility.RandomDouble() * 100;

                        if (Core.Debug && from.AccessLevel>= AccessLevel.Developer)
                            from.SendMessage("randomValue was {0}", randomValue.ToString());

                        for (int i = 0; i < def.BonusResources.Length; ++i)
                        {
                            if (randomValue <= def.BonusResources[i].Chance)
                            {
                                bonus = def.BonusResources[i];
                                if (Core.Debug && from.AccessLevel >= AccessLevel.Developer)
                                {
                                    from.SendMessage("randomValue was {0} on pass {1}", randomValue.ToString(), i.ToString());
                                    if (i > 0)
                                        from.SendMessage("Should give {0} on Min Skill: {1}", bonus.Type.Name, bonus.ReqSkill.ToString());
                                    else
                                        from.SendMessage("Should give no bonus resource.");
                                }
                                break;
                            }

                            randomValue -= def.BonusResources[i].Chance;
                        }

                        if (bonus != null && bonus.Type != null && skillBase >= bonus.ReqSkill)
                        {
                            Item bonusItem = Construct(bonus.Type, from);

                            if (Give(from, bonusItem, true))	//Bonuses always allow placing at feet
                                bonus.SendSuccessTo(from);
                            else
                                item.Delete();
                        }
                    }
                }
            }

            if (type == null)
                def.SendMessageTo(from, def.FailMessage);

            OnHarvestFinished(from, tool, def, vein, bank, resource, toHarvest);
        }

		public override void OnHarvestStarted( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			base.OnHarvestStarted( from, tool, def, toHarvest );

			int tileID;
			Map map;
			Point3D loc;

			if ( GetHarvestDetails( from, tool, toHarvest, out tileID, out map, out loc ) )
				Timer.DelayCall( TimeSpan.FromSeconds( 1.5 ), 
					delegate
					{
						if( Core.ML )
							from.RevealingAction();

						Effects.SendLocationEffect( loc, map, 0x352D, 16, 4 );
						Effects.PlaySound( loc, map, 0x364 );
					} );
		}

		public override void OnHarvestFinished( Mobile from, Item tool, HarvestDefinition def, HarvestVein vein, HarvestBank bank, HarvestResource resource, object harvested )
		{
			base.OnHarvestFinished( from, tool, def, vein, bank, resource, harvested );

			if ( Core.ML )
				from.RevealingAction();
		}

		public override object GetLock( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			return this;
		}

		public override bool BeginHarvesting( Mobile from, Item tool )
		{
			if ( !base.BeginHarvesting( from, tool ) )
				return false;

			from.SendMessage( "What water do you want to pan in?" ); // What water do you want to pan in?
			return true;
		}

		public override bool CheckHarvest( Mobile from, Item tool )
		{
			if ( !base.CheckHarvest( from, tool ) )
				return false;

			if ( from.Mounted )
			{
                from.SendMessage("You can't pan for gold while riding!"); // You can't pan for gold while riding!
				return false;
			}

			return true;
		}

		public override bool CheckHarvest( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			if ( !base.CheckHarvest( from, tool, def, toHarvest ) )
				return false;

			if ( from.Mounted )
			{
                from.SendMessage("You can't pan for gold while riding!"); // You can't pan for gold while riding!
				return false;
			}

			return true;
		}

		private static int[] m_WaterTiles = new int[]
			{
                //Static Item IDs for river tiles:
                0x5797, 0x5798,
                0x5799, 0x579A,
                0x579B, 0x579C,
                0x579D, 0x579E,
                0x579F, 0x57A0,
                0x57A1, 0x57A2,
                0x57A3, 0x57A4,
                0x57A5, 0x57A6,
                0x57A7, 0x57A8,
                0x57A9, 0x57AA,
                0x57AB, 0x57AC,
                0x57AD, 0x57AE,
                0x57AF, 0x57B0,
                0x57B1, 0x57B2,
			};
	}
}