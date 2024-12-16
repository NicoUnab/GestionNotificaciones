namespace GestionNotificaciones.Models
{
    public class Notificacion
    {
        public int id { get; set; }
        public string mensaje { get; set; }
        public DateTime fecha { get; set; }
        public bool leido { get; set; }

        // Relación con Reporte
        public int idReporte { get; set; }
        public Reporte Reporte { get; set; }

        //// Relación con Vecino
        //public int idVecino { get; set; }
        //public Vecino Destinatario { get; set; }
    }
}
