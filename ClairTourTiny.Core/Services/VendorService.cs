using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using ClairTourTiny.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ClairTourTiny.Infrastructure.Dto.Vendor;

namespace ClairTourTiny.Core.Services;

/// <summary>
/// Implementation of IVendorService for managing vendor operations
/// </summary>
public class VendorService : IVendorService
{
    private readonly ClairTourTinyContext _context;
    private readonly ILogger<VendorService> _logger;

    public VendorService(ClairTourTinyContext context, ILogger<VendorService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public static class SubhireStatusHelper
    {
        public static string GetStatusDescription(string statusCode)
        {
            return statusCode switch
            {
                "P" => "Pending",
                "A" => "Active",
                "C" => "Completed",
                "X" => "Cancelled",
                "H" => "On Hold",
                "R" => "Returned",
                _ => $"Status {statusCode}"
            };
        }

        public static string GetStatusColor(string statusCode)
        {
            return statusCode switch
            {
                "P" => "#FFA500", // Orange
                "A" => "#008000", // Green
                "C" => "#0000FF", // Blue
                "X" => "#FF0000", // Red
                "H" => "#FFFF00", // Yellow
                "R" => "#800080", // Purple
                _ => "#808080"    // Gray
            };
        }

        public static bool IsCompletedStatus(string statusCode) => statusCode == "C";
        public static bool IsCancelledStatus(string statusCode) => statusCode == "X";
        public static bool IsPendingStatus(string statusCode) => statusCode == "P";
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<VendorDto>> GetKnownVendorsAsync(string partNo)
    {
        try
        {
            var vendors = await _context.PartSubhireVendors
                .Where(p => p.Partno == partNo)
                .Join(_context.Povendors,
                    p => p.Vendno,
                    v => v.Vendno,
                    (p, v) => new { PartVendor = p, Vendor = v })
                .Join(_context.Povendsites,
                    pv => new { pv.PartVendor.Vendno, SiteNo = pv.PartVendor.Siteno },
                    s => new { s.Vendno, SiteNo = s.SiteNo },
                    (pv, s) => new VendorDto
                    {
                        VendNo = pv.PartVendor.Vendno,
                        SiteNo = pv.PartVendor.Siteno,
                        VendorName = pv.Vendor.VendorName,
                        Currency = pv.PartVendor.Currency ?? "USD",
                        Rate = pv.PartVendor.Rate,
                        RateType = pv.PartVendor.RateType,
                        TwoDayWeek = pv.PartVendor.RateType == "D" ? pv.PartVendor.Rate * 2 : 0,
                        ThreeDayWeek = pv.PartVendor.RateType == "D" ? pv.PartVendor.Rate * 3 : 0,
                        DeliveryRate = pv.PartVendor.DeliveryRate,
                        ReturnRate = pv.PartVendor.ReturnRate,
                        City = s.City,
                        State = s.State,
                        Country = s.Country,
                        Phone = s.Phone,
                        Contact = s.Contact,
                        Email = s.Usenet,
                        Mobile = s.Voicemail
                    })
                .ToListAsync();

            return vendors;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving known vendors for part {PartNo}", partNo);
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<VendorAddressDto>> GetVendorAddressesAsync(string vendNo)
    {
        try
        {
            var addresses = await _context.Povendsites
                .Where(s => s.Vendno == vendNo)
                .Select(s => new VendorAddressDto
                {
                    SiteNo = s.SiteNo,
                    VendorName = s.Vendno,
                    Contact = s.Contact,
                    Address1 = s.Address1,
                    Address2 = s.Address2,
                    Address3 = s.Address3,
                    City = s.City,
                    State = s.State,
                    ZipCode = s.Zipcode
                })
                .ToListAsync();

            return addresses;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving vendor addresses for vendor {VendNo}", vendNo);
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<bool> AddKnownVendorAsync(AddKnownVendorRequestDto request)
    {
        try
        {
            var vendor = new PartSubhireVendor
            {
                Partno = request.PartNo,
                Vendno = request.VendNo,
                Siteno = request.SiteNo,
                Notes = request.Notes,
                Currency = request.Currency,
                Rate = request.Rate,
                RateType = request.RateType,
                DeliveryRate = request.DeliveryRate,
                ReturnRate = request.ReturnRate
            };

            await _context.PartSubhireVendors.AddAsync(vendor);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding known vendor for part {PartNo}, vendor {VendNo}", 
                request.PartNo, request.VendNo);
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<bool> IsKnownVendorAsync(string partNo, string vendNo, string siteNo)
    {
        try
        {
            return await _context.PartSubhireVendors
                .AnyAsync(p => p.Partno == partNo && 
                              p.Vendno == vendNo && 
                              p.Siteno == siteNo);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking if vendor is known for part {PartNo}, vendor {VendNo}", 
                partNo, vendNo);
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<EquipmentSubhireStatusDto>> GetSubhireStatusesAsync()
    {
        try
        {
            var statuses = await _context.EquipmentSubhireStatuses
                .Select(s => new EquipmentSubhireStatusDto
                {
                    StatusCode = s.StatusCode,
                    Description = SubhireStatusHelper.GetStatusDescription(s.StatusCode),
                    ColorCode = SubhireStatusHelper.GetStatusColor(s.StatusCode),
                    SortOrder = s.SortOrder,
                    IsCompleted = SubhireStatusHelper.IsCompletedStatus(s.StatusCode),
                    IsCancelled = SubhireStatusHelper.IsCancelledStatus(s.StatusCode),
                    IsPending = SubhireStatusHelper.IsPendingStatus(s.StatusCode)
                })
                .OrderBy(s => s.SortOrder)
                .ToListAsync();

            return statuses;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving subhire statuses");
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<RateTypeDto>> GetRateTypesAsync()
    {
        try
        {
            // Define the standard rate types
            var rateTypes = new List<RateTypeDto>
            {
                new RateTypeDto
                {
                    Code = "D",
                    Description = "Daily",
                    SortOrder = 1,
                    IsActive = true,
                    IsDaily = true,
                    DaysPerUnit = 1
                },
                new RateTypeDto
                {
                    Code = "W",
                    Description = "Weekly",
                    SortOrder = 2,
                    IsActive = true,
                    IsWeekly = true,
                    DaysPerUnit = 7
                },
                new RateTypeDto
                {
                    Code = "M",
                    Description = "Monthly",
                    SortOrder = 3,
                    IsActive = true,
                    IsMonthly = true,
                    DaysPerUnit = 30
                }
            };

            // Get any additional rate types from the database if they exist
            var dbRateTypes = await _context.EquipmentSubhires
                .Select(s => s.RateType)
                .Distinct()
                .Where(rt => !rateTypes.Any(r => r.Code == rt))
                .ToListAsync();

            foreach (var rateType in dbRateTypes)
            {
                rateTypes.Add(new RateTypeDto
                {
                    Code = rateType,
                    Description = GetRateTypeDescription(rateType),
                    SortOrder = rateTypes.Count + 1,
                    IsActive = true,
                    DaysPerUnit = GetDaysPerUnit(rateType)
                });
            }

            return rateTypes.OrderBy(rt => rt.SortOrder);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving rate types");
            throw;
        }
    }

    private string GetRateTypeDescription(string rateType)
    {
        return rateType switch
        {
            "D" => "Daily",
            "W" => "Weekly",
            "M" => "Monthly",
            "H" => "Hourly",
            "Q" => "Quarterly",
            "Y" => "Yearly",
            _ => $"Rate Type {rateType}"
        };
    }

    private int GetDaysPerUnit(string rateType)
    {
        return rateType switch
        {
            "D" => 1,
            "W" => 7,
            "M" => 30,
            "Q" => 90,
            "Y" => 365,
            _ => 1
        };
    }    

    public async Task<IEnumerable<VendorDto>> GetVendorAddressesByVendorSiteAsync(IEnumerable<VendorSiteRequest> vendorSites)
    {
        try
        {
            var pairs = vendorSites.ToList();
            if (!pairs.Any()) return new List<VendorDto>();

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var vendorNos = pairs.Select(p => p.VendorNo).Distinct().ToList();
            var siteNos = pairs.Select(p => p.SiteNo).Distinct().ToList();

            // 1. Get all possible matches from DB
            var joined = await (
                from v in _context.Povendors
                join s in _context.Povendsites on v.Vendno equals s.Vendno
                where vendorNos.Contains(v.Vendno) && siteNos.Contains(s.SiteNo)
                select new { v, s }
            ).ToListAsync();

            // 2. Filter in memory for exact vendorNo-siteNo pairs
            var searchResults = joined
                .Where(js => pairs.Any(p => p.VendorNo == js.v.Vendno && p.SiteNo == js.s.SiteNo))
                .Select(js => new VendorDto
                {
                    VendNo = js.v.Vendno,
                    SiteNo = js.s.SiteNo,
                    VendorName = js.v.VendorName,
                    Currency = "USD",
                    Rate = 0,
                    RateType = "D",
                    TwoDayWeek = 0,
                    ThreeDayWeek = 0,
                    DeliveryRate = 0,
                    ReturnRate = 0,
                    City = js.s.City,
                    State = js.s.State,
                    Country = js.s.Country,
                    Phone = js.s.Phone,
                    Contact = js.s.Contact,
                    Email = js.s.Usenet,
                    Mobile = js.s.Voicemail
                })
                .OrderBy(v => v.VendorName)
                .ToList();

            return searchResults;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving vendor addresses for vendor-site service");
            throw;
        }
    }
} 