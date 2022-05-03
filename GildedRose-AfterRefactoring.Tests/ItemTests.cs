using System.Collections.Generic;
using Xunit;

namespace GildedRose_AfterRefactoring.Tests
{
    public class ItemTests
    {
        [Fact]
        public void Foo()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
        }

        [Fact]
        public void QualityShouldNeverBeNegative()
        {
            var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void QualityShouldNeverBeGreaterThan50()
        {
            var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 50 } };

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(49, items[0].Quality);
        }

        [Fact]
        public void QualityShouldDegradeBy1BeforeSellingByDateHasPassed()
        {
            var items = new List<Item> {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 50 }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.Equal(48, items[0].Quality);
        }

        [Fact]
        public void QualityShouldDegradeTwiceAsFastAfterSellByDateHasPassed()
        {

            var items = new List<Item> {
                new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 50 }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(48, items[0].Quality);
        }
    }
}