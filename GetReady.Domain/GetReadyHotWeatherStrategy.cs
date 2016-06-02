using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReady.Domain
{
    public class GetReadyHotWeatherStrategy : GetReadyStrategy
    {
        public GetReadyHotWeatherStrategy()
        {
            PutOn(ClothingType.Socks);
            PutOn(ClothingType.Jacket);
        }

        public override string PutOnFootwear()
        {
            return PutOnClothing(ClothingType.Footwear, "sandals");
        }

        public override string PutOnHeadwear()
        {
            return PutOnClothing(ClothingType.Headwear, "sun visor");
        }

        public override string PutOnSocks()
        {
            return Constants.Fail;
        }

        public override string PutOnShirt()
        {
            return PutOnClothing(ClothingType.Shirt, "t-shirt");
        }

        public override string PutOnJacket()
        {
            return Constants.Fail;
        }

        public override string PutOnPants()
        {
            return PutOnClothing(ClothingType.Pants, "shorts");
        }
    }
}
