using BettingSystem.Core.DomainModels;
using System;
using Xunit;

namespace BettingSystem.Tests
{
    public class CoefficientSpecs
    {
        [Fact]
        public void Coefficient_should_not_be_lower_than_1()
        {
            var coefficient = new CoefficientDomainModel() {
                CoefficientValue = -3
            };

            Assert.Throws<Exception>(() => coefficient.ErrorCheck());
        }
    }
}
