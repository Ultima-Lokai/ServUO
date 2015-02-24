namespace Server.TimeSystem
{
    using Server;
    using Server.Gumps;
    using Server.Mobiles;
    using System;

    public class ShowToolThree : Gump
    {
        public ShowToolThree(PlayerMobile owner) : base(0, 0x69)
        {
            string str;
            PlayerMobile mobile = owner;
            int num = 0;
            int num2 = 0;
            int num3 = 200;
            double num4 = 5.0;
            int num5 = (AosAttributes.GetValue(owner, AosAttribute.LowerRegCost) > num3) ? num3 : AosAttributes.GetValue(owner, AosAttribute.LowerRegCost);
            if ((5.0 + (0.5 * (((double) (120 - owner.get_Dex())) / 10.0))) >= num4)
            {
                double num1 = ((double) (120 - owner.get_Dex())) / 10.0;
            }
            base.set_Closable(true);
            base.set_Disposable(false);
            base.set_Dragable(true);
            base.set_Resizable(false);
            base.AddPage(0);
            num = 0;
            num2 = 0;
            base.AddBackground(num, num2, 300, 470, 0x251c);
            num = 2;
            num2 = 6;
            base.AddImageTiled(num, num2, 0x128, 0x1d1, 0xa8e);
            num = 2;
            num2 = 6;
            base.AddAlphaRegion(num, num2, 0x128, 0x1d1);
            num = 15;
            num2 = 15;
            base.AddHtml(num, num2, 170, 20, "<basefont color=#FFFFFF><center>人物属性</center></font>", false, false);
            num = 15;
            num2 = 0x23;
            base.AddLabel(num, num2, 0x40, string.Format("力量:{0}+{1}", owner.get_RawStr(), owner.get_Str() - owner.get_RawStr()));
            num = 0x5f;
            num2 = 0x23;
            base.AddLabel(num, num2, 0x40, string.Format("敏捷:{0}+ {1}", owner.get_RawDex(), owner.get_Dex() - owner.get_RawDex()));
            num = 15;
            num2 = 0x37;
            base.AddLabel(num, num2, 0x40, string.Format("智力:{0}+{1}", owner.get_RawInt(), owner.get_Int() - owner.get_RawInt()));
            num = 15;
            num2 = 0x4b;
            base.AddLabel(num, num2, 0x40, string.Format("善恶:{0}", owner.get_Karma()));
            num = 0x5f;
            num2 = 0x4b;
            base.AddLabel(num, num2, 0x40, string.Format("声望:{0}", owner.get_Fame()));
            num = 15;
            num2 = 0x5f;
            base.AddLabel(num, num2, 0x40, string.Format("降低药材消耗:{0}%", num5));
            base.AddLabel(15, 0x73, 0x4eb, "饥饿");
            base.AddImageTiled(15, 0x87, 150, 14, 0x2340);
            base.AddImage(15, 0x87, 0x233f);
            base.AddImage(0xa5, 0x87, 0x2341);
            double num6 = ((double) owner.get_Hunger()) / 20.0;
            int num7 = (int) (148.0 * num6);
            base.AddImage(15 + num7, 0x87, 0x233e, 0x4eb);
            base.AddLabel(15, 0x9b, 0x4f0, "口渴");
            base.AddImageTiled(15, 0xaf, 150, 14, 0x2340);
            base.AddImage(15, 0xaf, 0x233f);
            base.AddImage(0xa5, 0xaf, 0x2341);
            double num8 = ((double) owner.get_Thirst()) / 20.0;
            int num9 = (int) (148.0 * num8);
            base.AddImage(15 + num9, 0xaf, 0x233e, 0x4f0);
            base.AddLabel(15, 0xc3, 0x480, "体力");
            base.AddImageTiled(15, 0xd7, 150, 14, 0x2340);
            base.AddImage(15, 0xd7, 0x233f);
            base.AddImage(0xa5, 0xd7, 0x2341);
            double num10 = ((double) owner.Sleep) / 30.0;
            int num11 = (int) (148.0 * num10);
            base.AddImage(15 + num11, 0xd7, 0x233e, 0x480);
            num = 15;
            num2 = 0xeb;
            base.AddLabel(num, num2, 0x40, string.Format("铁匠订单剩余: {0}:{1}:{2}", owner.NextSmithBulkOrder.Hours, owner.NextSmithBulkOrder.Minutes, owner.NextSmithBulkOrder.Seconds));
            num = 15;
            num2 = 0xff;
            base.AddLabel(num, num2, 0x40, string.Format("裁缝订单剩余: {0}:{1}:{2}", owner.NextTailorBulkOrder.Hours, owner.NextTailorBulkOrder.Minutes, owner.NextTailorBulkOrder.Seconds));
            num = 15;
            num2 = 0x113;
            base.AddLabel(num, num2, 0x40, string.Format("悬赏订单剩余: {0}:{1}:{2}", owner.NextKillingAnimalBulkOrder.Hours, owner.NextKillingAnimalBulkOrder.Minutes, owner.NextKillingAnimalBulkOrder.Seconds));
            num = 15;
            num2 = 0x127;
            base.AddLabel(num, num2, 0x40, string.Format("驯兽订单剩余: {0}:{1}:{2}", owner.NextTamingBulkOrder.Hours, owner.NextTamingBulkOrder.Minutes, owner.NextTamingBulkOrder.Seconds));
            num = 15;
            num2 = 0x13b;
            base.AddLabel(num, num2, 0x40, string.Format("杀人数: {0}", owner.get_Kills()));
            num = 15;
            num2 = 0x14f;
            base.AddLabel(num, num2, 0x40, "你的坐标是:");
            num = 15;
            num2 = 0x163;
            base.AddLabel(num, num2, 0x40, string.Format("大陆: {0}", owner.get_Map()));
            str = str = System.GetTime(mobile.get_X(), false);
            num = 15;
            num2 = 0x177;
            base.AddLabel(num, num2, 0x488, string.Format("大陆时间: {0} ", str));
            num = 15;
            num2 = 0x18b;
            base.AddLabel(num, num2, 0x20, string.Format("Ｘ:{0}-Ｙ:{1}-Ｚ:{2}", owner.get_X(), owner.get_Y(), owner.get_Z()));
            num = 15;
            num2 = 0x19f;
            base.AddLabel(num, num2, 0x110, string.Format("帐号日期:", new object[0]));
            num = 15;
            num2 = 0x1b3;
            base.AddLabel(num, num2, 0x110, string.Format("{0}天{1}小时{2}分钟{3}秒", new object[] { owner.GameTime.Days, owner.GameTime.Hours, owner.GameTime.Minutes, owner.GameTime.Seconds }));
        }
    }
}

