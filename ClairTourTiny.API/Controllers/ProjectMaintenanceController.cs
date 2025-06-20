using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Infrastructure.Models.ProjectMaintenance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClairTourTiny.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/")]
    [Produces("application/json")]
    public class ProjectMaintenanceController(IProjectMaintenanceService pjtMaintenanceService) : ControllerBase
    {
        private IProjectMaintenanceService _pjtMaintenanceService = pjtMaintenanceService;

        [HttpGet("projects/next")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNextAvailableProjectNumber() => Ok(await _pjtMaintenanceService.GetNextAvailableProjectNumber());

        [HttpGet("projects/{entityNo}/equipments")]
        [ProducesResponseType(typeof(List<ProjectEquipmentModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEquipments(string entityNo)
        {
            var phases = await _pjtMaintenanceService.GetEquipments(entityNo);
            return Ok(phases);
        }

        [HttpGet("projects/{entityNo}/purchases")]
        [ProducesResponseType(typeof(List<ProjectPurchaseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPurchases(string entityNo)
        {
            var purchaseOrders = await _pjtMaintenanceService.GetPurchases(entityNo);
            return Ok(purchaseOrders);
        }

        [HttpGet("projects/{entityNo}/purchases/new-po")]
        [ProducesResponseType(typeof(List<ProjectPurchaseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPurchases(string entityNo, [FromQuery] string poDescription)
        {
            var newPo = await _pjtMaintenanceService.AddNewPOAsync(entityNo,poDescription);
            var purchaseOrders = await _pjtMaintenanceService.GetPurchases(entityNo, newPo);
            return Ok(purchaseOrders);
        }

        [HttpGet("projects/{entityNo}/shipments")]
        [ProducesResponseType(typeof(List<ProjectShipmentModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetShipments(string entityNo)
        {
            var phases = await _pjtMaintenanceService.GetShipments(entityNo);
            return Ok(phases);
        }

        [HttpGet("projects/{entityNo}/equipment/subhires")]
        [ProducesResponseType(typeof(List<ProjectEquipmentModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEquipmentSubhires(string entityNo)
        {
            var phases = await _pjtMaintenanceService.GetEquipmentSubhires(entityNo);
            return Ok(phases);
        }

        [HttpGet("projects/{entityNo}/phases")]
        [ProducesResponseType(typeof(List<PhaseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPhases(string entityNo)
        {
            var phases = await _pjtMaintenanceService.GetPhases(entityNo);
            return Ok(phases);
        }

        [HttpGet("projects/{entityNo}/bid-expenses")]
        [ProducesResponseType(typeof(List<ProjectBidExpenseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBidExpenses(string entityNo)
        {
            var expenses = await _pjtMaintenanceService.GetBidExpenses(entityNo);
            return Ok(expenses);
        }

        [HttpGet("projects/{entityNo}/bid-summary")]
        [ProducesResponseType(typeof(List<BidSummaryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBidSummary(string entityNo)
        {
            var expenses = await _pjtMaintenanceService.GetBidSummaryData(entityNo);
            return Ok(expenses);
        }

        [HttpGet("projects/{entityNo}/rfis")]
        [ProducesResponseType(typeof(List<ProjectRfiModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRfis(string entityNo)
        {
            var rfis = await _pjtMaintenanceService.GetRfis(entityNo);
            return Ok(rfis);
        }

        [HttpGet("projects/{entityNo}/notes")]
        [ProducesResponseType(typeof(List<ProjectNoteModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNotes(string entityNo)
        {
            var notes = await _pjtMaintenanceService.GetNotes(entityNo);
            return Ok(notes);
        }

        [HttpGet("projects/{entityNo}/assigned-crew/ot")]
        [ProducesResponseType(typeof(List<ProjectAssignedCrewOtModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAssignedCrewOtData(string entityNo)
        {
            var otData = await _pjtMaintenanceService.GetAssignedCrewOtData(entityNo);
            return Ok(otData);
        }

        [HttpGet("projects/{entityNo}/billing-items")]
        [ProducesResponseType(typeof(List<ProjectBillingItemModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBillingItems(string entityNo)
        {
            var items = await _pjtMaintenanceService.GetBillingItems(entityNo);
            return Ok(items);
        }

        [HttpGet("projects/{entityNo}/part-bids")]
        [ProducesResponseType(typeof(List<ProjectPartBidValueModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPartBids(string entityNo)
        {
            var bids = await _pjtMaintenanceService.GetPartBids(entityNo);
            return Ok(bids);
        }

        [HttpGet("projects/{entityNo}/production-schedules")]
        [ProducesResponseType(typeof(List<ProjectProductionScheduleModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductionSchedules(string entityNo)
        {
            var schedules = await _pjtMaintenanceService.GetProductionSchedules(entityNo);
            return Ok(schedules);
        }

        [HttpGet("projects/{entityNo}/assigned-crews")]
        [ProducesResponseType(typeof(List<ProjectAssignedCrewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAssignedCrews(string entityNo)
        {
            var crews = await _pjtMaintenanceService.GetAssignedCrews(entityNo);
            return Ok(crews);
        }

        [HttpGet("projects/{entityNo}/crews")]
        [ProducesResponseType(typeof(List<ProjectCrewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCrews(string entityNo)
        {
            var crews = await _pjtMaintenanceService.GetCrews(entityNo);
            return Ok(crews);
        }

        [HttpGet("projects/{entityNo}/billing-periods")]
        [ProducesResponseType(typeof(List<ProjectBillingPeriodModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBillingPeriods(string entityNo)
        {
            var periods = await _pjtMaintenanceService.GetBillingPeriods(entityNo);
            return Ok(periods);
        }

        [HttpGet("projects/{entityNo}/billing-period-items")]
        [ProducesResponseType(typeof(List<ProjectBillingPeriodItemModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBillingPeriodItems(string entityNo)
        {
            var items = await _pjtMaintenanceService.GetBillingPeriodItems(entityNo);
            return Ok(items);
        }

        [HttpGet("projects/{entityNo}/client-shipping-addresses")]
        [ProducesResponseType(typeof(List<ProjectClientShippingAddressModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientShippingAddresses(string entityNo)
        {
            var addresses = await _pjtMaintenanceService.GetClientShippingAddresses(entityNo);
            return Ok(addresses);
        }

        [HttpGet("projects/{entityNo}/parts")]
        [ProducesResponseType(typeof(List<ProjectPartModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetParts(string entityNo)
        {
            var parts = await _pjtMaintenanceService.GetParts(entityNo);
            return Ok(parts);
        }

        [HttpGet("projects/{entityNo}/client-contacts")]
        [ProducesResponseType(typeof(List<ProjectClientContactModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientContacts(string entityNo)
        {
            var contacts = await _pjtMaintenanceService.GetClientContacts(entityNo);
            return Ok(contacts);
        }

        [HttpGet("projects/{entityNo}/client-addresses")]
        [ProducesResponseType(typeof(List<ProjectClientAddressModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientAddresses(string entityNo)
        {
            var addresses = await _pjtMaintenanceService.GetClientAddresses(entityNo);
            return Ok(addresses);
        }

        /// <summary>
        /// Calculate bottleneck values for equipment items
        /// </summary>
        /// <remarks>
        /// This endpoint calculates inventory bottleneck values for equipment items based on:
        /// * Current inventory levels
        /// * Internal project demands (parts leaving/returning)
        /// * External project demands
        /// * Early checkouts
        /// 
        /// Sample request:
        ///     POST /api/bottleneck-calculation
        ///     {
        ///         "projectNumber": "PROJ123",
        ///         "equipmentItems": [
        ///             {
        ///                 "entityNo": "PROJ123-001",
        ///                 "partNo": "PART001",
        ///                 "warehouse": "WH001",
        ///                 "startDate": "2024-01-15T00:00:00",
        ///                 "endDate": "2024-02-15T00:00:00",
        ///                 "quantity": 10,
        ///                 "checkedOut": 2
        ///             }
        ///         ]
        ///     }
        /// 
        /// Returns bottleneck calculations including:
        /// * Overall availability across project duration
        /// * 1-day availability on start date
        /// * 1-week availability within first 7 days
        /// * Base inventory and demand analysis
        /// </remarks>
        /// <param name="request">Bottleneck calculation request</param>
        /// <returns>Bottleneck calculation results</returns>
        /// <response code="200">Returns the bottleneck calculation results</response>
        /// <response code="400">If the request is invalid</response>
        /// <response code="500">If there was an internal server error</response>
        // [HttpPost("bottleneck-calculation")]
        // [ProducesResponseType(typeof(BottleneckCalculationResponse), StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // public async Task<IActionResult> CalculateBottlenecks([FromBody] BottleneckCalculationRequest request)
        // {
        //     try
        //     {
        //         if (!ModelState.IsValid)
        //         {
        //             return BadRequest(ModelState);
        //         }

        //         var result = await _pjtMaintenanceService.CalculateBottlenecks(request);
        //         return Ok(result);
        //     }
        //     catch (ArgumentException ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, $"Internal server error: {ex.Message}");
        //     }
        // }

        [HttpPost("projects/{entityNo}/save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SubmitPhases(string entityNo, [FromBody] ProjectSaveModel model)
        {
            try
            {
                await _pjtMaintenanceService.SubmitPhases(entityNo, model);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
