using Microsoft.EntityFrameworkCore;
using Register.Api.Data.Interfaces;
using Register.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Data.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly DataContext _context;

        public RegisterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Visit>> GetVisits()
        {
            return await _context.Visits.Where(x => x.Arrival < DateTime.Now && x.Departure > DateTime.Now).ToListAsync();
        }

        public async Task<List<Visit>> GetVisits(string src)
        {
            return await _context.Visits.Where(x => x.Arrival < DateTime.Now && x.Departure > DateTime.Now && x.Email.Contains(src)).ToListAsync();
        }

        public async Task<Visit> LogIn(Visit visit)
        {
            await _context.Visits.AddAsync(visit);
            return visit;
        }

        public async Task LogOut(int id)
        {
            var visitToLogOut = await _context.Visits.Where(x => x.Id == id).FirstOrDefaultAsync();
            visitToLogOut.Departure = DateTime.Now;
            _context.Entry(visitToLogOut).Property(x => x.Departure).IsModified = true;
        }
    }
}
