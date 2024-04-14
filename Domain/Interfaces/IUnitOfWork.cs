using Core.Interfaces.InterfacesPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISlider Slider { get; }
        IAbout About { get; }
        IContact Contact { get; }
        IWork Work { get; }
        IMyServices Services { get; }
        ITeam Team { get; }
        IUser User { get; }
        Task<int> CompleteAsync();
	}
}
