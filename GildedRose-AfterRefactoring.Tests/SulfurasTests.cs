using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose_AfterRefactoring.Tests
{
    public class SulfurasTests
    {
        [Fact]
        public void SulfurasQualityShouldNeverChange()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(80, items[0].Quality);
        }
    }
}
