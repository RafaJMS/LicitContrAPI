using System;
using System.Collections.Generic;

namespace LicitContrAPI.Models
{
    public partial class Entidade
    {
        public Entidade()
        {
            Contratos = new HashSet<Contrato>();
            Licitacos = new HashSet<Licitaco>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdEntidade { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public string? Endereco { get; set; }
        public string? Contato { get; set; }

        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Licitaco> Licitacos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
