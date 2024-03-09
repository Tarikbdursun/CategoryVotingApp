using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class UserForLoginDto:IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
