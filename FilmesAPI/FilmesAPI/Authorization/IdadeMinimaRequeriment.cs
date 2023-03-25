using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Authorization
{
    public class IdadeMinimaRequeriment : IAuthorizationRequirement
    {
        public int IdadeMinima { get; set; }

        public IdadeMinimaRequeriment(int idadeMinima)
        {
            IdadeMinima = idadeMinima;
        }
    }
}
