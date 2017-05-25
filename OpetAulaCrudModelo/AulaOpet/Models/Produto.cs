using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaOpet.Models
{
    public class Produto
    {
        public long? ProdutoId { get; set; }
        public string Nome { get; set; }

        public Int32? CategoriaId { get; set; }
        public long? FornecedorId { get; set; }

        public Categoria Categoria { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}