using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using System;

namespace Server.Gumps
{
    public class ShowToolThree : Gump
    {
        public ShowToolThree(PlayerMobile owner)
            : base(0, 0x69)
        {
            string str;
            int num = 0;
            int num2 = 0;
            int num3 = 200;
            double num4 = 5.0;
            int num5 = (AosAttributes.GetValue(owner, AosAttribute.LowerRegCost) > num3) ? num3 : AosAttributes.GetValue(owner, AosAttribute.LowerRegCost);
            if ((5.0 + (0.5 * (((double)(120 - owner.Dex)) / 10.0))) >= num4)
            {
                double num1 = ((double)(120 - owner.Dex)) / 10.0;
            }
            Closable = true;
            Disposable = false;
            Dragable = true;
            Resizable = false;
            AddPage(0);
            num = 0;
            num2 = 0;
            AddBackground(num, num2, 300, 470, 0x251c);
            num = 2;
            num2 = 6;
            AddImageTiled(num, num2, 0x128, 0x1d1, 0xa8e);
            num = 2;
            num2 = 6;
            AddAlphaRegion(num, num2, 0x128, 0x1d1);
            num = 15;
            num2 = 15;
            AddHtml(num, num2, 170, 20, "<basefont color=#FFFFFF><center>Character Attributes</center></font>", false, false);
            num = 15;
            num2 = 0x23;
            AddLabel(num, num2, 0x40, string.Format("Power: {0} + {1}", owner.RawStr, owner.Str - owner.RawStr));
            num = 0x5f;
            num2 = 0x23;
            AddLabel(num, num2, 0x40, string.Format("Agility: {0} + {1}", owner.RawDex, owner.Dex - owner.RawDex));
            num = 15;
            num2 = 0x37;
            AddLabel(num, num2, 0x40, string.Format("Intellect: {0} + {1}", owner.RawInt, owner.Int - owner.RawInt));
            num = 15;
            num2 = 0x4b;
            AddLabel(num, num2, 0x40, string.Format("Karma: {0}", owner.Karma));
            num = 0x5f;
            num2 = 0x4b;
            AddLabel(num, num2, 0x40, string.Format("Reputation: {0}", owner.Fame));
            num = 15;
            num2 = 0x5f;
            AddLabel(num, num2, 0x40, string.Format("Lower Reagent Cost: {0}%", num5));
            AddLabel(15, 0x73, 0x4eb, "Hunger");
            AddImageTiled(15, 0x87, 150, 14, 0x2340);
            AddImage(15, 0x87, 0x233f);
            AddImage(0xa5, 0x87, 0x2341);
            double num6 = ((double)owner.Hunger) / 20.0;
            int num7 = (int)(148.0 * num6);
            AddImage(15 + num7, 0x87, 0x233e, 0x4eb);
            AddLabel(15, 0x9b, 0x4f0, "Thirst");
            AddImageTiled(15, 0xaf, 150, 14, 0x2340);
            AddImage(15, 0xaf, 0x233f);
            AddImage(0xa5, 0xaf, 0x2341);
            double num8 = ((double)owner.Thirst) / 20.0;
            int num9 = (int)(148.0 * num8);
            AddImage(15 + num9, 0xaf, 0x233e, 0x4f0);
            //AddLabel(15, 0xc3, 0x480, "体力");
            //AddImageTiled(15, 0xd7, 150, 14, 0x2340);
            //AddImage(15, 0xd7, 0x233f);
            //AddImage(0xa5, 0xd7, 0x2341);
            //double num10 = ((double) owner.Sleep) / 30.0;
            //int num11 = (int) (148.0 * num10);
            //AddImage(15 + num11, 0xd7, 0x233e, 0x480);
            num = 15;
            num2 = 0xeb;
            AddLabel(num, num2, 0x40, string.Format("Next Smith BOD: {0}:{1}:{2}", owner.NextSmithBulkOrder.Hours, owner.NextSmithBulkOrder.Minutes, owner.NextSmithBulkOrder.Seconds));
            num = 15;
            num2 = 0xff;
            AddLabel(num, num2, 0x40, string.Format("Next Tailor BOD: {0}:{1}:{2}", owner.NextTailorBulkOrder.Hours, owner.NextTailorBulkOrder.Minutes, owner.NextTailorBulkOrder.Seconds));
            num = 15;
            num2 = 0x113;
            //AddLabel(num, num2, 0x40, string.Format("悬赏订单剩余: {0}:{1}:{2}", owner.NextKillingAnimalBulkOrder.Hours, owner.NextKillingAnimalBulkOrder.Minutes, owner.NextKillingAnimalBulkOrder.Seconds));
            num = 15;
            num2 = 0x127;
            //AddLabel(num, num2, 0x40, string.Format("驯兽订单剩余: {0}:{1}:{2}", owner.NextTamingBulkOrder.Hours, owner.NextTamingBulkOrder.Minutes, owner.NextTamingBulkOrder.Seconds));
            num = 15;
            num2 = 0x13b;
            AddLabel(num, num2, 0x40, string.Format("Kills: {0}", owner.Kills));
            num = 15;
            num2 = 0x14f;
            AddLabel(num, num2, 0x40, "Your location is:");
            num = 15;
            num2 = 0x163;
            AddLabel(num, num2, 0x40, string.Format("Map: {0}", owner.Map));
            //str = str = System.GetTime(mobile.X, false);
            num = 15;
            num2 = 0x177;
            //AddLabel(num, num2, 0x488, string.Format("大陆时间: {0} ", str));
            num = 15;
            num2 = 0x18b;
            AddLabel(num, num2, 0x20, string.Format("Ｘ:{0}-Ｙ:{1}-Ｚ:{2}", owner.X, owner.Y, owner.Z));
            num = 15;
            num2 = 0x19f;
            AddLabel(num, num2, 0x110, "Account Time:");
            num = 15;
            num2 = 0x1b3;
            AddLabel(num, num2, 0x110, string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds.", new object[] { owner.GameTime.Days, owner.GameTime.Hours, owner.GameTime.Minutes, owner.GameTime.Seconds }));
        }
    }
}

