using System;
using System.Collections.Generic;

#nullable disable

namespace MecanicoApi.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Mecanicos = new HashSet<Mecanico>();
        }

        public int SexoId { get; set; }
        public string Sexo1 { get; set; }

        public virtual ICollection<Mecanico> Mecanicos { get; set; }
    }
}
