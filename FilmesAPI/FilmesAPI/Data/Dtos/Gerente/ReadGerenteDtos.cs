﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class ReadGerenteDtos
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
