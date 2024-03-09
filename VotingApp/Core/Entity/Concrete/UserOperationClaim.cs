using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int OperationClaim { get; set; }
    }
}
