using LeapYear.Interfaces;
using LeapYear.Form;
using System;

namespace LeapYear.Services
{
    public class LeapYearInterface : ILeapYearInterface
    {
        private readonly YearFormContext _context;
        public LeapYearInterface(YearFormContext context)
        {
            _context = context;
        }

        public IQueryable<YearForm> GetAllResults()
        {
            return _context.YearForm;
        }

        public void AddResult(YearForm result)
        {
            _context.Set<YearForm>().Add(result);
            _context.SaveChanges();
        }
    }
}
