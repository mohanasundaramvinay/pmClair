using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Dto.DTOs;

public interface IBidSummaryHelper
{
    BidSummaryResponse GetBidSummaryData(string entityNo);
}