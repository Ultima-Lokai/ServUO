/***************************************************************************
 *   New LokaiSkill System script by Lokai. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/
using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Build
{
    public class DefFraming : BuildSystem
    {
        public override LokaiSkillName MainLokaiSkill
        {
            get { return LokaiSkillName.Framing; }
        }

        public override string  GumpTitleString
        {
            get { return "Framing"; }
        }

        public override void PlayBuildEffect(Mobile from) { }
        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken,
            int quality, bool makersMark, BuildItem item) { return 0; }

        public override int CanBuild(Mobile from, BaseBuildingTool tool, Type itemType) { return 0; }

        private static BuildSystem m_BuildSystem;

        public static BuildSystem BuildSystem
        {
            get
            {
                if (m_BuildSystem == null)
                    m_BuildSystem = new DefFraming();

                return m_BuildSystem;
            }
        }

        public override double GetChanceAtMin(BuildItem item)
        {
            return 0.0; // 0% 
        }

        private DefFraming()
            : base(1, 1, 1.25)// base( 1, 2, 1.7 ) 
        {
        }

        public override void InitBuildList()
        {
            int index = -1;

            // Panels
            index = AddBuild(typeof(WoodPanel), "Panels", "Wood Panel", 10.0, 100.0, typeof(WoodPiece), "Wood Pieces", 3, "You don't have enough wood pieces.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(LogPanel), "Panels", "Log Panel", 10.0, 100.0, typeof(LogPiece), "Log Pieces", 3, "You don't have enough log pieces.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(RatanPanel), "Panels", "Ratan Panel", 10.0, 100.0, typeof(RatanPiece), "Ratan Pieces", 3, "You don't have enough ratan pieces.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(HidePanel), "Panels", "Hide Panel", 10.0, 100.0, typeof(HidePiece), "Hide Pieces", 3, "You don't have enough hide pieces.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(BambooPanel), "Panels", "Bamboo Panel", 10.0, 100.0, typeof(BambooPiece), "Bamboo Pieces", 3, "You don't have enough bamboo pieces.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);

            // Flooring
            index = AddBuild(typeof(WoodFlooring), "Flooring", "Wood Flooring", 10.0, 100.0, typeof(WoodPiece), "Wood Pieces", 2, "You don't have enough wood pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 15);

            // Walls
            index = AddBuild(typeof(WoodWall), "Walls", "Wood Wall", 10.0, 100.0, typeof(WoodPanel), "Wood Panels", 2, "You don't have enough wood panels.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(LogWall), "Walls", "Log Wall", 10.0, 100.0, typeof(LogPanel), "Log Panels", 2, "You don't have enough log panels.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(RatanWall), "Walls", "Ratan Wall", 10.0, 100.0, typeof(RatanPanel), "Ratan Panels", 2, "You don't have enough ratan panels.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(HideWall), "Walls", "Hide Wall", 10.0, 100.0, typeof(HidePanel), "Hide Panels", 2, "You don't have enough hide panels.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(BambooWall), "Walls", "Bamboo Wall", 10.0, 100.0, typeof(BambooPanel), "Bamboo Panels", 2, "You don't have enough bamboo panels.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);

            // Windows
            index = AddBuild(typeof(WoodWindow), "Windows", "Wood Window", 10.0, 100.0, typeof(WoodPanel), "Wood Panels", 2, "You don't have enough wood panels.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(LogWindow), "Windows", "Log Window", 10.0, 100.0, typeof(LogPanel), "Log Panels", 2, "You don't have enough log panels.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(RatanWindow), "Windows", "Ratan Window", 10.0, 100.0, typeof(RatanPanel), "Ratan Panels", 2, "You don't have enough ratan panels.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(HideWindow), "Windows", "Hide Window", 10.0, 100.0, typeof(HidePanel), "Hide Panels", 2, "You don't have enough hide panels.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(BambooWindow), "Windows", "Bamboo Window", 10.0, 100.0, typeof(BambooPanel), "Bamboo Panels", 2, "You don't have enough bamboo panels.");
            AddRes(index, typeof(NailSupply), "Nails", 30);
            AddRes(index, typeof(JointSupply), "Joints", 4);

            // Doors
            index = AddBuild(typeof(WoodDoor), "Doors", "Wood Door", 10.0, 100.0, typeof(WoodPanel), "Wood Panels", 2, "You don't have enough wood panels.");
            AddRes(index, typeof(NailSupply), "Nails", 20);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            AddRes(index, typeof(HingeSupply), "Hinges", 3);
            index = AddBuild(typeof(LogDoor), "Doors", "Log Door", 10.0, 100.0, typeof(LogPanel), "Log Panels", 2, "You don't have enough log panels.");
            AddRes(index, typeof(NailSupply), "Nails", 20);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            AddRes(index, typeof(HingeSupply), "Hinges", 3);
            index = AddBuild(typeof(RatanDoor), "Doors", "Ratan Door", 10.0, 100.0, typeof(RatanPanel), "Ratan Panels", 2, "You don't have enough ratan panels.");
            AddRes(index, typeof(NailSupply), "Nails", 20);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            AddRes(index, typeof(HingeSupply), "Hinges", 3);
            index = AddBuild(typeof(HideDoor), "Doors", "Hide Door", 10.0, 100.0, typeof(HidePanel), "Hide Panels", 2, "You don't have enough hide panels.");
            AddRes(index, typeof(NailSupply), "Nails", 20);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            AddRes(index, typeof(HingeSupply), "Hinges", 3);
            index = AddBuild(typeof(BambooDoor), "Doors", "Bamboo Door", 10.0, 100.0, typeof(BambooPanel), "Bamboo Panels", 2, "You don't have enough bamboo panels.");
            AddRes(index, typeof(NailSupply), "Nails", 20);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            AddRes(index, typeof(HingeSupply), "Hinges", 3);

            // Stairs
            index = AddBuild(typeof(WoodStair), "Stairs", "Wood Stair", 10.0, 100.0, typeof(WoodPiece), "Wood Pieces", 10, "You don't have enough wood pieces.");
            AddRes(index, typeof(NailSupply), "Nails", 25);

            // Foundations
            index = AddBuild(typeof(WoodFoundation), "Foundations", "Wood Foundation", 10.0, 100.0, typeof(WoodPiece), "Wood Pieces", 3, "You don't have enough wood pieces.");
            AddRes(index, typeof(NailSupply), "Nails", 25);

            MarkOption = false;
            Repair = false;

            SetSubRes(typeof(WoodPiece), 1044525);
        }
    }
}