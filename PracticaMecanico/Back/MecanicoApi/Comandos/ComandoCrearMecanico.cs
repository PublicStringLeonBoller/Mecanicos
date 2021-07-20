using System;

namespace Comandos
{
    public class ComandoCrearMecanico
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? SexoId { get; set; }
        public int? EspecialidadId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? ZonaId { get; set; }
        public bool? Soltero { get; set; }
    }
}