using Core2.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public int StreetId { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String PostCode { get; set; }
        public int UserId { get; set; }

    }
}