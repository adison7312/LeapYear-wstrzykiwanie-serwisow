using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LeapYear.Form;
using LeapYear.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Net;
using LeapYear.Pages;
using LeapYear.Pagination;
using Microsoft.EntityFrameworkCore;
using System;

namespace LeapYear.Pages
{
    public class ZapisaneModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly YearFormContext _yearFormContext;
        private readonly ILeapYearInterface _leapYearService;
        public PaginatedList<YearForm> YearForms { get; set; }
        public IQueryable<YearForm> Records { get; set; }

        public ZapisaneModel(YearFormContext yearFormContext, IConfiguration configuration, ILeapYearInterface leapYearService)
        {
            _yearFormContext = yearFormContext;
            _configuration = configuration;
            _leapYearService = leapYearService;
        }

        public async Task OnGetAsync(int? pageIndex)
        {
            Records = _leapYearService.GetAllResults();

            IQueryable<YearForm> yearNameFormsIQ = from s in _yearFormContext.YearForm select s;

            yearNameFormsIQ = yearNameFormsIQ.OrderByDescending(s => s.Timestamp);

            int pageSize = _configuration.GetValue<int>("PageSize");
            YearForms = await PaginatedList<YearForm>.CreateAsync(
                               yearNameFormsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
