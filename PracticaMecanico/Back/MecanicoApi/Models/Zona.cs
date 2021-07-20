using System;
using System.Collections.Generic;

#nullable disable

namespace MecanicoApi.Models
{
    public partial class Zona
    {
        public Zona()
        {
            Mecanicos = new HashSet<Mecanico>();
        }

        public int ZonaId { get; set; }
        public string Zona1 { get; set; }

        public virtual ICollection<Mecanico> Mecanicos { get; set; }
    }
}
