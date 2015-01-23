/* ShardEvent.cs
 * by Lokai
 * 
 * WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWKKWWKKWWWWWWWWWWWW
 * KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKWWWWWWKKKKKKWWWWWWWW
 * EEEEKKEEEEEEEEEEEEEEEEGGffttjjLLLLGGEEEEEEEEEEEEEEEEEEEEKKKKKK
 * ##################GGii::ii,,,,;;;;iiGGWW############WWKKDDKKKK
 * ################GGjjffjjjjjjjjttjj;;ttffKK##############KKEEKK
 * ##############WWEEEEGGffDDDDDDDDDDjjttjjff##############WWDDEE
 * ####################WWWWWWDDLLEEEEDDjjjjttLL############WWDDEE
 * ####################EEGGii;;iiGGEEEELLjjffttKK############DDEE
 * ##################EEffii..    ::GGKKEEGGjjttjj##########WWDDKK
 * ################WWGGii::        iiGGEEEEGGffjjWW########WWDDKK
 * ################EEjj,,..        iiLLGGKKKKGGGGWW########WWDDKK
 * ################EEjj,,..  ....  iiGGGGGGKKEEDD##########WWEEKK
 * ##############KKGGtttttttttttt,,jj####KKEEWWKK##########WWDDKK
 * ##########GGLLDDffttttjjLLGGtt::ttWW######WWWW##########WWDDKK
 * ########WWffttffffii..,,,,,,....,,GGEEEEWWWWWW##WW######WWDDKK
 * ##########GGffffGGtt..      ......jjLLLLLLKK############WWDDKK
 * ##########EEttjjGGtt,,..    ..;;;;GGttLL##WW############KKDDKK
 * ############ttttjjtt,,..  ..iiffGG##LLKK##WW############KKDDKK
 * ##############GGjjtt,,..        jjDDffWW##WWWWWW########KKDDKK
 * ##############GGiittii..  ..::..LLWWWW######WWWWWW######KKDDKK
 * ##############DDiitttt,,......,,GGWW##########KKWWWWKK##KKGGKK
 * ##############DDiiiiiiii....    jjGG############KKKKEE##KKGGKK
 * ##############GGiiiiiiiiii,,....GG######KK######WWWWWWWWEEGGKK
 * ############WWjjiiiiiittttttttttKK##################KKEEDDGGKK
 * ############GGffttiiiiiittjjffKKWWWW##################DDLLEEKK
 * EEEEEEKKDDLLLLDDjjttttttttjjGG##WWWWKKKKKKKKKKKKKKKKKKGGGGKKKK
 * DDGGLLii::::LLDDDDGGLLjjffjjDD##KKjjffGGGGLLLLLLLLLLGGGGKKKKKK
 * GGtt..  ....iiffGGDDGGLLjjttLLGGtt::..ttGGKKEEEEEEEEKKKKKKKKKK
 *       ......iiiiiiiittttiittttii::..      iiffGGEEKKEEEEKKEEEE
 *       ....::iiiiiiiiiiii,,,,::::..            ..ffGGEEEEEEEEEE
 * ..........,,iiiiiiiiiiii,,::::::..                jjDDDDDDDDDD
 * 
 * 4/19/2008
 * 
 * Description: Event system using AP_EventGate (formerly AdvancedPlayerGate.)
 *          System includes Invitations, 12 new commands, ability to adjust
 *          player stats, skills, etc., give items, and remove all Event items,
 *          skill and stat adjustments, hue, name and title changes, when
 *          the Event is finished.
 * 
 * Installation: Drop in Custom folder. No Distro changes needed.
 * 
 * Use: GMs+ can create an Event using the 'EventNew' command. Players can join
 *          an open Event or by Invitation. Events can be limited to certain numbers
 *          of players. The following is the complete command list:
 * 
 *  - EventNew:     creates a ShardEvent item in the GM's pack. Begins the Event planning stage.
 *  - EventJoin:    players use this to attempt to join an Event in progress.
 *  - EventInvite:  Host uses this to place invitations in a person's pack (or use 'all' argument for all users.)
 *  - EventI:       - same as EventInvite - 
 *  - EventMark:    Host uses this to move the join location to his current location and map. 
 *  - EventGate     Creates an AP_EventGate at host's current location, with Gate Target being the current Join location.
 *  - EventOpen:    Sets the Event to Open access. Anyone can join without an Invitation.
 *  - EventMax:     Sets the Max number of players permitted. If no parameter given, uses default number.
 *  - EventShut:    Closes access to the Event. Status is set to 'Shut'.
 *  - EventEnd:     Sets the Status of the Event to 'Finished'.
 *  - EventFinish:   - same as ClearGates - 
 *  - ClearGates:   Removes all Event items, including Temporary gates, Invitations, temp Items given, and restores users
 *                  to their state before they entered any Temporary AP_EventGate
 * 
 * AP_EventGate: The new AP_EventGate will do the following when used (when BOOL is true - misc.):
 * 
 *  - Teleports the user to the location and map set on the Moongate. (m_DoesTeleport)
 *  - Renames the user (m_DoesRename - m_NameGiven)
 *  - May only allow certain number of players (m_PlayerCountMax) to use the gate (m_PlayerCountLimited - m_PlayerCountExeededMessage)
 *  - Changes the player's Title (m_TitleAdds - m_TitleToAdd)
 *  - Resurrects the player (m_DoesResurrect)
 *  - Alters the player's skills (m_ChangesSkills) and stats (m_ChangesStats)
 *  - Changes the player's Hue (m_ChangesHue - uses the Hue of the Gate)
 *  - Gives Items based on Skill levels given (m_SkillsGiveItems - when skill value >= m_SkillsItemsMin)
 * 
 * TempGateItem: When a player uses an AP_EventGate, with the TempGate option set to 'true', the player will 
 *          receive a TempGateItem, which stores their current stats, skills, name, title, hue, and a list of
 *          the items given when using the gate. At the end of the Event, when the item is deleted, it will be
 *          Activated, restoring the player to their former state.
 * 
 */

using System;
using Server;
using Server.Mobiles;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Server.Network;
using Server.Commands;
using Server.Misc;
using Server.Gumps;
using Server.Prompts;
using Server.Targeting;

namespace Server.Custom
{
    public class ShardEventCommands
    {
        public static void Initialize()
        {
            CommandSystem.Register("EventJoin", AccessLevel.Player, new CommandEventHandler(EventJoin_OnCommand));
            CommandSystem.Register("EventNew", AccessLevel.GameMaster, new CommandEventHandler(EventNew_OnCommand));
            CommandSystem.Register("EventInvite", AccessLevel.GameMaster, new CommandEventHandler(EventInvite_OnCommand));
            CommandSystem.Register("EventI", AccessLevel.GameMaster, new CommandEventHandler(EventInvite_OnCommand));
            CommandSystem.Register("EventMark", AccessLevel.GameMaster, new CommandEventHandler(EventMark_OnCommand));
            CommandSystem.Register("EventGate", AccessLevel.Player, new CommandEventHandler(EventGate_OnCommand));
            CommandSystem.Register("EventOpen", AccessLevel.GameMaster, new CommandEventHandler(EventOpen_OnCommand));
            CommandSystem.Register("EventMax", AccessLevel.GameMaster, new CommandEventHandler(EventMax_OnCommand));
            CommandSystem.Register("EventShut", AccessLevel.GameMaster, new CommandEventHandler(EventShut_OnCommand));
            CommandSystem.Register("EventEnd", AccessLevel.GameMaster, new CommandEventHandler(EventEnd_OnCommand));
            CommandSystem.Register("EventFinish", AccessLevel.GameMaster, new CommandEventHandler(ClearGates_OnCommand));
            CommandSystem.Register("ClearGates", AccessLevel.GameMaster, new CommandEventHandler(ClearGates_OnCommand));
        }

        public static void EventNew_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            if (m == null) return;
            ShardEvent shard = GetShardEvent(m);
            if (shard == null)
            {
                m.SendMessage("...so we will create one.");
                string name = e.GetString(0);
                if (name == null || name.Length < 1)
                    shard = new ShardEvent(e.Mobile);
                else
                    shard = new ShardEvent(e.Mobile, name);
                Container pack = e.Mobile.Backpack;
                if (pack != null)
                    pack.DropItem(shard);
                else
                {
                    shard.Delete();
                    Console.WriteLine("Error creating new Event.");
                }
            }
            else
                m.SendMessage("Shard Event already exists. Please see the Shard Administrator.");
        }

        public static void EventInvite_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            if (m == null) return;
            string who = e.GetString(0);
            ShardEvent shard = FindEventOn(m);
            if (shard != null)
            {
                if (who == null || who.Length == 0)
                {
                    m.SendMessage("Target a player to invite, or say \"EventInvite All\" to invite everyone.");
                    m.Target = new InvitationTarget(shard);
                }
                else if (who.ToLower() == "all")
                {
                    foreach (Mobile mob in World.Mobiles.Values)
                    {
                        if (mob is PlayerMobile)
                        {
                            Container pack = mob.Backpack;
                            if (pack != null)
                            {
                                EventInvitation einv = new EventInvitation(shard.Name);
                                pack.DropItem(einv);
                            }
                        }
                    }
                }
            }
            else
                m.SendMessage("You must have a Shard Event to use this command.");
        }

        public static ShardEvent FindEventOn(Mobile m)
        {
            Container pack = m.Backpack;
            ShardEvent shard = null;
            if (pack != null)
            {
                foreach (Item i in pack.Items)
                    if (i is ShardEvent)
                        shard = i as ShardEvent;
            }
            return shard;
        }


        private class InvitationTarget : Target
        {
            private ShardEvent m_Shard;

            public InvitationTarget(ShardEvent shard)
                : base(10, false, TargetFlags.None)
            {
                m_Shard = shard;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is PlayerMobile)
                {
                    Container pack = ((PlayerMobile)targeted).Backpack;
                    if (pack != null)
                    {
                        pack.DropItem(new EventInvitation(m_Shard.Name));
                    }
                }
                else
                    from.SendMessage("Invitee must be a Player.");
            }
        }

        public static ShardEvent GetShardEvent(Mobile m)
        {
            foreach (Item i in World.Items.Values)
            {
                if (i is ShardEvent && ((ShardEvent)i).Status >= EventStatus.Planning)
                    return i as ShardEvent;
            }
            m.SendMessage("Unable to find Shard Event.");
            return null;
        }

        public static void EventJoin_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            if (m == null) return;
            ShardEvent shard = GetShardEvent(m);
            if (shard != null)
            {
                if (CanJoin(m, shard))
                    m.MoveToWorld(shard.Location, shard.Map);
            }
            else
                m.SendMessage("There is no Shard Event to join.");
        }

        public static void EventMark_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            if (m == null) return;
            ShardEvent shard = FindEventOn(m);
            if (shard != null)
            {
                shard.Location = m.Location;
                shard.Map = m.Map;
                m.SendMessage("Shard Event is now marked to your location.");
            }
            else
                m.SendMessage("You must have a Shard Event to use this command.");
        }

        public static void EventGate_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            if (m == null) return;
            ShardEvent shard = FindEventOn(m);
            if (shard != null)
            {
                AP_EventGate gate = new AP_EventGate();
                gate.Target = shard.Location;
                gate.TargetMap = shard.Map;
                gate.EventGate = true;
                gate.MoveToWorld(m.Location, m.Map);
                
                m.SendMessage("Gate has been generated at your location.");
            }
            else
                m.SendMessage("You must have a Shard Event to use this command.");
        }

        public static void EventOpen_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            if (m == null) return;
            ShardEvent shard = FindEventOn(m);
            if (shard != null)
            {
                shard.Status = EventStatus.Open;
                World.Broadcast(0, false, "Shard Event is now Open.");
            }
            else
                m.SendMessage("You must have a Shard Event to use this command.");
        }

        public static void EventMax_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            if (m == null) return;
            int num = e.GetInt32(0);
            if (num != null && num > 0)
            {
                ShardEvent shard = FindEventOn(m);
                if (shard != null)
                {
                    shard.MaxPlayers = num;
                    shard.Status = EventStatus.Limited;
                    m.SendMessage("Shard Event is now limited to {0} players.", num.ToString());
                }
                else
                    m.SendMessage("You must have a Shard Event to use this command.");
            }
        }

        public static void EventShut_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            if (m == null) return;
            ShardEvent shard = FindEventOn(m);
            if (shard != null)
            {
                shard.Status = EventStatus.Shut;
                World.Broadcast(0, false, "Shard Event is now closed for joining.");
            }
            else
                m.SendMessage("You must have a Shard Event to use this command.");
        }

        public static void EventEnd_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            if (m == null) return;
            ShardEvent shard = FindEventOn(m);
            if (shard != null)
            {
                shard.Status = EventStatus.Finished;
                World.Broadcast(0, false, "Shard Event is now over.");
            }
            else
                m.SendMessage("You must have a Shard Event to use this command.");
        }

        public static bool CanJoin(Mobile m, ShardEvent shard)
        {
            if (shard.Status == EventStatus.Open) return true;
            else if (shard.Status == EventStatus.Invite)
            {
                Container pack = m.Backpack;
                if (pack != null)
                {
                    foreach (Item i in pack.Items)
                        if (i is EventInvitation && ((EventInvitation)i).EventName == shard.Name)
                        {
                            ((EventInvitation)i).EventName = shard.Name + ": Attending";
                            return true;
                        }
                    m.SendMessage("You must have an invitation to join this Event.");
                }
            }
            else if (shard.Status == EventStatus.Limited)
            {
                if (shard.Players < shard.MaxPlayers)
                    return true;
                else
                    m.SendMessage("Event has reached the maximum number of attendees.");
            }
            else if (shard.Status == EventStatus.Shut)
                m.SendMessage("Event is closed.");
            else if (shard.Status == EventStatus.Finished)
                m.SendMessage("The Event is over.");
            else if (shard.Status >= EventStatus.Planning && m.AccessLevel >= AccessLevel.GameMaster)
                return true;
            return false;
        }

        [Usage("ClearGates")]
        [Aliases("EventFinish")]
        [Description("Clears TempGates, finishes an Event, and restores users.")]
        public static void ClearGates_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
            if (m == null) return;
            List<Item> tempGates = new List<Item>();
            List<Item> tempInvitations = new List<Item>();

            foreach (Item i in World.Items.Values)
            {
                if (i is AP_EventGate && ((AP_EventGate)i).EventGate) tempGates.Add(i);
                if (i is EventInvitation) tempInvitations.Add(i);
            }
            int count = tempGates.Count;
            if (count > 0)
            {
                for (int x = 0; x < count; x++)
                {
                    try { tempGates[x].Delete(); }
                    catch { }
                }
                m.SendMessage("{0} temporary gates were found and deleted.", count);
            }
            count = tempInvitations.Count;
            if (count > 0)
            {
                for (int x = 0; x < count; x++)
                {
                    try { tempInvitations[x].Delete(); }
                    catch { }
                }
                m.SendMessage("{0} invitations were found and deleted.", count);
            }
            tempGates.Clear();
            tempInvitations.Clear();

            ShardEvent shard = FindEventOn(m);
            if (shard != null)
            {
                shard.Delete();
                m.SendMessage("Shard Event has been deleted.");
            }
        }
    }

    public enum EventStatus
    {
        None = 0,
        Planning,
        Invite,
        Open,
        Limited,
        Shut,
        Finished
    }

    public class ShardEvent : Item
    {
        private Point3D m_Location;
        private Map m_Map;
        private int m_Players;
        private int m_MaxPlayers;
        private Mobile m_Host;
        private EventStatus m_Status;

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D Location { get { return m_Location; } set { m_Location = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public Map Map { get { return m_Map; } set { m_Map = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Players { get { return m_Players; } set { m_Players = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxPlayers { get { return m_MaxPlayers; } set { m_MaxPlayers = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Host { get { return m_Host; } set { m_Host = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public EventStatus Status { get { return m_Status; } set { m_Status = value; } }

        public ShardEvent(Mobile m)
            : this(m, 100, "Shard Event Control Item")
        {
        }

        public ShardEvent(Mobile m, string name)
            : this(m, 100, name)
        {
        }

        public ShardEvent(Mobile m, int max, string name)
            : base(0x1F1B)
        {
            Name = name;
            m_Host = m;
            m_Location = m.Location;
            m_Map = m.Map;
            m_Status = EventStatus.Planning;
            m_MaxPlayers = max;
        }

        public ShardEvent(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((Point3D)m_Location);
            writer.Write((Map)m_Map);
            writer.Write((int)m_Players);
            writer.Write((int)m_MaxPlayers);
            writer.Write((Mobile)m_Host);
            writer.Write((int)m_Status);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Location = reader.ReadPoint3D();
            m_Map = reader.ReadMap();
            m_Players = reader.ReadInt();
            m_MaxPlayers = reader.ReadInt();
            m_Host = reader.ReadMobile();
            m_Status = (EventStatus)reader.ReadInt();
        }
    }

    public class EventInvitation : Item
    {
        private string m_EventName;

        [CommandProperty(AccessLevel.GameMaster)]
        public string EventName { get { return m_EventName; } set { m_EventName = value; InvalidateProperties(); } }

        [Constructable]
        public EventInvitation()
            : this("")
        {
        }

        [Constructable]
        public EventInvitation(string name)
            : base(0x1F23)
        {
            m_EventName = name;
            Name = string.Format("Event Invitation: {0}", name);
        }

        public EventInvitation(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendMessage("Type the command \"EventJoin\" to join the Event.");
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
