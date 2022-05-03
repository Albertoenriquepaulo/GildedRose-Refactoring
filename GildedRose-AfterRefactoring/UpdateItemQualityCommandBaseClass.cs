using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose_AfterRefactoring
{
    public abstract class UpdateItemQualityCommandBaseClass
    {
        public void SetQuality(Item item)
        {
            DecreaseSellIn(item);
            UpdateQuality(item);
        }

        protected virtual void UpdateQuality(Item item)
        {
            return;
        }

        protected void IncreaseQuality(Item item, int timesToIncrease)
        {
            if (item.Quality >= Constant.MaxQuality) return;

            if (item.Quality < Constant.MaxQuality)
                item.Quality += 1 * timesToIncrease;
        }

        protected void DecreaseQuality(Item item, int timesToDecrease)
        {
            if (item.Quality > Constant.MinQuality)
            {
                if (item.Name != Constant.Sulfuras)
                {
                    item.Quality -= 1 * timesToDecrease;
                }
            }
        }

        public void DecreaseSellIn(Item item)
        {
            if (item.Name == Constant.Sulfuras) return;

            item.SellIn--;
        }
    }
}
