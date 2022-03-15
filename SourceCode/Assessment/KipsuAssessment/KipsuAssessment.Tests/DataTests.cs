using KipsuAssessment.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KipsuAssessment.Tests
{
    [TestFixture]
    public class DataTests
    {
        [Test]
        public void CanLoadCompanies()
        {
            var repo = new CompaniesRepository();

            var result = repo.GetCompanies();

            Assert.AreEqual(5, result.Count);
            Assert.AreEqual("Hotel California", result[0].Name);
            Assert.AreEqual("US/Central", result[3].Timezone);
        }

        [Test]
        public void CanLoadCompanyById()
        {
            var repo = new CompaniesRepository();

            var result = repo.GetCompanyById(2);

            Assert.AreEqual("The Grand Budapest Hotel", result.Name);
        }

        [Test]
        public void CanLoadGuests()
        {
            var repo = new GuestsRepository();

            var result = repo.GetGuests();

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual("Candy", result[0].FirstName);
            Assert.AreEqual("Herrera", result[4].LastName);
            Assert.AreEqual(new DateTime(2017, 2, 9, 9, 39, 52), result[0].Reservation.StartDate);
        }
    }
}
