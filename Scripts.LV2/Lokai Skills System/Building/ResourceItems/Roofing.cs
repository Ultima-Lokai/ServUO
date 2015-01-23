/***************************************************************************
 *   New LokaiSkill System script by Lokai. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/
using System;
using System.Collections;

namespace Server.Items
{
    public class RoofingItem : ResourceItem
    {
        [Constructable]
        public RoofingItem() { Weight = 5.0; }
        public RoofingItem(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class ShingleRoofing : RoofingItem
    {
        [Constructable]
        public ShingleRoofing() { Name = "Shingle Roofing"; ItemID = 0x2C3F; }
        public ShingleRoofing(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class TileRoofing : RoofingItem
    {
        [Constructable]
        public TileRoofing() { Name = "Tile Roofing"; ItemID = 0x2C30; }
        public TileRoofing(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class LogRoofing : RoofingItem
    {
        [Constructable]
        public LogRoofing() { Name = "Log Roofing"; ItemID = 0x2C4E; }
        public LogRoofing(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class ThatchRoofing : RoofingItem
    {
        [Constructable]
        public ThatchRoofing() { Name = "Thatch Roofing"; ItemID = 0x2C55; }
        public ThatchRoofing(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class PalmRoofing : RoofingItem
    {
        [Constructable]
        public PalmRoofing() { Name = "Palm Roofing"; ItemID = 0x2C6D; }
        public PalmRoofing(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class SlateRoofing : RoofingItem
    {
        [Constructable]
        public SlateRoofing() { Name = "Slate Roofing"; ItemID = 0x2C7B; }
        public SlateRoofing(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
