/***************************************************************************
 *   New LokaiSkill System script by Lokai. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/
using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Build
{
    public class DefRoofing : BuildSystem
    {
        public override LokaiSkillName MainLokaiSkill
        {
            get { return LokaiSkillName.Roofing; }
        }

        public override string GumpTitleString
        {
            get { return "Roofing"; }
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
                    m_BuildSystem = new DefRoofing();

                return m_BuildSystem;
            }
        }

        public override double GetChanceAtMin(BuildItem item)
        {
            return 0.0; // 0% 
        }

        private DefRoofing()
            : base(1, 1, 1.25)// base( 1, 2, 1.7 ) 
        {
        }

        public override void InitBuildList()
        {
            int index = -1;

            /*
            // Base Pieces
            index = AddBuild(typeof(BrickPiece), "Base Pieces", "Brick Piece", 0.0, 40.0, typeof(Clay), "Clay", 5, "You don't have enough clay.");

            // Base Pieces
            index = AddBuild(typeof(StonePiece), "Base Pieces", "Stone Piece", 0.0, 40.0, typeof(BaseGranite), "Granite", 5, "You don't have enough granite.");
            index = AddBuild(typeof(SandstonePiece), "Base Pieces", "Sandstone Piece", 10.0, 50.0, typeof(BaseGranite), "Granite", 5, "You don't have enough granite.");
            index = AddBuild(typeof(MarblePiece), "Base Pieces", "Marble Piece", 20.0, 60.0, typeof(BaseGranite), "Granite", 5, "You don't have enough granite.");

            // Base Pieces
            index = AddBuild(typeof(TilePiece), "Base Pieces", "Tile Piece", 20.0, 60.0, typeof(Clay), "Granite", 5, "You don't have enough granite.");
            index = AddBuild(typeof(LogPiece), "Base Pieces", "Log Piece", 10.0, 50.0, typeof(Log), "Granite", 5, "You don't have enough granite.");
            index = AddBuild(typeof(WoodPiece), "Base Pieces", "Wood Piece", 15.0, 55.0, typeof(Board), "Granite", 5, "You don't have enough granite.");
            index = AddBuild(typeof(ThatchPiece), "Base Pieces", "Thatch Piece", 0.0, 40.0, typeof(BaseGranite), "Granite", 5, "You don't have enough granite.");
            index = AddBuild(typeof(PalmPiece), "Base Pieces", "Palm Piece", 5.0, 45.0, typeof(TreeResourceItem), "Granite", 5, "You don't have enough granite.", TreeResource.PalmHusks);
            index = AddBuild(typeof(SlatePiece), "Base Pieces", "Slate Piece", 30.0, 70.0, typeof(Clay), "Granite", 5, "You don't have enough granite.");
            */

            // Roofing
            index = AddBuild(typeof(TileRoofing), "Roofing", "Tile Roofing", 40.0, 85.0, typeof(TilePiece), "Tile Piece", 3, "You don't have enough tile pieces.");
            AddRes(index, typeof(PitchSupply), "Pitch", 4);
            AddRes(index, typeof(TarSupply), "Tar", 2);
            index = AddBuild(typeof(LogRoofing), "Roofing", "Log Roofing", 20.0, 60.0, typeof(LogPiece), "Log Piece", 3, "You don't have enough clay pieces.");
            AddRes(index, typeof(PitchSupply), "Pitch", 4);
            AddRes(index, typeof(TarSupply), "Tar", 2);
            index = AddBuild(typeof(ShingleRoofing), "Roofing", "Shingle Roofing", 25.0, 65.0, typeof(WoodPiece), "Wood Piece", 3, "You don't have enough wood pieces.");
            AddRes(index, typeof(PitchSupply), "Pitch", 4);
            AddRes(index, typeof(TarSupply), "Tar", 2);
            index = AddBuild(typeof(ThatchRoofing), "Roofing", "Thatch Roofing", 10.0, 50.0, typeof(ThatchPiece), "Thatch Piece", 3, "You don't have enough thatch pieces.");
            AddRes(index, typeof(PitchSupply), "Pitch", 4);
            AddRes(index, typeof(TarSupply), "Tar", 2);
            index = AddBuild(typeof(PalmRoofing), "Roofing", "Palm Roofing", 15.0, 55.0, typeof(PalmPiece), "Palm Piece", 3, "You don't have enough palm pieces.");
            AddRes(index, typeof(PitchSupply), "Pitch", 4);
            AddRes(index, typeof(TarSupply), "Tar", 2);
            index = AddBuild(typeof(SlateRoofing), "Roofing", "Slate Roofing", 50.0, 100.0, typeof(SlatePiece), "Slate Piece", 3, "You don't have enough slate pieces.");
            AddRes(index, typeof(PitchSupply), "Pitch", 4);
            AddRes(index, typeof(TarSupply), "Tar", 2);
        }
    }
}