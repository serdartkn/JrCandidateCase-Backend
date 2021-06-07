﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core2.Aspect.Autofac.Validation;
using Core2.CrossCuttingConcerns.Validation.FluentValidation;
using Core2.Utilities.Result.Abstract;
using Core2.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {

            return new SuccessDataResult<List<User>>(_userDal.GetAll().OrderBy(u => u.FirstName).ThenBy(u=>u.LastName).ToList(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserListed);
        }

        public IDataResult<List<UserDetailsDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailsDto>>(_userDal.GetUserDetails().OrderBy(u=>u.FirstName).ThenBy(u=>u.LastName).ToList(), Messages.UserListed);
        }

        public IDataResult<List<UserDetailsDto>> GetUserDetailsById(int id)
        {
             return new SuccessDataResult<List<UserDetailsDto>>(_userDal.GetUserDetails(u => u.UserId == id), Messages.UserListed);

        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}