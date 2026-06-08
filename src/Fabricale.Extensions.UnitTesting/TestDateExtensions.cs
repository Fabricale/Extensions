using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabricale.Extensions.UnitTesting
{
    [TestClass]
    public sealed class TestDateExtensions
    {

        [TestMethod]
        [DataRow(2020, 1, 1, 18, 0, 0, JulianDateFormats.Standard, 2458850.25)]
        [DataRow(2020, 1, 2, 0, 0, 0, JulianDateFormats.Standard, 2458850.5)]
        [DataRow(2020, 1, 2, 6, 0, 0, JulianDateFormats.Standard, 2458850.75)]
        [DataRow(2020, 1, 1, 0, 0, 0, JulianDateFormats.Standard, 2458849.5)]
        [DataRow(2020, 1, 1, 0, 0, 0, JulianDateFormats.Modified, 58849)]
        [DataRow(2020, 1, 1, 0, 0, 0, JulianDateFormats.Reduced, 58849.5)]
        [DataRow(2020, 1, 1, 12, 0, 0, JulianDateFormats.Standard, 2458850)]
        [DataRow(2020, 1, 1, 12, 0, 0, JulianDateFormats.Modified, 58849.5)]
        [DataRow(2020, 1, 1, 12, 0, 0, JulianDateFormats.Reduced, 58850)]
        [DataRow(2024, 2, 29, 0, 0, 0, JulianDateFormats.AS400, 124060)]
        [DataRow(2026, 6, 5, 0, 0, 0, JulianDateFormats.AS400, 126156)]
        [DataRow(2026, 1, 1, 0, 0, 0, JulianDateFormats.AS400, 126001)]
        public void JulianDateConversion(int year, int month, int day, int hour, int minute, int second, JulianDateFormats format, double expectedResult)
        {
            Assert.AreEqual(expectedResult, new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc).ToJulian(format));
        }

        [TestMethod]
        [DataRow(2026, 6, 1, 10, 2026, 6, 15, DisplayName = "June 1st 2026 - Add 10 Days")]
        [DataRow(2026, 6, 2, 10, 2026, 6, 16, DisplayName = "June 2nd 2026 - Add 10 Days")]
        [DataRow(2026, 6, 3, 10, 2026, 6, 17, DisplayName = "June 3rd 2026 - Add 10 Days")]
        [DataRow(2026, 6, 4, 10, 2026, 6, 18, DisplayName = "June 4th 2026 - Add 10 Days")]
        [DataRow(2026, 6, 5, 10, 2026, 6, 19, DisplayName = "June 5th 2026 - Add 10 Days")]
        [DataRow(2026, 6, 6, 10, 2026, 6, 19, DisplayName = "June 6th 2026 - Add 10 Days")]
        [DataRow(2026, 6, 7, 10, 2026, 6, 19, DisplayName = "June 7th 2026 - Add 10 Days")]
        [DataRow(2026, 6, 1, 16, 2026, 6, 23, DisplayName = "June 1st 2026 - Add 16 Days")]
        [DataRow(2026, 6, 2, 16, 2026, 6, 24, DisplayName = "June 2nd 2026 - Add 16 Days")]
        [DataRow(2026, 6, 3, 16, 2026, 6, 25, DisplayName = "June 3rd 2026 - Add 16 Days")]
        [DataRow(2026, 6, 4, 16, 2026, 6, 26, DisplayName = "June 4th 2026 - Add 16 Days")]
        [DataRow(2026, 6, 5, 16, 2026, 6, 29, DisplayName = "June 5th 2026 - Add 16 Days")]
        [DataRow(2026, 6, 6, 16, 2026, 6, 29, DisplayName = "June 6th 2026 - Add 16 Days")]
        [DataRow(2026, 6, 7, 16, 2026, 6, 29, DisplayName = "June 7th 2026 - Add 16 Days")]
        [DataRow(2026, 6, 1, -10, 2026, 5, 18, DisplayName = "June 1st 2026 - Subtract 10 Days")]
        [DataRow(2026, 6, 2, -10, 2026, 5, 19, DisplayName = "June 2nd 2026 - Subtract 10 Days")]
        [DataRow(2026, 6, 3, -10, 2026, 5, 20, DisplayName = "June 3rd 2026 - Subtract 10 Days")]
        [DataRow(2026, 6, 4, -10, 2026, 5, 21, DisplayName = "June 4th 2026 - Subtract 10 Days")]
        [DataRow(2026, 6, 5, -10, 2026, 5, 22, DisplayName = "June 5th 2026 - Subtract 10 Days")]
        [DataRow(2026, 6, 6, -10, 2026, 5, 25, DisplayName = "June 6th 2026 - Subtract 10 Days")]
        [DataRow(2026, 6, 7, -10, 2026, 5, 25, DisplayName = "June 7th 2026 - Subtract 10 Days")]
        [DataRow(2026, 6, 1, -16, 2026, 5, 8, DisplayName = "June 1st 2026 - Subtract 16 Days")]
        [DataRow(2026, 6, 2, -16, 2026, 5, 11, DisplayName = "June 2nd 2026 - Subtract 16 Days")]
        [DataRow(2026, 6, 3, -16, 2026, 5, 12, DisplayName = "June 3rd 2026 - Subtract 16 Days")]
        [DataRow(2026, 6, 4, -16, 2026, 5, 13, DisplayName = "June 4th 2026 - Subtract 16 Days")]
        [DataRow(2026, 6, 5, -16, 2026, 5, 14, DisplayName = "June 5th 2026 - Subtract 16 Days")]
        [DataRow(2026, 6, 6, -16, 2026, 5, 15, DisplayName = "June 6th 2026 - Subtract 16 Days")]
        [DataRow(2026, 6, 7, -16, 2026, 5, 15, DisplayName = "June 7th 2026 - Subtract 16 Days")]
        public void AddBusinessDays(int year, int month, int day, int nDays, int expYear, int expMonth, int expDay)
        {
            Assert.AreEqual(new DateTime(expYear, expMonth, expDay), new DateTime(year, month, day).AddBusinessDays(nDays));
        }

    }
}
