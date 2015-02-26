using System;
using Server;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{
    public enum CarouselLoop
    {
        None, Inner, Outer
    }

    public class CarouselInfo
    {
        private readonly int m_carouselID;

        public int CarouselID { get { return m_carouselID; } }

        public int X { get; set; }

        public int Y { get; set; }

        public Direction Facing { get; set; }

        public CarouselInfo(int carouselID, int x, int y, Direction facing)
        {
            m_carouselID = carouselID;
            X = x;
            Y = y;
            Facing = facing;
        }

        private static CarouselInfo[] m_OuterLoop = new CarouselInfo[24]
		{
            new CarouselInfo(0, 9, 3, Direction.North),
            new CarouselInfo(1, 9, 1, Direction.North),
            new CarouselInfo(2, 9, -1, Direction.North),
            new CarouselInfo(3, 9, -3, Direction.Up),
            new CarouselInfo(4, 7, -5, Direction.Up),
            new CarouselInfo(5, 5, -7, Direction.Up),
            new CarouselInfo(6, 3, -9, Direction.West),
            new CarouselInfo(7, 1, -9, Direction.West),
            new CarouselInfo(8, -1, -9, Direction.West),
            new CarouselInfo(9, -3, -9, Direction.Left),
            new CarouselInfo(10, -5, -7, Direction.Left),
            new CarouselInfo(11, -7, -5, Direction.Left),
            new CarouselInfo(12, -9, -3, Direction.South),
            new CarouselInfo(13, -9, -1, Direction.South),
            new CarouselInfo(14, -9, 1, Direction.South),
            new CarouselInfo(15, -9, 3, Direction.Down),
            new CarouselInfo(16, -7, 5, Direction.Down),
            new CarouselInfo(17, -5, 7, Direction.Down),
            new CarouselInfo(18, -3, 9, Direction.East),
            new CarouselInfo(19, -1, 9, Direction.East),
            new CarouselInfo(20, 1, 9, Direction.East),
            new CarouselInfo(21, 3, 9, Direction.Right),
            new CarouselInfo(22, 5, 7, Direction.Right),
            new CarouselInfo(23, 7, 5, Direction.Right),
        };

        private static CarouselInfo[] m_InnerLoop = new CarouselInfo[20]
		{
            new CarouselInfo(0, -7, 3, Direction.North),
            new CarouselInfo(1, -7, 1, Direction.North),
            new CarouselInfo(2, -7, -1, Direction.North),
            new CarouselInfo(3, -7, -3, Direction.Right),
            new CarouselInfo(4, -5, -5, Direction.Right),
            new CarouselInfo(5, -3, -7, Direction.East),
            new CarouselInfo(6, -1, -7, Direction.East),
            new CarouselInfo(7, 1, -7, Direction.East),
            new CarouselInfo(8, 3, -7, Direction.Down),
            new CarouselInfo(9, 5, -5, Direction.Down),
            new CarouselInfo(10, 7, -3, Direction.South),
            new CarouselInfo(11, 7, -1, Direction.South),
            new CarouselInfo(12, 7, 1, Direction.South),
            new CarouselInfo(13, 7, 3, Direction.Left),
            new CarouselInfo(14, 5, 5, Direction.Left),
            new CarouselInfo(15, 3, 7, Direction.West),
            new CarouselInfo(16, 1, 7, Direction.West),
            new CarouselInfo(17, -1, 7, Direction.West),
            new CarouselInfo(18, -3, 7, Direction.Up),
            new CarouselInfo(19, -5, 5, Direction.Up),
		};

        public static CarouselInfo[] OuterLoop { get { return m_OuterLoop; } set { m_OuterLoop = value; } }
        public static CarouselInfo[] InnerLoop { get { return m_InnerLoop; } set { m_InnerLoop = value; } }
    }

    public class Carousel : Item
    {
        private Timer m_RecordLocation;
        private Timer m_CarouselMovement;

        int mXr = 0;
        int mYr = 0;
        int mZr = 0;

        bool mPower = false;

        [CommandProperty(AccessLevel.GameMaster)]
        public int Xr { get { return mXr; } set { mXr = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Yr { get { return mYr; } set { mYr = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Zr { get { return mZr; } set { mZr = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Power { get { return mPower; } set { mPower = value; } }

        [Constructable]
        public Carousel()
            : base()
        {
            Movable = false;
            Name = "Carousel";
            ItemID = 0x3E57;
            Hue = 0;

            this.m_RecordLocation = new RecordLocation(this);
            this.m_RecordLocation.Start();
        }

        private static Type GetRandomCarouselMount()
        {
            int rand = Utility.Random(50);

            if (rand < 34) return typeof(CarouselHorse);
            if (rand < 40) return typeof(CarouselDesertOstard);
            if (rand < 44) return typeof(CarouselNightmare);
            if (rand < 48) return typeof(CarouselSeaHorse);
            else return typeof(CarouselUnicorn);

        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from == null || from.AccessLevel < AccessLevel.GameMaster) { return; }

            if (!from.InRange(this.GetWorldLocation(), 12))
                from.SendMessage("I can't reach that!");

            else if (this.Power == false)
            {
                from.SendMessage("You turn the Carousel on.");
                this.Power = true;
                this.m_CarouselMovement = new CarouselMovement(this);
                this.m_CarouselMovement.Start();
            }

            else if (this.Power == true)
            {
                from.SendMessage("You turn the Carousel off.");
                this.Power = false;
                this.m_CarouselMovement.Stop();
            }

            base.OnDoubleClick(from);
        }


        public Carousel(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version

            writer.Write((int)mXr);
            writer.Write((int)mYr);
            writer.Write((int)mZr);
            writer.Write((bool)mPower);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            mXr = reader.ReadInt();
            mYr = reader.ReadInt();
            mZr = reader.ReadInt();
            mPower = reader.ReadBool();
        }

        private class RecordLocation : Timer
        {
            private Carousel m_Carousel;

            public RecordLocation(Carousel carousel)
                : base(TimeSpan.FromSeconds(1.5))
            {
                m_Carousel = carousel;
            }

            public void RecordCarouselLocation()
            {
                Point3D loc = m_Carousel.GetWorldLocation();
                m_Carousel.Xr = loc.X;
                m_Carousel.Yr = loc.Y;
                m_Carousel.Zr = loc.Z;
            }

            public void GenerateMounts()
            {

                for (int i = 0; i < 24; i++)
                {
                    Object o = Activator.CreateInstance(GetRandomCarouselMount());
                    BaseCarouselMount mob = (BaseCarouselMount)o;
                    mob.Loop = CarouselLoop.Outer;
                    mob.LoopID = i;
                    Point3D loc = new Point3D(m_Carousel.Xr + CarouselInfo.OuterLoop[i].X, m_Carousel.Yr + CarouselInfo.OuterLoop[i].Y, m_Carousel.Zr);
                    Map map = (m_Carousel.Map == null ? Map.Trammel : m_Carousel.Map == Map.Internal ? Map.Trammel : m_Carousel.Map);
                    mob.MoveToWorld(loc, map);
                    mob.Direction = CarouselInfo.OuterLoop[i].Facing;
                }

                for (int i = 0; i < 20; i++)
                {
                    Object o = Activator.CreateInstance(GetRandomCarouselMount());
                    BaseCarouselMount mob = (BaseCarouselMount)o;
                    mob.Loop = CarouselLoop.Inner;
                    mob.LoopID = i;
                    Point3D loc = new Point3D(m_Carousel.Xr + CarouselInfo.InnerLoop[i].X, m_Carousel.Yr + CarouselInfo.InnerLoop[i].Y, m_Carousel.Zr);
                    Map map = (m_Carousel.Map == null ? Map.Trammel : m_Carousel.Map == Map.Internal ? Map.Trammel : m_Carousel.Map);
                    mob.MoveToWorld(loc, map);
                    mob.Direction = CarouselInfo.InnerLoop[i].Facing;
                }
            }

            protected override void OnTick()
            {
                RecordCarouselLocation();
                GenerateMounts();
                Stop();
            }
        }

        public override void OnDelete()
        {
            List<Mobile> mobilelist = new List<Mobile>();

            foreach (Mobile mobile in this.GetMobilesInRange(10))
            {
                if (mobile is BaseCarouselMount)
                    mobilelist.Add(mobile);
                if (mobile is PlayerMobile && mobile.Mounted && mobile.Mount is BaseCarouselMount)
                    mobilelist.Add(mobile);
            }
            base.OnDelete();
        }

        private class CarouselMovement : Timer
        {
            private Carousel m_Carousel;

            public CarouselMovement(Carousel carousel)
                : base(TimeSpan.FromSeconds(1.0))
            {
                Priority = TimerPriority.FiftyMS; 
                m_Carousel = carousel;
            }

            protected override void OnTick()
            {

                List<Mobile> mobilelist = new List<Mobile>();

                foreach (Mobile mobile in m_Carousel.GetMobilesInRange(9))
                {
                    if (mobile is BaseCarouselMount)
                        mobilelist.Add(mobile);
                    if (mobile is PlayerMobile && mobile.Mounted && mobile.Mount is BaseCarouselMount)
                        mobilelist.Add(mobile);
                }

                foreach (Mobile mobile in mobilelist)
                {
                    Point3D loc;
                    Direction facing;
                    if (mobile is BaseCarouselMount)
                    {
                        BaseCarouselMount mount = mobile as BaseCarouselMount;
                        if (mount.Loop == CarouselLoop.Inner)
                        {
                            if (mount.LoopID == 19) mount.LoopID = 0;
                            else mount.LoopID++;
                            loc = new Point3D(m_Carousel.Xr + CarouselInfo.InnerLoop[mount.LoopID].X, m_Carousel.Yr + CarouselInfo.InnerLoop[mount.LoopID].Y, m_Carousel.Zr);
                            facing = CarouselInfo.InnerLoop[mount.LoopID].Facing;
                        }
                        else
                        {
                            if (mount.LoopID == 23) mount.LoopID = 0;
                            else mount.LoopID++;
                            loc = new Point3D(m_Carousel.Xr + CarouselInfo.OuterLoop[mount.LoopID].X, m_Carousel.Yr + CarouselInfo.OuterLoop[mount.LoopID].Y, m_Carousel.Zr);
                            facing = CarouselInfo.OuterLoop[mount.LoopID].Facing;
                        }
                        mount.X = loc.X;
                        mount.Y = loc.Y;
                        mount.Direction = facing;
                    }
                    else if (mobile is PlayerMobile && mobile.Mounted && mobile.Mount is BaseCarouselMount)
                    {
                        BaseCarouselMount mount = mobile.Mount as BaseCarouselMount;
                        if (mount.Loop == CarouselLoop.Inner)
                        {
                            if (mount.LoopID == 19) mount.LoopID = 0;
                            else mount.LoopID++;
                            loc = new Point3D(m_Carousel.Xr + CarouselInfo.InnerLoop[mount.LoopID].X, m_Carousel.Yr + CarouselInfo.InnerLoop[mount.LoopID].Y, m_Carousel.Zr);
                            facing = CarouselInfo.InnerLoop[mount.LoopID].Facing;
                        }
                        else
                        {
                            if (mount.LoopID == 23) mount.LoopID = 0;
                            else mount.LoopID++;
                            loc = new Point3D(m_Carousel.Xr + CarouselInfo.OuterLoop[mount.LoopID].X, m_Carousel.Yr + CarouselInfo.OuterLoop[mount.LoopID].Y, m_Carousel.Zr);
                            facing = CarouselInfo.OuterLoop[mount.LoopID].Facing;
                        }
                        mobile.X = loc.X;
                        mobile.Y = loc.Y;
                        mobile.Direction = facing;
                    }

                }

                if (m_Carousel.Power == false) { Stop(); }
                else { Start(); }

            }
        }
    }
}