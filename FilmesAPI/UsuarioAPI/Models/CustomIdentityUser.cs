using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNacimento { get; set; }
    }
}
