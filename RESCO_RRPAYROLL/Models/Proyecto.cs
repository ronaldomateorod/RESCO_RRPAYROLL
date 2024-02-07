using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Actividades = new HashSet<Actividade>();
            EmpleadoProyectos = new HashSet<EmpleadoProyecto>();
            Nominas = new HashSet<Nomina>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cliente { get; set; } = null!;
        public string? Locacion { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime? FechaModificacion { get; set; }
        public string? ModificadoPor { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        public virtual ICollection<Actividade> Actividades { get; set; }
        public virtual ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; }
        public virtual ICollection<Nomina> Nominas { get; set; }
    }
}
