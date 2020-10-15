using Register.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Data.Interfaces
{
    public interface IRegisterRepository
    {
        Task LogIn(Visit visit);
        Task LogOut(string email);
    }
}
