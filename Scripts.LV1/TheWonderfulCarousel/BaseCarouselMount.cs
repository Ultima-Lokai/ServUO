using System;
using System.Collections;
using Server.Commands;
using Server.Gumps;
using Server.Network;

namespace Server.Mobiles
{
    public abstract class BaseCarouselMount : BaseCreature, IMount
    {
        private static readonly Hashtable m_Table = new Hashtable();
        private Mobile m_Rider;
        private Item m_InternalItem;
        private DateTime m_NextMountAbility;

        public BaseCarouselMount(string name, int bodyID, int itemID, AIType aiType, FightMode fightMode, int rangePerception, int rangeFight, double activeSpeed, double passiveSpeed)
            : base(aiType, fightMode, rangePerception, rangeFight, activeSpeed, passiveSpeed)
        {
            this.Name = name;
            this.Body = bodyID;
            this.Frozen = true;
            this.CantWalk = true;
            this.Tamable = false;

            this.m_InternalItem = new CarouselMountItem(this, itemID);
        }

        public override bool IsDispellable
        {
            get { return false; }
        }

        public override bool CanBeDamaged()
        {
            return false;
        }

        public BaseCarouselMount(Serial serial)
            : base(serial)
        {
        }

        public virtual TimeSpan MountAbilityDelay
        {
            get
            {
                return TimeSpan.Zero;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextMountAbility
        {
            get
            {
                return this.m_NextMountAbility;
            }
            set
            {
                this.m_NextMountAbility = value;
            }
        }
        public virtual bool AllowMaleRider
        {
            get
            {
                return true;
            }
        }
        public virtual bool AllowFemaleRider
        {
            get
            {
                return true;
            }
        }
        [Hue, CommandProperty(AccessLevel.GameMaster)]
        public override int Hue
        {
            get
            {
                return base.Hue;
            }
            set
            {
                base.Hue = value;

                if (this.m_InternalItem != null)
                    this.m_InternalItem.Hue = value;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int ItemID
        {
            get
            {
                if (this.m_InternalItem != null)
                    return this.m_InternalItem.ItemID;
                else
                    return 0;
            }
            set
            {
                if (this.m_InternalItem != null)
                    this.m_InternalItem.ItemID = value;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Rider
        {
            get
            {
                return this.m_Rider;
            }
            set
            {
                if (this.m_Rider != value)
                {
                    if (value == null)
                    {
                        Point3D loc = this.m_Rider.Location;
                        Map map = this.m_Rider.Map;

                        if (map == null || map == Map.Internal)
                        {
                            loc = this.m_Rider.LogoutLocation;
                            map = this.m_Rider.LogoutMap;
                        }

                        this.Direction = this.m_Rider.Direction;
                        this.Location = loc;
                        this.Map = map;

                        if (this.m_InternalItem != null)
                            this.m_InternalItem.Internalize();
                    }
                    else
                    {
                        if (this.m_Rider != null)
                            Dismount(this.m_Rider);

                        Dismount(value);

                        if (this.m_InternalItem != null)
                            value.AddItem(this.m_InternalItem);

                        value.Direction = this.Direction;

                        this.Internalize();
                    }

                    this.m_Rider = value;
                }
            }
        }

        protected Item InternalItem
        {
            get
            {
                return this.m_InternalItem;
            }
        }

        public override void OnThink()
        {
            if (Rider == null)
            {
                
            }
        }

        public static void Dismount(Mobile dismounted)
        {
            Dismount(dismounted, dismounted, BlockMountType.None, TimeSpan.FromSeconds(0), false);
        }

        public static void Dismount(Mobile dismounter, Mobile dismounted, BlockMountType blockmounttype, TimeSpan delay)
        {
            Dismount(dismounter, dismounted, blockmounttype, TimeSpan.FromSeconds(0), true);
        }

        public static void Dismount(Mobile dismounter, Mobile dismounted, BlockMountType blockmounttype, TimeSpan delay, bool message)
        {
            if (!dismounted.Mounted)
                return;

            if (dismounted is ChaosDragoonElite)
            {
                dismounter.SendLocalizedMessage(1042047); // You fail to knock the rider from its mount.
            }

            IMount mount = dismounted.Mount;

            if (mount != null)
            {
                mount.Rider.Paralyzed = false;
                mount.Rider = null;
                BaseCarouselMount.SetMountPrevention(dismounted, blockmounttype, delay);

                if (message)
                    dismounted.SendLocalizedMessage(1040023); // You have been knocked off of your mount!
            }
            else if (dismounted.Flying)
            {
                if (!OnFlightPath(dismounted))
                {
                    dismounted.Flying = false;
                    dismounted.Freeze(TimeSpan.FromSeconds(1));
                    dismounted.Animate(61, 10, 1, true, false, 0);
                }
            }
        }

        public static bool OnFlightPath(Mobile m)
        {
            if (!m.Flying)
                return false;

            StaticTile[] tiles = m.Map.Tiles.GetStaticTiles(m.X, m.Y, true);
            ItemData itemData;
            bool onpath = false;

            for (int i = 0; i < tiles.Length && !onpath; ++i)
            {
                itemData = TileData.ItemTable[tiles[i].ID & TileData.MaxItemValue];
                onpath = (itemData.Name == "hover over");
            }

            return onpath;
        }

        public static void SetMountPrevention(Mobile mob, BlockMountType type, TimeSpan duration)
        {
            if (mob == null)
                return;

            DateTime expiration = DateTime.UtcNow + duration;

            BlockEntry entry = m_Table[mob] as BlockEntry;

            if (entry != null)
            {
                entry.m_Type = type;
                entry.m_Expiration = expiration;
            }
            else
            {
                m_Table[mob] = entry = new BlockEntry(type, expiration);
            }
        }

        public static void ClearMountPrevention(Mobile mob)
        {
            if (mob != null)
                m_Table.Remove(mob);
        }

        public static BlockMountType GetMountPrevention(Mobile mob)
        {
            if (mob == null)
                return BlockMountType.None;

            BlockEntry entry = m_Table[mob] as BlockEntry;

            if (entry == null)
                return BlockMountType.None;

            if (entry.IsExpired)
            {
                m_Table.Remove(mob);
                return BlockMountType.None;
            }

            return entry.m_Type;
        }

        public static bool CheckMountAllowed(Mobile mob, bool message)
        {
            BlockMountType type = GetMountPrevention(mob);

            if (type == BlockMountType.None)
                return true;

            if (message)
            {
                switch ( type )
                {
                    case BlockMountType.Dazed:
                        {
                            mob.SendLocalizedMessage(1040024); // You are still too dazed from being knocked off your mount to ride!
                            break;
                        }
                    case BlockMountType.BolaRecovery:
                        {
                            mob.SendLocalizedMessage(1062910); // You cannot mount while recovering from a bola throw.
                            break;
                        }
                    case BlockMountType.DismountRecovery:
                        {
                            mob.SendLocalizedMessage(1070859); // You cannot mount while recovering from a dismount special maneuver.
                            break;
                        }
                }
            }

            return false;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write(this.m_NextMountAbility);

            writer.Write(this.m_Rider);
            writer.Write(this.m_InternalItem);
        }

        public override bool OnBeforeDeath()
        {
            this.Rider = null;

            return base.OnBeforeDeath();
        }

        public override void OnAfterDelete()
        {
            if (this.m_InternalItem != null)
                this.m_InternalItem.Delete();

            this.m_InternalItem = null;

            base.OnAfterDelete();
        }

        public override void OnDelete()
        {
            this.Rider = null;

            base.OnDelete();
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch ( version )
            {
                case 1:
                    {
                        this.m_NextMountAbility = reader.ReadDateTime();
                        goto case 0;
                    }
                case 0:
                    {
                        this.m_Rider = reader.ReadMobile();
                        this.m_InternalItem = reader.ReadItem();

                        if (this.m_InternalItem == null)
                            this.Delete();

                        break;
                    }
            }
        }

        public virtual void OnDisallowedRider(Mobile m)
        {
            m.SendMessage("You may not ride this creature.");
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (this.IsDeadPet)
                return;

            if (from is PlayerMobile)
            {
                if (from.IsBodyMod && !from.Body.IsHuman)
                {
                    if (Core.AOS) // You cannot ride a mount in your current form.
                        this.PrivateOverheadMessage(Network.MessageType.Regular, 0x3B2, false,
                            "You cannot ride the carousel if your current form.", from.NetState);
                    else
                        from.SendLocalizedMessage(1061628); // You can't do that while polymorphed.

                    return;
                }

                if (!CheckMountAllowed(from, true))
                    return;

                if (from.Mounted)
                {
                    from.SendLocalizedMessage(1005583); // Please dismount first.
                    return;
                }

                if (from.Race == Race.Gargoyle && from.IsPlayer())
                {
                    from.SendLocalizedMessage(1114057, "Gargoyles are unable to ride the carousel.");
                    this.OnDisallowedRider(from);
                    return;
                }

                if (from.Female ? !this.AllowFemaleRider : !this.AllowMaleRider)
                {
                    this.OnDisallowedRider(from);
                    return;
                }

                if (!Multis.DesignContext.Check(from))
                    return;

                if (from.HasTrade)
                {
                    from.SendLocalizedMessage(1042317, "", 0x41); // You may not ride at this time
                    return;
                }

                if (from.InRange(this, 1))
                {
                    from.Location = this.Location;
                    from.Paralyzed = true;
                    from.SendGump(new RideCarousel((PlayerMobile)from, this));
                    this.Rider = from;
                }
                else
                {
                    from.SendLocalizedMessage(500206); // That is too far away to ride.
                }
            }
        }
        private class RideCarousel : Gump
        {
            private PlayerMobile pm;
            private BaseCarouselMount bcm;

            public RideCarousel(PlayerMobile owner, BaseCarouselMount mount)
                : base(40, 45)
            {
                pm = owner;
                bcm = mount;
                Closable = false;
                Disposable = false;
                Dragable = true;
                Resizable = true;
                AddPage(0);
                AddBackground(0, 13, 300, 30, 0x2422);
                AddLabel(8, 10, 777, "Click to get off the carousel.");
                AddButton(8, 0x13, 0x15a5, 0x15a2, 1, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState state, RelayInfo info)
            {
                switch (info.ButtonID)
                {
                    case 0:
                        break;

                    case 1:
                        pm.CloseGump(typeof(RideCarousel));
                        if (pm.Paralyzed) pm.Paralyzed = false;
                        break;

                    default:
                        return;
                }
            }
        }

        public virtual void OnRiderDamaged(int amount, Mobile from, bool willKill)
        {
            if (this.m_Rider == null)
                return;

            Mobile attacker = from;
            if (attacker == null)
                attacker = this.m_Rider.FindMostRecentDamager(true);

            if (!(attacker == this || attacker == this.m_Rider || willKill || DateTime.UtcNow < this.m_NextMountAbility))
            {
                if (this.DoMountAbility(amount, from))
                    this.m_NextMountAbility = DateTime.UtcNow + this.MountAbilityDelay;
            }
        }

        public virtual bool DoMountAbility(int damage, Mobile attacker)
        {
            return false;
        }

        private class BlockEntry
        {
            public BlockMountType m_Type;
            public DateTime m_Expiration;
            public BlockEntry(BlockMountType type, DateTime expiration)
            {
                this.m_Type = type;
                this.m_Expiration = expiration;
            }

            public bool IsExpired
            {
                get
                {
                    return (DateTime.UtcNow >= this.m_Expiration);
                }
            }
        }
    }

    public class CarouselMountItem : Item, IMountItem
    {
        private BaseCarouselMount m_Mount;
        public CarouselMountItem(BaseCarouselMount mount, int itemID)
            : base(itemID)
        {
            this.Layer = Layer.Mount;
            this.Movable = false;

            this.m_Mount = mount;
        }

        public CarouselMountItem(Serial serial)
            : base(serial)
        {
        }

        public override double DefaultWeight
        {
            get
            {
                return 0;
            }
        }
        public IMount Mount
        {
            get
            {
                return this.m_Mount;
            }
        }
        public override void OnAfterDelete()
        {
            if (this.m_Mount != null)
                this.m_Mount.Delete();

            this.m_Mount = null;

            base.OnAfterDelete();
        }

        public override DeathMoveResult OnParentDeath(Mobile parent)
        {
            if (this.m_Mount != null)
                this.m_Mount.Rider = null;

            return DeathMoveResult.RemainEquiped;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(this.m_Mount);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch ( version )
            {
                case 0:
                    {
                        this.m_Mount = reader.ReadMobile() as BaseCarouselMount;

                        if (this.m_Mount == null)
                            this.Delete();

                        break;
                    }
            }
        }
    }
}