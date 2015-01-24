/***************************************************************************
 *   New LokaiSkill System script by Lokai. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/
using System;
using System.Collections;

namespace Server.Items
{
    public class DoorItem : ResourceItem
    {
        [Constructable]
        public DoorItem() { Weight = 5.0; }
        public DoorItem(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class WoodDoor : DoorItem
    {
        [Constructable]
        public WoodDoor() { Name = "Wood Door"; ItemID = 0x6B2; }
        public WoodDoor(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class Metal_Door : DoorItem
    {
        [Constructable]
        public Metal_Door() { Name = "Metal Door"; ItemID = 0x680; }
        public Metal_Door(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class BarredMetal_Door : DoorItem
    {
        [Constructable]
        public BarredMetal_Door() { Name = "Barred Metal Door"; ItemID = 0x690; }
        public BarredMetal_Door(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class LogDoor : DoorItem
    {
        [Constructable]
        public LogDoor() { Name = "Log Door"; ItemID = 0x228; }
        public LogDoor(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class WroughtIronGate : DoorItem
    {
        [Constructable]
        public WroughtIronGate() { Name = "Wrought Iron Gate"; ItemID = 0x84E; }
        public WroughtIronGate(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class RatanDoor : DoorItem
    {
        [Constructable]
        public RatanDoor() { Name = "Ratan Door"; ItemID = 0x6A0; }
        public RatanDoor(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class HideDoor : DoorItem
    {
        [Constructable]
        public HideDoor() { Name = "Hide Door"; ItemID = 0x22C; }
        public HideDoor(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class BambooDoor : DoorItem
    {
        [Constructable]
        public BambooDoor() { Name = "Bamboo Door"; ItemID = 0x2D49; }
        public BambooDoor(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
