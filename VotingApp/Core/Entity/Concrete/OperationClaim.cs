﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Concrete
{
    public class OperationClaim : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
