﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose_BeforeRefactoring.Test
{
    public class ConjuredManaCakeSpecsTest
    {
        private Item _item = new Item { Quality = 30, SellIn = 8, Name = "Conjured Mana Cake" };

        [Fact]
        public void ShouldDecreaseQualityByTwoBeforeSellIn()
        {
            var item = new Item { Quality = 30, SellIn = 8, Name = "Conjured Mana Cake" };

            var app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();

            Assert.Equal(28, item.Quality);
            Assert.Equal(7, item.SellIn);

        }

        [Fact]
        public void ShouldDecreaseQualityByFourAfterSellIn()
        {
            var item = new Item { Quality = 30, SellIn = 0, Name = "Conjured Mana Cake" };

            var app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();

            Assert.Equal(26, item.Quality);
            Assert.Equal(-1, item.SellIn);

        }
    }
}
