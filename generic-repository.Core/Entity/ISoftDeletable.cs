using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Core.Entity
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedTime { get; set; }
    }
}
