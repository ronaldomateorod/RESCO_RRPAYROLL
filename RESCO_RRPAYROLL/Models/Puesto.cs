using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models
{
    public partial class Puesto
    {
        public Puesto()
        {
            EmpleadoProyectos = new HashSet<EmpleadoProyecto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime? FechaModificacion { get; set; }
        public string? ModificadoPor { get; set; }

        public virtual ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; }
    }
}
