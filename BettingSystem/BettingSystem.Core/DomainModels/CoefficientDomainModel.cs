using BettingSystem.Common.Core.Enums;
using System;

namespace BettingSystem.Core.DomainModels
{
    public class CoefficientDomainModel : BaseDomainModel
    {
        public CoefficientDomainModel()
        {
        }

        public CoefficientDomainModel(BetType betType, float coefficientValue)
        {
            BetType = betType;
            CoefficientValue = coefficientValue;
            ErrorCheck();
        }

        public BetType BetType { get; set; }
        public float CoefficientValue { get; set; }

        public void ErrorCheck()
        {
            if (CoefficientValue <= 1)
                throw new Exception("Invalid coefficient value.");
        }
    }
}
