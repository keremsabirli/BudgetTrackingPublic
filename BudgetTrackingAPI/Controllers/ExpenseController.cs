using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BudgetTracking.DTOs;
using BudgetTracking.Errors;
using BudgetTracking.Models;
using BudgetTracking.Models.Enum;
using BudgetTracking.Repositories.Wrappers;
using BudgetTrackingAPI.Core.Date;
using BudgetTrackingAPI.Core.GenerateRandom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BudgetTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private DateHelper dateHelper;
        public ExpenseController(IRepositoryWrapper repoWrapper, IMapper mapper, IHttpClientFactory httpClientFactory) : base(repoWrapper, mapper) 
        {
            _httpClientFactory = httpClientFactory;
            dateHelper = new DateHelper();
        }
        [HttpGet("GenerateData")]
        public ActionResult<bool> GenerateData()
        {
            RandomHelper randomHelper = new RandomHelper();
            for (int i = 1; i < 29; i++)
            {
                Random rand = new Random();
                var categories = repoWrapper.Category.Get().ToList();
                var corporates = repoWrapper.Corporate.Get().ToList();
                Expense expense = new Expense()
                {
                    Name = "Expense",
                    UserID = BudgetTrackingUserResult.Id,
                    CategoryID = categories[rand.Next(0, categories.Count - 1)].Id,
                    CorporateID = corporates[rand.Next(0, corporates.Count - 1)].Id,
                    Amount = rand.Next(0, 600),
                    Date = randomHelper.RandomDate(DateTimeOffset.Now.AddDays(-720), 720),
                    City = "İstanbul",
                    IsActive = true,
                    CreatedDate = DateTimeOffset.Now,
                };
                repoWrapper.Expense.Insert(expense);
                repoWrapper.Save();
            }
            return true;
        }
        [HttpGet]
        public ActionResult<List<LiteExpenseDTO>> Get(DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            List<Expense> result = new List<Expense>();
            if (startDate == null) startDate = DateTimeOffset.MinValue;
            if (endDate == null) endDate = DateTimeOffset.MaxValue;
            result = repoWrapper.Expense.GetByCondition(x => x.UserID == BudgetTrackingUserResult.Id && x.Date > startDate && x.Date < endDate).ToList();
            return Ok(mapper.Map<IEnumerable<LiteExpenseDTO>>(result));
        }
        [HttpGet("Report/Daily")]
        public ActionResult<List<ReportData>> GetDailyReport(DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            if (startDate == null) startDate = DateTimeOffset.MinValue;
            if (endDate == null) endDate = DateTimeOffset.MaxValue;
            List<Expense> result = new List<Expense>();
            result = repoWrapper.Expense.GetByCondition(x => x.UserID == BudgetTrackingUserResult.Id && x.Date > startDate && x.Date < endDate).ToList();
            List<ReportData> dailyReport = new List<ReportData>();
            //Dictionary<string, double> dailyReport = new Dictionary<string, double>();
            result.Sort((x, y) => DateTimeOffset.Compare(x.Date, y.Date));
            foreach (Expense expense in result)
            {
                string dayName = dateHelper.GenerateDayString(expense.Date);
                if(dailyReport.Any(x => x.Date == dayName))
                {
                    dailyReport.FirstOrDefault(x => x.Date == dayName).Value += expense.Amount;
                }
                else
                {
                    dailyReport.Add(new ReportData()
                    {
                        Date = dayName,
                        Value = expense.Amount,
                        DateTime = expense.Date
                    });
                }
            }
            return Ok(dailyReport);
        }
        [HttpGet("Report/Weekly")]
        public ActionResult<Dictionary<string, int>> GetWeeklyReport(DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            if (startDate == null) startDate = DateTimeOffset.MinValue;
            if (endDate == null) endDate = DateTimeOffset.MaxValue;
            List<Expense> result;
            result = repoWrapper.Expense.GetByCondition(x => x.UserID == BudgetTrackingUserResult.Id && x.Date > startDate && x.Date < endDate).ToList();
            List<ReportData> weeklyReport = new List<ReportData>();
            result.Sort((x, y) => DateTimeOffset.Compare(x.Date, y.Date));
            foreach (Expense expense in result)
            {
                string weekName = dateHelper.GenerateWeekString(expense.Date);
                if (weeklyReport.Any(x => x.Date == weekName))
                {
                    weeklyReport.FirstOrDefault(x => x.Date == weekName).Value += expense.Amount;
                }
                else
                {
                    weeklyReport.Add(new ReportData()
                    {
                        Date = weekName,
                        Value = expense.Amount,
                        DateTime = expense.Date
                    });
                }
            }
            return Ok(weeklyReport);
        }
        [HttpGet("Report/Monthly")]
        public ActionResult<Dictionary<string, int>> GetMonthlyReport(DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            if (startDate == null) startDate = DateTimeOffset.MinValue;
            if (endDate == null) endDate = DateTimeOffset.MaxValue;
            List<Expense> result = new List<Expense>();
            result = repoWrapper.Expense.GetByCondition(x => x.UserID == BudgetTrackingUserResult.Id && x.Date > startDate && x.Date < endDate).ToList();
            List<ReportData> monthlyReport = new List<ReportData>();
            //Dictionary<string, double> monthlyReport = new Dictionary<string, double>();
            result.Sort((x, y) => DateTimeOffset.Compare(x.Date, y.Date));
            foreach (Expense expense in result)
            {
                string monthName = dateHelper.GenerateMonthString(expense.Date);
                if (monthlyReport.Any(x => x.Date == monthName))
                {
                    monthlyReport.FirstOrDefault(x => x.Date == monthName).Value += expense.Amount;
                }
                else
                {
                    monthlyReport.Add(new ReportData()
                    {
                        Date = monthName,
                        Value = expense.Amount,
                        DateTime = expense.Date
                    });
                }
            }
            return Ok(monthlyReport);
        }
        [HttpPost("Forecast/DayToWeek")]
        public async Task<ActionResult<List<ReportData>>> DayToWeekForecast(List<ReportData> expenses)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://budget-tracking-forecast.herokuapp.com/api/Expense/Forecast/DayToWeek");
            List<double> requestValues = new List<double>();
            expenses.ForEach(expense =>
            {
                requestValues.Add(expense.Value);
            });
            var response = await client.PostAsync("", new StringContent(JsonConvert.SerializeObject(requestValues), Encoding.UTF8, "application/json"));
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<double>>(jsonResult);
            var lastExpense = expenses.Last();
            List<ReportData> forecastReportDatas = new List<ReportData>();
            for (int i = 1; i < 7; i++)
            {
                ReportData currentData = new ReportData()
                {
                    Date = dateHelper.GenerateDayString(lastExpense.DateTime.AddDays(i)),
                    DateTime = lastExpense.DateTime.AddDays(i),
                    Value = result[i],
                };
                forecastReportDatas.Add(currentData);
            };
            return forecastReportDatas;
        }
        [HttpPost("Forecast/DayToMonth")]
        public async Task<ActionResult<List<ReportData>>> DayToMonthForecast(List<ReportData> expenses)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://budget-tracking-forecast.herokuapp.com/api/Expense/Forecast/DayToMonth");
            List<double> requestValues = new List<double>();
            expenses.ForEach(expense =>
            {
                requestValues.Add(expense.Value);
            });
            var response = await client.PostAsync("", new StringContent(JsonConvert.SerializeObject(requestValues), Encoding.UTF8, "application/json"));
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<double>>(jsonResult);
            var lastExpense = expenses.Last();
            List<ReportData> forecastReportDatas = new List<ReportData>();
            for (int i = 1; i < 31; i++)
            {
                ReportData currentData = new ReportData()
                {
                    Date = dateHelper.GenerateDayString(lastExpense.DateTime.AddDays(i)),
                    DateTime = lastExpense.DateTime.AddDays(i),
                    Value = result[i],
                };
                forecastReportDatas.Add(currentData);
            }
            return forecastReportDatas;
        }
        [HttpPost("Forecast/WeekToWeek")]
        public async Task<ActionResult<List<ReportData>>> WeekToWeekForecast(List<ReportData> expenses)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://budget-tracking-forecast.herokuapp.com/api/Expense/Forecast/WeekToWeek");
            List<double> requestValues = new List<double>();
            expenses.ForEach(expense =>
            {
                requestValues.Add(expense.Value);
            });
            var response = await client.PostAsync("", new StringContent(JsonConvert.SerializeObject(requestValues), Encoding.UTF8, "application/json"));
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<double>>(jsonResult);
            var lastExpense = expenses.Last();
            List<ReportData> forecastReportDatas = new List<ReportData>();
            ReportData reportData = new ReportData()
            {
                Date = dateHelper.GenerateDayString(lastExpense.DateTime.AddDays(7)),
                DateTime = lastExpense.DateTime.AddDays(7),
                Value = result[0]
            };
            forecastReportDatas.Add(reportData);
            return forecastReportDatas;
        }
        [HttpPost("Forecast/WeekToMonth")]
        public async Task<ActionResult<List<ReportData>>> WeekToMonthForecast(List<ReportData> expenses)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://budget-tracking-forecast.herokuapp.com/api/Expense/Forecast/WeekToMonth");
            List<double> requestValues = new List<double>();
            expenses.ForEach(expense =>
            {
                requestValues.Add(expense.Value);
            });
            var response = await client.PostAsync("", new StringContent(JsonConvert.SerializeObject(requestValues), Encoding.UTF8, "application/json"));
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<double>>(jsonResult);
            var lastExpense = expenses.Last();
            List<ReportData> forecastReportDatas = new List<ReportData>();
            for (int i = 1; i < 5; i++)
            {
                ReportData currentData = new ReportData()
                {
                    Date = dateHelper.GenerateDayString(lastExpense.DateTime.AddDays(i*7)),
                    DateTime = lastExpense.DateTime.AddDays(i*7),
                    Value = result[i],
                };
                forecastReportDatas.Add(currentData);
            }
            return forecastReportDatas;
        }
        [HttpPost("Forecast/MonthToMonth")]
        public async Task<ActionResult<List<ReportData>>> MonthToMonthForecast(List<ReportData> expenses)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://budget-tracking-forecast.herokuapp.com/api/Expense/Forecast/MonthToMonth");
            List<double> requestValues = new List<double>();
            expenses.ForEach(expense =>
            {
                requestValues.Add(expense.Value);
            });
            var response = await client.PostAsync("",new StringContent(JsonConvert.SerializeObject(requestValues), Encoding.UTF8, "application/json"));
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<double>>(jsonResult)[0];
            var lastExpense = expenses.Last();
            List<ReportData> forecastReportDatas = new List<ReportData>();
            ReportData reportData = new ReportData()
            {
                Date = dateHelper.GenerateDayString(lastExpense.DateTime.AddDays(7)),
                DateTime = lastExpense.DateTime.AddDays(7),
                Value = result
            };
            forecastReportDatas.Add(reportData);
            return forecastReportDatas;
        }
        [HttpPost]
        public ActionResult<ExpenseDTO> Post([FromBody] LiteExpenseDTO value)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (value == null) return BadRequest();
            try
            {
                repoWrapper.Expense.Insert(mapper.Map<Expense>(value));
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var entity = repoWrapper.Expense.GetById(id);
            if (entity == null) return BadRequest("Value with the given id is null");
            repoWrapper.Expense.Delete(entity);
            repoWrapper.Save();
            return Ok();
        }
    }
}