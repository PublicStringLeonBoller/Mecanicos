namespace Comandos
{
    public class ComandoUpdateMecanico
    {
        public int MecanicoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? EspecialidadId { get; set; }
        public int? ZonaId { get; set; }
        public bool? Soltero { get; set; }
    }
}