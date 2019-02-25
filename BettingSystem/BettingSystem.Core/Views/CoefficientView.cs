using BettingSystem.Common.Core.Enums;

namespace BettingSystem.Core.Views
{
    public class CoefficientView
    {
        public int Id { get; set; }
        public BetType BetType { get; set; }
        public float CoefficientValue { get; set; }
    }
}
