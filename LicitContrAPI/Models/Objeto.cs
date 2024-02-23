using System;
using System.Collections.Generic;

namespace LicitContrAPI.Models
{
    public partial class Objeto
    {
        public Objeto()
        {
            Contratos = new HashSet<Contrato>();
        }

        public int IdObjeto { get; set; }
        public string Descricao { get; set; } = null!;
        public string? Categoria { get; set; }
        public decimal? ValorEstimado { get; set; }
        public int? Quantidade { get; set; }
        public string? Observacoes { get; set; }
        public int? IdLote { get; set; }
        public int? IdFornecedor { get; set; }

        public virtual Fornecedor? IdFornecedorNavigation { get; set; }
        public virtual Lote? IdLoteNavigation { get; set; }
        public virtual ICollection<Contrato> Contratos { get; set; }
    }
}
