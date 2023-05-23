using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LeapYear.Form;
using LeapYear.Services;
using LeapYear.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Microsoft.Extensions.Logging;

namespace LeapYear.Pages
{
    public class IndexModel : PageModel
    {
        public readonly ILogger<IndexModel> _logger;
        private readonly YearFormContext _context;
        private readonly ILeapYearInterface _leapYearService;

        [BindProperty]

        public YearForm YearForm { get; set; }
        public IList<YearForm> YearForms { get; set; }


        public IndexModel(ILogger<IndexModel> logger, YearFormContext context, ILeapYearInterface leapYearService)
        {
            _logger = logger;
            _context = context;
            _leapYearService = leapYearService;
        }

        public void OnGet()
        {

        }

        
        public IActionResult OnPost()
        {
            _leapYearService.AddResult(YearForm);

            return Page();
        }
    }
}