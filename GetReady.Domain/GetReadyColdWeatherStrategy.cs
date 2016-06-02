using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReady.Domain
{
    public class GetReadyColdWeatherStrategy : GetReadyStrategy
    {
        public override string PutOnFootwear()
        {
            return PutOnClothing(ClothingType.Footwear, "boots");
        }

        public override string PutOnHeadwear()
        {
            return PutOnClothing(ClothingType.Headwear, "hat");
        }

        public override string PutOnSocks()
        {
            return PutOnClothing(ClothingType.Socks, "socks");
        }

        public override string PutOnShirt()
        {
            return PutOnClothing(ClothingType.Shirt, "shirt");
        }

        public override string PutOnJacket()
        {
            return PutOnClothing(ClothingType.Jacket, "jacket");
        }

        public override string PutOnPants()
        {
            return PutOnClothing(ClothingType.Pants, "pants");
        }
    }
}
