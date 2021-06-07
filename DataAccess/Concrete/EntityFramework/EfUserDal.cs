using Core2.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, JrCandidateCaseContext>, IUserDal
    {
        public List<UserDetailsDto> GetUserDetails(Expression<Func<UserDetailsDto, bool>> filter = null)
        {
            using (JrCandidateCaseContext context = new JrCandidateCaseContext())
            {
                var result = from u in context.Users
                             join l in context.Locations on u.Id equals l.UserId
                             join s in context.Streets on l.StreetId equals s.Id
                             join g in context.Genders on u.GenderId equals g.Id
                             join i in context.UserImages on u.Id equals i.UserId
                             //let image = (from i in context.UserImages where u.Id == i.UserId select i.ImagePath)

                             select new UserDetailsDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Gender = g.GenderType,
                                 DateOfBirth = u.DateOfBirth,
                                 Email = u.Email,
                                 Phone = u.Phone,
                                 Street = s.Name + s.Number,
                                 State = l.State,
                                 City = l.City,
                                 Country = l.Country,
                                 PostCode = l.PostCode,
                                 ImagePath = i.ImagePath
                                 //ImagePath = image.Any() ? image.FirstOrDefault() : new UserImage { ImagePath = "Images/DefaultPp.jpg" }.ImagePath

                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}