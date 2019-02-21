using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.InfrastructureContracts
{
    public interface IQuery<Tview>
    {
        ICollection<Tview> Project();
    }
}
