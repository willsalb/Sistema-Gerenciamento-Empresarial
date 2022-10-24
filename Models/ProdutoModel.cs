using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Qtde { get; set; }
        public decimal ValorUnit { get; set; }
        public decimal Total { get; set; }

    }
}
