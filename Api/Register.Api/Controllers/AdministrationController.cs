using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.Api.Data.Interfaces;
using Register.Api.Dtos;
using Register.Api.Models;

namespace Register.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdministrationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("addcompany")]
        public async Task<IActionResult> AddCompany(CompanyDto companyToAdd)
        {
            var company = _mapper.Map<Company>(companyToAdd);
            company = await _unitOfWork.AdministrationRepository.AddCompany(company);
            if (await _unitOfWork.Complete())
                return CreatedAtRoute("GetCompany", new { controller = "Administration", id = company.Id }, company);


            return BadRequest("something went wrong");
        }

        [HttpPost("addemployee")]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeToAdd)
        {
            var employee = _mapper.Map<Employee>(employeeToAdd);
            int employeeId = await _unitOfWork.AdministrationRepository.AddEmployee(employee);
            if (await _unitOfWork.Complete())
                return CreatedAtRoute("GetEmployee", new { controller = "Administration", id = employeeId }, employee);


            return BadRequest("something went wrong");
        }

        [HttpPost("addnewemployee")]
        public async Task<IActionResult> AddNewEmployee(NewEmployeeToCompany newEmployeeToCompany)
        {
            var employee = new Employee
            {
                FirstName = newEmployeeToCompany.FirstName,
                LastName = newEmployeeToCompany.LastName
            };

            var employeeId = await _unitOfWork.AdministrationRepository.AddEmployee(employee);
            EmployeeCompany employeeCompany = new EmployeeCompany
            {
                EmployeeId = employeeId,
                CompanyId = newEmployeeToCompany.CompanyId
            };

            await _unitOfWork.AdministrationRepository.AddEmployeeToCompany(employeeCompany);
            if (await _unitOfWork.Complete())
                return Ok();

            return BadRequest("something went wrong");
        }

        [HttpPost("addexistingemployee/{employeeid}/{companyid}")]
        public async Task<IActionResult> AddExistingEmployee(int employeeid, int companeeid)
        {
            EmployeeCompany employeeCompany = new EmployeeCompany
            {
                EmployeeId = employeeid,
                CompanyId = companeeid
            };

            await _unitOfWork.AdministrationRepository.AddEmployeeToCompany(employeeCompany);
            if (await _unitOfWork.Complete())
                return Ok();

            return BadRequest("something went wrong");
        }

        [HttpGet("getcompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            List<Company> companies = await _unitOfWork.AdministrationRepository.GetCompanies();

            return Ok(companies);
        }

        [HttpGet("getcompanyemployees/{id}")]
        public async Task<IActionResult> getCompanyEmployees(int id)
        {
            List<EmployeeCompany> employeeCompanies = await _unitOfWork.AdministrationRepository.GetEmployees(id);
            List<Employee> employees = new List<Employee>();
            foreach(EmployeeCompany employeeCompany in employeeCompanies)
            {
                employees.Add(employeeCompany.Employee);
            }

            return Ok(employees);
        }

        [HttpGet("getemployees")]
        public async Task<IActionResult> GetEmployees()
        {
            List<Employee> employees = await _unitOfWork.AdministrationRepository.GetEmployees();

            return Ok(employees);
        }

        [HttpGet("getcompanies/{src}")]
        public async Task<IActionResult> GetCompanies(string src)
        {
            List<Company> companies = await _unitOfWork.AdministrationRepository.GetCompaniesByName(src);

            return Ok(companies);
        }

        [HttpGet("getemployees/{src}")]
        public async Task<IActionResult> GetEmployes(string src)
        {
            List<Employee> employees = await _unitOfWork.AdministrationRepository.FindEmployees(src);

            return Ok(employees);
        }

        [HttpGet("getcompany/{id}", Name = "GetCompany")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _unitOfWork.AdministrationRepository.GetCompanyById(id);
            return Ok(company);
        }

        [HttpGet("getemployee/{id}", Name = "GetEmployee")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _unitOfWork.AdministrationRepository.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpDelete("removecompany/{id}")]
        public async Task<IActionResult> RemoveCompany(int id)
        {
            await _unitOfWork.AdministrationRepository.RemoveCompany(id);
            if(await _unitOfWork.Complete())
                return Ok();

            return BadRequest("couldn't remove company");
        }

        [HttpDelete("removeemployee/{id}")]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await _unitOfWork.AdministrationRepository.RemoveEmployee(id);
            if (await _unitOfWork.Complete())
                return Ok();

            return BadRequest("couldn't remove company");
        }
    }
}