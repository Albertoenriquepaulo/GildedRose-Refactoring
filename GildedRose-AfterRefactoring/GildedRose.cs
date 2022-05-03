using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose_AfterRefactoring
{
    public class GildedRose
    {
        readonly IList<Item> _items;

        private const string BACKSTAGE_PASSES_TO_ATAFKAL80ETC_CONCERT = "Backstage passes to a TAFKAL80ETC concert";
        private const string AGED_BRIE = "Aged Brie";
        private const string SULFURAS_AND_HAND_OF_RAGNAROS = "Sulfuras, Hand of Ragnaros";
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALITY = 0;
        private const int MIN_SELL_IN = 0;
        private const int SINGLE_INCREASE = 1;
        private const int DOUBLE_INCREASE = 2;
        private const int TRIPLE_INCREASE = 3;

        Dictionary<string, UpdateItemQualityCommandBaseClass> _factory = new Dictionary<string, UpdateItemQualityCommandBaseClass>
        {
            { Constant.Backstage, new UpdateBakstagePassesItemQualityCommand() },
            { Constant.AgedBrie, new UpdateAgedBrieItemQualityCommand() },
            { Constant.Sulfuras, new UpdateSulfurasItemQualityCommand() },
            { Constant.Dexterity, new UpdateNormalItemQualityCommand() },
            { Constant.Eixir, new UpdateNormalItemQualityCommand() },
            { Constant.Conjured, new UpdateConjuredItemQualityCommand() },

        };

        public GildedRose(IList<Item> Items)
        {
            this._items = Items;
        }

        public void UpdateQuality()
        {

            foreach (var item in _items)
            {
                var key = item.Name;
                if (!_factory.ContainsKey(key)) continue;
                _factory[item.Name].SetQuality(item);
            }
        }


        //This code could be remove, stay here to info the code we rich before passing to the command pattern
        private void UpdateNormalItemQuality(Item item)
        {
            if (item.Name == AGED_BRIE || item.Name == BACKSTAGE_PASSES_TO_ATAFKAL80ETC_CONCERT) return;
            
            DecreaseQuality(item, (item.SellIn < MIN_SELL_IN ? 2 : 1));
        }

        private void UpdateAgedBrieQuality(Item item)
        {
            if (item.Name != AGED_BRIE) return;

            IncreaseQuality(item, SINGLE_INCREASE);

            if (item.SellIn < MIN_SELL_IN)
                IncreaseQuality(item, SINGLE_INCREASE);
        }

        private void UpdateBakstagePassesQuality(Item item)
        {
            if (item.Name != BACKSTAGE_PASSES_TO_ATAFKAL80ETC_CONCERT) return;

            if (item.SellIn < MIN_SELL_IN)
                item.Quality = MIN_QUALITY;
            else
                IncreaseQuality(item, GetTimesToIncrease(item.Quality, item.SellIn));
        }

        private static int GetTimesToIncrease(int quality, int sellIn)
        {
            var doesQualityLackOneUnitToReachMaxQuality = quality == MAX_QUALITY - 1;
            return doesQualityLackOneUnitToReachMaxQuality ? SINGLE_INCREASE : quality < MAX_QUALITY
                                ? (sellIn > 0 && sellIn <= 5 ? TRIPLE_INCREASE : (sellIn > 5 && sellIn <= 10 ? DOUBLE_INCREASE : SINGLE_INCREASE))
                                : SINGLE_INCREASE;
        }

        private void DecreaseSellIn(Item item)
        {
            if (item.Name == SULFURAS_AND_HAND_OF_RAGNAROS) return;
         
            item.SellIn = item.SellIn - 1;
        }

        private void IncreaseQuality(Item item, int timesToIncrease)
        {
            if (item.Quality >= MAX_QUALITY) return;

            if (item.Quality < MAX_QUALITY)
                item.Quality += 1 * timesToIncrease;
        }

        private void DecreaseQuality(Item item, int timesToDecrease)
        {
            if (item.Quality > MIN_QUALITY)
            {
                if (item.Name != SULFURAS_AND_HAND_OF_RAGNAROS)
                {
                    item.Quality -= 1 * timesToDecrease;
                }
            }
        }
    }
}
