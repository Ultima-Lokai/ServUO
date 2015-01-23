/* Self-Replicating Puzzle Box by Lokai */

using System;
using System.Collections.Generic;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;
using Server.Targeting;
using Server.Engines.Craft;

namespace Server.Items
{
    public class SelfReplicatingPuzzleBox : Item
    {
        private bool m_Active;
        private Timer m_Timer;
        private Mobile m_Mobile;

        public bool Active { get { return m_Active; } set { m_Active = value; } }

        public SelfReplicatingPuzzleBox()
            : this(true)
        {
        }

        public SelfReplicatingPuzzleBox(Serial s)
            : base(s)
        {
        }

        public SelfReplicatingPuzzleBox(bool active)
            : base(0x2835)
        {
            m_Active = active;
            Movable = false;
            Weight = 1.0;
            Name = "Self-Replicating Puzzle Box";
            if (m_Active)
                new FirstTimer(this).Start();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

        private class FirstTimer : Timer
        {
            private PlayerMobile m_Pm;
            private SelfReplicatingPuzzleBox m_Box;
            private Container m_Pack;

            public FirstTimer(SelfReplicatingPuzzleBox box) : this(null, box, null) { }

            public FirstTimer(PlayerMobile pm, SelfReplicatingPuzzleBox box, Container pack)
                : base(TimeSpan.FromSeconds(2.0), TimeSpan.FromSeconds(2.0), 10)
            {
                m_Box = box;
                m_Pm = pm;
                m_Pack = pack;
            }

            protected override void OnTick()
            {
                if (m_Box.Parent is Container)
                {
                    m_Pack = m_Box.Parent as Container;
                    if (m_Pack.Parent is PlayerMobile)
                    {
                        m_Pm = m_Pack.Parent as PlayerMobile;
                        this.Stop();
                        if (m_Pm == null || m_Pack == null || m_Box == null)
                        {
                            Console.WriteLine("Null value in FirstTimer detected.");
                            try { m_Box.Delete(); }
                            catch { Console.WriteLine("There may have been a problem deleting a Self-Replicating Box."); }
                        }
                        else
                            new InternalTimer(m_Pm, m_Box, m_Pack, true).Start();
                    }
                    else
                    {
                        if (Core.Debug) Console.WriteLine("My parent's parent was NOT a PlayerMobile.");
                    }
                }
                else
                {
                    if (Core.Debug) Console.WriteLine("My ParentEntity was NOT a container.");
                }
            }
        }

        private class InternalTimer : Timer
        {
            private PlayerMobile m_Pm;
            private SelfReplicatingPuzzleBox m_Box;
            private Container m_Pack;
            private bool m_FirstPass;
            private int tick;

            public InternalTimer(SelfReplicatingPuzzleBox box) : this(null, box, null, false) { }

            public InternalTimer(PlayerMobile pm, SelfReplicatingPuzzleBox box, Container pack, bool first)
                : base(TimeSpan.FromSeconds(2.0), TimeSpan.FromSeconds(2.0), 600)
            {
                m_Box = box;
                m_Pm = pm;
                m_Pack = pack;
                m_FirstPass = first;
                tick = 0;
            }

            protected override void OnTick()
            {
                tick++;
                if (m_FirstPass)
                {
                    m_Pm.SendGump(new InternalGump(m_Pm, m_Box, m_Pack, this));
                }
                m_FirstPass = false;
                try
                {
                    if (m_Box.Active) m_Pack.DropItem(new SelfReplicatingPuzzleBox(false));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (tick >= 599)
                {
                    Stop();
                    CleanPack(m_Pm, m_Box, m_Pack, "The box self-destructed!");
                }
            }
        }

        private static void CleanPack(PlayerMobile pm, SelfReplicatingPuzzleBox box, Container pack, string message)
        {
            box.Active = false;
            List<SelfReplicatingPuzzleBox> boxes = new List<SelfReplicatingPuzzleBox>();
            foreach (Item i in pack.Items)
            {
                if (i is SelfReplicatingPuzzleBox) boxes.Add(i as SelfReplicatingPuzzleBox);
            }
            if (boxes != null)
            {
                int count = boxes.Count;
                try
                {
                    for (int x = 0; x < count; x++)
                    {
                        boxes[x].Delete();
                    }
                    boxes.Clear();
                }
                catch { Console.WriteLine("Caught exception trying to delete boxes."); }
                if (message == "")
                {
                    int amount = Utility.RandomMinMax(300, 700) - count;
                    if (amount < 10) amount = 10;
                    pack.DropItem(new Gold(amount));
                    pm.SendMessage("You find {0} gold after solving the puzzle box!", amount);
                }
                else
                    pm.SendMessage(message);
            }
            else
                Console.WriteLine("No boxes found???");
        }

        private class InternalGump : Gump
        {
            private PlayerMobile m_Pm;
            private SelfReplicatingPuzzleBox m_Box;
            private Container m_Pack;
            private int m_Choice;
            private InternalTimer m_Timer;

            public InternalGump(PlayerMobile pm, SelfReplicatingPuzzleBox box, Container pack, InternalTimer timer)
                : base(150, 150)
            {
                this.Closable = false;
                this.Disposable = false;
                this.Dragable = false;
                this.Resizable = false;

                m_Pm = pm;
                m_Box = box;
                m_Pack = pack;
                m_Timer = timer;
                m_Choice = Utility.RandomMinMax(1, 3);

                string choice = m_Choice == 1 ? "fish" : m_Choice == 2 ? "gold" : "old prospector";

                AddPage(0);
                AddBackground(150, 150, 300, 200, 9300);
                AddLabel(220, 165, 0, string.Format("Select the {0}.", choice));
                AddLabel(180, 190, 0, "The box will continue replicating");
                AddLabel(180, 215, 0, "until you get it right.");
                AddButton(165, 250, 0x15BD, 0x15BE, 1, GumpButtonType.Reply, 0);
                AddButton(235, 250, 0x15C3, 0x15C4, 2, GumpButtonType.Reply, 0);
                AddButton(305, 250, 0x15C5, 0x15C6, 3, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                m_Pm.CloseGump(typeof(InternalGump));

                if (info.ButtonID == m_Choice)
                {
                    m_Timer.Stop();
                    CleanPack(m_Pm, m_Box, m_Pack, "");
                }
                else
                    m_Pm.SendGump(new InternalGump(m_Pm, m_Box, m_Pack, m_Timer));
            }
        }
    }
}
