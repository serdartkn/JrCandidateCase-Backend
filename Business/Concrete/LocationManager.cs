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
    public class LocationManager : ILocationService
    {
        ILocationDal _locationDal;
        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        [ValidationAspect(typeof(LocationValidator))]
        public IResult Add(Location location)
        {
            _locationDal.Add(location);
            return new SuccessResult(Messages.LocationAdded);
        }

        [ValidationAspect(typeof(LocationValidator))]
        public IResult Delete(Location location)
        {
            _locationDal.Delete(location);
            return new SuccessResult(Messages.LocationDeleted);
        }

        public IDataResult<List<Location>> GetAll()
        {
            return new SuccessDataResult<List<Location>>(_locationDal.GetAll(), Messages.LocationListed);
        }

        public IDataResult<Location> GetById(int id)
        {
            return new SuccessDataResult<Location>(_locationDal.Get(l => l.Id == id), Messages.LocationListed);
        }

        [ValidationAspect(typeof(LocationValidator))]
        public IResult Update(Location location)
        {
            _locationDal.Update(location);
            return new SuccessResult(Messages.LocationUpdated);
        }
    }
}