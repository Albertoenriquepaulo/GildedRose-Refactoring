using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose_AfterRefactoring
{
    public class UpdateConjuredItemQualityCommand : UpdateItemQualityCommandBaseClass
    {
        protected override void UpdateQuality(Item item)
        {
            DecreaseQuality(item, item.SellIn < 0 ? 4 : 2);
        }
    }
}
