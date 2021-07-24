using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilviaCosmeticos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public int Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
