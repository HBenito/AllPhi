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

        public async Task LogIn(Visit visit)
        {
            await _context.Visits.AddAsync(visit);
        }

        public async Task LogOut(string email)
        {
            var visitToLogOut = await _context.Visits.Where(x => x.Email == email).FirstOrDefaultAsync();
            visitToLogOut.Departure = DateTime.Now;
            _context.Entry(visitToLogOut).Property(x => x.Departure).IsModified = true;
        }
    }
}
