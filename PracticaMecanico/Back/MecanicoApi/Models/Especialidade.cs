using System;
using System.Collections.Generic;

#nullable disable

namespace MecanicoApi.Models
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Mecanicos = new HashSet<Mecanico>();
        }

        public int EspecialidadId { get; set; }
        public string Especialidad { get; set; }

        public virtual ICollection<Mecanico> Mecanicos { get; set; }
    }
}
