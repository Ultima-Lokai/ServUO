/***************************************************************************
 *   New LokaiSkill System script by Lokai. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/
using System;
using System.Collections;

namespace Server.Items
{
    public class PanelItem : ResourceItem
    {
        [Constructable]
        public PanelItem() { Weight = 5.0; }
        public PanelItem(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class WoodPanel : PanelItem
    {
        [Constructable]
        public WoodPanel() { Name = "Wood Panel"; ItemID = 0x16; }
        public WoodPanel(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class StoneSlab : PanelItem
    {
        [Constructable]
        public StoneSlab() { Name = "Stone Slab"; ItemID = 0x63; }
        public StoneSlab(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class BrickPanel : PanelItem
    {
        [Constructable]
        public BrickPanel() { Name = "Brick Panel"; ItemID = 0x42; }
        public BrickPanel(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class LogPanel : PanelItem
    {
        [Constructable]
        public LogPanel() { Name = "Log Panel"; ItemID = 0x9F; }
        public LogPanel(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class WroughtIronPanel : PanelItem
    {
        [Constructable]
        public WroughtIronPanel() { Name = "Wrought Iron Panel"; ItemID = 0x084B; }
        public WroughtIronPanel(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class SandstonePanel : PanelItem
    {
        [Constructable]
        public SandstonePanel() { Name = "Sandstone Panel"; ItemID = 0x184; }
        public SandstonePanel(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    class MarbleSlab : PanelItem
    {
        [Constructable]
        public MarbleSlab() { Name = "Marble Slab"; ItemID = 0x2A2; }
        public MarbleSlab(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    class RatanPanel : PanelItem
    {
        [Constructable]
        public RatanPanel() { Name = "Ratan Panel"; ItemID = 0x1A6; }
        public RatanPanel(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class HidePanel : PanelItem
    {
        [Constructable]
        public HidePanel() { Name = "Hide Panel"; ItemID = 0x1C2; }
        public HidePanel(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class BambooPanel : PanelItem
    {
        [Constructable]
        public BambooPanel() { Name = "Bamboo Panel"; ItemID = 0x214; }
        public BambooPanel(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
