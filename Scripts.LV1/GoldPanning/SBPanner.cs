/* SBPanner for Gold Panning System */

using System; 
using System.Collections.Generic; 
using Server.Items;

namespace Server.Mobiles
{
    public class SBPanner : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBPanner()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(GoldPan), 1500, 10, 0x9D7, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(SmallGoldNugget), 300);
                Add(typeof(MediumGoldNugget), 1500);
                Add(typeof(LargeGoldNugget), 5000);
                Add(typeof(GoldBrick), 10000);
            }
        }
    }
}