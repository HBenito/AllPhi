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
            await _unitOfWork.AdministrationRepository.AddCompany(company);
            if (await _unitOfWork.Complete())
                return Ok();

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
            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return Ok(companiesToReturn);
        }


    }
}