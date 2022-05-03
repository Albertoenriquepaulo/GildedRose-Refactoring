namespace GildedRose_AfterRefactoring
{
    public class UpdateNormalItemQualityCommand : UpdateItemQualityCommandBaseClass
    {
        protected override void UpdateQuality(Item item)
        {
            if (item.Name == Constant.AgedBrie || item.Name == Constant.Backstage) return;

            DecreaseQuality(item, (item.SellIn < Constant.MinSellIn ? 2 : 1));
        }

        
    }
}
