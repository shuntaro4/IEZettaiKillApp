using System.Collections.Generic;

namespace IEZettaiKillApp.Core.Infrastructure.Interfaces
{
    public interface IProcessFinder
    {
        IEnumerable<IIEZettaiProcess> FindByName(string name);
    }
}
