using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Business.Models.ResultModel
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
