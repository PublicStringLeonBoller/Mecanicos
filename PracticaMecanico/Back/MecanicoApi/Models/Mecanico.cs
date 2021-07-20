using System;
using System.Collections.Generic;

#nullable disable

namespace MecanicoApi.Models
{
    public partial class Mecanico
    {
        public int MecanicoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? SexoId { get; set; }
        public int? EspecialidadId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? ZonaId { get; set; }
        public bool? Soltero { get; set; }

        public virtual Especialidade Especialidad { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual Zona Zona { get; set; }
    }
}
