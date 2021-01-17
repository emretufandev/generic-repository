using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Business.Models.ResultModel
{
    public class DataResult<T> : Result
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
