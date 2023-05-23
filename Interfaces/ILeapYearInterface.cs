using System;
using LeapYear.Form;

namespace LeapYear.Interfaces
{
    public interface ILeapYearInterface
    {
        public IQueryable<YearForm> GetAllResults();
        public void AddResult(YearForm yearForm);
    }
}
