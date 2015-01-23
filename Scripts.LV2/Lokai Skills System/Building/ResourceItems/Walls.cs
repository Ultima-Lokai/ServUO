/***************************************************************************
 *   New LokaiSkill System script by Lokai. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/
using System;
using System.Collections;

namespace Server.Items
{
    public class WallItem : ResourceItem
    {
        [Constructable]
        public WallItem() { Weight = 5.0; }
        public WallItem(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class WoodWall : WallItem
    {
        [Constructable]
        public WoodWall() { Name = "Wood Wall"; ItemID = 0x12; }
        public WoodWall(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class StoneWall : WallItem
    {
        [Constructable]
        public StoneWall() { Name = "Stone Wall"; ItemID = 0x58; }
        public StoneWall(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class BrickWall : WallItem
    {
        [Constructable]
        public BrickWall() { Name = "Brick Wall"; ItemID = 0x34; }
        public BrickWall(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class LogWall : WallItem
    {
        [Constructable]
        public LogWall() { Name = "Log Wall"; ItemID = 0x95; }
        public LogWall(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class WroughtIronFence : WallItem
    {
        [Constructable]
        public WroughtIronFence() { Name = "Wrought Iron Fence"; ItemID = 0x0823; }
        public WroughtIronFence(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class SandstoneWall : WallItem
    {
        [Constructable]
        public SandstoneWall() { Name = "Sandstone Wall"; ItemID = 0x160; }
        public SandstoneWall(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    class MarbleWall : WallItem
    {
        [Constructable]
        public MarbleWall() { Name = "Marble Wall"; ItemID = 0x292; }
        public MarbleWall(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    class RatanWall : WallItem
    {
        [Constructable]
        public RatanWall() { Name = "Ratan Wall"; ItemID = 0x1A6; }
        public RatanWall(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class HideWall : WallItem
    {
        [Constructable]
        public HideWall() { Name = "Hide Wall"; ItemID = 0x1B8; }
        public HideWall(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class BambooWall : WallItem
    {
        [Constructable]
        public BambooWall() { Name = "Bamboo Wall"; ItemID = 0x211; }
        public BambooWall(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
