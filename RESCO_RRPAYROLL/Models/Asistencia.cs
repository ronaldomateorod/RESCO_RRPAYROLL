using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models
{
    public partial class Asistencia
    {
        public Asistencia()
        {
            Horas = new HashSet<Hora>();
            Permisos = new HashSet<Permiso>();
        }

        public int Id { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int IdEmpleadoProyecto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime? FechaModificacion { get; set; }
        public string? ModificadoPor { get; set; }

        public virtual EmpleadoProyecto IdEmpleadoProyectoNavigation { get; set; } = null!;
        public virtual ICollection<Hora> Horas { get; set; }
        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}
