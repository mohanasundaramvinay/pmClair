using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClairTourTiny.API.Controllers;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
namespace ClairTourTiny.Tests
{
    public class ProjectDataPointsControllerTests
    {
        private readonly Mock<IProjectDataPointsService> _mockService;
        private readonly ProjectDataPointsController _controller;
        public ProjectDataPointsControllerTests()
        {
            _mockService = new Mock<IProjectDataPointsService>();
            var mockConfig = new Mock<IConfiguration>();
            _controller = new ProjectDataPointsController(_mockService.Object, mockConfig.Object);
        }
        [Fact]
        public async Task GetAllProjectData_ReturnsOkResult_WithAllProjectData()
        {
            // Arrange
            var mockData = new AllProjectData();
            _mockService.Setup(service => service.GetAllProjectData(It.IsAny<string>())).ReturnsAsync(mockData);
            // Act
            var result = await _controller.GetAllProjectData();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<AllProjectData>(okResult.Value);
        }
        [Fact]
        public async Task GetUserPermissions_ReturnsOkResult_WithUserPermissions()
        {
            // Arrange
            var mockPermissions = new UserPermissions();
            _mockService.Setup(service => service.GetUserPermissions()).ReturnsAsync(mockPermissions);
            // Act
            var result = await _controller.GetUserPermissions();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<UserPermissions>(okResult.Value);
        }
        [Fact]
        public async Task GetUserCompanyInfo_ReturnsOkResult_WithUserCompanyInfo()
        {
            // Arrange
            var mockCompanyInfo = new UserCompanyInfo();
            _mockService.Setup(service => service.GetUserCompanyInfo()).ReturnsAsync(mockCompanyInfo);
            // Act
            var result = await _controller.GetUserCompanyInfo();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<UserCompanyInfo>(okResult.Value);
        }
        [Fact]
        public async Task GetCompanies_ReturnsOkResult_WithListOfCompanies()
        {
            // Arrange
            var mockCompanies = new List<CompanyInfo>();
            _mockService.Setup(service => service.GetCompanies()).ReturnsAsync(mockCompanies);
            // Act
            var result = await _controller.GetCompanies();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<CompanyInfo>>(okResult.Value);
        }
        [Fact]
        public async Task GetProjectStatuses_ReturnsOkResult_WithListOfProjectStatuses()
        {
            // Arrange
            var mockStatuses = new List<ProjectStatus>();
            _mockService.Setup(service => service.GetProjectStatuses()).ReturnsAsync(mockStatuses);
            // Act
            var result = await _controller.GetProjectStatuses();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ProjectStatus>>(okResult.Value);
        }
        [Fact]
        public async Task GetWarehouses_ReturnsOkResult_WithListOfWarehouses()
        {
            // Arrange
            var mockWarehouses = new List<WarehouseInfo>();
            _mockService.Setup(service => service.GetWarehouses()).ReturnsAsync(mockWarehouses);
            // Act
            var result = await _controller.GetWarehouses();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<WarehouseInfo>>(okResult.Value);
        }
        [Fact]
        public async Task GetRateTypes_ReturnsOkResult_WithListOfRateTypes()
        {
            // Arrange
            var mockRateTypes = new List<RateType>();
            _mockService.Setup(service => service.GetRateTypes()).ReturnsAsync(mockRateTypes);
            // Act
            var result = await _controller.GetRateTypes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<RateType>>(okResult.Value);
        }
        [Fact]
        public async Task GetContactCategories_ReturnsOkResult_WithListOfContactCategories()
        {
            // Arrange
            var mockCategories = new List<ContactCategoryDto>();
            _mockService.Setup(service => service.GetContactCategories()).ReturnsAsync(mockCategories);
            // Act
            var result = await _controller.GetContactCategories();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ContactCategoryDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetProductionScheduleEventTypes_ReturnsOkResult_WithListOfEventTypes()
        {
            // Arrange
            var mockEventTypes = new List<ProductionScheduleEventTypeDto>();
            _mockService.Setup(service => service.GetProductionScheduleEventTypes()).ReturnsAsync(mockEventTypes);
            // Act
            var result = await _controller.GetProductionScheduleEventTypes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ProductionScheduleEventTypeDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetBillSchedules_ReturnsOkResult_WithListOfBillSchedules()
        {
            // Arrange
            var mockSchedules = new List<BillSchedule>();
            _mockService.Setup(service => service.GetBillSchedules()).ReturnsAsync(mockSchedules);
            // Act
            var result = await _controller.GetBillSchedules();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<BillSchedule>>(okResult.Value);
        }
        [Fact]
        public async Task GetCommodities_ReturnsOkResult_WithListOfCommodities()
        {
            // Arrange
            var mockCommodities = new List<Commodity>();
            _mockService.Setup(service => service.GetCommodities()).ReturnsAsync(mockCommodities);
            // Act
            var result = await _controller.GetCommodities();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Commodity>>(okResult.Value);
        }
        [Fact]
        public async Task GetBillingAccounts_ReturnsOkResult_WithListOfBillingAccounts()
        {
            // Arrange
            var mockAccounts = new List<BillingAccountDto>();
            _mockService.Setup(service => service.GetBillingAccounts()).ReturnsAsync(mockAccounts);
            // Act
            var result = await _controller.GetBillingAccounts();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<BillingAccountDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetJobTypes_ReturnsOkResult_WithListOfJobTypes()
        {
            // Arrange
            var mockJobTypes = new List<JobType>();
            _mockService.Setup(service => service.GetJobTypes()).ReturnsAsync(mockJobTypes);
            // Act
            var result = await _controller.GetJobTypes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<JobType>>(okResult.Value);
        }
        [Fact]
        public async Task GetCrewBidValues_ReturnsOkResult_WithListOfCrewBidValues()
        {
            // Arrange
            var mockBidValues = new List<CrewBidValueDto>();
            _mockService.Setup(service => service.GetCrewBidValues()).ReturnsAsync(mockBidValues);
            // Act
            var result = await _controller.GetCrewBidValues();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<CrewBidValueDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetEmployees_ReturnsOkResult_WithListOfEmployees()
        {
            // Arrange
            var mockEmployees = new List<EmployeeDto>();
            _mockService.Setup(service => service.GetEmployees()).ReturnsAsync(mockEmployees);
            // Act
            var result = await _controller.GetEmployees();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<EmployeeDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetEmployeeAssignmentStatuses_ReturnsOkResult_WithListOfAssignmentStatuses()
        {
            // Arrange
            var mockStatuses = new List<EmployeeAssignmentStatusCodeDto>();
            _mockService.Setup(service => service.GetEmployeeAssignmentStatuses()).ReturnsAsync(mockStatuses);
            // Act
            var result = await _controller.GetEmployeeAssignmentStatuses();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<EmployeeAssignmentStatusCodeDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetPayingPerDiemStatusTypes_ReturnsOkResult_WithListOfPerDiemStatusTypes()
        {
            // Arrange
            var mockStatusTypes = new List<PerDiemStatusType>();
            _mockService.Setup(service => service.GetPayingPerDiemStatusTypes()).ReturnsAsync(mockStatusTypes);
            // Act
            var result = await _controller.GetPayingPerDiemStatusTypes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PerDiemStatusType>>(okResult.Value);
        }
        [Fact]
        public async Task GetPerDiemBillableStatusTypes_ReturnsOkResult_WithListOfBillableStatusTypes()
        {
            // Arrange
            var mockStatusTypes = new List<PerDiemBillableStatusType>();
            _mockService.Setup(service => service.GetPerDiemBillableStatusTypes()).ReturnsAsync(mockStatusTypes);
            // Act
            var result = await _controller.GetPerDiemBillableStatusTypes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PerDiemBillableStatusType>>(okResult.Value);
        }
        [Fact]
        public async Task GetEmployeeJobTypes_ReturnsOkResult_WithListOfEmployeeJobTypes()
        {
            // Arrange
            var mockJobTypes = new List<EmployeeJobType>();
            _mockService.Setup(service => service.GetEmployeeJobTypes()).ReturnsAsync(mockJobTypes);
            // Act
            var result = await _controller.GetEmployeeJobTypes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<EmployeeJobType>>(okResult.Value);
        }
        [Fact]
        public async Task GetBudgetCategories_ReturnsOkResult_WithListOfBudgetCategories()
        {
            // Arrange
            var mockCategories = new List<BudgetCategoryDto>();
            _mockService.Setup(service => service.GetBudgetCategories()).ReturnsAsync(mockCategories);
            // Act
            var result = await _controller.GetBudgetCategories();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<BudgetCategoryDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetExpenseCodes_ReturnsOkResult_WithListOfExpenseCodes()
        {
            // Arrange
            var mockExpenseCodes = new List<ExpenseCode>();
            _mockService.Setup(service => service.GetExpenseCodes()).ReturnsAsync(mockExpenseCodes);
            // Act
            var result = await _controller.GetExpenseCodes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ExpenseCode>>(okResult.Value);
        }
        [Fact]
        public async Task GetEquipmentSubhireStatuses_ReturnsOkResult_WithListOfSubhireStatuses()
        {
            // Arrange
            var mockStatuses = new List<EquipmentSubhireStatusDto>();
            _mockService.Setup(service => service.GetEquipmentSubhireStatuses()).ReturnsAsync(mockStatuses);
            // Act
            var result = await _controller.GetEquipmentSubhireStatuses();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<EquipmentSubhireStatusDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetExpenseCategories_ReturnsOkResult_WithListOfExpenseCategories()
        {
            // Arrange
            var mockCategories = new List<ExpenseCategoryDto>();
            _mockService.Setup(service => service.GetExpenseCategories()).ReturnsAsync(mockCategories);
            // Act
            var result = await _controller.GetExpenseCategories();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ExpenseCategoryDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetExpensePeriodTypes_ReturnsOkResult_WithListOfPeriodTypes()
        {
            // Arrange
            var mockPeriodTypes = new List<ExpensePeriodTypeDTO>();
            _mockService.Setup(service => service.GetExpensePeriodTypes()).ReturnsAsync(mockPeriodTypes);
            // Act
            var result = await _controller.GetExpensePeriodTypes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ExpensePeriodTypeDTO>>(okResult.Value);
        }
        [Fact]
        public async Task GetPropertyTypes_ReturnsOkResult_WithListOfPropertyTypes()
        {
            // Arrange
            var mockPropertyTypes = new List<PropertyTypeDTO>();
            _mockService.Setup(service => service.GetPropertyTypes()).ReturnsAsync(mockPropertyTypes);
            // Act
            var result = await _controller.GetPropertyTypes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PropertyTypeDTO>>(okResult.Value);
        }
        [Fact]
        public async Task GetCurrencies_ReturnsOkResult_WithListOfCurrencies()
        {
            // Arrange
            var mockCurrencies = new List<CurrencyDto>();
            _mockService.Setup(service => service.GetCurrencies()).ReturnsAsync(mockCurrencies);
            // Act
            var result = await _controller.GetCurrencies();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<CurrencyDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetReferralPrograms_ReturnsOkResult_WithListOfReferralPrograms()
        {
            // Arrange
            var mockPrograms = new List<ReferralProgramDto>();
            _mockService.Setup(service => service.GetReferralPrograms()).ReturnsAsync(mockPrograms);
            // Act
            var result = await _controller.GetReferralPrograms();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ReferralProgramDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetFavoriteProjects_ReturnsOkResult_WithListOfFavoriteProjects()
        {
            // Arrange
            var mockProjects = new List<string>();
            _mockService.Setup(service => service.GetFavoriteProjects()).ReturnsAsync(mockProjects);
            // Act
            var result = await _controller.GetFavoriteProjects();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<string>>(okResult.Value);
        }
        [Fact]
        public async Task GetTaxCodes_ReturnsOkResult_WithListOfTaxCodes()
        {
            // Arrange
            var mockTaxCodes = new List<TaxCodeDto>();
            _mockService.Setup(service => service.GetTaxCodes()).ReturnsAsync(mockTaxCodes);
            // Act
            var result = await _controller.GetTaxCodes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<TaxCodeDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetProjectPriceLevels_ReturnsOkResult_WithListOfPriceLevels()
        {
            // Arrange
            var mockPriceLevels = new List<ProjectPriceLevelDto>();
            _mockService.Setup(service => service.GetProjectPriceLevels()).ReturnsAsync(mockPriceLevels);
            // Act
            var result = await _controller.GetProjectPriceLevels();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ProjectPriceLevelDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetAccountMatrix_ReturnsOkResult_WithAccountMatrix()
        {
            // Arrange
            var mockMatrix = new List<AccountMatrix>();
            _mockService.Setup(service => service.GetAccountMatrix()).ReturnsAsync(mockMatrix);
            // Act
            var result = await _controller.GetAccountMatrix();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<AccountMatrix>>(okResult.Value);
        }
        [Fact]
        public async Task GetOvertimeRates_ReturnsOkResult_WithListOfOvertimeRates()
        {
            // Arrange
            var mockRates = new List<OvertimeRateDto>();
            _mockService.Setup(service => service.GetOvertimeRates()).ReturnsAsync(mockRates);
            // Act
            var result = await _controller.GetOvertimeRates();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<OvertimeRateDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetGUIColumnNames_ReturnsOkResult_WithListOfGUIColumnNames()
        {
            // Arrange
            var mockColumnNames = new List<GUIColumnName>();
            _mockService.Setup(service => service.GetGUIColumnNames()).ReturnsAsync(mockColumnNames);
            // Act
            var result = await _controller.GetGUIColumnNames();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<GUIColumnName>>(okResult.Value);
        }
        [Fact]
        public async Task GetCrewBillRatesVisibility_ReturnsOkResult_WithCrewBillRatesVisibility()
        {
            // Arrange
            var mockVisibility = new CrewBillRatesVisibility();
            _mockService.Setup(service => service.GetCrewBillRatesVisibility()).ReturnsAsync(mockVisibility);
            // Act
            var result = await _controller.GetCrewBillRatesVisibility();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<CrewBillRatesVisibility>(okResult.Value);
        }
        [Fact]
        public async Task GetShippingRequests_ReturnsOkResult_WithListOfShippingRequests()
        {
            // Arrange
            var mockRequests = new List<ShippingRequest>();
            _mockService.Setup(service => service.GetShippingRequests(It.IsAny<string>())).ReturnsAsync(mockRequests);
            // Act
            var result = await _controller.GetShippingRequests("PROJ123");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ShippingRequest>>(okResult.Value);
        }
        [Fact]
        public async Task GetUserMenuInclusions_ReturnsOkResult_WithListOfMenuInclusions()
        {
            // Arrange
            var mockInclusions = new List<string>();
            _mockService.Setup(service => service.GetUserMenuInclusions()).ReturnsAsync(mockInclusions);
            // Act
            var result = await _controller.GetUserMenuInclusions();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<string>>(okResult.Value);
        }
        [Fact]
        public async Task GetPollstarArtists_ReturnsOkResult_WithListOfPollstarArtists()
        {
            // Arrange
            var mockArtists = new List<PollstarArtist>();
            _mockService.Setup(service => service.GetPollstarArtists()).ReturnsAsync(mockArtists);
            // Act
            var result = await _controller.GetPollstarArtists();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PollstarArtist>>(okResult.Value);
        }
        [Fact]
        public async Task SearchPollstarArtists_ReturnsOkResult_WithListOfMatchingArtists()
        {
            // Arrange
            var mockArtists = new List<PollstarArtist>();
            _mockService.Setup(service => service.SearchPollstarArtists(It.IsAny<string>())).ReturnsAsync(mockArtists);
            // Act
            var result = await _controller.SearchPollstarArtists("artistname");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PollstarArtist>>(okResult.Value);
        }
        [Fact]
        public async Task GetPollstarArtist_ReturnsOkResult_WithPollstarArtist()
        {
            // Arrange
            var mockArtist = new PollstarArtist();
            _mockService.Setup(service => service.GetPollstarArtistById(It.IsAny<int>())).ReturnsAsync(mockArtist);
            // Act
            var result = await _controller.GetPollstarArtist(123);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<PollstarArtist>(okResult.Value);
        }
        [Fact]
        public async Task GetContactsByCategory_ReturnsOkResult_WithListOfContacts()
        {
            // Arrange
            var mockContacts = new List<Contact>();
            _mockService.Setup(service => service.GetContactsByCategory(It.IsAny<int>())).ReturnsAsync(mockContacts);
            // Act
            var result = await _controller.GetContactsByCategory(1);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Contact>>(okResult.Value);
        }
        [Fact]
        public async Task SearchContacts_ReturnsOkResult_WithListOfMatchingContacts()
        {
            // Arrange
            var mockContacts = new List<Contact>();
            _mockService.Setup(service => service.SearchContacts(It.IsAny<string>())).ReturnsAsync(mockContacts);
            // Act
            var result = await _controller.SearchContacts("searchTerm");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Contact>>(okResult.Value);
        }
        [Fact]
        public async Task GetCustomers_ReturnsOkResult_WithListOfCustomers()
        {
            // Arrange
            var mockCustomers = new List<Oecustomer>();
            _mockService.Setup(service => service.GetCustomers()).ReturnsAsync(mockCustomers);
            // Act
            var result = await _controller.GetCustomers();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Oecustomer>>(okResult.Value);
        }
        [Fact]
        public async Task SearchCustomers_ReturnsOkResult_WithListOfMatchingCustomers()
        {
            // Arrange
            var mockCustomers = new List<Oecustomer>();
            _mockService.Setup(service => service.SearchCustomers(It.IsAny<string>())).ReturnsAsync(mockCustomers);
            // Act
            var result = await _controller.SearchCustomers("searchTerm");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Oecustomer>>(okResult.Value);
        }
        [Fact]
        public async Task GetCustomerBillingAddresses_ReturnsOkResult_WithListOfBillingAddresses()
        {
            // Arrange
            var mockAddresses = new List<Oecustbill>();
            _mockService.Setup(service => service.GetCustomerBillingAddresses(It.IsAny<string>())).ReturnsAsync(mockAddresses);
            // Act
            var result = await _controller.GetCustomerBillingAddresses("customerNo");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Oecustbill>>(okResult.Value);
        }
        [Fact]
        public async Task GetTruckingCompanies_ReturnsOkResult_WithListOfTruckingCompanies()
        {
            // Arrange
            var mockCompanies = new List<TruckingCompany>();
            _mockService.Setup(service => service.GetTruckingCompanies()).ReturnsAsync(mockCompanies);
            // Act
            var result = await _controller.GetTruckingCompanies();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<TruckingCompany>>(okResult.Value);
        }
        [Fact]
        public async Task SearchTruckingCompanies_ReturnsOkResult_WithListOfMatchingCompanies()
        {
            // Arrange
            var mockCompanies = new List<TruckingCompany>();
            _mockService.Setup(service => service.SearchTruckingCompanies(It.IsAny<string>())).ReturnsAsync(mockCompanies);
            // Act
            var result = await _controller.SearchTruckingCompanies("searchTerm");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<TruckingCompany>>(okResult.Value);
        }
        [Fact]
        public async Task GetAllProductionScheduleEventTypes_ReturnsOkResult_WithListOfEventTypes()
        {
            // Arrange
            var mockEventTypes = new List<ClairTourTiny.Infrastructure.Models.ProductionScheduleEventType>();
            _mockService.Setup(service => service.GetAllProductionScheduleEventTypes()).ReturnsAsync(mockEventTypes);
            // Act
            var result = await _controller.GetAllProductionScheduleEventTypes();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ClairTourTiny.Infrastructure.Models.ProductionScheduleEventType>>(okResult.Value);
        }
        [Fact]
        public async Task GetAllShippingDestinations_ReturnsOkResult_WithListOfShippingDestinations()
        {
            // Arrange
            var mockDestinations = new List<ShippingDestination>();
            _mockService.Setup(service => service.GetAllShippingDestinations()).ReturnsAsync(mockDestinations);
            // Act
            var result = await _controller.GetAllShippingDestinations();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ShippingDestination>>(okResult.Value);
        }
        [Fact]
        public async Task SearchShippingDestinations_ReturnsOkResult_WithListOfMatchingDestinations()
        {
            // Arrange
            var mockDestinations = new List<ShippingDestination>();
            _mockService.Setup(service => service.SearchShippingDestinations(It.IsAny<string>())).ReturnsAsync(mockDestinations);
            // Act
            var result = await _controller.SearchShippingDestinations("searchTerm");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ShippingDestination>>(okResult.Value);
        }
        [Fact]
        public async Task GetAllPollstarVenues_ReturnsOkResult_WithListOfPollstarVenues()
        {
            // Arrange
            var mockVenues = new List<PollstarVenue>();
            _mockService.Setup(service => service.GetAllPollstarVenues()).ReturnsAsync(mockVenues);
            // Act
            var result = await _controller.GetAllPollstarVenues();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PollstarVenue>>(okResult.Value);
        }
        [Fact]
        public async Task SearchPollstarVenues_ReturnsOkResult_WithListOfMatchingVenues()
        {
            // Arrange
            var mockVenues = new List<PollstarVenue>();
            _mockService.Setup(service => service.SearchPollstarVenues(It.IsAny<string>())).ReturnsAsync(mockVenues);
            // Act
            var result = await _controller.SearchPollstarVenues("searchTerm");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PollstarVenue>>(okResult.Value);
        }
        [Fact]
        public async Task SearchParts_ReturnsOkResult_WithListOfParts()
        {
            // Arrange
            var mockParts = new List<PartSearchResultDto>();
            var request = new PartSearchRequestDto();
            _mockService.Setup(service => service.SearchPartsAsync(It.IsAny<PartSearchRequestDto>())).ReturnsAsync(mockParts);
            // Act
            var result = await _controller.SearchParts(request);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PartSearchResultDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetPartCategories_ReturnsOkResult_WithListOfPartCategories()
        {
            // Arrange
            var mockCategories = new List<PartCategoryDto>();
            _mockService.Setup(service => service.GetPartCategoriesAsync()).ReturnsAsync(mockCategories);
            // Act
            var result = await _controller.GetPartCategories();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PartCategoryDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetPartSubCategories_ReturnsOkResult_WithListOfPartSubCategories()
        {
            // Arrange
            var mockSubCategories = new List<PartSubCategoryDto>();
            _mockService.Setup(service => service.GetPartSubCategoriesAsync(It.IsAny<string>())).ReturnsAsync(mockSubCategories);
            // Act
            var result = await _controller.GetPartSubCategories("ELECTRICAL");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PartSubCategoryDto>>(okResult.Value);
        }
        [Fact]
        public async Task GetDefaultProjectSettings_ReturnsOkResult_WithDefaultProjectSettings()
        {
            // Arrange
            var mockSettings = new DefaultProjectSettingsDto();
            _mockService.Setup(service => service.GetDefaultProjectSettingsAsync(It.IsAny<string>())).ReturnsAsync(mockSettings);
            // Act
            var result = await _controller.GetDefaultProjectSettings();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<DefaultProjectSettingsDto>(okResult.Value);
        }
        [Fact]
        public async Task CalculatePartBottlenecks_ReturnsOkResult_WithListOfBottleneckCalculations()
        {
            // Arrange
            var mockResults = new List<PartBottleneckDto>();
            var request = new PartBottleneckRequestDto();
            _mockService.Setup(service => service.CalculatePartBottlenecksAsync(It.IsAny<PartBottleneckRequestDto>())).ReturnsAsync(mockResults);
            // Act
            var result = await _controller.CalculatePartBottlenecks(request);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<PartBottleneckDto>>(okResult.Value);
        }
    }
}