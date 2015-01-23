using System;
using System.Collections;
using System.Collections.Generic;
using Server;

namespace Server.TAR
{
    public class RaceTeam
    {
        private int m_TeamID;
        private int m_RaceID;
        private string m_Relationship;
        private string m_Nickname;
        private Mobile m_MemberOne;
        private Mobile m_MemberTwo;
        private RaceStatus m_Status;
        private PenaltyType m_Penalty;
        private RouteInfoType m_CurrentInfo;

        private bool m_HasPenalty;
        private bool m_IsMarked;
        private bool m_HasInfo;
        private bool m_HasFastForward;

        private TimeSpan m_PenaltyTime;
        private TimeSpan m_LegDelay;
        private DateTime m_NextLegTime;

        public int TeamID { get { return m_TeamID; } set { m_TeamID = value; } }
        public int RaceID { get { return m_RaceID; } set { m_RaceID = value; } }
        public string Relationship { get { return m_Relationship; } set { m_Relationship = value; } }
        public string Nickname { get { return m_Nickname; } set { m_Nickname = value; } }
        public Mobile MemberOne { get { return m_MemberOne; } set { m_MemberOne = value; } }
        public Mobile MemberTwo { get { return m_MemberTwo; } set { m_MemberTwo = value; } }
        public RaceStatus Status { get { return m_Status; } set { m_Status = value; } }
        public PenaltyType Penalty { get { return m_Penalty; } set { m_Penalty = value; } }
        public RouteInfoType CurrentInfo { get { return m_CurrentInfo; } set { m_CurrentInfo = value; } }

        public bool HasPenalty { get { return m_HasPenalty; } set { m_HasPenalty = value; } }
        public bool IsMarked { get { return m_IsMarked; } set { m_IsMarked = value; } }
        public bool HasInfo { get { return m_HasInfo; } set { m_HasInfo = value; } }
        public bool HasFastForward { get { return m_HasFastForward; } set { m_HasFastForward = value; } }

        public TimeSpan PenaltyTime { get { return m_PenaltyTime; } set { m_PenaltyTime = value; } }
        public TimeSpan LegDelay { get { return m_LegDelay; } set { m_LegDelay = value; } }
        public DateTime NextLegTime { get { return m_NextLegTime; } set { m_NextLegTime = value; } }

        public RaceTeam(int teamID, int raceID, List<Mobile> members)
            : this(teamID, raceID, "", "", members[0], members[1])
        {
        }

        public RaceTeam(int teamID, int raceID, string relationship, string nickname, Mobile memberOne, Mobile memberTwo)
            : this(teamID, raceID, relationship, nickname, memberOne, memberTwo, RaceStatus.None, PenaltyType.None, 
            RouteInfoType.Rest, false, false, false, false, TimeSpan.FromSeconds(0.0), TimeSpan.FromSeconds(0.0), DateTime.Now)
        {
        }

        public RaceTeam(int teamID, int raceID, string relationship, string nickname, Mobile memberOne, Mobile memberTwo, 
            RaceStatus status, PenaltyType penalty, RouteInfoType currentInfo, bool hasPenalty, bool isMarked, bool hasInfo, 
            bool hasFastForward, TimeSpan penaltyTime, TimeSpan legDelay, DateTime nextLegTime)
        {
            m_TeamID = teamID;
            m_RaceID = raceID;
            m_Relationship = relationship;
            m_Nickname = nickname;
            m_MemberOne = memberOne;
            m_MemberTwo = memberTwo;
            m_Status = status;
            m_Penalty = penalty;
            m_CurrentInfo = currentInfo;
            m_HasPenalty = hasPenalty;
            m_IsMarked = isMarked;
            m_HasInfo = hasInfo;
            m_HasFastForward = hasFastForward;
            m_PenaltyTime = penaltyTime;
            m_LegDelay = legDelay;
            m_NextLegTime = nextLegTime;
        }

        public RaceTeam(int teamID, int raceID, GenericReader reader)
        {
            m_TeamID = teamID;
            m_RaceID = raceID;

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_Relationship = reader.ReadString();
                        m_Nickname = reader.ReadString();
                        m_MemberOne = reader.ReadMobile();
                        m_MemberTwo = reader.ReadMobile();
                        m_Status = (RaceStatus)reader.ReadInt();
                        m_Penalty = (PenaltyType)reader.ReadInt();
                        m_CurrentInfo = (RouteInfoType)reader.ReadInt();
                        m_HasPenalty = reader.ReadBool();
                        m_IsMarked = reader.ReadBool();
                        m_HasInfo = reader.ReadBool();
                        m_HasFastForward = reader.ReadBool();
                        m_PenaltyTime = reader.ReadTimeSpan();
                        m_LegDelay = reader.ReadTimeSpan();
                        m_NextLegTime = reader.ReadDateTime();
                        break;
                    }
            }
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); //version

            writer.Write((string)m_Relationship);
            writer.Write((string)m_Nickname);
            writer.Write((Mobile)m_MemberOne);
            writer.Write((Mobile)m_MemberTwo);
            writer.Write((int)m_Status);
            writer.Write((int)m_Penalty);
            writer.Write((int)m_CurrentInfo);
            writer.Write((bool)m_HasPenalty);
            writer.Write((bool)m_IsMarked);
            writer.Write((bool)m_HasInfo);
            writer.Write((bool)m_HasFastForward);
            writer.Write((TimeSpan)m_PenaltyTime);
            writer.Write((TimeSpan)m_LegDelay);
            writer.Write((DateTime)m_NextLegTime);
        }

        public bool IsMember(Mobile member)
        {
            if (m_MemberOne == member || m_MemberTwo == member)
                return true;
            return false;
        }
    }

    public class RouteInfo
    {
        private RouteInfoType m_RIType;
        private TravelType m_Travel;
        //private Type m_ItemType;
        private string m_Description;
        private Point3D m_Destination;
        private Map m_Map;

        public RouteInfoType RIType { get { return m_RIType; } set { m_RIType = value; } }
        public TravelType Travel { get { return m_Travel; } set { m_Travel = value; } }
        //public Type ItemType { get { return m_ItemType; } set { m_ItemType = value; } }
        public string Description { get { return m_Description; } set { m_Description = value; } }
        public Point3D Destination { get { return m_Destination; } set { m_Destination = value; } }
        public Map Map { get { return m_Map; } set { m_Map = value; } }

        public RouteInfo(RouteInfoType rIType, TravelType travel, /*Type itemType,*/ string description, Point3D destination, Map map)
        {
            m_RIType = rIType;
            m_Travel = travel;
            //m_ItemType = itemType;
            m_Description = description;
            m_Destination = destination;
            m_Map = map;
        }

        public RouteInfo(GenericReader reader)
        {
            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_RIType = (RouteInfoType)reader.ReadInt();
                        m_Travel = (TravelType)reader.ReadInt();
                        //m_ItemType = Type.GetType(reader.ReadString());
                        m_Description = reader.ReadString();
                        m_Destination = reader.ReadPoint3D();
                        m_Map = reader.ReadMap();
                        break;
                    }
            }
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); //version

            writer.Write((int)m_RIType);
            writer.Write((int)m_Travel);
            //writer.Write((string)m_ItemType.ToString());
            writer.Write((string)m_Description);
            writer.Write((Point3D)m_Destination);
            writer.Write((Map)m_Map);
        }
    }

    public class Leg
    {
        private int m_LegID;
        private List<RouteInfo> m_Info;
        private bool m_IsNonEliminationLeg;
        private PenaltyType m_LastPlacePenalty;
        private Point3D m_MatLocation;
        private Map m_MatMap;

        public List<RouteInfo> Info { get { return m_Info; } set { m_Info = value; } }
        public bool IsNonEliminationLeg { get { return m_IsNonEliminationLeg; } set { m_IsNonEliminationLeg = value; } }
        public PenaltyType LastPlacePenalty { get { return m_LastPlacePenalty; } set { m_LastPlacePenalty = value; } }
        public Point3D MatLocation { get { return m_MatLocation; } set { m_MatLocation = value; } }
        public Map MatMap { get { return m_MatMap; } set { m_MatMap = value; } }

        public Leg(int legID, List<RouteInfo> info, bool isNonEliminationLeg, PenaltyType lastPlacePenalty,
            Point3D matLocation, Map matMap)
        {
            m_LegID = legID;
            m_Info = info;
            m_IsNonEliminationLeg = isNonEliminationLeg;
            m_LastPlacePenalty = lastPlacePenalty;
            m_MatLocation = matLocation;
            m_MatMap = matMap;
        }

        public Leg(int legID, GenericReader reader)
        {
            m_LegID = legID;

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        int count = reader.ReadInt();
                        m_Info = new List<RouteInfo>();
                        if (count > 0)
                        {
                            for (int x = 0; x < count; x++)
                            {
                                m_Info.Add(new RouteInfo(reader));
                            }
                            m_IsNonEliminationLeg = reader.ReadBool();
                            m_LastPlacePenalty = (PenaltyType)reader.ReadInt();
                            m_MatLocation = reader.ReadPoint3D();
                            m_MatMap = reader.ReadMap();
                        }
                        break;
                    }
            }
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); //version

            writer.Write((int)m_Info.Count);
            foreach (RouteInfo info in m_Info)
            {
                info.Serialize(writer);
            }
            writer.Write((bool)m_IsNonEliminationLeg);
            writer.Write((int)m_LastPlacePenalty);
            writer.Write((Point3D)m_MatLocation);
            writer.Write((Map)m_MatMap);
        }
    }
}
