using Core2.Business;
using Core2.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : ICrudServiceRepository<User>
    {
        IDataResult<List<UserDetailsDto>> GetUserDetails();
        IDataResult<List<UserDetailsDto>> GetUserDetailsById(int id);
    }
}