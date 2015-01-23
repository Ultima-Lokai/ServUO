using System;
using System.Collections.Generic;
using Server;

namespace Server.TAR
{
    public class TARace
    {
        private int m_RaceID;
        private List<Leg> m_Legs;
        private List<RaceTeam> m_Teams;
        private string m_Description;
        private Point3D m_StartLocation;
        private Map m_StartMap;

        public int RaceID { get { return m_RaceID; } set { m_RaceID = value; } }
        public List<Leg> Legs { get { return m_Legs; } set { m_Legs = value; } }
        public List<RaceTeam> Teams { get { return m_Teams; } set { m_Teams = value; } }
        public string Description { get { return m_Description; } set { m_Description = value; } }
        public Point3D StartLocation { get { return m_StartLocation; } set { m_StartLocation = value; } }
        public Map StartMap { get { return m_StartMap; } set { m_StartMap = value; } }

        public TARace(int raceID, List<Leg> legs, List<RaceTeam> teams, string description, Point3D startLocation, Map startMap)
        {
            m_RaceID = raceID;
            m_Legs = legs;
            m_Teams = teams;
            m_Description = description;
            m_StartLocation = startLocation;
            m_StartMap = startMap;
        }

        public TARace(int raceID, GenericReader reader)
        {
            m_RaceID = raceID;

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_Legs = new List<Leg>();
                        int count = reader.ReadInt();
                        if (count > 0)
                        {
                            for (int x = 0; x < count; x++)
                            {
                                m_Legs.Add(new Leg(x, reader));
                            }
                        }
                        m_Teams = new List<RaceTeam>();
                        count = reader.ReadInt();
                        if (count > 0)
                        {
                            for (int x = 0; x < count; x++)
                            {
                                m_Teams.Add(new RaceTeam(x, m_RaceID, reader));
                            }
                        }
                        m_Description = reader.ReadString();
                        m_StartLocation = reader.ReadPoint3D();
                        m_StartMap = reader.ReadMap();
                        break;
                    }
            }
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); //version
            writer.Write((int)m_Legs.Count);
            foreach (Leg leg in Legs)
            {
                leg.Serialize(writer);
            }
            writer.Write((int)m_Teams.Count);
            foreach (RaceTeam team in Teams)
            {
                team.Serialize(writer);
            }
            writer.Write((string)m_Description);
            writer.Write((Point3D)m_StartLocation);
            writer.Write((Map)m_StartMap);
        }
    }
}
