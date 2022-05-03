using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose_BeforeRefactoring.Test
{
    public class AgedBrieSpecsTest
    {
        [Fact]
        public void AgedBrieQualityShouldIncreaseAsTimePasses()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };

            var agedBrieOldQuality = items[0].Quality;

            var app = new GildedRose(items);
            app.UpdateQuality();

            var agedBrieNewQuality = items[0].Quality;

            Assert.True(agedBrieOldQuality < agedBrieNewQuality);
        }
    }
}
