using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eder_web_api.modules.auth.enums;

using Microsoft.AspNetCore.Identity;

namespace eder_web_api.modules.auth.entities
{
    public class UserRole : IdentityRole<Guid>
    {
        public int RoleType { get; set; } = 1;


    }
}
