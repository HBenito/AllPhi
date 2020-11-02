using Microsoft.EntityFrameworkCore;
using Register.Api.Data.Interfaces;
using Register.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Data.Repositories
{
    public class AdministrationRepository : IAdministrationRepository
    {
        private readonly DataContext _context;

        public AdministrationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Company> AddCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
            return company;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee.Id;
        }

        public async Task AddEmployeeToCompany(EmployeeCompany employeeCompany)
        {
            await _context.EmployeeCompanies.AddAsync(employeeCompany);
        }

        public async Task<List<Employee>> FindEmployees(string firstName, string lastName)
        {
            return await _context.Employees.Where(x => x.FirstName == firstName && x.LastName == lastName).ToListAsync();
        }

        public async Task<List<Company>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Company>> GetCompaniesByName(string name)
        {
            return await _context.Companies.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<List<EmployeeCompany>> GetEmployees(int companyId)
        {
            return await _context.EmployeeCompanies.Where(x => x.CompanyId == companyId).ToListAsync();
        }

        public async Task<List<Visit>> GetVisitors()
        {
            return await _context.Visits.Where(x => x.Departure > DateTime.Now).ToListAsync();
        }

        public async Task<List<Visit>> GetVisitorsByCompany(int companyId)
        {
            return await _context.Visits.Where(x => x.CompanyId == companyId).ToListAsync();
        }

        public async Task<List<Visit>> GetVisitorsByEmail(string email)
        {
            return await _context.Visits.Where(x => x.Email == email).ToListAsync();
        }

        public async Task<List<Visit>> GetVisitorsByEmployee(int employeeId)
        {
            return await _context.Visits.Where(x => x.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<List<Visit>> GetVisitorsByName(string firstName)
        {
            return await _context.Visits.Where(x => x.FirstName == firstName).ToListAsync();
        }

        public async Task RemoveCompany(int companyId)
        {
            List<EmployeeCompany> employeeCompanies = await _context.EmployeeCompanies.Where(x => x.CompanyId == companyId).ToListAsync();
            
            foreach(EmployeeCompany removeEmployeeCompany in employeeCompanies)
            {
                await RemoveEmployeeFromCompany(removeEmployeeCompany.EmployeeId, removeEmployeeCompany.CompanyId);
            }
            _context.Remove(await _context.Companies.Where(x => x.Id == companyId).FirstOrDefaultAsync());
        }

        public async Task RemoveEmployeeFromCompany(int employeeId, int companyId)
        {
            _context.Remove(await _context.EmployeeCompanies.Where(x => x.EmployeeId == employeeId && x.CompanyId == companyId).FirstOrDefaultAsync());
            if (!await _context.EmployeeCompanies.AnyAsync(x => x.EmployeeId == employeeId))
                _context.Remove(await _context.Employees.Where(x => x.Id == employeeId).FirstOrDefaultAsync());
        }

        public async Task<Company> GetCompanyById(int Id)
        {
            return await _context.Companies.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
