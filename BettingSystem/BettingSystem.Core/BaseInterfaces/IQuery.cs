using System.Linq;

namespace BettingSystem.Core.BaseInterfaces
{
    public interface IQuery<Tview>
    {
        IQueryable<Tview> Project();
    }
}
