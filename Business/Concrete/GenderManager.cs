using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core2.Aspect.Autofac.Validation;
using Core2.Utilities.Result.Abstract;
using Core2.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenderManager : IGenderService
    {
        IGenderDal _genderDal;
        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }

        [ValidationAspect(typeof(GenderValidator))]
        public IResult Add(Gender gender)
        {
            _genderDal.Add(gender);
            return new SuccessResult(Messages.GenderAdded);
        }

        [ValidationAspect(typeof(GenderValidator))]
        public IResult Delete(Gender gender)
        {
            _genderDal.Delete(gender);
            return new SuccessResult(Messages.GenderDeleted);
        }

        public IDataResult<List<Gender>> GetAll()
        {
            return new SuccessDataResult<List<Gender>>(_genderDal.GetAll(), Messages.GenderListed);
        }

        public IDataResult<Gender> GetById(int id)
        {
            return new SuccessDataResult<Gender>(_genderDal.Get(g => g.Id == id), Messages.GenderListed);
        }

        [ValidationAspect(typeof(GenderValidator))]
        public IResult Update(Gender gender)
        {
            _genderDal.Update(gender);
            return new SuccessResult(Messages.GenderUpdated);
        }
    }
}