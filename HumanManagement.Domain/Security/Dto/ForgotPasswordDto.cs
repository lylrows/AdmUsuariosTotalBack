﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Security.Dto
{
    public class ForgotPasswordDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
