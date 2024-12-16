namespace GestionNotificaciones.Models
{
    public class Reporte
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int imagen { get; set; }

        // Relaciones
        public int idVecino { get; set; }
        public Vecino Vecino { get; set; }
        public int idEstado { get; set; }
        public EstadoReporte Estado { get; set; }
        public int idTipo { get; set; }
        public TipoReporte Tipo { get; set; }
    }
}
