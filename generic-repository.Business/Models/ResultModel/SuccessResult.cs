using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Business.Models.ResultModel
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(success: true, message)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
