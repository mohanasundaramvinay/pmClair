using AutoMapper;
using ClairTourTiny.Core.Helpers;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Dto.ProjectMaintenance;
using ClairTourTiny.Infrastructure.Models.ProjectMaintenance;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClairTourTiny.Core.Services
{
    public class ProjectMaintenanceService : IProjectMaintenanceService
    {
        private readonly ClairTourTinyContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IProjectMaintenanceHelper _pjtHelper;
        private readonly IProjectDataPointsService _projectDataPointsService;

        public ProjectMaintenanceService(ClairTourTinyContext clairTourTinyContext, IMapper mapper, IProjectMaintenanceHelper pjtHelper, IProjectDataPointsService projectDataPointsService)
        {
            _dbContext = clairTourTinyContext;
            _mapper = mapper;
            _pjtHelper = pjtHelper;
            _projectDataPointsService = projectDataPointsService;
        }

        public async Task<int> GetNextAvailableProjectNumber()
        {
            var param = new SqlParameter("@nextProjectNumber", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
            };
            await _dbContext.ExecuteStoredProcedureNonQueryOutputParamAsync("get_next_project_number", param);
            return Convert.ToInt32(param.Value ?? 0);
        }

        public async Task<List<PhaseModel>> GetPhases(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var phasesDtos = await _dbContext.ExecuteStoredProcedureAsync<PhaseDto>("pm2_get_phases_new", param);
            return _mapper.Map<List<PhaseModel>>(phasesDtos);
        }

        public async Task<List<ProjectPurchaseModel>> GetPurchases(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var phasesDtos = await _dbContext.ExecuteStoredProcedureAsync<PurchaseDto>("Get_Purchase_Orders_By_Project", param);
            return _mapper.Map<List<ProjectPurchaseModel>>(phasesDtos);
        }

        public async Task<List<ProjectEquipmentModel>> GetEquipments(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var equipmentDtos = await _dbContext.ExecuteStoredProcedureAsync<EquipmentDto>("pm2_get_equipment_new", param);
            return _mapper.Map<List<ProjectEquipmentModel>>(equipmentDtos);
        }

        public async Task<List<ProjectEquipmentSubhireModel>> GetEquipmentSubhires(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var subhireDtos = await _dbContext.ExecuteStoredProcedureAsync<EquipmentSubhireDto>("pm2_get_equipment_subhires", param);
            var subhires = _mapper.Map<List<ProjectEquipmentSubhireModel>>(subhireDtos);

            var projects = await this.GetPhases(entityNo);
            var equipments = await this.GetEquipments(entityNo);
            subhires.ForEach(subhire =>
            {
                var part = equipments.Find(e=> e.Entityno == entityNo && e.Partno == subhire.PartNo);
                subhire.PartDescription = part?.PartDescription ?? "THIS PART NO LONGER ORDERED ON THIS PROJECT.";
                var equipmentPhase = projects.Find(p => p.EntityNo == subhire.EntityNo);
                if (equipmentPhase != null)
                {
                    var baseEntityNo = $"{entityNo}-$U3-{equipmentPhase.Agency}-{subhire.VendorNo}.{subhire.SiteNo}";
                    var inbound = equipments.Find(e => e.Entityno == $"{baseEntityNo}-IN" && e.Partno == subhire.PartNo);
                    if (inbound != null)
                        subhire.TransferInboundEntityno = inbound.Entityno;
                    var outbound = equipments.Find(e => e.Entityno == $"{baseEntityNo}-OUT" && e.Partno == subhire.PartNo);
                    if (outbound != null)
                        subhire.TransferOutboundEntityno = outbound.Entityno;
                    subhire.TransferLinkedPhases = !string.IsNullOrEmpty(subhire.TransferInboundEntityno);
                }
            });
            return subhires;
        }

        public async Task<BidSummaryResponse> GetBidSummaryData(string entityNo)
        {
            var phases = await this.GetPhases(entityNo);
            var billingItems = await this.GetBillingItems(entityNo);
            var billingPeriods = await this.GetBillingPeriods(entityNo);
            var billingPeriodItems = await this.GetBillingPeriodItems(entityNo);    
            var bidExpenses = await this.GetBidExpenses(entityNo);
            var crews = await this.GetCrews(entityNo);
            var expenseCodes = await _projectDataPointsService.GetExpenseCodes();
            var jobTypes = await _projectDataPointsService.GetJobTypes();
            var propertyTypes = await _projectDataPointsService.GetPropertyTypes();
            var bidSummaryHelper = new BidSummaryHelper(phases, billingItems, billingPeriods, billingPeriodItems, bidExpenses, crews, expenseCodes.ToList(), jobTypes.ToList(), propertyTypes.ToList(),_dbContext);
            return bidSummaryHelper.GetBidSummaryData(entityNo);
        }


        public async Task<List<ProjectBidExpenseModel>> GetBidExpenses(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var bidExpenseDtos = await _dbContext.ExecuteStoredProcedureAsync<BidExpenseDto>("pm2_get_bid_expenses", param);
            return _mapper.Map<List<ProjectBidExpenseModel>>(bidExpenseDtos);
        }

        public async Task<List<ProjectRfiModel>> GetRfis(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var rfiDtos = await _dbContext.ExecuteStoredProcedureAsync<RfiDto>("pm2_get_RFIs", param);
            return _mapper.Map<List<ProjectRfiModel>>(rfiDtos);
        }

        public async Task<List<ProjectNoteModel>> GetNotes(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var noteDtos = await _dbContext.ExecuteStoredProcedureAsync<NoteDto>("pm2_get_notes", param);
            return _mapper.Map<List<ProjectNoteModel>>(noteDtos);
        }

        public async Task<List<ProjectAssignedCrewOtModel>> GetAssignedCrewOtData(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var assignedCrewOtDtos = await _dbContext.ExecuteStoredProcedureAsync<AssignedCrewOtDto>("pm2_get_assigned_crew_OT_data", param);
            return _mapper.Map<List<ProjectAssignedCrewOtModel>>(assignedCrewOtDtos);
        }

        public async Task<List<ProjectBillingItemModel>> GetBillingItems(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var billingItemDtos = await _dbContext.ExecuteStoredProcedureAsync<BillingItemDto>("pm2_get_project_billing_items", param);
            return _mapper.Map<List<ProjectBillingItemModel>>(billingItemDtos);
        }

        public async Task<List<ProjectPartBidValueModel>> GetPartBids(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var partBidDtos = await _dbContext.ExecuteStoredProcedureAsync<PartBidValueDto>("pm2_get_part_bid_values_on_project", param);
            return _mapper.Map<List<ProjectPartBidValueModel>>(partBidDtos);
        }

        public async Task<List<ProjectProductionScheduleModel>> GetProductionSchedules(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var productionScheduleDtos = await _dbContext.ExecuteStoredProcedureAsync<ProductionScheduleDto>("pm2_get_project_production_schedule", param);
            return _mapper.Map<List<ProjectProductionScheduleModel>>(productionScheduleDtos);
        }

        public async Task<List<ProjectAssignedCrewModel>> GetAssignedCrews(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var assignedCrewDtos = await _dbContext.ExecuteStoredProcedureAsync<AssignedCrewDto>("pm2_get_assigned_crew", param);
            return _mapper.Map<List<ProjectAssignedCrewModel>>(assignedCrewDtos);
        }

        public async Task<List<ProjectCrewModel>> GetCrews(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var crewDtos = await _dbContext.ExecuteStoredProcedureAsync<CrewDto>("pm2_get_crew", param);
            var crews = _mapper.Map<List<ProjectCrewModel>>(crewDtos);
            var crewJobTypes = crews.Select(crew => crew.JobType).ToList();
            var assignedCrews = await this.GetAssignedCrews(entityNo);
            var assignedCrewOtData = await this.GetAssignedCrewOtData(entityNo);
            var jobTypes = _dbContext.JobTypesInMyDivisions.Where(e=> crewJobTypes.Contains(e.Jobtype)).Select(e => new { e.Jobtype, e.Hours }).ToList();
            foreach (var crew in crews)
            {
                var assignedCrewData = assignedCrews.Where(ac => ac.EntityNo == crew.EntityNo && ac.JobType == crew.JobType && ac.EmpLineNo == crew.EmpLineNo)?.ToList();
                assignedCrewData?.ForEach(e =>
                {
                    e.AssignedCrewOt = assignedCrewOtData.Where(ot => ot.EmpNo == e.EmpNo && ot.EntityNo == e.EntityNo && ot.JobType == e.JobType && ot.FromDate == e.FromDate)?.ToList();
                });
                crew.AssignedCrew = assignedCrewData ?? [];
                var jobType = jobTypes.FirstOrDefault(j => j.Jobtype == crew.JobType);
                crew.DailyBill = (jobType != null) ? crew.EstRate * jobType.Hours : 0;
                crew.WeeklyBill = (jobType != null) ? crew.EstRate * jobType.Hours * 7 : 0;
            }
            return crews;
        }

        public async Task<List<ProjectBillingPeriodModel>> GetBillingPeriods(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var billingPeriodDtos = await _dbContext.ExecuteStoredProcedureAsync<BillingPeriodDto>("pm2_get_project_billing_periods", param);
            return _mapper.Map<List<ProjectBillingPeriodModel>>(billingPeriodDtos);
        }

        public async Task<List<ProjectBillingPeriodItemModel>> GetBillingPeriodItems(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var billingPeriodItemDtos = await _dbContext.ExecuteStoredProcedureAsync<BillingPeriodItemDto>("pm2_get_project_billing_period_items_new", param);
            return _mapper.Map<List<ProjectBillingPeriodItemModel>>(billingPeriodItemDtos);
        }

        public async Task<List<ProjectClientShippingAddressModel>> GetClientShippingAddresses(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var clientAddressDtos = await _dbContext.ExecuteStoredProcedureAsync<ClientShippingAddressDto>("pm2_get_project_client_shipping_addresses", param);
            return _mapper.Map<List<ProjectClientShippingAddressModel>>(clientAddressDtos);
        }

        public async Task<List<ProjectPartModel>> GetParts(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var partDtos = await _dbContext.ExecuteStoredProcedureAsync<PartDto>("pm2_get_parts_on_project", param);
            return _mapper.Map<List<ProjectPartModel>>(partDtos);
        }

        public async Task<List<ProjectClientContactModel>> GetClientContacts(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var clientContactDtos = await _dbContext.ExecuteStoredProcedureAsync<ClientContactDto>("pm2_get_project_client_contacts", param);
            return _mapper.Map<List<ProjectClientContactModel>>(clientContactDtos);
        }

        public async Task<List<ProjectClientAddressModel>> GetClientAddresses(string entityNo)
        {
            var param = new SqlParameter("@entityno", entityNo);
            var clientAddressDtos = await _dbContext.ExecuteStoredProcedureAsync<ClientAddressDto>("pm2_get_project_client_addresses", param);
            return _mapper.Map<List<ProjectClientAddressModel>>(clientAddressDtos);
        }

        public async Task<List<ProjectShipmentModel>> GetShipments(string entityNo)
        {
            var shipmentDtos = await _dbContext.ExecuteSqlQueryAsync<ShipmentDto>($@"
            DECLARE @p varchar(50) = '%-[0-9]%-%'
            SELECT 
                SUBSTRING(s.entityno, 0, PATINDEX(@p, s.entityno) + PATINDEX('%-%', SUBSTRING(s.entityno, PATINDEX(@p, s.entityno) + 1, 100))) as ProjectLegNo,
                s.entityno as EntityNo, 
                g.entitydesc as EntityDesc,
                s.ShipDate,
                s.DestinationName as Destination,
                s.City,
                s.State,
                p.MasterTrackingNumber as TrackingNo,
                s.Amount as EstimatedCost,
                s.Amount * 1.25 as Cost,
                s.idShippingRequest as ShippingRequestID,
                s.ServiceTypeDisplayName as ServiceType
            FROM dbo.ShippingRequestForShipmentVault s
            LEFT JOIN dbo.glentities g ON g.entityno = s.entityno
            LEFT JOIN dbo.ShippingPackages p ON p.idShippingRequest = s.idShippingRequest
            WHERE s.entityno LIKE '{entityNo}' + '-%'");
            return _mapper.Map<List<ProjectShipmentModel>>(shipmentDtos);
        }

        public async Task<bool> SubmitPhases(string entityNo, ProjectSaveModel model)
        {
            bool result = false;
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.ExecuteStoredProcedureNonQueryAsync("clear_pm2_temp_tables", []);
                await _pjtHelper.ProcessAllBulkSaves(model, _mapper, _dbContext);
                await _dbContext.ExecuteStoredProcedureNonQueryAsync("commit_project_maintenance", []);
                await transaction.CommitAsync();
                result = true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            return result;
        }
    }
}
