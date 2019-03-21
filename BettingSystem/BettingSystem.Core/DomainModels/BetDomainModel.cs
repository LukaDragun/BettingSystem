using System.Collections.Generic;

namespace BettingSystem.Core.DomainModels
{
    public class BetDomainModel : BaseDomainModel
    {
        public BetDomainModel() {

        }

        public bool IsResolved { get; set; }

        public List<CoefficientDomainModel> Coefficients { get; set; }

        public void Resolve()
        {
            IsResolved = true;
        }
    }
}
