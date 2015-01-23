/* Originally created as:
 * "Advanced Player Gate" for RunUO 2.0 (Now RunUO 2.2)
 * 	by Lokai
 * 
 * 4/18/2008 Added TempGateItem for Event handling
 *  - Item retains skills, stats, etc.
 *  - Until deleted by GM/Admin at which
 *  - time it restores user to original state.
 * 
 * 4/19/2008 Changed to AP_EventGate, and added to
 *  - new ShardEvent system.
 *  
 * 2/9/2012 Added support for RunUO 2.2 new skills.
 *  - TempGateItem remembers what items you got, and
 *  - tries to delete them when the TempGateItem is 
 *  - deleted. GateDialogGump renamed to AP_EventGateGump.
 *  - Fixed some crashes when reloading. Made it so any 
 *  - time you use an AP_EventGate, it deletes any 
 *  - TempGateItems you have, which also removes any items 
 *  - you received from them. (Only 1 Temp Gate can be used.)
 */

using System;
using Server;
using Server.Mobiles;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Server.Network;
using Server.Commands;
using Server.Misc;
using Server.Gumps;
using Server.Prompts;
using Server.HuePickers;

namespace Server.Custom
{
    public class AP_EventGate : Moongate
    {
        #region " Variable declarations "
        private bool m_EventGate = false; //Specifically for ShardEvents
        private bool m_TempGate = false; //For Events and other uses for temporary gates.

        private List<Item> m_AddedItems;
        private bool m_Decays;
        private bool m_DoesRename = false;
        private string m_NameGiven = "";
        private bool m_DoesTeleport = true;
        private bool m_DoesResurrect = true;
        private bool m_ChangesSkills = true;
        private bool m_ChangesSkillCaps = true;
        private bool m_ChangesStats = true;
        private bool m_ChangesHue = false;
        private bool m_SkillsGiveItems = true;
        private int m_SkillsItemsMin = 50;
        private DateTime m_DecayTime;
        private Timer m_Timer;
        private int m_Int = 10;
        private int m_Dex = 10;
        private int m_Str = 10;
        private string m_GateMessage = "Advanced Player Gate";

        //these are Public for use by the AP_GateDialogGump
        public int[] gAllSkills = new int[58];
        public int[] gAllSkillCaps = new int[]{ 100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,
						100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,
						100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100 };

        // Title
        private bool m_TitleAdds = false;
        private string m_TitleToAdd = "";

        // Player Count
        private bool m_PlayerCountLimited = false;
        private int m_PlayerCountMax = 10; //set how many players you want to be affected.
        private int m_PlayersPassed = 0;
        private string m_PlayerCountExeededMessage = "too many players passed already";

        #endregion

        #region " Set Skills "
        // Public Command-list
        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Alchemy { get { return gAllSkills[0]; } set { gAllSkills[0] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Anatomy { get { return gAllSkills[1]; } set { gAllSkills[1] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_AnimalLore { get { return gAllSkills[2]; } set { gAllSkills[2] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_ItemID { get { return gAllSkills[3]; } set { gAllSkills[3] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_ArmsLore { get { return gAllSkills[4]; } set { gAllSkills[4] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Parry { get { return gAllSkills[5]; } set { gAllSkills[5] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Begging { get { return gAllSkills[6]; } set { gAllSkills[6] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Blacksmith { get { return gAllSkills[7]; } set { gAllSkills[7] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Fletching { get { return gAllSkills[8]; } set { gAllSkills[8] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Peacemaking { get { return gAllSkills[9]; } set { gAllSkills[9] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Camping { get { return gAllSkills[10]; } set { gAllSkills[10] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Carpentry { get { return gAllSkills[11]; } set { gAllSkills[11] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Cartography { get { return gAllSkills[12]; } set { gAllSkills[12] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Cooking { get { return gAllSkills[13]; } set { gAllSkills[13] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_DetectHidden { get { return gAllSkills[14]; } set { gAllSkills[14] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Discordance { get { return gAllSkills[15]; } set { gAllSkills[15] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_EvalInt { get { return gAllSkills[16]; } set { gAllSkills[16] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Healing { get { return gAllSkills[17]; } set { gAllSkills[17] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Fishing { get { return gAllSkills[18]; } set { gAllSkills[18] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Forensics { get { return gAllSkills[19]; } set { gAllSkills[19] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Herding { get { return gAllSkills[20]; } set { gAllSkills[20] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Hiding { get { return gAllSkills[21]; } set { gAllSkills[21] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Provocation { get { return gAllSkills[22]; } set { gAllSkills[22] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Inscribe { get { return gAllSkills[23]; } set { gAllSkills[23] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Lockpicking { get { return gAllSkills[24]; } set { gAllSkills[24] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Magery { get { return gAllSkills[25]; } set { gAllSkills[25] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_MagicResist { get { return gAllSkills[26]; } set { gAllSkills[26] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Tactics { get { return gAllSkills[27]; } set { gAllSkills[27] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Snooping { get { return gAllSkills[28]; } set { gAllSkills[28] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Musicianship { get { return gAllSkills[29]; } set { gAllSkills[29] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Poisoning { get { return gAllSkills[30]; } set { gAllSkills[30] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Archery { get { return gAllSkills[31]; } set { gAllSkills[31] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_SpiritSpeak { get { return gAllSkills[32]; } set { gAllSkills[32] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Stealing { get { return gAllSkills[33]; } set { gAllSkills[33] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Tailoring { get { return gAllSkills[34]; } set { gAllSkills[34] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_AnimalTaming { get { return gAllSkills[35]; } set { gAllSkills[35] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_TasteID { get { return gAllSkills[36]; } set { gAllSkills[36] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Tinkering { get { return gAllSkills[37]; } set { gAllSkills[37] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Tracking { get { return gAllSkills[38]; } set { gAllSkills[38] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Veterinary { get { return gAllSkills[39]; } set { gAllSkills[39] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Swords { get { return gAllSkills[40]; } set { gAllSkills[40] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Macing { get { return gAllSkills[41]; } set { gAllSkills[41] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Fencing { get { return gAllSkills[42]; } set { gAllSkills[42] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Wrestling { get { return gAllSkills[43]; } set { gAllSkills[43] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Lumberjacking { get { return gAllSkills[44]; } set { gAllSkills[44] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Mining { get { return gAllSkills[45]; } set { gAllSkills[45] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Meditation { get { return gAllSkills[46]; } set { gAllSkills[46] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Stealth { get { return gAllSkills[47]; } set { gAllSkills[47] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_RemoveTrap { get { return gAllSkills[48]; } set { gAllSkills[48] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Necromancy { get { return gAllSkills[49]; } set { gAllSkills[49] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Focus { get { return gAllSkills[50]; } set { gAllSkills[50] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Chivalry { get { return gAllSkills[51]; } set { gAllSkills[51] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Bushido { get { return gAllSkills[52]; } set { gAllSkills[52] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Ninjitsu { get { return gAllSkills[53]; } set { gAllSkills[53] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_SpellWeaving { get { return gAllSkills[54]; } set { gAllSkills[54] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Mysticism { get { return gAllSkills[55]; } set { gAllSkills[55] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Imbuing { get { return gAllSkills[56]; } set { gAllSkills[56] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetSkill_Throwing { get { return gAllSkills[57]; } set { gAllSkills[57] = value; } }
        #endregion

        #region " Set Skill Caps "
        // Public Command-list
        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Alchemy { get { return gAllSkillCaps[0]; } set { gAllSkillCaps[0] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Anatomy { get { return gAllSkillCaps[1]; } set { gAllSkillCaps[1] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_AnimalLore { get { return gAllSkillCaps[2]; } set { gAllSkillCaps[2] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_ItemID { get { return gAllSkillCaps[3]; } set { gAllSkillCaps[3] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_ArmsLore { get { return gAllSkillCaps[4]; } set { gAllSkillCaps[4] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Parry { get { return gAllSkillCaps[5]; } set { gAllSkillCaps[5] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Begging { get { return gAllSkillCaps[6]; } set { gAllSkillCaps[6] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Blacksmith { get { return gAllSkillCaps[7]; } set { gAllSkillCaps[7] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Fletching { get { return gAllSkillCaps[8]; } set { gAllSkillCaps[8] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Peacemaking { get { return gAllSkillCaps[9]; } set { gAllSkillCaps[9] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Camping { get { return gAllSkillCaps[10]; } set { gAllSkillCaps[10] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Carpentry { get { return gAllSkillCaps[11]; } set { gAllSkillCaps[11] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Cartography { get { return gAllSkillCaps[12]; } set { gAllSkillCaps[12] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Cooking { get { return gAllSkillCaps[13]; } set { gAllSkillCaps[13] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_DetectHidden { get { return gAllSkillCaps[14]; } set { gAllSkillCaps[14] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Discordance { get { return gAllSkillCaps[15]; } set { gAllSkillCaps[15] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_EvalInt { get { return gAllSkillCaps[16]; } set { gAllSkillCaps[16] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Healing { get { return gAllSkillCaps[17]; } set { gAllSkillCaps[17] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Fishing { get { return gAllSkillCaps[18]; } set { gAllSkillCaps[18] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Forensics { get { return gAllSkillCaps[19]; } set { gAllSkillCaps[19] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Herding { get { return gAllSkillCaps[20]; } set { gAllSkillCaps[20] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Hiding { get { return gAllSkillCaps[21]; } set { gAllSkillCaps[21] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Provocation { get { return gAllSkillCaps[22]; } set { gAllSkillCaps[22] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Inscribe { get { return gAllSkillCaps[23]; } set { gAllSkillCaps[23] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Lockpicking { get { return gAllSkillCaps[24]; } set { gAllSkillCaps[24] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Magery { get { return gAllSkillCaps[25]; } set { gAllSkillCaps[25] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_MagicResist { get { return gAllSkillCaps[26]; } set { gAllSkillCaps[26] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Tactics { get { return gAllSkillCaps[27]; } set { gAllSkillCaps[27] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Snooping { get { return gAllSkillCaps[28]; } set { gAllSkillCaps[28] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Musicianship { get { return gAllSkillCaps[29]; } set { gAllSkillCaps[29] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Poisoning { get { return gAllSkillCaps[30]; } set { gAllSkillCaps[30] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Archery { get { return gAllSkillCaps[31]; } set { gAllSkillCaps[31] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_SpiritSpeak { get { return gAllSkillCaps[32]; } set { gAllSkillCaps[32] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Stealing { get { return gAllSkillCaps[33]; } set { gAllSkillCaps[33] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Tailoring { get { return gAllSkillCaps[34]; } set { gAllSkillCaps[34] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_AnimalTaming { get { return gAllSkillCaps[35]; } set { gAllSkillCaps[35] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_TasteID { get { return gAllSkillCaps[36]; } set { gAllSkillCaps[36] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Tinkering { get { return gAllSkillCaps[37]; } set { gAllSkillCaps[37] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Tracking { get { return gAllSkillCaps[38]; } set { gAllSkillCaps[38] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Veterinary { get { return gAllSkillCaps[39]; } set { gAllSkillCaps[39] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Swords { get { return gAllSkillCaps[40]; } set { gAllSkillCaps[40] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Macing { get { return gAllSkillCaps[41]; } set { gAllSkillCaps[41] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Fencing { get { return gAllSkillCaps[42]; } set { gAllSkillCaps[42] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Wrestling { get { return gAllSkillCaps[43]; } set { gAllSkillCaps[43] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Lumberjacking { get { return gAllSkillCaps[44]; } set { gAllSkillCaps[44] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Mining { get { return gAllSkillCaps[45]; } set { gAllSkillCaps[45] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Meditation { get { return gAllSkillCaps[46]; } set { gAllSkillCaps[46] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Stealth { get { return gAllSkillCaps[47]; } set { gAllSkillCaps[47] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_RemoveTrap { get { return gAllSkillCaps[48]; } set { gAllSkillCaps[48] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Necromancy { get { return gAllSkillCaps[49]; } set { gAllSkillCaps[49] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Focus { get { return gAllSkillCaps[50]; } set { gAllSkillCaps[50] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Chivalry { get { return gAllSkillCaps[51]; } set { gAllSkillCaps[51] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Bushido { get { return gAllSkillCaps[52]; } set { gAllSkillCaps[52] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Ninjitsu { get { return gAllSkillCaps[53]; } set { gAllSkillCaps[53] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_SpellWeaving { get { return gAllSkillCaps[54]; } set { gAllSkillCaps[54] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Mysticism { get { return gAllSkillCaps[52]; } set { gAllSkillCaps[55] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Imbuing { get { return gAllSkillCaps[53]; } set { gAllSkillCaps[56] = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SetCap_Throwing { get { return gAllSkillCaps[54]; } set { gAllSkillCaps[57] = value; } }
        #endregion

        #region " Miscellaneous Variables "

        [CommandProperty(AccessLevel.GameMaster)]
        public bool TempGate { get { return m_TempGate; } set { m_TempGate = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool EventGate { get { return m_EventGate; } set { m_EventGate = value; } }

        // Title Props
        [CommandProperty(AccessLevel.GameMaster)]
        public string MC_TitleToAdd { get { return m_TitleToAdd; } set { m_TitleToAdd = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool MC_TitleAdds { get { return m_TitleAdds; } set { m_TitleAdds = value; } }

        // Player Count Props
        [CommandProperty(AccessLevel.GameMaster)]
        public bool MC_PlayerCountLimited { get { return m_PlayerCountLimited; } set { m_PlayerCountLimited = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MC_PlayerCountMax { get { return m_PlayerCountMax; } set { m_PlayerCountMax = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MC_PlayersPassed { get { return m_PlayersPassed; } set { m_PlayersPassed = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public string MC_PlayerCountExeededMessage { get { return m_PlayerCountExeededMessage; } set { m_PlayerCountExeededMessage = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Set_STAT_Int { get { return m_Int; } set { m_Int = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Set_STAT_Dex { get { return m_Dex; } set { m_Dex = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Set_STAT_Str { get { return m_Str; } set { m_Str = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public string _GateMessage { get { return m_GateMessage; } set { m_GateMessage = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool _DoesTeleport { get { return m_DoesTeleport; } set { m_DoesTeleport = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool _DoesResurrect { get { return m_DoesResurrect; } set { m_DoesResurrect = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool _ChangesSkillCaps { get { return m_ChangesSkillCaps; } set { m_ChangesSkillCaps = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool _ChangesSkills { get { return m_ChangesSkills; } set { m_ChangesSkills = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool _ChangesStats { get { return m_ChangesStats; } set { m_ChangesStats = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool _ChangesHue { get { return m_ChangesHue; } set { m_ChangesHue = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool _SkillsGiveItems { get { return m_SkillsGiveItems; } set { m_SkillsGiveItems = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int _SkillsItemsMin { get { return m_SkillsItemsMin; } set { m_SkillsItemsMin = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool _DoesRename { get { return m_DoesRename; } set { m_DoesRename = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public string NameGiven { get { return m_NameGiven; } set { m_NameGiven = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public List<Item> AddedItems { get { return m_AddedItems; } set { m_AddedItems = value; } }

        #endregion

        #region " Constructors "

        //Base Constructor
        [Constructable]
        public AP_EventGate()
            : this(false)
        {
            Movable = false;
            Hue = 0x2D1;
            Light = LightType.Circle300;
            m_AddedItems = new List<Item>();
        }

        [Constructable]
        public AP_EventGate(bool decays, Point3D loc, Map map)
            : this(decays)
        {
            MoveToWorld(loc, map);
            Effects.PlaySound(loc, map, 0x20E);
        }

        [Constructable]
        public AP_EventGate(bool decays)
            : base(new Point3D(1401, 1625, 28), Map.Trammel)
        {
            Dispellable = false;
            ItemID = 0x1FD4;

            if (decays)
            {
                m_Decays = true;
                m_DecayTime = DateTime.Now + TimeSpan.FromMinutes(2.0);

                m_Timer = new InternalTimer(this, m_DecayTime);
                m_Timer.Start();
            }
        }

        public override string DefaultName
        {
            get
            {
                return m_GateMessage;
            }
        }

        public AP_EventGate(Serial serial)
            : base(serial)
        {
        }
        #endregion

        #region " Methods "
        public override void OnDoubleClick(Mobile from)
        {
            if (!from.Player)
                return;

            // When players double-click on the gate, they see the Stats and Skills 
            // they will get, as well as any other Gate effects.
            // GM's and up will also be able to make edits to the Gate using the Gump.
            from.SendGump(new AP_GateDialogGump(m_Str, m_Dex, m_Int, m_GateMessage, m_DoesRename, m_NameGiven,
                 gAllSkills, gAllSkillCaps, from, m_DoesResurrect, m_ChangesStats, m_ChangesSkills, m_TempGate,
                 m_SkillsGiveItems, m_ChangesSkillCaps, m_SkillsItemsMin, m_TitleAdds, m_TitleToAdd,
                m_PlayerCountLimited, m_PlayerCountMax, m_PlayersPassed, m_PlayerCountExeededMessage, this));
        }

        public override void UseGate(Mobile m)
        {
            // If you are casting a spell, you are too busy to use the gate.
            if (m.Spell != null)
            {
                m.SendLocalizedMessage(1049616);
            }
            else if (m_PlayerCountMax <= m_PlayersPassed && m_PlayerCountLimited)
            {
                m.SendMessage(m_PlayerCountExeededMessage);
            }
            else
            {
                DeleteTempGateItemsOn(m);

                if (_ChangesStats)
                {
                    m.RawStr = this.m_Str;
                    m.RawDex = this.m_Dex;
                    m.RawInt = this.m_Int;
                }

                if (_DoesResurrect && !m.Alive)
                {
                    m.Resurrect();
                }

                if (_DoesRename)
                {
                    string nam = "";
                    if (m.Female)
                        nam = NameList.RandomName("female");
                    else
                        nam = NameList.RandomName("male");

                    if (NameGiven == "")
                        m.Name = nam;
                    else
                        m.Name = NameGiven;
                }

                if (_DoesTeleport)
                {
                    m.Map = this.TargetMap;
                    m.Location = this.Target;
                }

                if (_ChangesSkills)
                {
                    Server.Skills skills = m.Skills;
                    for (int i = 0; i < skills.Length; ++i) skills[i].Base = gAllSkills[i];
                }

                if (_ChangesSkillCaps)
                {
                    Server.Skills skills = m.Skills;
                    for (int i = 0; i < skills.Length; ++i) skills[i].Cap = gAllSkillCaps[i];
                }

                if (_ChangesHue) m.Hue = this.Hue;

                if (_SkillsGiveItems)
                {
                    Server.Skills s = m.Skills;
                    for (int i = 0; i < s.Length; ++i)
                        if (gAllSkills[i] >= _SkillsItemsMin)
                            SkillsItems((SkillName)i, m);
                }
                if (TempGate)
                {
                    TempGateItem tgi = new TempGateItem();

                    if (_ChangesStats)
                    {
                        tgi.Str = m.RawStr;
                        tgi.Dex = m.RawDex;
                        tgi.Int = m.RawInt;
                        tgi.ChangesStats = true;
                    }
                    else
                        tgi.ChangesStats = false;

                    if (_DoesRename)
                    {
                        tgi.OldName = m.Name;
                        tgi.DoesRename = true;
                    }
                    else
                        tgi.DoesRename = false;

                    if (_DoesTeleport)
                    {
                        tgi.OldMap = this.Map;
                        tgi.OldLocation = this.Location;
                        tgi.DoesTeleport = true;
                    }
                    else
                        tgi.DoesTeleport = false;

                    if (_ChangesSkills)
                    {
                        Server.Skills skills = m.Skills;
                        for (int i = 0; i < skills.Length; ++i) tgi.gAllSkills[i] = skills[i].Base;
                        tgi.ChangesSkills = true;
                    }
                    else
                        tgi.ChangesSkills = false;

                    if (_ChangesSkillCaps)
                    {
                        Server.Skills skills = m.Skills;
                        for (int i = 0; i < skills.Length; ++i) tgi.gAllSkillCaps[i] = skills[i].Cap;
                        tgi.ChangesSkillCaps = true;
                    }
                    else
                        tgi.ChangesSkillCaps = false;

                    if (_ChangesHue)
                    {
                        tgi.OldHue = m.Hue;
                        tgi.ChangesHue = true;
                    }
                    else
                        tgi.ChangesHue = false;

                    if (m_TitleAdds)
                    {
                        tgi.OldTitle = m.Title;
                        tgi.TitleAdds = true;
                    }
                    else
                        tgi.TitleAdds = false;

                    if (_SkillsGiveItems)
                    {
                        tgi.AddedItems = m_AddedItems;
                    }

                    tgi.GateSerial = this.Serial.Value;

                    m.AddToBackpack(tgi);
                }

                if (m_TitleAdds)
                {
                    m.Title = this.m_TitleToAdd;
                }


                m.PlaySound(0x1FE);
                m_PlayersPassed++;
            }
        }

        public static void DeleteTempGateItemsOn(Mobile m)
        {
            Container pack = m.Backpack;
            List<TempGateItem> list = new List<TempGateItem>();
            if (pack != null)
            {
                foreach (Item i in pack.Items)
                    if (i is TempGateItem)
                        list.Add(i as TempGateItem);

                if (list.Count > 0)
                {
                    int count = list.Count;
                    for (int x = 0; x < count; x++)
                        list[x].Delete();
                }
            }
        }

        public override void OnDelete()
        {
            List<Item> tempGateItems = new List<Item>();
            foreach (Item i in World.Items.Values)
            {
                if (i is TempGateItem && (i as TempGateItem).GateSerial == this.Serial.Value) tempGateItems.Add(i);
            }
            int count = tempGateItems.Count;
            if (count > 0)
            {
                for (int x = 0; x < count; x++)
                {
                    try { tempGateItems[x].Delete(); }
                    catch { }
                }
                Console.WriteLine("{0} TempGateItems were found and deleted.", count);
            }
            tempGateItems.Clear();
            base.OnDelete();
        }

        public override void OnAfterDelete()
        {
            if (m_Timer != null)
                m_Timer.Stop();

            base.OnAfterDelete();
        }

        public override bool OnMoveOver(Mobile m)
        {
            if (m.Player)
            {
                CheckGate(m, 0);
            }

            return true;
        }
        #endregion

        #region " Skill Items "
        private void EquipItem(Item item, Mobile m)
        {
            if (!Core.AOS)
                item.LootType = LootType.Newbied;

            if (m != null && m.EquipItem(item))
            {
                AddedItems.Add(item);
                return;
            }

            Container pack = m.Backpack;

            if (pack != null)
            {
                pack.DropItem(item);
                AddedItems.Add(item);
            }
            else
                item.Delete();
        }

        private void PackItem(Item item, Mobile m)
        {
            if (!Core.AOS)
                item.LootType = LootType.Newbied;

            Container pack = m.Backpack;

            if (pack != null)
            {
                pack.DropItem(item);
                AddedItems.Add(item);
            }
            else
                item.Delete();
        }

        private void PackInstrument(Mobile m)
        {
            switch (Utility.Random(6))
            {
                case 0: PackItem(new Drums(), m); break;
                case 1: PackItem(new Harp(), m); break;
                case 2: PackItem(new LapHarp(), m); break;
                case 3: PackItem(new Lute(), m); break;
                case 4: PackItem(new Tambourine(), m); break;
                case 5: PackItem(new TambourineTassel(), m); break;
            }
        }

        private void SkillsItems(SkillName skill, Mobile m)
        {
            bool elf = (m.Race == Server.Race.Elf);

            switch (skill)
            {
                case SkillName.Alchemy:
                    {
                        PackItem(new Bottle(4), m);
                        PackItem(new MortarPestle(), m);

                        int hue = Utility.RandomPinkHue();

                        if (elf)
                        {
                            if (m.Female)
                                EquipItem(new FemaleElvenRobe(hue), m);
                            else
                                EquipItem(new MaleElvenRobe(hue), m);
                        }
                        else
                        {
                            EquipItem(new Robe(Utility.RandomPinkHue()), m);
                        }
                        break;
                    }
                case SkillName.Anatomy:
                    {
                        PackItem(new Bandage(3), m);

                        int hue = Utility.RandomYellowHue();

                        if (elf)
                        {
                            if (m.Female)
                                EquipItem(new FemaleElvenRobe(hue), m);
                            else
                                EquipItem(new MaleElvenRobe(hue), m);
                        }
                        else
                        {
                            EquipItem(new Robe(Utility.RandomPinkHue()), m);
                        }
                        break;
                    }
                case SkillName.AnimalLore:
                    {


                        int hue = Utility.RandomBlueHue();

                        if (elf)
                        {
                            EquipItem(new WildStaff(), m);

                            if (m.Female)
                                EquipItem(new FemaleElvenRobe(hue), m);
                            else
                                EquipItem(new MaleElvenRobe(hue), m);
                        }
                        else
                        {
                            EquipItem(new ShepherdsCrook(), m);
                            EquipItem(new Robe(hue), m);
                        }
                        break;
                    }
                case SkillName.Archery:
                    {
                        PackItem(new Arrow(25), m);

                        if (elf)
                            EquipItem(new ElvenCompositeLongbow(), m);
                        else
                            EquipItem(new Bow(), m);

                        break;
                    }
                case SkillName.ArmsLore:
                    {
                        if (elf)
                        {
                            switch (Utility.Random(3))
                            {
                                case 0: EquipItem(new Leafblade(), m); break;
                                case 1: EquipItem(new RuneBlade(), m); break;
                                case 2: EquipItem(new DiamondMace(), m); break;
                            }
                        }
                        else
                        {
                            switch (Utility.Random(3))
                            {
                                case 0: EquipItem(new Kryss(), m); break;
                                case 1: EquipItem(new Katana(), m); break;
                                case 2: EquipItem(new Club(), m); break;
                            }
                        }

                        break;
                    }
                case SkillName.Begging:
                    {
                        if (elf)
                            EquipItem(new WildStaff(), m);
                        else
                            EquipItem(new GnarledStaff(), m);
                        break;
                    }
                case SkillName.Blacksmith:
                    {
                        PackItem(new Tongs(), m);
                        PackItem(new Pickaxe(), m);
                        PackItem(new Pickaxe(), m);
                        PackItem(new IronIngot(50), m);
                        EquipItem(new HalfApron(Utility.RandomYellowHue()), m);
                        break;
                    }
                case SkillName.Bushido:
                    {
                        EquipItem(new Hakama(), m);
                        EquipItem(new Kasa(), m);
                        EquipItem(new BookOfBushido(), m);
                        break;
                    }
                case SkillName.Fletching:
                    {
                        PackItem(new Board(14), m);
                        PackItem(new Feather(5), m);
                        PackItem(new Shaft(5), m);
                        break;
                    }
                case SkillName.Camping:
                    {
                        PackItem(new Bedroll(), m);
                        PackItem(new Kindling(5), m);
                        break;
                    }
                case SkillName.Carpentry:
                    {
                        PackItem(new Board(10), m);
                        PackItem(new Saw(), m);
                        EquipItem(new HalfApron(Utility.RandomYellowHue()), m);
                        break;
                    }
                case SkillName.Cartography:
                    {
                        PackItem(new BlankMap(), m);
                        PackItem(new BlankMap(), m);
                        PackItem(new BlankMap(), m);
                        PackItem(new BlankMap(), m);
                        PackItem(new Sextant(), m);
                        break;
                    }
                case SkillName.Chivalry:
                    {
                        EquipItem(new BookOfChivalry(), m);
                        break;
                    }
                case SkillName.Cooking:
                    {
                        PackItem(new Kindling(2), m);
                        PackItem(new RawLambLeg(), m);
                        PackItem(new RawChickenLeg(), m);
                        PackItem(new RawFishSteak(), m);
                        PackItem(new SackFlour(), m);
                        PackItem(new Pitcher(BeverageType.Water), m);
                        break;
                    }
                case SkillName.DetectHidden:
                    {
                        EquipItem(new Cloak(0x455), m);
                        break;
                    }
                case SkillName.Discordance:
                    {
                        PackInstrument(m);
                        break;
                    }
                case SkillName.Fencing:
                    {
                        if (elf)
                            EquipItem(new Leafblade(), m);
                        else
                            EquipItem(new Kryss(), m);

                        break;
                    }
                case SkillName.Fishing:
                    {
                        EquipItem(new FishingPole(), m);

                        int hue = Utility.RandomYellowHue();

                        if (elf)
                        {
                            Item i = new Circlet();
                            i.Hue = hue;
                            EquipItem(i, m);
                        }
                        else
                        {
                            EquipItem(new FloppyHat(Utility.RandomYellowHue()), m);
                        }

                        break;
                    }
                case SkillName.Healing:
                    {
                        PackItem(new Bandage(50), m);
                        PackItem(new Scissors(), m);
                        break;
                    }
                case SkillName.Herding:
                    {
                        if (elf)
                            EquipItem(new WildStaff(), m);
                        else
                            EquipItem(new ShepherdsCrook(), m);

                        break;
                    }
                case SkillName.Hiding:
                    {
                        EquipItem(new Cloak(0x455), m);
                        break;
                    }
                case SkillName.Inscribe:
                    {
                        PackItem(new BlankScroll(2), m);
                        PackItem(new BlueBook(), m);
                        break;
                    }
                case SkillName.ItemID:
                    {
                        if (elf)
                            EquipItem(new WildStaff(), m);
                        else
                            EquipItem(new GnarledStaff(), m);
                        break;
                    }
                case SkillName.Lockpicking:
                    {
                        PackItem(new Lockpick(20), m);
                        break;
                    }
                case SkillName.Lumberjacking:
                    {
                        EquipItem(new Hatchet(), m);
                        break;
                    }
                case SkillName.Macing:
                    {
                        if (elf)
                            EquipItem(new DiamondMace(), m);
                        else
                            EquipItem(new Club(), m);

                        break;
                    }
                case SkillName.Magery:
                    {
                        BagOfReagents regs = new BagOfReagents(30);

                        if (!Core.AOS)
                        {
                            foreach (Item item in regs.Items)
                                item.LootType = LootType.Newbied;
                        }

                        PackItem(regs, m);

                        regs.LootType = LootType.Regular;

                        Spellbook book = new Spellbook((ulong)0x382A8C38);

                        EquipItem(book, m);

                        book.LootType = LootType.Blessed;

                        if (elf)
                        {
                            EquipItem(new Circlet(), m);

                            if (m.Female)
                                EquipItem(new FemaleElvenRobe(Utility.RandomBlueHue()), m);
                            else
                                EquipItem(new MaleElvenRobe(Utility.RandomBlueHue()), m);
                        }
                        else
                        {
                            EquipItem(new WizardsHat(), m);
                            EquipItem(new Robe(Utility.RandomBlueHue()), m);
                        }

                        break;
                    }
                case SkillName.Mining:
                    {
                        PackItem(new Pickaxe(), m);
                        break;
                    }
                case SkillName.Musicianship:
                    {
                        PackInstrument(m);
                        break;
                    }
                case SkillName.Ninjitsu:
                    {
                        EquipItem(new Hakama(0x2C3), m);	//Only ninjas get the hued one.
                        EquipItem(new Kasa(), m);
                        EquipItem(new BookOfNinjitsu(), m);
                        break;
                    }
                case SkillName.Parry:
                    {
                        EquipItem(new WoodenShield(), m);
                        break;
                    }
                case SkillName.Peacemaking:
                    {
                        PackInstrument(m);
                        break;
                    }
                case SkillName.Poisoning:
                    {
                        PackItem(new LesserPoisonPotion(), m);
                        PackItem(new LesserPoisonPotion(), m);
                        break;
                    }
                case SkillName.Provocation:
                    {
                        PackInstrument(m);
                        break;
                    }
                case SkillName.Snooping:
                    {
                        PackItem(new Lockpick(20), m);
                        break;
                    }
                case SkillName.SpiritSpeak:
                    {
                        EquipItem(new Cloak(0x455), m);
                        break;
                    }
                case SkillName.Stealing:
                    {
                        PackItem(new Lockpick(20), m);
                        break;
                    }
                case SkillName.Swords:
                    {
                        if (elf)
                            EquipItem(new RuneBlade(), m);
                        else
                            EquipItem(new Katana(), m);

                        break;
                    }
                case SkillName.Tactics:
                    {
                        if (elf)
                            EquipItem(new RuneBlade(), m);
                        else
                            EquipItem(new Katana(), m);

                        break;
                    }
                case SkillName.Tailoring:
                    {
                        PackItem(new BoltOfCloth(), m);
                        PackItem(new SewingKit(), m);
                        break;
                    }
                case SkillName.Tracking:
                    {
                        if (m != null)
                        {
                            Item shoes = m.FindItemOnLayer(Layer.Shoes);

                            if (shoes != null)
                                shoes.Delete();
                        }

                        int hue = Utility.RandomYellowHue();

                        if (elf)
                            EquipItem(new ElvenBoots(hue), m);
                        else
                            EquipItem(new Boots(hue), m);

                        EquipItem(new SkinningKnife(), m);
                        break;
                    }
                case SkillName.Veterinary:
                    {
                        PackItem(new Bandage(5), m);
                        PackItem(new Scissors(), m);
                        break;
                    }
                case SkillName.Wrestling:
                    {
                        if (elf)
                            EquipItem(new LeafGloves(), m);
                        else
                            EquipItem(new LeatherGloves(), m);

                        break;
                    }
            }
        }
        #endregion

        #region " InternalTimer "
        private class InternalTimer : Timer
        {
            private Item m_Item;

            public InternalTimer(Item item, DateTime end)
                : base(end - DateTime.Now)
            {
                m_Item = item;
            }

            protected override void OnTick()
            {
                m_Item.Delete();
            }
        }
        #endregion

        #region " Serialization "
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)4); // version

            writer.Write((bool)m_EventGate); // version 4

            writer.Write((int)m_AddedItems.Count); // version 3
            if (m_AddedItems.Count > 0)
            {
                writer.WriteItemList(m_AddedItems);
            }

            writer.Write((bool)m_TempGate); // version 2

            for (int x = 0; x < gAllSkillCaps.Length; x++) writer.Write((int)gAllSkillCaps[x]); // version 0 and 1
            writer.Write((bool)m_ChangesSkillCaps);
            writer.Write((bool)m_DoesRename);
            writer.Write((string)m_NameGiven);

            writer.Write((bool)m_PlayerCountLimited);
            writer.Write((int)m_PlayerCountMax);
            writer.Write((int)m_PlayersPassed);
            writer.Write((string)m_PlayerCountExeededMessage);

            writer.Write((bool)m_TitleAdds);
            writer.Write((string)m_TitleToAdd);

            writer.Write((bool)m_DoesTeleport);
            writer.Write((bool)m_DoesResurrect);
            writer.Write((bool)m_ChangesSkills);
            writer.Write((bool)m_ChangesStats);
            writer.Write((bool)m_ChangesHue);
            writer.Write((bool)m_SkillsGiveItems);
            writer.Write((int)m_SkillsItemsMin);
            writer.Write((int)m_Int);
            writer.Write((int)m_Dex);
            writer.Write((int)m_Str);
            for (int x = 0; x < gAllSkills.Length; x++) writer.Write((int)gAllSkills[x]);
            writer.Write((string)m_GateMessage);

            writer.Write((bool)m_Decays);
            if (m_Decays) writer.WriteDeltaTime(m_DecayTime);
        }
        #endregion

        #region " Deserialization "
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            gAllSkills = new int[58];
            gAllSkillCaps = new int[58];

            m_AddedItems = new List<Item>();
            if (version >= 4)
            {
                m_EventGate = reader.ReadBool();
            }

            if (version >= 3)
            {
                int count = reader.ReadInt();
                if (count > 0)
                {
                    ArrayList a = reader.ReadItemList();
                    for (int x = 0; x < a.Count; x++)
                    {
                        m_AddedItems.Add(a[x] as Item);
                    }
                }
            }

            if (version >= 2) m_TempGate = reader.ReadBool();

            for (int y = 0; y < gAllSkillCaps.Length; y++) gAllSkillCaps[y] = reader.ReadInt();
            m_ChangesSkillCaps = reader.ReadBool();
            bool capsBoolRemoved;
            if (version == 0)
            {
                capsBoolRemoved = reader.ReadBool();
            }
            m_DoesRename = reader.ReadBool();
            m_NameGiven = reader.ReadString();
            m_PlayerCountLimited = reader.ReadBool();
            m_PlayerCountMax = reader.ReadInt();
            m_PlayersPassed = reader.ReadInt();
            m_PlayerCountExeededMessage = reader.ReadString();
            m_TitleAdds = reader.ReadBool();
            m_TitleToAdd = reader.ReadString();
            m_DoesTeleport = reader.ReadBool();
            m_DoesResurrect = reader.ReadBool();
            m_ChangesSkills = reader.ReadBool();
            m_ChangesStats = reader.ReadBool();
            m_ChangesHue = reader.ReadBool();
            m_SkillsGiveItems = reader.ReadBool();
            m_SkillsItemsMin = reader.ReadInt();
            m_Int = reader.ReadInt();
            m_Dex = reader.ReadInt();
            m_Str = reader.ReadInt();
            int capsRemoved;
            if (version == 0)
            {
                capsRemoved = reader.ReadInt();
                capsRemoved = reader.ReadInt();
                capsRemoved = reader.ReadInt();
            }
            for (int y = 0; y < gAllSkills.Length; y++) gAllSkills[y] = reader.ReadInt();
            m_GateMessage = reader.ReadString();
            m_Decays = reader.ReadBool();

            if (m_Decays)
            {
                m_DecayTime = reader.ReadDeltaTime();

                m_Timer = new InternalTimer(this, m_DecayTime);
                m_Timer.Start();
            }
        }
        #endregion
    }

    #region " Gate Dialog Gump "
    public class AP_GateDialogGump : Gump
    {
        // ** AMOUNT is a constant value, so will be the same for each Gate **
        // This is how much Skills, Stats and Caps will increase/decrease when
        // we press the '+' and '-' buttons. Usually, this should be either 5 or 10.
        // Anything lower than 5 would require ALOT OF clicking, but give more precision.
        private const int AMOUNT = 5;
        private const int GreenHue = 0x40;
        private const int RedHue = 0x20;
        private static string[] stNames = new string[] { "Alchemy", "Anatomy", 
				"AnimalLore", "ItemID", "ArmsLore", "Parry", "Begging", "Blacksmith",
				"Fletching", "Peacemaking", "Camping", "Carpentry", "Cartography",
				"Cooking", "DetectHidden", "Discordance", "EvalInt", "Healing",
				"Fishing", "Forensics", "Herding", "Hiding", "Provocation",
				"Inscribe", "Lockpicking", "Magery", "MagicResist", "Tactics",
				"Snooping", "Musicianship", "Poisoning", "Archery", "SpiritSpeak",
				"Stealing", "Tailoring", "AnimalTaming", "TasteID", "Tinkering",
				"Tracking", "Veterinary", "Swords", "Macing", "Fencing", "Wrestling",
				"Lumberjacking", "Mining", "Meditation", "Stealth", "RemoveTrap",
				"Necromancy", "Focus", "Chivalry", "Bushido", "Ninjitsu", "SpellWeaving",
                "Mysticism","Imbuing","Throwing"}; //These last 3 added for RunUO 2.2 Support

        private static int m_Str, m_Dex, m_Int;
        private static int m_SkillMin, m_PlayerCountMax, m_PlayersPassed;
        private static int m_Page = 1;
        private static string m_Message, m_TitleToAdd, m_PlayerCountExeededMessage, m_NameGiven;
        private static int[] m_Skills, m_SkillCaps;
        private static Mobile m_From;
        private static bool b_Res, b_Stats, b_Skills, b_SkillCaps, b_Gives, b_Renames, b_Temp;
        private static bool b_TitleAdds, b_PlayerCountLimited;
        private static AP_EventGate m_Sender;

        public static void initialize()
        {

        }

        public AP_GateDialogGump(int mStr, int mDex, int mInt, string mMessage, bool bRenames, string mNameGiven,
            int[] mSkills, int[] mSkillCaps, Mobile from, bool bRes, bool bStats, bool bSkills, bool bTemp,
            bool bGives, bool bSkillCaps, int mSkillMin, bool bTitleAdds, string mTitleToAdd,
            bool bPlayerCountLimited, int mPlayerCountMax, int mPlayersPassed,
            string mPlayerCountExeededMessage, AP_EventGate sender)
            : base(48, 36)
        {

            AddBackground(65, 205, 720, 340, 5054);
            Closable = true;
            Resizable = false;

            bool GM = (from.AccessLevel >= AccessLevel.GameMaster);
            m_Str = mStr;
            m_Dex = mDex;
            m_Int = mInt;
            m_SkillMin = mSkillMin;
            m_PlayerCountMax = mPlayerCountMax;
            m_PlayersPassed = mPlayersPassed;
            m_Message = mMessage;
            m_NameGiven = mNameGiven;
            b_Renames = bRenames;
            b_Temp = bTemp;
            m_TitleToAdd = mTitleToAdd;
            m_PlayerCountExeededMessage = mPlayerCountExeededMessage;
            m_Skills = new int[58];
            for (int i = 0; i < m_Skills.Length; i++) m_Skills[i] = mSkills[i];
            m_SkillCaps = new int[58];
            for (int i = 0; i < m_SkillCaps.Length; i++) m_SkillCaps[i] = mSkillCaps[i];
            m_From = from;
            b_Res = bRes;
            b_Stats = bStats;
            b_Skills = bSkills;
            b_SkillCaps = bSkillCaps;
            b_Gives = bGives;
            b_TitleAdds = bTitleAdds;
            b_PlayerCountLimited = bPlayerCountLimited;
            m_Sender = sender;
            string stStr = m_Str.ToString();
            string stDex = m_Dex.ToString();
            string stInt = m_Int.ToString();
            string[] stSkills = new string[58];
            for (int i = 0; i < stSkills.Length; i++) stSkills[i] = m_Skills[i].ToString();
            string[] stSkillCaps = new string[58];
            for (int i = 0; i < stSkillCaps.Length; i++) stSkillCaps[i] = m_SkillCaps[i].ToString();

            AddPage(0);

            AddImageTiled(25, 175, 50, 45, 0xCE);   //Top left corner
            AddImageTiled(67, 175, 715, 44, 0xC9);  //Top bar
            AddImageTiled(782, 175, 43, 45, 0xCF);   //Top right corner
            AddImageTiled(25, 219, 44, 320, 0xCA);  //Left side
            AddImageTiled(782, 219, 44, 320, 0xCB);  //Right side
            AddImageTiled(25, 539, 44, 43, 0xCC);   //Lower left corner
            AddImageTiled(67, 539, 715, 43, 0xE9);  //Lower Bar
            AddImageTiled(782, 539, 43, 43, 0xCD);   //Lower right corner

            // ...if the Gate gives Items for Skills...
            if (bGives) { AddLabelCropped(70, 525, 70, 35, GreenHue, "ITEMS ON"); }
            else { AddLabelCropped(70, 525, 70, 35, RedHue, "ITEMS OFF"); }
            if (GM) AddButton(70, 545, 4005, 4007, 51, GumpButtonType.Reply, 0);

            // ...if the Gate does Resurrection...
            if (bRes) { AddLabelCropped(155, 525, 110, 35, GreenHue, "RESURRECTS ON"); }
            else { AddLabelCropped(155, 525, 110, 35, RedHue, "RESURRECTS OFF"); }
            if (GM) AddButton(155, 545, 4005, 4007, 52, GumpButtonType.Reply, 0);

            AddLabelCropped(395, 525, 250, 20, 200, m_Message);
            if (GM) AddButton(395, 545, 4005, 4007, 60, GumpButtonType.Reply, 0);

            // ...if the Gate is a Temp Gate (for Events, etc.)...
            if (bTemp) { AddLabelCropped(285, 525, 110, 20, GreenHue, "TEMP GATE ON"); }
            else { AddLabelCropped(285, 525, 110, 20, RedHue, "TEMP GATE OFF"); }
            if (GM) AddButton(285, 545, 4005, 4007, 81, GumpButtonType.Reply, 0);

            if (m_Page == 1)
            {
                AddPage(1);
                // ...if the Gate affects a player's Skills...
                if (bSkills) { AddLabelCropped(620, 190, 110, 20, GreenHue, "SETS SKILLS ON"); }
                else { AddLabelCropped(620, 190, 110, 20, RedHue, "SETS SKILLS OFF"); }
                if (GM) AddButton(750, 190, 4005, 4007, 53, GumpButtonType.Reply, 0);

                string name = "New Name: " + m_NameGiven;
                if (b_Renames) AddLabelCropped(250, 190, 500, 20, 200, name);
                if (GM) AddButton(220, 190, 4005, 4007, 71, GumpButtonType.Reply, 0);

                if (b_Renames) { AddLabelCropped(100, 190, 120, 20, GreenHue, "DOES RENAME"); }
                else { AddLabelCropped(100, 190, 120, 20, RedHue, "DOES NOT RENAME"); }
                if (GM) AddButton(70, 190, 4005, 4007, 72, GumpButtonType.Reply, 0);

                int inCount = 0;
                int sk;
                for (int inLeft = 85; inLeft <= 645; inLeft += 140)
                {
                    for (int inDown = 225; inDown <= 500; inDown += 25)
                    {
                        try
                        {
                            if (bGives && (m_Skills[inCount] >= m_SkillMin)) sk = 777; else sk = inLeft * 3;
                            AddLabelCropped(inLeft, inDown, 85, 20, (inLeft * 3), stNames[inCount]);
                            AddLabelCropped((inLeft + 85), inDown, 20, 20, sk, stSkills[inCount++]);
                            if (GM)
                            {
                                if ((m_Skills[inCount - 1] - AMOUNT) >= 0)
                                    AddButton((inLeft + 108), inDown, 5401, 5401, (inCount + 99), GumpButtonType.Reply, 0);
                                if ((m_Skills[inCount - 1] + AMOUNT) <= m_SkillCaps[inCount - 1])
                                    AddButton((inLeft + 123), inDown, 5402, 5402, (inCount + 199), GumpButtonType.Reply, 0);
                            }
                        }
                        catch
                        {
                        }
                    }
                }

                AddLabelCropped(700, 525, 85, 20, 777, "Next Page ->");
                AddButton(750, 545, 4005, 4007, 2, GumpButtonType.Reply, 0);

                // ...if the Gate affects a player's Stats...
                if (bStats)
                {
                    AddLabelCropped(45, 470, 40, 20, GreenHue, "ON");
                    AddLabelCropped(50, 440, 40, 10, GreenHue, "^");
                    AddLabelCropped(52, 450, 40, 20, GreenHue, "|");
                }
                else
                {
                    AddLabelCropped(45, 470, 40, 20, RedHue, "OFF");
                    AddLabelCropped(50, 440, 40, 10, RedHue, "^");
                    AddLabelCropped(52, 450, 40, 20, RedHue, "|");
                }
                if (GM) AddButton(45, 490, 4005, 4007, 50, GumpButtonType.Reply, 0);

                AddLabelCropped(45, 240, 100, 20, 350, "STR");
                AddLabelCropped(45, 260, 100, 20, 350, stStr);
                if (GM)
                {
                    AddButton(43, 280, 5401, 5401, 31, GumpButtonType.Reply, 0);
                    AddButton(58, 280, 5402, 5402, 41, GumpButtonType.Reply, 0);
                }
                AddLabelCropped(45, 310, 100, 20, 450, "DEX");
                AddLabelCropped(45, 330, 100, 20, 450, stDex);
                if (GM)
                {
                    AddButton(43, 350, 5401, 5401, 32, GumpButtonType.Reply, 0);
                    AddButton(58, 350, 5402, 5402, 42, GumpButtonType.Reply, 0);
                }
                AddLabelCropped(45, 380, 100, 20, 550, "INT");
                AddLabelCropped(45, 400, 100, 20, 550, stInt);
                if (GM)
                {
                    AddButton(43, 420, 5401, 5401, 33, GumpButtonType.Reply, 0);
                    AddButton(58, 420, 5402, 5402, 43, GumpButtonType.Reply, 0);
                }
            }
            else
            {
                AddPage(1);
                // ...if the Gate affects a player's Caps...
                if (b_SkillCaps) { AddLabelCropped(620, 190, 100, 20, GreenHue, "SETS CAPS ON"); }
                else { AddLabelCropped(620, 190, 100, 20, RedHue, "SETS CAPS OFF"); }
                if (GM) AddButton(750, 190, 4005, 4007, 54, GumpButtonType.Reply, 0);

                int inCount = 0;
                int sk;
                for (int inLeft = 85; inLeft <= 645; inLeft += 140)
                {
                    for (int inDown = 225; inDown <= 500; inDown += 25)
                    {
                        try
                        {
                            sk = inLeft * 3;
                            AddLabelCropped(inLeft, inDown, 85, 20, (inLeft * 3), stNames[inCount]);
                            AddLabelCropped((inLeft + 85), inDown, 20, 20, sk, stSkillCaps[inCount++]);
                            if (GM)
                            {
                                if (((m_SkillCaps[inCount - 1] - AMOUNT) >= 0) && ((m_SkillCaps[inCount - 1] - AMOUNT) >= m_Skills[inCount - 1]))
                                    AddButton((inLeft + 108), inDown, 5401, 5401, (inCount + 299), GumpButtonType.Reply, 0);
                                AddButton((inLeft + 123), inDown, 5402, 5402, (inCount + 399), GumpButtonType.Reply, 0);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                string title = "Title to Give: " + m_TitleToAdd;
                if (b_TitleAdds) AddLabelCropped(250, 190, 500, 20, 200, title);
                if (GM) AddButton(220, 190, 4005, 4007, 61, GumpButtonType.Reply, 0);

                if (b_TitleAdds) { AddLabelCropped(100, 190, 120, 20, GreenHue, "GIVES TITLE ON"); }
                else { AddLabelCropped(100, 190, 120, 20, RedHue, "GIVES TITLE OFF"); }
                if (GM) AddButton(70, 190, 4005, 4007, 62, GumpButtonType.Reply, 0);

                AddLabelCropped(700, 525, 85, 20, 777, "<- Prev Page");
                AddButton(750, 545, 4005, 4007, 1, GumpButtonType.Reply, 0);
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile m = state.Mobile;

            m.CloseGump(typeof(AP_GateDialogGump));
            if (info.ButtonID > 399)
            {
                m_Sender.gAllSkillCaps[info.ButtonID - 400] += AMOUNT;
                m_SkillCaps[info.ButtonID - 400] += AMOUNT;
                RestartGump();
            }
            else if (info.ButtonID > 299)
            {
                m_Sender.gAllSkillCaps[info.ButtonID - 300] -= AMOUNT;
                m_SkillCaps[info.ButtonID - 300] -= AMOUNT;
                RestartGump();
            }
            else if (info.ButtonID > 199)
            {
                m_Sender.gAllSkills[info.ButtonID - 200] += AMOUNT;
                m_Skills[info.ButtonID - 200] += AMOUNT;
                RestartGump();
            }
            else if (info.ButtonID > 99)
            {
                m_Sender.gAllSkills[info.ButtonID - 100] -= AMOUNT;
                m_Skills[info.ButtonID - 100] -= AMOUNT;
                RestartGump();
            }
            else if (info.ButtonID == 31)
            {
                m_Sender.Set_STAT_Str -= AMOUNT;
                m_Str -= AMOUNT;
                RestartGump();
            }
            else if (info.ButtonID == 32)
            {
                m_Sender.Set_STAT_Dex -= AMOUNT;
                m_Dex -= AMOUNT;
                RestartGump();
            }
            else if (info.ButtonID == 33)
            {
                m_Sender.Set_STAT_Int -= AMOUNT;
                m_Int -= AMOUNT;
                RestartGump();
            }
            else if (info.ButtonID == 41)
            {
                m_Sender.Set_STAT_Str += AMOUNT;
                m_Str += AMOUNT;
                RestartGump();
            }
            else if (info.ButtonID == 42)
            {
                m_Sender.Set_STAT_Dex += AMOUNT;
                m_Dex += AMOUNT;
                RestartGump();
            }
            else if (info.ButtonID == 43)
            {
                m_Sender.Set_STAT_Int += AMOUNT;
                m_Int += AMOUNT;
                RestartGump();
            }
            else if (info.ButtonID == 50)
            {
                m_Sender._ChangesStats = !m_Sender._ChangesStats;
                b_Stats = !b_Stats;
                RestartGump();
            }
            else if (info.ButtonID == 51)
            {
                m_Sender._SkillsGiveItems = !m_Sender._SkillsGiveItems;
                b_Gives = !b_Gives;
                RestartGump();
            }
            else if (info.ButtonID == 52)
            {
                m_Sender._DoesResurrect = !m_Sender._DoesResurrect;
                b_Res = !b_Res;
                RestartGump();
            }
            else if (info.ButtonID == 53)
            {
                m_Sender._ChangesSkills = !m_Sender._ChangesSkills;
                b_Skills = !b_Skills;
                RestartGump();
            }
            else if (info.ButtonID == 54)
            {
                m_Sender._ChangesSkillCaps = !m_Sender._ChangesSkillCaps;
                b_SkillCaps = !b_SkillCaps;
                RestartGump();
            }
            else if (info.ButtonID == 2)
            {
                m_Page = 2;
                RestartGump();
            }
            else if (info.ButtonID == 1)
            {
                m_Page = 1;
                RestartGump();
            }
            else if (info.ButtonID == 60)
            {
                m_From.SendMessage("Enter the new Gate Message.");
                m_From.Prompt = new RenamePrompt(PromptEntry.Message);
            }
            else if (info.ButtonID == 61)
            {
                m_From.SendMessage("Enter the new Title to Give Players.");
                m_From.Prompt = new RenamePrompt(PromptEntry.Title);
            }
            else if (info.ButtonID == 62)
            {
                m_Sender.MC_TitleAdds = !m_Sender.MC_TitleAdds;
                b_TitleAdds = !b_TitleAdds;
                RestartGump();
            }
            else if (info.ButtonID == 71)
            {
                m_From.SendMessage("Enter the new Name to Give Players.");
                m_From.Prompt = new RenamePrompt(PromptEntry.Name);
            }
            else if (info.ButtonID == 72)
            {
                m_Sender._DoesRename = !m_Sender._DoesRename;
                b_Renames = !b_Renames;
                RestartGump();
            }
            else if (info.ButtonID == 81)
            {
                m_Sender.TempGate = !m_Sender.TempGate;
                b_Temp = !b_Temp;
                RestartGump();
            }

        }

        private class RenamePrompt : Prompt
        {
            private PromptEntry m_Entry;

            public RenamePrompt(PromptEntry entry)
            {
                m_Entry = entry;
            }

            public override void OnResponse(Mobile from, string text)
            {
                if (m_Entry == PromptEntry.Message)
                {
                    if (text.Length <= 70)
                    {
                        m_Sender._GateMessage = text;
                        m_Sender.InvalidateProperties();
                        m_Message = text;
                        from.SendMessage("Message changed.");
                    }
                    else
                        from.SendMessage("Too long (max 70 characters.)");
                }
                else if (m_Entry == PromptEntry.Title)
                {
                    if (text.Length <= 22)
                    {
                        m_Sender.MC_TitleToAdd = text;
                        m_TitleToAdd = text;
                        from.SendMessage("Title changed.");
                    }
                    else
                        from.SendMessage("Too long (max 22 characters.)");
                }
                else if (m_Entry == PromptEntry.Name)
                {
                    if (text.Length <= 22)
                    {
                        m_Sender.NameGiven = text;
                        m_NameGiven = text;
                        from.SendMessage("Name changed.");
                    }
                    else
                        from.SendMessage("Too long (max 22 characters.)");
                }
                RestartGump();
            }
        }

        private enum PromptEntry
        {
            Message,
            Title,
            Name,
            CountExceeded
        }

        private static void RestartGump()
        {
            m_From.SendGump(new AP_GateDialogGump(m_Str, m_Dex, m_Int, m_Message, b_Renames, m_NameGiven, m_Skills, m_SkillCaps,
                m_From, b_Res, b_Stats, b_Skills, b_Temp, b_Gives, b_SkillCaps, m_SkillMin, b_TitleAdds, m_TitleToAdd,
                b_PlayerCountLimited, m_PlayerCountMax, m_PlayersPassed, m_PlayerCountExeededMessage, m_Sender));
        }
    }
    #endregion

    #region " TempGateItem "
    public class TempGateItem : Item
    {

        #region " Variables "
        private bool m_DoesRename = false;
        private string m_OldName = "";
        private bool m_DoesTeleport = true;
        private Point3D m_OldLocation;
        private Map m_OldMap;
        private bool m_DoesResurrect = true;
        private bool m_ChangesSkills = true;
        private bool m_ChangesSkillCaps = true;
        private bool m_ChangesStats = true;
        private bool m_ChangesHue = false;
        private int m_OldHue = 0;
        private int m_Int = 10;
        private int m_Dex = 10;
        private int m_Str = 10;
        private bool m_TitleAdds = false;
        private string m_OldTitle = "";

        private int m_GateSerial;
        public int GateSerial { get { return m_GateSerial; } set { m_GateSerial = value; } }

        private List<Item> m_AddedItems;

        public double[] gAllSkills = new double[58];
        public double[] gAllSkillCaps = new double[58];

        // Title Props
        public string OldTitle { get { return m_OldTitle; } set { m_OldTitle = value; } }
        public bool TitleAdds { get { return m_TitleAdds; } set { m_TitleAdds = value; } }
        public bool DoesRename { get { return m_DoesRename; } set { m_DoesRename = value; } }
        public string OldName { get { return m_OldName; } set { m_OldName = value; } }

        public int Int { get { return m_Int; } set { m_Int = value; } }
        public int Dex { get { return m_Dex; } set { m_Dex = value; } }
        public int Str { get { return m_Str; } set { m_Str = value; } }
        public bool DoesTeleport { get { return m_DoesTeleport; } set { m_DoesTeleport = value; } }
        public Point3D OldLocation { get { return m_OldLocation; } set { m_OldLocation = value; } }
        public Map OldMap { get { return m_OldMap; } set { m_OldMap = value; } }
        public bool DoesResurrect { get { return m_DoesResurrect; } set { m_DoesResurrect = value; } }
        public bool ChangesSkillCaps { get { return m_ChangesSkillCaps; } set { m_ChangesSkillCaps = value; } }
        public bool ChangesSkills { get { return m_ChangesSkills; } set { m_ChangesSkills = value; } }
        public bool ChangesStats { get { return m_ChangesStats; } set { m_ChangesStats = value; } }
        public bool ChangesHue { get { return m_ChangesHue; } set { m_ChangesHue = value; } }
        public int OldHue { get { return m_OldHue; } set { m_OldHue = value; } }
        public List<Item> AddedItems { get { return m_AddedItems; } set { m_AddedItems = value; } }

        #endregion

        #region " TempGate Methods "
        [Constructable]
        public TempGateItem()
            : base(0xFA9)
        {
            Name = "APG Temp Item"; 
            Weight = 0.0; 
            Visible = false; 
            Movable = false;
            m_AddedItems = new List<Item>();
        }

        public TempGateItem(Serial serial) : base(serial) { }

        public override void OnDelete()
        {
            Mobile owner = null;
            if (this.Parent is Backpack)
            {
                Backpack b = this.Parent as Backpack;
                if (b.Parent is Mobile)
                    owner = b.Parent as Mobile;
            }

            if (owner != null)
                Activate(owner);

            base.OnDelete();
        }

        public void Activate(Mobile m)
        {
            if (ChangesStats)
            {
                m.RawStr = this.m_Str;
                m.RawDex = this.m_Dex;
                m.RawInt = this.m_Int;
            }

            if (DoesRename)
            {
                m.Name = OldName;
            }
            

            if (DoesTeleport)
            {
                m.Map = OldMap;
                m.Location = OldLocation;
            }

            if (ChangesSkills)
            {
                Server.Skills skills = m.Skills;
                for (int i = 0; i < skills.Length; ++i) skills[i].Base = gAllSkills[i];
            }

            if (ChangesSkillCaps)
            {
                Server.Skills skills = m.Skills;
                for (int i = 0; i < skills.Length; ++i) skills[i].Cap = gAllSkillCaps[i];
            }

            if (ChangesHue) m.Hue = OldHue;

            if (TitleAdds)
            {
                m.Title = OldTitle;
            }

            if (AddedItems.Count > 0)
            {
                int deleted = 0;
                int count = AddedItems.Count;
                try
                {
                    for (int x = 0; x < count; x++)
                    {
                        AddedItems[x].Delete();
                        deleted++;
                    }
                    AddedItems.Clear();
                }
                catch { }
                Console.WriteLine("{0} out of {1} items found and deleted from {2}.", deleted, count, m.Name);
            }
        }
        #endregion

        #region " Serialization "
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)2); // version

            writer.Write((int)m_GateSerial); // version 2

            writer.Write((int)m_AddedItems.Count); // version 1
            if (m_AddedItems.Count > 0)
            {
                writer.WriteItemList(m_AddedItems);
            }

            for (int x = 0; x < gAllSkillCaps.Length; x++) writer.Write((double)gAllSkillCaps[x]);
            writer.Write((bool)m_ChangesSkillCaps);
            writer.Write((bool)m_DoesRename);
            writer.Write((string)m_OldName);
            writer.Write((bool)m_TitleAdds);
            writer.Write((string)m_OldTitle);
            writer.Write((bool)m_DoesTeleport);
            writer.Write((Point3D)m_OldLocation);
            writer.Write((Map)m_OldMap);
            writer.Write((bool)m_DoesResurrect);
            writer.Write((bool)m_ChangesSkills);
            writer.Write((bool)m_ChangesStats);
            writer.Write((bool)m_ChangesHue);
            writer.Write((int)m_OldHue);
            writer.Write((int)m_Int);
            writer.Write((int)m_Dex);
            writer.Write((int)m_Str);
            for (int x = 0; x < gAllSkills.Length; x++) writer.Write((double)gAllSkills[x]);
        }
        #endregion

        #region " Deserialization "
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            gAllSkills = new double[58];
            gAllSkillCaps = new double[58];

            m_AddedItems = new List<Item>();

            switch (version)
            {
                case 2:
                    {
                        m_GateSerial = reader.ReadInt();
                        goto case 1;
                    }
                case 1:
                    {
                        int count = reader.ReadInt();
                        if (count > 0)
                        {
                            ArrayList a = reader.ReadItemList();
                            try
                            {
                                for (int x = 0; x < count; x++)
                                {
                                    m_AddedItems.Add(a[x] as Item);
                                }
                            }
                            catch { }
                        }
                        goto case 0;
                    }
                case 0:
                    {
                        for (int y = 0; y < gAllSkillCaps.Length; y++) gAllSkillCaps[y] = reader.ReadDouble();
                        m_ChangesSkillCaps = reader.ReadBool();
                        m_DoesRename = reader.ReadBool();
                        m_OldName = reader.ReadString();
                        m_TitleAdds = reader.ReadBool();
                        m_OldTitle = reader.ReadString();
                        m_DoesTeleport = reader.ReadBool();
                        m_OldLocation = reader.ReadPoint3D();
                        m_OldMap = reader.ReadMap();
                        m_DoesResurrect = reader.ReadBool();
                        m_ChangesSkills = reader.ReadBool();
                        m_ChangesStats = reader.ReadBool();
                        m_ChangesHue = reader.ReadBool();
                        m_OldHue = reader.ReadInt();
                        m_Int = reader.ReadInt();
                        m_Dex = reader.ReadInt();
                        m_Str = reader.ReadInt();
                        for (int y = 0; y < gAllSkills.Length; y++) gAllSkills[y] = reader.ReadDouble();
                        break;
                    }
            }

        }
        #endregion
    }
    #endregion
}