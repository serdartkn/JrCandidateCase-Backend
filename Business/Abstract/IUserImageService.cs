using Core2.Business;
using Core2.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IDataResult<List<UserImage>> GetAll(Expression<Func<UserImage, bool>> filter = null);
        IDataResult<UserImage> GetById(int id);
        //IDataResult<List<UserImage>> GetByUserId(int id);
        IResult Add(IFormFile file, UserImage userImage);
        IResult Update(IFormFile file, UserImage userImage);
        IResult Delete(UserImage userImage);
    }
}