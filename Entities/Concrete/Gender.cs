using Core2.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Gender : IEntity
    {
        public int Id { get; set; }        
        public String GenderType { get; set; }
    }
}