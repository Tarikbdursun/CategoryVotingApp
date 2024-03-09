using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Concrete
{
    public class User : IEntity
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
