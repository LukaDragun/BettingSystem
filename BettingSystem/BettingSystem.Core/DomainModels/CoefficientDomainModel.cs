using BettingSystem.Common.Core.Enums;

namespace BettingSystem.Core.DomainModels
{
    public class CoefficientDomainModel : BaseDomainModel
    {
        public BetType BetType { get; set; }
        public float CoefficientValue { get; set; }
    }
}
