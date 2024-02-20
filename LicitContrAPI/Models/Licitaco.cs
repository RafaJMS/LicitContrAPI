using System;
using System.Collections.Generic;

namespace LicitContrAPI.Models
{
    public partial class Licitaco
    {
        public Licitaco()
        {
            Lotes = new HashSet<Lote>();
        }

        public int IdLicitacao { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string? Modalidade { get; set; }
        public int? IdEntidade { get; set; }
        public decimal? ValorEstimado { get; set; }
        public string? Status { get; set; }

        public virtual Entidade? IdEntidadeNavigation { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }
    }
}
