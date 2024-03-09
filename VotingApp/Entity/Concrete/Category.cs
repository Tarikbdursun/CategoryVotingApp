using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Category : IEntity
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public int VoteCount { get; set; }
    }
}
