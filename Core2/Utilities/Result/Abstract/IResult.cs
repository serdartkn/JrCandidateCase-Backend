using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core2.Utilities.Result.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
