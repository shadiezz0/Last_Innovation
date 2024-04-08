using Core.Interfaces;
using Core.Interfaces.InterfacesPages;
using Infrastructure.Contexts;
using Infrastructure.Repositories.ReposPages;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InnovationDbContext _context;
        public ISlider Slider { get; }
        public IAbout About { get; }
        public IContact Contact { get; }
        public IMyServices Services { get; }
        public IWork Work { get; }

        public UnitOfWork(InnovationDbContext context) 
        {
            _context = context;
            Slider = new SliderRepos(_context);
            About = new AboutRepos(_context);
            Contact = new ContactRepos(_context);
            Services = new ServiceReposs(_context);
            Work = new WorkRepos(_context);
        }

        public async Task<int> CompleteAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
        {
            _context.Dispose();
        }

    }
}
