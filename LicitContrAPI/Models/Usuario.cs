using System;
using System.Collections.Generic;

namespace LicitContrAPI.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? NivelPermissao { get; set; }
        public int? IdEntidade { get; set; }

        public virtual Entidade? IdEntidadeNavigation { get; set; }
    }
}
