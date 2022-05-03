using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose_AfterRefactoring
{
    public class UpdateBakstagePassesItemQualityCommand : UpdateItemQualityCommandBaseClass
    {
        protected override void UpdateQuality(Item item)
        {
            if (item.Name != Constant.Backstage) return;

            if (item.SellIn < Constant.MinSellIn)
                item.Quality = Constant.MinQuality;
            else
                IncreaseQuality(item, GetTimesToIncrease(item.Quality, item.SellIn));
        }

        private static int GetTimesToIncrease(int quality, int sellIn)
        {
            var doesQualityLackOneUnitToReachMaxQuality = quality == Constant.MaxQuality - 1;
            return doesQualityLackOneUnitToReachMaxQuality ? Constant.SingleIncrease : quality < Constant.MaxQuality
                                ? (sellIn > 0 && sellIn <= 5 ? Constant.TripleIncrease : (sellIn > 5 && sellIn <= 10 ? Constant.DoubleIncrease : Constant.SingleIncrease))
                                : Constant.SingleIncrease;
        }
    }
}
