﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilviaCosmeticos.Models
{
    public class Usuario
    {
      public int Id { get; set; }
      public string Nome {get; set; }
      public string Senha { get; set; }
      public string Email { get; set; }
    }
}
