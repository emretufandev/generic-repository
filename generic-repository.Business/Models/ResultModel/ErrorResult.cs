using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Business.Models.ResultModel
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }
        public ErrorResult() : base(false)
        {
        }
    }
}
