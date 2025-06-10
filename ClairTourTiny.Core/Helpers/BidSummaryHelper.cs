using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Dto.DTOs;

public class BidSummaryHelper : IBidSummaryHelper
{
    private List<PhaseModel> _phases { get; set; }
    private List<ProjectBillingItemModel> _billingItems { get; set; }
    private List<ProjectBillingPeriodModel> _billingPeriods { get; set; }
    private List<ProjectBillingPeriodItemModel> _billingPeriodItems { get; set; }
    private List<ProjectBidExpenseModel> _bidExpenses { get; set; }
    private List<ProjectCrewModel> _crews { get; set; }
    private List<ExpenseCode> _expenseCode { get; set; }
    private List<JobType> _jobTypes { get; set; }
    private List<PropertyTypeDTO> _propertyTypes { get; set; }
    private ClairTourTinyContext _dbContext { get; set; }

    public BidSummaryHelper(
        List<PhaseModel> phases,
        List<ProjectBillingItemModel> billingItems,
        List<ProjectBillingPeriodModel> billingPeriods,
        List<ProjectBillingPeriodItemModel> billingPeriodItems,
        List<ProjectBidExpenseModel> bidExpenses,
        List<ProjectCrewModel> crews,
        List<ExpenseCode> expenseCode,
        List<JobType> jobTypes,
        List<PropertyTypeDTO> propertyTypes,
        ClairTourTinyContext dbContext)
    {
        _phases = phases;
        _billingItems = billingItems;
        _billingPeriods = billingPeriods;
        _billingPeriodItems = billingPeriodItems;
        _bidExpenses = bidExpenses;
        _crews = crews;
        _expenseCode = expenseCode;
        _jobTypes = jobTypes;
        _propertyTypes = propertyTypes;
        _dbContext = dbContext;
    }

    public BidSummaryResponse GetBidSummaryData(string entityNo)
    {
        var response = GetDefaultBidSummaryResponse(entityNo,out PhaseModel selectedPhase, out PropertyTypeDTO selectedPropType);
        var isBidDailyPricing = selectedPropType?.BidValueType != null && selectedPropType.BidValueType == "Dry Hire";
        var operationalExpenseTotals = GetOperationalExpenseTotals(selectedPhase, entityNo, out List<ProjectBidExpenseModel> allExpenses);
        response.Equipment = GetEquipmentsSummary(selectedPhase, entityNo, selectedPhase.BidMarkup ?? 0, selectedPropType?.BidFactor ?? 0, isBidDailyPricing, operationalExpenseTotals);
        response.Crew = GetCrewsSummary(selectedPhase, entityNo, selectedPhase.BidMarkup ?? 0, selectedPropType?.BidFactor ?? 0, isBidDailyPricing, operationalExpenseTotals);
        response.Expenses = GetExpensesSummary(selectedPhase, entityNo, selectedPhase.BidMarkup ?? 0, selectedPropType?.BidFactor ?? 0, isBidDailyPricing, allExpenses);
        double equipWeekly = response.Equipment.Subtotal.WeeklyTotal;
        double crewWeekly = response.Crew.Subtotal.WeeklyTotal;
        double weeklyExpWeekly = response.Expenses.WeeklyExpensesSubtotal?.WeeklyTotal ?? 0;
        double fixedAmortizedExpClientWeekly = response.Expenses.SingleExpensesSubtotal?.ClientTotal ?? 0;
        response.WeeklyTotal = equipWeekly + operationalExpenseTotals.EquipmentWeekly +
                              crewWeekly + operationalExpenseTotals.CrewWeekly +
                              weeklyExpWeekly +
                              fixedAmortizedExpClientWeekly;

        response.GrandTotal = response.Equipment.Subtotal.ProjectTotal +
                             response.Crew.Subtotal.ProjectTotal +
                             (response.Expenses.WeeklyExpensesSubtotal?.ProjectTotal ?? 0) +
                             (response.Expenses.SingleExpensesSubtotal?.ProjectTotal ?? 0);

        response.BenchmarkTotal = response.Equipment.Subtotal.ProjectBenchmark +
                                 response.Crew.Subtotal.ProjectBenchmark +
                                 (response.Expenses.WeeklyExpensesSubtotal?.ProjectBenchmark ?? 0) +
                                 (response.Expenses.SingleExpensesSubtotal?.ProjectBenchmark ?? 0);

        response.QuoteMinGrandTotal = response.WeeklyTotal - equipWeekly;
        response.QuoteEquipmentValue = response.Equipment.Subtotal.BidValue;
        response.OverrideMarkupPercentage = (selectedPhase.BidMarkup ?? 0) * 100;
        response.ProposedWeekly = response.WeeklyTotal;
        response.ProposedTotal = response.GrandTotal;

        return response;
    }

    private BidSummaryResponse GetDefaultBidSummaryResponse(string entityNo,out PhaseModel selectedPhase, out PropertyTypeDTO selectedPropType)
    {
        var currentPhase = _phases.FirstOrDefault(p => p.EntityNo == entityNo);
        if (currentPhase == null)
        {
            selectedPhase = new PhaseModel();
            selectedPropType = new PropertyTypeDTO();
            return new BidSummaryResponse();
        }
        var currentPropType = _propertyTypes.FirstOrDefault(pt => pt.PropType == currentPhase.PropType);
        selectedPhase = currentPhase;
        selectedPropType = currentPropType ?? new();
        _billingPeriodItems.Where(bpi => bpi.BidEntityNo == entityNo || bpi.BidEntityNo.StartsWith($"{entityNo}-"))?.ToList().ForEach(bpi =>
        {
            bpi.ItemDescription = GetBillingItemDescription(bpi);
        });
        return new BidSummaryResponse()
        {
            DefaultMarkupPercentage = selectedPropType?.BidFactor ?? 0,
            RevenueOnSalesForecast = !string.IsNullOrEmpty(selectedPhase.SfActiveCd) && selectedPhase.SfActiveCd.Equals("A"),
            BillingPeriods = _billingPeriods.Where(bp => bp.BidEntityNo == entityNo || bp.BidEntityNo.StartsWith($"{entityNo}-")).ToList(),
            BillingPeriodItems = _billingPeriodItems.Where(bpi => bpi.BidEntityNo == entityNo || bpi.BidEntityNo.StartsWith($"{entityNo}-")).ToList(),
        };
    }

    private OperationalExpenseTotals GetOperationalExpenseTotals(PhaseModel bidPhase, string entityNo, out List<ProjectBidExpenseModel> allExpenses)
    {
        var operationalExpenseTotals = new OperationalExpenseTotals();
        allExpenses = _bidExpenses
            .Where(bdExp => bdExp.EntityNo == entityNo || bdExp.EntityNo.StartsWith($"{entityNo}-"))
            .ToList();

        var operationalExpenses = allExpenses
            .Where(ex => ex.Category == "O")
            .ToList();

        foreach (var oe in operationalExpenses)
        {
            double cost = oe.Type switch
            {
                "S" or "F" => oe.Cost / (bidPhase.PropType == "TOUR" ?
                    DaysBetween(bidPhase.StartDate, bidPhase.EndDate) / 7.0 : 1),
                "W" => oe.Cost,
                "D" => oe.Cost * 7,
                _ => 0
            };

            var budgetCategory = _expenseCode
                .FirstOrDefault(ec => ec.ExpCd == oe.ExpenseCode)
                ?.BudgetCategoryCode;

            if (budgetCategory == "E")
                operationalExpenseTotals.EquipmentWeekly += cost;
            else if (budgetCategory == "L")
                operationalExpenseTotals.CrewWeekly += cost;
        }

        return operationalExpenseTotals;
    }

    private int DaysBetween(DateTime startDate, DateTime endDate)
    {
        return (endDate - startDate).Days + 1;
    }

    public string GetFormattedDescription(ProjectBidExpenseModel expense)
    {
        return $"{(expense.Category == "O" ? "** " : "")}" +
               $"{_expenseCode.Find(ec => ec.ExpCd == expense.ExpenseCode)?.Description ?? ""}" +
               $"{(!string.IsNullOrEmpty(expense.Notes) ? " - " + expense.Notes : "")}";
    }

    private double GetDaysBilledFromDaysUsed(PhaseModel selectedPhase, double DaysUsed)
    {
        string billingCompany = selectedPhase.BillingCompany;
        string propType = selectedPhase.PropType;
        var missingDaysUsedBelow = _dbContext.BillingDaysBenchmarks
            .Where(bdb => bdb.Company == billingCompany && bdb.Proptype == propType && bdb.Daysused < DaysUsed)
            .Select(bdb => (double?)bdb.Daysused)
            .DefaultIfEmpty()
            .Max();
        var missingDaysUsedAbove = _dbContext.BillingDaysBenchmarks
            .Where(bdb => bdb.Company == billingCompany && bdb.Proptype == propType && bdb.Daysused > DaysUsed)
            .Select(bdb => (double?)bdb.Daysused)
            .DefaultIfEmpty()
            .Min();
        int daysUsedLowerBound = (int)Math.Max(DaysUsed - 30, missingDaysUsedBelow.HasValue ? missingDaysUsedBelow.Value + 1 : 1);
        int daysUsedUpperBound = (int)Math.Min(DaysUsed + 30, missingDaysUsedAbove.HasValue ? missingDaysUsedAbove.Value - 1 : 99999);
        var benchmarkList = _dbContext.BillingDaysBenchmarks.Where(bdb => bdb.Company == billingCompany && bdb.Proptype == propType && bdb.Daysused >= daysUsedLowerBound && bdb.Daysused <= daysUsedUpperBound).ToList();
        var bd = benchmarkList.FirstOrDefault(bdb => bdb.Daysused == DaysUsed);
        if (bd == null)
        {
            int num = (int)DaysUsed;
            double DaysBilled = DaysUsed;
            if (num > 2)
            {
                if (num < 3 || num > 6)
                {
                    if (num >= 7)
                    {
                        DaysBilled = DaysUsed;
                    }
                }
                else
                {
                    DaysBilled = 7;
                }
            }
            else
            {
                DaysBilled = 2.33333333333333 * DaysUsed;
            }
            return DaysBilled;
        }
        else
            return bd.Daysbilled;
    }

    private int DailyPricingMultiplier(bool isBidDailyPricing) => isBidDailyPricing ? 7 : 1;
    private EquipmentSummaryResponse GetEquipmentsSummary(PhaseModel bidPhaseRow, string entityNo, double fMarkupToUse, double fMarkupDefault, bool isBidDailyPricing, OperationalExpenseTotals operationalExpenseTotals)
    {
        var response = new EquipmentSummaryResponse();
        double equipWeekly = 0;
        double equipProjectTotal = 0;
        double equipBenchmarkTotal = 0;
        var equipmentTotals = _phases.Where(p => p.EntityNo == entityNo || p.EntityNo.StartsWith($"{entityNo}-"))
            .Select(pr => new
            {
                entityno = pr.EntityNo,
                entitydesc = pr.EntityDesc,
                TotalEquipmentCost = pr.TotalCubicInches
            })
            .Where(x => x.TotalEquipmentCost != 0);
        double equipValue = equipmentTotals.Sum(x => x.TotalEquipmentCost) * DailyPricingMultiplier(isBidDailyPricing);
        equipWeekly = equipValue * fMarkupToUse;

        foreach (var equipment in equipmentTotals)
        {
            var item = new ItemSummary
            {
                EntityNo = equipment.entityno ?? string.Empty,
                Description = string.IsNullOrEmpty(equipment.entitydesc) ?
                    equipment.entityno ?? string.Empty :
                    equipment.entitydesc.Replace(bidPhaseRow.EntityDesc ?? string.Empty, string.Empty).Trim(),
                BidValue = equipment.TotalEquipmentCost,
                MultiplierSymbol = "@",
                MarkupPercentage = fMarkupToUse * 100
            };

            double itemCost = item.BidValue * fMarkupToUse * DailyPricingMultiplier(isBidDailyPricing);
            double itemBenchmark = item.BidValue * fMarkupDefault * DailyPricingMultiplier(isBidDailyPricing);

            item.BaseWeekly = itemCost;
            double itemShareOfOperationalExpenses = equipWeekly == 0 ? 0 : operationalExpenseTotals.EquipmentWeekly * (itemCost / equipWeekly);

            item.WeeklyOperationalExpense = itemShareOfOperationalExpenses;
            item.WeeklyTotal = itemCost + itemShareOfOperationalExpenses;
            item.DailyRate = (itemCost + itemShareOfOperationalExpenses) / 7;

            var billingItem = _billingItems.FirstOrDefault(bi =>
                bi.BidEntityNo == entityNo &&
                bi.EquipmentEntityNo == equipment.entityno);

            if (billingItem != null)
            {
                var periodItems = _billingPeriodItems
                    .Where(bpi => bpi.BidEntityNo == entityNo &&
                           bpi.ItemNo == billingItem.ItemNo &&
                           bpi.IsActive)
                    .ToList();
                item.ItemNo = billingItem.ItemNo;
                var activePeriodItems = periodItems
                    .Where(pi => _billingPeriods.Any(bp =>
                        bp.BidEntityNo == pi.BidEntityNo &&
                        bp.PeriodNo == pi.PeriodNo &&
                        bp.IsActive));

                item.TotalDays = activePeriodItems.Sum(pi => pi.Days ?? 0);
                double itemBenchmarkTotal = 0;

                foreach (var periodItem in activePeriodItems)
                {
                    var periodItemBenchmarkDays = GetDaysBilledFromDaysUsed(bidPhaseRow,periodItem.ActivePeriodDays ?? 0);
                    if (!isBidDailyPricing && billingItem.EquipmentEntityNo != null)
                    {
                        if (periodItems.Sum(pi=>pi.ActivePeriodDays??0) > periodItemBenchmarkDays)
                            periodItemBenchmarkDays = periodItem.ActivePeriodDays ?? 0;
                    }
                    itemBenchmarkTotal += ((itemBenchmark + itemShareOfOperationalExpenses) / 7) * periodItemBenchmarkDays;
                }
                if (itemBenchmarkTotal == 0)
                {
                    var itemTotalBenchmarkDays = periodItems.Sum(pi => pi.ActivePeriodDays ?? 0);
                    var itemTotalBillingDaysBenchmark = itemTotalBenchmarkDays == 0 ? 0 : GetDaysBilledFromDaysUsed(bidPhaseRow,itemTotalBenchmarkDays);
                    itemBenchmarkTotal = ((itemBenchmark + itemShareOfOperationalExpenses) / 7) * itemTotalBillingDaysBenchmark;
                }
                item.ProjectTotal = periodItems.Sum(pi => pi.ActiveActualValue) ?? 0;
                item.ProjectBenchmark = itemBenchmarkTotal;
                item.CalculateVariance();
                equipProjectTotal += item.ProjectTotal;
                equipBenchmarkTotal += itemBenchmarkTotal;
            }
            
            response.Items.Add(item);
        }

        if (equipWeekly != 0)
        {
            response.Subtotal = new SubtotalSummary
            {
                BaseWeekly = equipWeekly,
                WeeklyOperationalExpense = operationalExpenseTotals.EquipmentWeekly,
                WeeklyTotal = equipWeekly + operationalExpenseTotals.EquipmentWeekly,
                DailyRate = (equipWeekly + operationalExpenseTotals.EquipmentWeekly) / 7,
                ProjectTotal = equipProjectTotal,
                ProjectBenchmark = equipBenchmarkTotal,
                BidValue = equipValue
            };
            response.Subtotal.CalculateVariance();
        }
        return response;
    }

    private CrewSummaryResponse GetCrewsSummary(PhaseModel bidPhaseRow, string entityNo, double fMarkupToUse, double fMarkupDefault, bool isBidDailyPricing, OperationalExpenseTotals operationalExpenseTotals)
    {
        var response = new CrewSummaryResponse();
        double crewWeekly = 0;
        double crewProjectTotal = 0;
        double crewBenchmarkTotal = 0;

        var entityCrews = _crews
            .Where(c => c.EntityNo == entityNo || c.EntityNo.StartsWith($"{entityNo}-"))
            .ToList();

        var totalCrewSize = entityCrews.Sum(x => x.CrewSize);

        foreach (var cr in entityCrews)
        {
            double days = 7;
            double hours = 8;
            var job = _jobTypes.FirstOrDefault(jt => jt.JobTypeCode == cr.JobType);
            if (job != null)
            {
                hours = job.Hours;
            }
            double itemCost = cr.EstRate * hours * days;
            double crewItemWeekly = itemCost * cr.CrewSize;
            crewWeekly += crewItemWeekly;
            var item = new ItemSummary
            {
                CrewSize = cr.CrewSize,
                Description = $"{cr.JobType} - {cr.JobDesc}",
                BidValue = itemCost,
                MultiplierSymbol = "x",
                CrewSizeMultiplier = cr.CrewSize,
                BaseWeekly = crewItemWeekly
            };

            double itemShareOfOperationalExpenses = totalCrewSize == 0 ? 0 : operationalExpenseTotals.CrewWeekly / totalCrewSize * cr.CrewSize;

            item.WeeklyOperationalExpense = itemShareOfOperationalExpenses;
            item.WeeklyTotal = crewItemWeekly + itemShareOfOperationalExpenses;
            item.DailyRate = (crewItemWeekly + itemShareOfOperationalExpenses) / 7;

            var billingItem = _billingItems.FirstOrDefault(bi =>
                bi.BidEntityNo == entityNo &&
                bi.CrewEntityNo == cr.EntityNo &&
                bi.CrewEmpLineNo == cr.EmpLineNo);
            if (billingItem != null)
            {
                var periodItems = _billingPeriodItems
                    .Where(bpi => bpi.BidEntityNo == entityNo &&
                           bpi.ItemNo == billingItem.ItemNo &&
                           bpi.IsActive)
                    .ToList();
                item.ItemNo = billingItem.ItemNo;
                var activePeriodItems = periodItems
                    .Where(pi => _billingPeriods.Any(bp =>
                        bp.BidEntityNo == pi.BidEntityNo &&
                        bp.PeriodNo == pi.PeriodNo &&
                        bp.IsActive));
                item.TotalDays = activePeriodItems.Sum(a=>a.ActivePeriodDays??0);
                item.ProjectTotal = activePeriodItems.Sum(a=>a.ActiveActualValue) ?? 0;
                item.ProjectBenchmark = ((crewItemWeekly + itemShareOfOperationalExpenses) / 7) * item.TotalDays;
                item.CalculateVariance();
                crewProjectTotal += item.ProjectTotal;
                crewBenchmarkTotal += item.ProjectBenchmark;
            }
            response.Items.Add(item);
        }
        if (crewWeekly != 0)
        {
            response.Subtotal = new SubtotalSummary
            {
                BaseWeekly = crewWeekly,
                WeeklyOperationalExpense = operationalExpenseTotals.CrewWeekly,
                WeeklyTotal = crewWeekly + operationalExpenseTotals.CrewWeekly,
                DailyRate = (crewWeekly + operationalExpenseTotals.CrewWeekly) / 7,
                ProjectTotal = crewProjectTotal,
                ProjectBenchmark = crewBenchmarkTotal
            };
            response.Subtotal.CalculateVariance();
        }
        return response;
    }

    private ExpenseSummaryResponse GetExpensesSummary(PhaseModel bidPhaseRow, string entityNo, double fMarkupToUse, double fMarkupDefault, bool isBidDailyPricing, List<ProjectBidExpenseModel> allExpenses)
    {
        var response = new ExpenseSummaryResponse
        {
            WeeklyExpenses = new List<ItemSummary>(),
            SingleExpenses = new List<ItemSummary>()
        };
        var weeklyExpenses = allExpenses.Where(e => e.Type == "W" || e.Type == "D");
        foreach (var we in weeklyExpenses)
        {
            var weeklyExpCost = we.Cost * (we.Type == "W" ? 1 : 7);
            var item = new ItemSummary
            {
                EntityNo = we.EntityNo,
                Description = GetFormattedDescription(we),
                Category = we.Category,
                ExpenseType = we.Type,
                BidValue = we.Cost,
                WeeklyTotal = we.Category != "O" ? weeklyExpCost : 0,
                DailyRate = we.Category != "O" ? weeklyExpCost / 7 : 0
            };

            var billingItem = _billingItems.FirstOrDefault(bi =>
                bi.BidEntityNo == entityNo &&
                bi.ExpenseEntityNo == we.EntityNo &&
                bi.ExpenseSeqNo == we.SeqNo);

            if (billingItem != null)
            {
                var periodItems = _billingPeriodItems
                    .Where(bpi => bpi.BidEntityNo == entityNo && bpi.ItemNo == billingItem.ItemNo)
                    .ToList();
                item.ItemNo = billingItem.ItemNo;
                item.TotalDays = periodItems.Sum(pi => pi.ActivePeriodDays ?? 0);
                item.ProjectTotal = (periodItems.Sum(pi => pi.ActiveActualValue ?? 0));
                item.ProjectBenchmark = ((weeklyExpCost / 7) * item.TotalDays);
                item.CalculateVariance();
            }
            response.WeeklyExpenses.Add(item);
        }
        if (response.WeeklyExpenses.Any())
        {
            response.WeeklyExpensesSubtotal = new SubtotalSummary
            {
                WeeklyTotal = response.WeeklyExpenses.Sum(we => we.WeeklyTotal),
                DailyRate = response.WeeklyExpenses.Sum(we => we.DailyRate),
                ProjectTotal = response.WeeklyExpenses.Sum(we => we.ProjectTotal),
                ProjectBenchmark = response.WeeklyExpenses.Sum(we => we.ProjectBenchmark),
                ClientTotal = response.WeeklyExpenses.Where(we => we.Category != "O").Sum(we => we.WeeklyTotal),
                OperationalTotal = response.WeeklyExpenses.Where(we => we.Category == "O").Sum(we => we.WeeklyTotal)
            };
            response.WeeklyExpensesSubtotal.CalculateVariance();
        }
        var singleExpenses = allExpenses.Where(e => e.Type == "S" || e.Type == "F");
        foreach (var se in singleExpenses)
        {
            var itemCost = se.Cost;
            var item = new ItemSummary
            {
                EntityNo = se.EntityNo,
                Description = GetFormattedDescription(se),
                Category = se.Category,
                ExpenseType = se.Type,
                Cost = itemCost,
                BidValue = se.Category == "O" ? itemCost : 0,
                ProjectBenchmark = se.Category != "O" ? itemCost : 0
            };

            var billingItem = _billingItems.FirstOrDefault(bi =>
                bi.BidEntityNo == entityNo &&
                bi.ExpenseEntityNo == se.EntityNo &&
                bi.ExpenseSeqNo == se.SeqNo);

            if (billingItem != null)
            {
                var periodItems = _billingPeriodItems
                    .Where(bpi => bpi.BidEntityNo == entityNo &&
                           bpi.ItemNo == billingItem.ItemNo &&
                           bpi.IsActive == true)
                    .ToList();
                item.ItemNo = billingItem.ItemNo;
                item.TotalDays = periodItems
                    .Where(pi => _billingPeriods.Any(bp =>
                        bp.BidEntityNo == pi.BidEntityNo &&
                        bp.PeriodNo == pi.PeriodNo &&
                        bp.IsActive))
                    .Sum(pi => pi.ActivePeriodDays ?? 0);
                if (se.Type == "F")
                {
                    var totalActivePeriodDays = periodItems
                        .Where(pi => _billingPeriods.Any(bp =>
                            bp.BidEntityNo == pi.BidEntityNo &&
                            bp.PeriodNo == pi.PeriodNo &&
                            bp.IsActive))
                        .Sum(pi => pi.ActivePeriodDays ?? 0);

                    item.ProjectTotal = totalActivePeriodDays;
                }
                else
                {
                    item.ProjectTotal = (periodItems.Sum(pi => pi.ActiveActualValue ?? 0));
                }
                item.CalculateVariance();
            }
            response.SingleExpenses.Add(item);
        }
        if (response.SingleExpenses.Any())
        {
            response.SingleExpensesSubtotal = new SubtotalSummary
            {
                ProjectTotal = response.SingleExpenses.Sum(se => se.ProjectTotal),
                ProjectBenchmark = response.SingleExpenses.Sum(se => se.ProjectBenchmark),
                ClientTotal = response.SingleExpenses.Where(se => se.Category != "O").Sum(se => se.Cost),
                OperationalTotal = response.SingleExpenses.Where(se => se.Category == "O").Sum(se => se.Cost)
            };
            response.SingleExpensesSubtotal.CalculateVariance();
        }
        return response;
    }

    private string GetBillingItemDescription(ProjectBillingPeriodItemModel billingPeriodItem)
    {
        var bidPhaseRow = _phases.FirstOrDefault(p => p.EntityNo == billingPeriodItem.BidEntityNo);
        var crew = _phases.FirstOrDefault(p => p.EntityNo == billingPeriodItem.CrewEntityNo);
        var expense = _phases.FirstOrDefault(p => p.EntityNo == billingPeriodItem.ExpenseEntityNo);
        var equipment = _phases.FirstOrDefault(p => p.EntityNo == billingPeriodItem.EquipmentEntityNo);
        var parentProjectDescription = new[] {
            crew?.EntityDesc,
            expense?.EntityDesc,
            equipment?.EntityDesc
        }.FirstOrDefault(desc => !string.IsNullOrEmpty(desc)) ?? string.Empty;
        var bidProjectDescription = bidPhaseRow?.EntityDesc ?? string.Empty;
        var parentWords = parentProjectDescription.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var bidWords = bidProjectDescription.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int i = 0;
        while (i < Math.Min(parentWords.Length, bidWords.Length) && parentWords[i].ToLower()== bidWords[i].ToLower())
        {
            i++;
        }
        var shortened = string.Join(" ", parentWords.Skip(i).Except(new[] { "BID" }, StringComparer.OrdinalIgnoreCase));
        if (crew != null)
        {
            var bidCrew = _crews.FirstOrDefault(cr => cr.EntityNo == billingPeriodItem.CrewEntityNo && cr.SeqNo== billingPeriodItem.CrewSeqNo) ?? new();
            var maybeCrewSize = bidCrew.CrewSize > 1 ? $" ({bidCrew.CrewSize})" : "";
            return $"{shortened}: {bidCrew.JobDesc}{maybeCrewSize}".TrimStart(' ', ':');
        }
        else if (expense != null)
        {
            var bidExpense = _bidExpenses.FirstOrDefault(bdExp => bdExp.EntityNo == billingPeriodItem.ExpenseEntityNo && bdExp.SeqNo==billingPeriodItem.ExpenseSeqNo) ?? new();
            var maybeAsterisks = bidExpense.Category == "O" ? "**" : "";
            var maybeNotes = !string.IsNullOrWhiteSpace(bidExpense.Notes) ? $" - {bidExpense.Notes.Trim()}" : "";
            var expenseCode = _expenseCode.FirstOrDefault(ec => ec.ExpCd == bidExpense.ExpenseCode) ?? new();
            return $"{shortened} Expense: {maybeAsterisks}{expenseCode.Description}{maybeNotes}".Trim();
        }
        else if (equipment != null)
        {
            return string.IsNullOrWhiteSpace(shortened) ? "Equipment" : $"{shortened} Equipment";
        }
        else
        {
            return "???";
        }
    }
}