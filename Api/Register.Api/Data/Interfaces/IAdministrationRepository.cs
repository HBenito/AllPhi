using Register.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Data.Interfaces
{
    public interface IAdministrationRepository
    {
        Task<List<Company>> GetCompanies();
        Task<Company> AddCompany(Company company);
        Task RemoveCompany(int companyId);
        Task RemoveEmployee(int EmployeeId);
        Task<List<Company>> GetCompaniesByName(string name);
        Task<List<EmployeeCompany>> GetEmployees(int companyId);
        Task<List<Employee>> GetEmployees();
        Task<List<Employee>> FindEmployees(string firstName, string lastName);
        Task<List<Employee>> FindEmployees(string src);
        Task<int> AddEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int id);
        Task AddEmployeeToCompany(EmployeeCompany employeeCompany);
        Task RemoveEmployeeFromCompany(int employeeId, int companyId);
        Task<List<Visit>> GetVisitors();
        Task<List<Visit>> GetVisitorsByName(string firstName);
        Task<List<Visit>> GetVisitorsByEmail(string email);
        Task<List<Visit>> GetVisitorsByCompany(int companyId);
        Task<List<Visit>> GetVisitorsByEmployee(int employeeId);
        Task<Company> GetCompanyById(int Id);
    }
}
