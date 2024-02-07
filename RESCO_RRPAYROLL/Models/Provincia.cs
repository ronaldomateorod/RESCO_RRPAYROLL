using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime? FechaModificacion { get; set; }
        public string? ModificadoPor { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
