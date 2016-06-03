using System;
using System.Collections.Generic;

namespace GetReady.Domain
{
    public abstract class GetReadyStrategy : IGetReady
    {
        private readonly Dictionary<ClothingType, bool> _wornClothing = new Dictionary<ClothingType, bool>();

        public static IGetReady Create(TemperatureType temperatureType)
        {
            return temperatureType == TemperatureType.HOT
                ? (IGetReady) new GetReadyHotWeatherStrategy()
                : new GetReadyColdWeatherStrategy();
        }

        protected GetReadyStrategy()
        {
            var values = Enum.GetValues(typeof(ClothingType));

            foreach (ClothingType val in values)
            {
                _wornClothing.Add(val, false);
            }

            PutOn(ClothingType.Pajamas);
        }

        protected bool IsWearing(ClothingType clothingType)
        {
            return _wornClothing[clothingType];
        }

        protected void PutOn(ClothingType clothingType)
        {
            _wornClothing[clothingType] = true;
        }

        protected void TakeOff(ClothingType clothingType)
        {
            _wornClothing[clothingType] = false;
        }

        protected string PutOnClothing(ClothingType clothingType, string responseMessage)
        {
            return CheckCommonRules(clothingType, () =>
            {
                PutOn(clothingType);
                return responseMessage;
            });
        }

        protected string CheckCommonRules(ClothingType type, Func<string> command)
        {
            if (IsWearing(ClothingType.Pajamas))
            {
                return Constants.Fail;
            }

            if (IsWearing(type))
            {
                return Constants.Fail;
            }

            if (type == ClothingType.Footwear)
            {
                if (!IsWearing(ClothingType.Socks) || 
                    !IsWearing(ClothingType.Pants))
                {
                    return Constants.Fail;
                }
            }

            if (type == ClothingType.Headwear)
            {
                if (!IsWearing(ClothingType.Shirt))
                {
                    return Constants.Fail;
                }
            }

            return command();
        }

        public virtual string TakeOffPajamas()
        {
            TakeOff(ClothingType.Pajamas);
            return "Removing PJs";
        }

        public virtual string LeaveHouse()
        {
            if (!(IsWearing(ClothingType.Footwear) &&
                IsWearing(ClothingType.Headwear) &&
                IsWearing(ClothingType.Socks) &&
                IsWearing(ClothingType.Shirt) &&
                IsWearing(ClothingType.Jacket) &&
                IsWearing(ClothingType.Pants)))
            {
                return Constants.Fail;
            }
            return "leaving house";
        }

        public abstract string PutOnFootwear();

        public abstract string PutOnHeadwear();

        public abstract string PutOnSocks();

        public abstract string PutOnShirt();

        public abstract string PutOnJacket();

        public abstract string PutOnPants();
    }
}
