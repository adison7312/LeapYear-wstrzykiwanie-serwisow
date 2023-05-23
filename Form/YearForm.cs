using System.ComponentModel.DataAnnotations;

namespace LeapYear.Form
{
    public class YearForm
    {
        public int Id { get; set; }

        [Display(Name = "Year"), Required(ErrorMessage = "Podaj rok!")]
        public int Year { get; set; }

        [Display(Name = "Name"), StringLength(100, ErrorMessage = "Maksymalna długość to {0} znaków")]
        public string ?Name { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;


        public string Result()
        {
            string result;
            if ((Year % 4 == 0 && Year % 100 != 0) || Year % 400 == 0) result = "";
            else result = "nie";

            if (Name == null)
            {
                return Year + " to " + result + " rok przestępny";
            }

            if (Name.EndsWith("a"))
            {
                return Name + " urodziła się w " + Year + " roku. To " + result + " rok przestępny";
            }
            else
            {
                return Name + " urodził się w " + Year + " roku. To " + result + " rok przestępny";
            }
        }
    }
}