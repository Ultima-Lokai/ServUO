/***************************************************************************
 *   New LokaiSkill System script by Lokai. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/
using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Build
{
    public class DefStoneMasonry : BuildSystem
    {
        public override LokaiSkillName MainLokaiSkill
        {
            get { return LokaiSkillName.StoneMasonry; }
        }

        public override string GumpTitleString
        {
            get { return "Stone Masonry"; }
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
                    m_BuildSystem = new DefStoneMasonry();

                return m_BuildSystem;
            }
        }

        public override double GetChanceAtMin(BuildItem item)
        {
            return 0.0; // 0% 
        }

        private DefStoneMasonry()
            : base(1, 1, 1.25)// base( 1, 2, 1.7 ) 
        {
        }

        public override void InitBuildList()
        {
            int index = -1;

            // Panels
            index = AddBuild(typeof(StoneSlab), "Panels", "Stone Slab", 10.0, 50.0, typeof(StonePiece), "Stone Pieces", 3, "You don't have enough stone pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 15);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(SandstonePanel), "Panels", "Sandstone Panel", 20.0, 60.0, typeof(SandstonePiece), "Sandstone Pieces", 3, "You don't have enough sandstone pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 15);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(MarbleSlab), "Panels", "Marble Slab", 30.0, 70.0, typeof(MarblePiece), "Marble Pieces", 3, "You don't have enough marble pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 15);
            AddRes(index, typeof(JointSupply), "Joints", 4);

            // Flooring
            index = AddBuild(typeof(StoneFlooring), "Flooring", "Stone Flooring", 15.0, 60.0, typeof(StonePiece), "Stone Pieces", 2, "You don't have enough stone pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 15);
            index = AddBuild(typeof(MarbleFlooring), "Flooring", "Marble Flooring", 35.0, 80.0, typeof(MarblePiece), "Sandstone Pieces", 2, "You don't have enough marble panels.");
            AddRes(index, typeof(MortarSupply), "Mortar", 15);

            // Walls
            index = AddBuild(typeof(StoneWall), "Walls", "Stone Wall", 20.0, 60.0, typeof(StoneSlab), "Stone Slabs", 2, "You don't have enough stone slabs.");
            AddRes(index, typeof(MortarSupply), "Mortar", 15);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(SandstoneWall), "Walls", "Sandstone Wall", 30.0, 70.0, typeof(SandstonePanel), "Sandstone Panels", 2, "You don't have enough sandstone panels.");
            AddRes(index, typeof(MortarSupply), "Mortar", 15);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            index = AddBuild(typeof(MarbleWall), "Walls", "Marble Wall", 40.0, 80.0, typeof(MarbleSlab), "Marble Panels", 2, "You don't have enough marble slabs.");
            AddRes(index, typeof(MortarSupply), "Mortar", 15);
            AddRes(index, typeof(JointSupply), "Joints", 4);

            // Windows
            index = AddBuild(typeof(StoneWindow), "Windows", "Stone Window", 30.0, 70.0, typeof(StoneSlab), "Stone Slabs", 2, "You don't have enough stone slabs.");
            AddRes(index, typeof(MortarSupply), "Mortar", 10);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            AddRes(index, typeof(HingeSupply), "Hinges", 3);
            index = AddBuild(typeof(SandstoneWindow), "Windows", "Sandstone Window", 40.0, 80.0, typeof(SandstonePanel), "Sandstone Panels", 2, "You don't have enough sandstone panels.");
            AddRes(index, typeof(MortarSupply), "Mortar", 10);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            AddRes(index, typeof(HingeSupply), "Hinges", 3);
            index = AddBuild(typeof(MarbleWindow), "Windows", "Marble Window", 50.0, 90.0, typeof(MarbleSlab), "Marble Panels", 2, "You don't have enough marble slabs.");
            AddRes(index, typeof(MortarSupply), "Mortar", 10);
            AddRes(index, typeof(JointSupply), "Joints", 4);
            AddRes(index, typeof(HingeSupply), "Hinges", 3);

            // Stairs
            index = AddBuild(typeof(StoneStair), "Stairs", "Stone Stair", 20.0, 60.0, typeof(StonePiece), "Stone Pieces", 10, "You don't have enough stone pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 12);
            index = AddBuild(typeof(SandstoneStair), "Stairs", "Sandstone Stair", 40.0, 80.0, typeof(SandstonePiece), "Sandstone Pieces", 10, "You don't have enough sandstone pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 12);
            index = AddBuild(typeof(MarbleStair), "Stairs", "Marble Stair", 60.0, 100.0, typeof(MarblePiece), "Marble Pieces", 2, "You don't have enough marble pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 10);

            // Foundations
            index = AddBuild(typeof(StoneFoundation), "Foundations", "Stone Foundation", 10.0, 50.0, typeof(WoodPiece), "Stone Pieces", 3, "You don't have enough stone pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 12);
            index = AddBuild(typeof(SandstoneFoundation), "Foundations", "Sandstone Foundation", 20.0, 60.0, typeof(SandstonePiece), "Sandstone Pieces", 10, "You don't have enough sandstone pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 12);
            index = AddBuild(typeof(MarbleFoundation), "Foundations", "Marble Foundation", 30.0, 70.0, typeof(MarblePiece), "Marble Pieces", 2, "You don't have enough marble pieces.");
            AddRes(index, typeof(MortarSupply), "Mortar", 10);

            MarkOption = false;
            Repair = false;

            SetSubRes(typeof(StonePiece), 1044525);
        }
    }
}