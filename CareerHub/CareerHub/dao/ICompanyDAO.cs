using CareerHub.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.dao
{
    public interface ICompanyDAO
    {
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int companyId);
        Company GetCompanyById(int companyId);
        List<Company> GetAllCompanies();
    }
}
