using GestionNotificaciones.Data;
using GestionNotificaciones.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionNotificaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotificacionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("reporte/{idReporte}")]
        public async Task<IActionResult> GetNotificacionesReporte(int idReporte)
        {
            var notificaciones = await _context.Notificaciones
                .Include(n => n.Reporte)
                .Where(n => n.idReporte == idReporte)
                .ToListAsync();
            return Ok(notificaciones);
        }

        [HttpGet("vecino/{idDestinatario}")]
        public async Task<IActionResult> GetNotificacionesVecino(int idDestinatario)
        {
            var notificaciones = await _context.Notificaciones
                .Include (n => n.Reporte)
                .Where(n => n.Reporte.idVecino == idDestinatario && !n.leido)
                .AnyAsync();
            return Ok(notificaciones);
        }

        [HttpPost]
        public async Task<IActionResult> CrearNotificacion([FromBody] Notifica dto)
        {
            Notificacion notificacion = new Notificacion();
            notificacion.idReporte = dto.idReporte;
            notificacion.mensaje = dto.mensaje;
            notificacion.leido = false;
            notificacion.fecha = DateTime.UtcNow;
            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();
            return Ok(notificacion);
        }

        [HttpPost("{id}/marcar-leida")]
        public async Task<IActionResult> MarcarComoLeida(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion == null) return NotFound();
            notificacion.leido = true;
            await _context.SaveChangesAsync();
            return Ok(notificacion);
        }
    }
    public class Notifica 
    {
        public int idReporte { get; set; }
        public string mensaje { get; set; }
    }
}
