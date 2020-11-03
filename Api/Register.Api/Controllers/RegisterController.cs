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
    public class RegisterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("addvisit")]
        public async Task<IActionResult> AddVisit(VisitDto visitDto)
        {
            Visit visit = _mapper.Map<Visit>(visitDto);
            visit.Arrival = DateTime.Now;
            visit.Departure = DateTime.Today.AddDays(1).AddSeconds(-1);
            visit = await _unitOfWork.RegisterRepository.LogIn(visit);
            if (await _unitOfWork.Complete())
                return Ok();


            return BadRequest("something went wrong");
        }

        [HttpGet("getvisits")]
        public async Task<IActionResult> GetVisits()
        {
            List<Visit> visits = await _unitOfWork.RegisterRepository.GetVisits();

            return Ok(visits);
        }

        [HttpGet("getvisits/{src}")]
        public async Task<IActionResult> GetCompanies(string src)
        {
            List<Visit> visits = await _unitOfWork.RegisterRepository.GetVisits(src);

            return Ok(visits);
        }
        [HttpPost("logout/{id}")]
        public async Task<IActionResult> LogOut(int id)
        {
            await _unitOfWork.RegisterRepository.LogOut(id);
            if (await _unitOfWork.Complete())
                return Ok();


            return BadRequest("something went wrong");
        }

    }
}