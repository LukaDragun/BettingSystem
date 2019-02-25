using BettingSystem.Common.Core.Enums;
using System;

namespace BettingSystem.Core.DomainModels
{
    public class CoefficientDomainModel : BaseDomainModel
    {
        public CoefficientDomainModel()
        {

        }

        public BetType BetType { get; set; }
        public float CoefficientValue { get; set; }


        private void ErrorCheck()
        {
            if (CoefficientValue <= 1)
            throw new Exception("Invalid coefficient value.");
        }
    }
}
