using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_Sales.Models
{
    public class Occasion
    {
        public int OccasionID { get; set; }
        public string OccasionName { get; set; }
        public DateTime OccasionDate { get; set; }
        public int ReminderDays { get; set; }
        public string Description { get; set; }
        public bool RepeatYearly { get; set; }
        public int DaysLeft { get; set; }
    }
}
