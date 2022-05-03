
namespace GildedRose_AfterRefactoring
{
    public class UpdateAgedBrieItemQualityCommand : UpdateItemQualityCommandBaseClass
    {
        protected override void UpdateQuality(Item item)
        {
            if (item.Name != Constant.AgedBrie) return;

            IncreaseQuality(item, Constant.SingleIncrease);

            if (item.SellIn < Constant.MinSellIn)
                IncreaseQuality(item, Constant.SingleIncrease);
        }
    }
}
