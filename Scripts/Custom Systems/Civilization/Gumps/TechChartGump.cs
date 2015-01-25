using System;
using System.Collections.Generic;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.UOC.Items;
using Server.UOC.Concepts;

namespace Server.UOC
{
    public class TechChartGump : Gump
    {
        public TechChartGump()
            : base(30, 30)
        {
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
            for (int page = 0; page < 6; page++)
            {
                AddPage(page);
                if (page == 0)
                {
                    AddBackground(40, 40, 720, 500, 9200);
                    AddLabel(96, 50, 62, "ANCIENT");
                    AddButton(72, 48, 2118, 2117, 0, GumpButtonType.Page, 1);
                    AddLabel(209, 50, 35, "MYSTIC");
                    AddButton(185, 48, 2118, 2117, 0, GumpButtonType.Page, 2);
                    AddLabel(348, 50, 132, "FEUDAL");
                    AddButton(324, 48, 2118, 2117, 0, GumpButtonType.Page, 3);
                    AddLabel(464, 50, 146, "ENLIGHTENED");
                    AddButton(440, 48, 2118, 2117, 0, GumpButtonType.Page, 4);
                    AddLabel(602, 50, 183, @"RENAISSANCE");
                    AddButton(578, 48, 2118, 2117, 0, GumpButtonType.Page, 5);
                }
                if (page > 0)
                {
                    AddLabel(71, 76, 62, "Horsebackriding");
                    AddLabel(91, 117, 62, "Fishing...........");
                    AddLabel(91, 157, 62, "Hunting......");
                    AddLabel(90, 205, 62, "Firemaking");
                    AddLabel(99, 355, 62, "TheWheel");
                    AddLabel(94, 312, 62, "Mysticism");
                    AddLabel(84, 273, 62, "StoryTelling");
                    AddLabel(109, 441, 62, "Mining");
                    AddLabel(102, 400, 62, "Pottery");
                    AddButton(77, 163, 9010, 9010, (int)Buttons.Hunting, GumpButtonType.Reply, 0);
                    AddButton(79, 122, 9010, 9010, (int)Buttons.Fishing, GumpButtonType.Reply, 0);
                    AddButton(79, 211, 9010, 9010, (int)Buttons.Firemaking, GumpButtonType.Reply, 0);
                    AddButton(74, 277, 9010, 9010, (int)Buttons.StoryTelling, GumpButtonType.Reply, 0);
                    AddButton(82, 317, 9010, 9010, (int)Buttons.Mysticism, GumpButtonType.Reply, 0);
                    AddButton(91, 360, 9010, 9010, (int)Buttons.TheWheel, GumpButtonType.Reply, 0);
                    AddButton(90, 405, 9010, 9010, (int)Buttons.Pottery, GumpButtonType.Reply, 0);
                    AddButton(97, 444, 9010, 9010, (int)Buttons.Mining, GumpButtonType.Reply, 0);
                    AddButton(63, 78, 9010, 9010, (int)Buttons.Horsebackriding, GumpButtonType.Reply, 0);
                    AddImage(181, 90, 22404);
                    AddImage(177, 171, 22404);
                    AddImage(167, 268, 22400);
                    AddImage(186, 132, 22404);
                    AddImage(167, 364, 22404);
                    AddImage(170, 291, 22404);
                    AddImage(165, 329, 22404);
                    AddImage(165, 213, 22404);
                    AddImage(155, 408, 22404);
                    AddImage(153, 450, 22404);
                }
                if (page > 1)
                {
                    AddLabel(212, 101, 35, "AnimalHusbandry");
                    AddLabel(185, 457, 35, "Roadbuilding");
                    AddLabel(205, 256, 35, "Writing....");
                    AddLabel(205, 305, 35, "Music");
                    AddLabel(200, 339, 35, "Philosophy...");
                    AddLabel(197, 380, 35, "Astronomy");
                    AddLabel(194, 419, 35, "Weaving");
                    AddLabel(222, 147, 35, "Farming.........");
                    AddLabel(220, 179, 35, "Archery.....");
                    AddLabel(205, 223, 35, "Metalworking");
                    AddLabel(205, 207, 35, "Chemistry");
                    AddButton(212, 146, 9010, 9010, (int)Buttons.Farming, GumpButtonType.Reply, 0);
                    AddButton(208, 183, 9010, 9010, (int)Buttons.Archery, GumpButtonType.Reply, 0);
                    AddButton(176, 461, 9010, 9010, (int)Buttons.Roadbuilding, GumpButtonType.Reply, 0);
                    AddButton(183, 422, 9010, 9010, (int)Buttons.Weaving, GumpButtonType.Reply, 0);
                    AddButton(185, 385, 9010, 9010, (int)Buttons.Astronomy, GumpButtonType.Reply, 0);
                    AddButton(190, 343, 9010, 9010, (int)Buttons.Philosophy, GumpButtonType.Reply, 0);
                    AddButton(195, 308, 9010, 9010, (int)Buttons.Music, GumpButtonType.Reply, 0);
                    AddButton(193, 260, 9010, 9010, (int)Buttons.Writing, GumpButtonType.Reply, 0);
                    AddButton(193, 229, 9010, 9010, (int)Buttons.Metalworking, GumpButtonType.Reply, 0);
                    AddButton(206, 103, 9010, 9010, (int)Buttons.AnimalHusbandry, GumpButtonType.Reply, 0);
                    AddButton(193, 212, 9010, 9010, (int)Buttons.Chemistry, GumpButtonType.Reply, 0);
                    AddImage(259, 418, 22400);
                    AddImage(317, 147, 22400);
                    AddImage(325, 115, 22404);
                    AddImage(269, 455, 22400);
                    AddImage(281, 337, 22400);
                    AddImage(273, 379, 22400);
                    AddImage(294, 236, 22404);
                    AddImage(296, 187, 22404);
                    AddImage(274, 269, 22404);
                }
                if (page > 2)
                {
                    AddLabel(353, 129, 132, "Agriculture");
                    AddLabel(335, 257, 132, "Engineering........");
                    AddLabel(313, 287, 132, "Alphabet....................");
                    AddLabel(301, 439, 132, "Masonry");
                    AddLabel(333, 234, 132, "Feudalism....");
                    AddLabel(338, 196, 132, "SeigeEngines");
                    AddLabel(295, 407, 132, "Sailing");
                    AddLabel(303, 372, 132, "Calendar");
                    AddLabel(312, 335, 132, "Theology");
                    AddLabel(311, 316, 132, "Code Of Laws......");
                    AddButton(325, 200, 9010, 9010, (int)Buttons.SeigeEngines, GumpButtonType.Reply, 0);
                    AddButton(323, 239, 9010, 9010, (int)Buttons.Feudalism, GumpButtonType.Reply, 0);
                    AddButton(322, 258, 9010, 9010, (int)Buttons.Engineering, GumpButtonType.Reply, 0);
                    AddButton(299, 292, 9010, 9010, (int)Buttons.Alphabet, GumpButtonType.Reply, 0);
                    AddButton(292, 445, 9010, 9010, (int)Buttons.Masonry, GumpButtonType.Reply, 0);
                    AddButton(344, 134, 9010, 9010, (int)Buttons.Agriculture, GumpButtonType.Reply, 0);
                    AddButton(283, 413, 9010, 9010, (int)Buttons.Sailing, GumpButtonType.Reply, 0);
                    AddButton(299, 321, 9010, 9010, (int)Buttons.CodeOfLaws, GumpButtonType.Reply, 0);
                    AddButton(302, 339, 9010, 9010, (int)Buttons.Theology, GumpButtonType.Reply, 0);
                    AddButton(296, 375, 9010, 9010, (int)Buttons.Calendar, GumpButtonType.Reply, 0);
                    AddImage(447, 254, 22400);
                    AddImage(382, 350, 22404);
                    AddImage(364, 388, 22404);
                    AddImage(427, 191, 22400);
                    AddImage(421, 231, 22400);
                    AddImage(424, 327, 22404);
                    AddImage(454, 297, 22404);
                }
                if (page > 3)
                {
                    AddLabel(456, 211, 146, "......Monarchy");
                    AddLabel(483, 240, 146, "Construction");
                    AddLabel(493, 307, 146, "Currency");
                    AddLabel(456, 336, 146, ".....Communism");
                    AddLabel(417, 366, 146, ".................Religion");
                    AddLabel(399, 400, 146, ".................Magic Arts");
                    AddLabel(463, 171, 146, "Shipbuilding");
                    AddButton(445, 217, 9010, 9010, (int)Buttons.Monarchy, GumpButtonType.Reply, 0);
                    AddButton(472, 245, 9010, 9010, (int)Buttons.Construction, GumpButtonType.Reply, 0);
                    AddButton(479, 311, 9010, 9010, (int)Buttons.Currency, GumpButtonType.Reply, 0);
                    AddButton(446, 339, 9010, 9010, (int)Buttons.Communism, GumpButtonType.Reply, 0);
                    AddButton(405, 366, 9010, 9010, (int)Buttons.Religion, GumpButtonType.Reply, 0);
                    AddButton(388, 403, 9010, 9010, (int)Buttons.MagicArts, GumpButtonType.Reply, 0);
                    AddButton(451, 177, 9010, 9010, (int)Buttons.Shipbuilding, GumpButtonType.Reply, 0);
                    AddImage(562, 303, 22400);
                    AddImage(549, 207, 22400);
                    AddImage(545, 180, 22404);
                }
                if (page > 4)
                {
                    AddLabel(584, 191, 183, "Republic");
                    AddLabel(687, 171, 183, "Democracy");
                    AddLabel(599, 288, 183, "Banking");
                    AddButton(575, 198, 9010, 9010, (int)Buttons.Republic, GumpButtonType.Reply, 0);
                    AddButton(674, 178, 9010, 9010, (int)Buttons.Democracy, GumpButtonType.Reply, 0);
                    AddButton(588, 294, 9010, 9010, (int)Buttons.Banking, GumpButtonType.Reply, 0);
                    AddImage(648, 187, 22400);
                }
            }

        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile as Mobile;
            if (info.ButtonID > 1)
            {
                from.SendGump(new Civilopedia(from, Civilopedia.Category.Technology, info.ButtonID));
            }
        }

        private enum Buttons
        {
            Agriculture = 300, Alphabet = 301, AnimalHusbandry = 302, Archery = 303, Astronomy = 304, Banking = 305,
            Calendar = 306, Chemistry = 307, CodeOfLaws = 308, Communism = 309, Construction = 310, Currency = 311,
            Democracy = 312, Engineering = 313, Farming = 314, Firemaking = 315, Fishing = 316, Feudalism = 317,
            Horsebackriding = 318, Hunting = 319, MagicArts = 320, Masonry = 321, Metalworking = 322,
            Mining = 323, Monarchy = 324, Music = 325, Mysticism = 326, Philosophy = 327, Pottery = 328,
            Religion = 329, Republic = 330, Roadbuilding = 331, Sailing = 332, SeigeEngines = 333, Shipbuilding = 334,
            StoryTelling = 335, Theology = 336, TheWheel = 337, Weaving = 338, Writing = 339,
        }

    }
}











