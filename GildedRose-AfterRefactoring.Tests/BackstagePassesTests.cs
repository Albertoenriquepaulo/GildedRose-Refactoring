using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose_AfterRefactoring.Tests
{
    public class BackstagePassesTests
    {
        private List<Item> _oldQualityItems = new List<Item> {
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            }
        };

        [Fact]
        public void BackstagePassesShouldIncreaseQualityByOneWhenSellInIsGreaterThan10()
        {
            var newQualityItems = _oldQualityItems;

            var app = new GildedRose(_oldQualityItems);

            var bsPassesOldQuality = _oldQualityItems.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            app.UpdateQuality();

            var bsPassesNewQuality = newQualityItems.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            Assert.True(bsPassesNewQuality == (bsPassesOldQuality + 1));
        }

        [Fact]
        public void BackstagePassesShouldIncreaseQualityByTwoWhenSellInIsLowerThan11()
        {
            _oldQualityItems.Find(x => x.Name.StartsWith("Backstage passes"))!.SellIn = 10;

            var newQualityItems = _oldQualityItems;

            var bsPassesOldQuality = _oldQualityItems.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            var app = new GildedRose(_oldQualityItems);
            app.UpdateQuality();

            var bsPassesNewQuality = newQualityItems.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            Assert.True(bsPassesNewQuality == (bsPassesOldQuality + 2));
        }

        [Fact]
        public void BackstagePassesShouldIncreaseQualityByThreeWhenSellInIsLowerThan6()
        {
            _oldQualityItems.Find(x => x.Name.StartsWith("Backstage passes"))!.SellIn = 5;

            var newQualityItems = _oldQualityItems;

            var bsPassesOldQuality = _oldQualityItems.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            var app = new GildedRose(_oldQualityItems);
            app.UpdateQuality();

            var bsPassesNewQuality = newQualityItems.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            Assert.True(bsPassesNewQuality == (bsPassesOldQuality + 3));
        }

        [Fact]
        public void BackstagePassesShouldDropToZeroWhenSellInIs0()
        {
            _oldQualityItems.Find(x => x.Name.StartsWith("Backstage passes"))!.SellIn = 0;

            var newQualityItems = _oldQualityItems;

            var app = new GildedRose(_oldQualityItems);
            app.UpdateQuality();

            var bsPassesNewQuality = newQualityItems.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            Assert.True(bsPassesNewQuality == 0);
        }

        [Fact]
        public void BackstagePassesQualityShouldNeverBeAbove50()
        {
            _oldQualityItems.Find(x => x.Name.StartsWith("Backstage passes"))!.Quality = 49;
            _oldQualityItems.Find(x => x.Name.StartsWith("Backstage passes"))!.SellIn = 3;

            var newQualityItems = _oldQualityItems;

            var app = new GildedRose(_oldQualityItems);
            app.UpdateQuality();
            app.UpdateQuality();

            var bsPassesNewQuality = newQualityItems.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            Assert.True(bsPassesNewQuality == 50);
        }
    }
}
