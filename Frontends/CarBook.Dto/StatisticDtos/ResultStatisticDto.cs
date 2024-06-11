using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticDtos
{
    public class ResultStatisticDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public decimal HourlyAvgPricing { get; set; }
        public decimal DailyAvgPricing { get; set; }
        public decimal WeeklyAvgPricing { get; set; }
        public int AutomaticTransmissionCarCount { get; set; }
        public string? BrandName { get; set; }
        public string? BlogTitle { get; set; }
        public int GasolineOrDieselCarCount { get; set; }
        public int ElectricCarCount { get; set; }
        public string? CarModel { get; set; }
    }
}
