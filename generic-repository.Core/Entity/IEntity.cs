using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Core.Entity
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime? UpdatedTime { get; set; }
    }
}
