using Business.Abstract;
using Core2.Utilities.Helpers;
using Core2.Utilities.Result.Abstract;
using Core2.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        IUserImageDal _userImageDal;
        public UserImageManager(IUserImageDal userImageDal) 
        {
            _userImageDal = userImageDal;
        }

        public IResult Add(IFormFile file, UserImage userImage)
        {
           
            userImage.ImagePath = FileHelper.Add(file);
            userImage.Date = DateTime.Now;
            _userImageDal.Add(userImage);
            return new SuccessResult();
        }

        public IResult Delete(UserImage userImage)
        {
            FileHelper.Delete(Environment.CurrentDirectory + @"\wwwroot\" + userImage.ImagePath);
            _userImageDal.Delete(userImage);
            return new SuccessResult();
        }

        public IDataResult<List<UserImage>> GetAll(Expression<Func<UserImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(filter));
        }

        public IDataResult<UserImage> GetById(int id)
        {
            return new SuccessDataResult<UserImage>(_userImageDal.Get(u => u.Id == id));
        }

        public IDataResult<List<UserImage>> GetByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, UserImage userImage)
        {
            userImage.ImagePath = FileHelper.Update(Environment.CurrentDirectory + @"\wwwroot\" + _userImageDal.Get(c => c.Id == userImage.Id).ImagePath, file);
            userImage.Date = DateTime.Now;
            _userImageDal.Update(userImage);
            return new SuccessResult();
        }
    }
}