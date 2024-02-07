using System;
using System.Collections.Generic;

namespace RESCO_RRPAYROLL.Models
{
    public partial class Estado
    {
        public Estado()
        {
            ActividadesAsignada = new HashSet<ActividadesAsignada>();
            Clientes = new HashSet<Cliente>();
            Empleados = new HashSet<Empleado>();
            Nominas = new HashSet<Nomina>();
            Pagos = new HashSet<Pago>();
            Proyectos = new HashSet<Proyecto>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime? FechaModificacion { get; set; }
        public string? ModificadoPor { get; set; }

        public virtual ICollection<ActividadesAsignada> ActividadesAsignada { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Nomina> Nominas { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
