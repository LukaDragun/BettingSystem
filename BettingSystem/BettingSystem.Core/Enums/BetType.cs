using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BettingSystem.Common.Core.Enums
{
    public enum BetType
    {
        [Description("1")]
        One = 1,
        [Description("2")]
        Two = 2,
        [Description("X")]
        X = 3,
        [Description("X1")]
        XOne = 4,
        [Description("X2")]
        XTwo = 5,
        [Description("12")]
        OneTwo = 6

    }
}
