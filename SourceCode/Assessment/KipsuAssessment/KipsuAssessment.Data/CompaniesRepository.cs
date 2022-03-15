using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using KipsuAssessment.Models;
using System.IO;

namespace KipsuAssessment.Data
{
    public class CompaniesRepository
    {
        private List<Company> _companies = new List<Company>();

        public List<Company> GetCompanies()
        {
            string path = "Files/Companies.json";

            var file = new StreamReader(path);
            string json = file.ReadToEnd();

            _companies = JsonSerializer.Deserialize<List<Company>>(json);

            return _companies;
        }

        public Company GetCompanyById(int id)
        {
            _companies = GetCompanies();

            return _companies.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
