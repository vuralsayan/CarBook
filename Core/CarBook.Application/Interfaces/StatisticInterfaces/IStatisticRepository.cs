using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticInterfaces
{
    public interface IStatisticRepository
    {
        Task<int> GetCarCount();                                        // Araba sayısı
        Task<int> GetLocationCount();                                   // Lokasyon sayısı
        Task<int> GetAuthorCount();                                     // Yazar sayısı
        Task<int> GetBlogCount();                                       // Blog sayısı
        Task<int> GetBrandCount();                                      // Marka sayısı
        Task<decimal> GetHourlyAvgPricing();                            // Saatlik ortalama araç kiralama fiyatı
        Task<decimal> GetDailyAvgPricing();                             // Günlük ortalama araç kiralama fiyatı
        Task<decimal> GetWeeklyAvgPricing();                            // Haftalık ortalama araç kiralama fiyatı
        Task<int> GetCarsWithAutomaticTransmission();                   // Otomatik vitesli araç sayısı
        Task<string> GetBrandWithTheMostCar();                          // En fazla araca sahip marka
        Task<string> GetBlogTitleWithTheMostComments();                 // En fazla yoruma sahip blog başlığı
        Task<int> GetCarWithLessThan1000Km();                           // 1000 km'den az olan araçların sayısı
        Task<int> GetGasolineOrDieselCar();                             // Benzinli veya Dizel araçların sayısı
        Task<int> GetElectricCar();                                     // Elektrikli araçların sayısı
        Task<string> GetCarModelWithTheMostExpensiveDailyPricing();     // Günlük kiralama fiyatı en pahalı olan araç modeli
        Task<string> GetCarModelWithTheCheapestDailyPricing();          // Günlük kiralama fiyatı en ucuz olan araç modeli
    }
}