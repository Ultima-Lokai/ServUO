/* Original script created by Hammerhand & Milva */
/* Extensive modifications by Lokai */

using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;

namespace Server.Mobiles
{
    public class GoldNuggetTrader : BaseVendor
    {
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        private static bool m_Talked; // flag to prevent spam 

        string[] kfcsay = new string[] // things to say while greeting 
        { 
         "I trades them gold nuggets!!", 
         "Gets a medium nugget for every 5  of them small ones.",
         "Gets a large nugget for every 3 of them medium ones.",
         "Gets a gold brick for every 2 of them large nuggets.",
         "Gets a 24,000 coins check for every 2 of them gold bricks.",
         "I buys nuggets and bricks.",
         "I sells pans."
        };

        public override void InitSBInfo() { m_SBInfos.Add(new SBPanner()); }

        [Constructable]
        public GoldNuggetTrader()
            : base("an old gold panner")
        {
            Name = "Johnson";
            InitBody();
            InitOutfit();

            SetSkill(SkillName.Fishing, 80.0, 90.0);
        }

        public override void InitBody()
        {
            Body = 400;
            Female = false;
            SpeechHue = 33;
            Hue = Utility.RandomSkinHue();
        }

        public override void InitOutfit()
        {
            AddItem(new Server.Items.LongPants(Utility.RandomNeutralHue()));
            AddItem(new Server.Items.Boots(Utility.RandomNeutralHue()));
            AddItem(new Server.Items.FancyShirt(Utility.RandomNeutralHue()));
            AddItem(new Server.Items.FloppyHat(Utility.RandomNeutralHue()));

            int hairHue = GetHairHue();
            Utility.AssignRandomHair(this, hairHue);
            Utility.AssignRandomFacialHair(this, hairHue);
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (m_Talked == false)
            {
                if (m is PlayerMobile && m.InRange(this, 4))
                {
                    m_Talked = true;
                    SayRandom(kfcsay, this);
                    this.Move(GetDirectionTo(m.Location));
                    // Start timer to prevent spam 
                    SpamTimer t = new SpamTimer();
                    t.Start();
                }
            }
        }

        private class SpamTimer : Timer
        {
            public SpamTimer()
                : base(TimeSpan.FromSeconds(4))
            {
                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                m_Talked = false;
            }
        }

        private static void SayRandom(string[] say, Mobile m)
        {
            m.Say(say[Utility.Random(say.Length)]);
        }

        public GoldNuggetTrader(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if (dropped is Gold)
                return base.OnDragDrop(from, dropped);

            if (from != null)
            {
                int amount = 0;
                if (dropped is SmallGoldNugget)
                {
                    if (dropped.Amount % 5 != 0)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I needs those in groups of 5.", from.NetState);
                        return false;
                    }
                    amount = dropped.Amount / 5;
                    dropped.Delete();
                    from.AddToBackpack(new MediumGoldNugget(amount));
                    this.PrivateOverheadMessage(MessageType.Regular, 1153, false, string.Format("Here's {0} of them Medium Gold Nuggets.", amount), from.NetState);
                    return true;
                }
                else if (dropped is MediumGoldNugget)
                {
                    if (dropped.Amount % 3 != 0)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I needs those in groups of 3.", from.NetState);
                        return false;
                    }
                    amount = dropped.Amount / 3;
                    dropped.Delete();
                    from.AddToBackpack(new LargeGoldNugget(amount));
                    this.PrivateOverheadMessage(MessageType.Regular, 1153, false, string.Format("Here's {0} of them Large Gold Nuggets.", amount), from.NetState);
                    return true;
                }
                else if (dropped is LargeGoldNugget)
                {
                    if (dropped.Amount % 2 != 0)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I needs those in groups of 2.", from.NetState);
                        return false;
                    }
                    amount = dropped.Amount / 2;
                    dropped.Delete();
                    from.AddToBackpack(new GoldBrick(amount));
                    this.PrivateOverheadMessage(MessageType.Regular, 1153, false, string.Format("Here's {0} of them Gold Bricks.", amount), from.NetState);
                    return true;
                }
                else if (dropped is GoldBrick)
                {
                    if (dropped.Amount % 2 != 0)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I needs those in groups of 2.", from.NetState);
                        return false;
                    }
                    dropped.Delete();
                    amount = (dropped.Amount / 2) * 24000;
                    from.AddToBackpack(new BankCheck(amount));
                    this.PrivateOverheadMessage(MessageType.Regular, 1153, false, string.Format("Here's a Check worth {0} of them coins.", amount), from.NetState);
                    return true;
                }

                else
                {
                    from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I only deals in them Gold items.", from.NetState);
                    return false;
                }
            }
            else
            {
                this.Say("What was that?");
                return false;
            }
        }
    }
}
