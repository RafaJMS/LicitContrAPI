using System;
using System.Collections.Generic;

namespace LicitContrAPI.Models
{
    public partial class Lote
    {
        public Lote()
        {
            Objetos = new HashSet<Objeto>();
        }

        public int IdLote { get; set; }
        public int? IdLicitacao { get; set; }
        public string Descricao { get; set; } = null!;
        public decimal? ValorEstimadoTotal { get; set; }

        public virtual Licitacao? IdLicitacaoNavigation { get; set; }
        public virtual ICollection<Objeto> Objetos { get; set; }
    }
}
