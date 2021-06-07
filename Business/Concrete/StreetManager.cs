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
    public class StreetManager : IStreetService                      
    {
        IStreetDal _streetDal;
        public StreetManager(IStreetDal streetDal)
        {
            _streetDal = streetDal;
        }

        [ValidationAspect(typeof(StreetValidator))]
        public IResult Add(Street street)
        {
            _streetDal.Add(street);
            return new SuccessResult(Messages.StreetAdded);
        }

        [ValidationAspect(typeof(StreetValidator))]
        public IResult Delete(Street street)
        {
            _streetDal.Delete(street);
            return new SuccessResult(Messages.StreetDeleted);
        }

        public IDataResult<List<Street>> GetAll()
        {
            return new SuccessDataResult<List<Street>>(_streetDal.GetAll(), Messages.StreetListed);
        }

        public IDataResult<Street> GetById(int id)
        {
            return new SuccessDataResult<Street>(_streetDal.Get(s => s.Id == id), Messages.StreetListed);
        }

        [ValidationAspect(typeof(StreetValidator))]
        public IResult Update(Street street)
        {
            _streetDal.Update(street);
            return new SuccessResult(Messages.StreetUpdated);
        }
    }
}