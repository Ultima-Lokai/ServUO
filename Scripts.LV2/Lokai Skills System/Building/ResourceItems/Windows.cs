/***************************************************************************
 *   New LokaiSkill System script by Lokai. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/
using System;
using System.Collections;

namespace Server.Items
{
    public class WindowItem : ResourceItem
    {
        [Constructable]
        public WindowItem() { Weight = 5.0; }
        public WindowItem(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class WoodWindow : WindowItem
    {
        [Constructable]
        public WoodWindow() { Name = "Wood Window"; ItemID = 0x00E; }
        public WoodWindow(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class StoneWindow : WindowItem
    {
        [Constructable]
        public StoneWindow() { Name = "Stone Window"; ItemID = 0x022; }
        public StoneWindow(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class BrickWindow : WindowItem
    {
        [Constructable]
        public BrickWindow() { Name = "Brick Window"; ItemID = 0x03B; }
        public BrickWindow(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class LogWindow : WindowItem
    {
        [Constructable]
        public LogWindow() { Name = "Log Window"; ItemID = 0x098; }
        public LogWindow(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class SandstoneWindow : WindowItem
    {
        [Constructable]
        public SandstoneWindow() { Name = "Sandstone Window"; ItemID = 0x163; }
        public SandstoneWindow(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class MarbleWindow : WindowItem
    {
        [Constructable]
        public MarbleWindow() { Name = "Marble Window"; ItemID = 0x108; }
        public MarbleWindow(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class RatanWindow : WindowItem
    {
        [Constructable]
        public RatanWindow() { Name = "Ratan Window"; ItemID = 0x1AD; }
        public RatanWindow(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class HideWindow : WindowItem
    {
        [Constructable]
        public HideWindow() { Name = "Hide Window"; ItemID = 0x1C6; }
        public HideWindow(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class BambooWindow : WindowItem
    {
        [Constructable]
        public BambooWindow() { Name = "Bamboo Window"; ItemID = 0x2D43; }
        public BambooWindow(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
