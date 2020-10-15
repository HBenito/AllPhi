using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IAdministrationRepository AdministrationRepository { get; }
        IRegisterRepository RegisterRepository { get; }
        Task<bool> Complete();
    }
}
