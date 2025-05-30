using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ClairTourTiny.Core.Services
{
    public class PhaseService : IPhaseService
    {
        private readonly ClairTourTinyContext _clairTourTinyContext;

        public PhaseService(ClairTourTinyContext clairTourTinyContext)
        {
            _clairTourTinyContext = clairTourTinyContext;
        }

        public async Task<List<string>> GetSuffixes()
        {
            return await _clairTourTinyContext.ProjectDefaultSuffixes.Select(s => s.Suffix).ToListAsync();
        }
    }
}
