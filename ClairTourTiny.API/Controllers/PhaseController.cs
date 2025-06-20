using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClairTourTiny.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PhaseController(IPhaseService phaseService) : ControllerBase
    {
        private IPhaseService _service = phaseService;

        [HttpGet("suffixes")]
        [ProducesResponseType(typeof(List<Project>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFavoriteProjects() => Ok(await _service.GetSuffixes());
    }
}
