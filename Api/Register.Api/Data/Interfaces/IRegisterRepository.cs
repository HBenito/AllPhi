using Register.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Data.Interfaces
{
    public interface IRegisterRepository
    {
        Task<Visit> LogIn(Visit visit);
        Task LogOut(int id);
        Task<List<Visit>> GetVisits();
        Task<List<Visit>> GetVisits(string src);

    }
}
