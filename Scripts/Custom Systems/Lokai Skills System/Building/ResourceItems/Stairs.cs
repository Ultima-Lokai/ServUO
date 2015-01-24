/***************************************************************************
 *   New LokaiSkill System script by Lokai. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/
using System;
using System.Collections;

namespace Server.Items
{
    public class StairItem : ResourceItem
    {
        [Constructable]
        public StairItem() { Weight = 5.0; }
        public StairItem(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class WoodStair : StairItem
    {
        [Constructable]
        public WoodStair() { Name = "Wood Stair"; ItemID = 0x722; }
        public WoodStair(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class StoneStair : StairItem
    {
        [Constructable]
        public StoneStair() { Name = "Stone Stair"; ItemID = 0x71F; }
        public StoneStair(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class SandstoneStair : StairItem
    {
        [Constructable]
        public SandstoneStair() { Name = "Sandstone Stair"; ItemID = 0x76D; }
        public SandstoneStair(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class MarbleStair : StairItem
    {
        [Constructable]
        public MarbleStair() { Name = "Marble Stair"; ItemID = 0x70A; }
        public MarbleStair(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
