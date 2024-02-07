using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RESCO_RRPAYROLL.Models
{
    public partial class RRPAYROLL_DBContext : DbContext
    {
        public RRPAYROLL_DBContext()
        {
        }

        public RRPAYROLL_DBContext(DbContextOptions<RRPAYROLL_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividade> Actividades { get; set; } = null!;
        public virtual DbSet<ActividadesAsignada> ActividadesAsignadas { get; set; } = null!;
        public virtual DbSet<Asistencia> Asistencias { get; set; } = null!;
        public virtual DbSet<Banco> Bancos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Deduccione> Deducciones { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<EmpleadoProyecto> EmpleadoProyectos { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Hora> Horas { get; set; } = null!;
        public virtual DbSet<Licencia> Licencias { get; set; } = null!;
        public virtual DbSet<Nacionalidade> Nacionalidades { get; set; } = null!;
        public virtual DbSet<Nomina> Nominas { get; set; } = null!;
        public virtual DbSet<NominaDeduccione> NominaDeducciones { get; set; } = null!;
        public virtual DbSet<NominaDetalle> NominaDetalles { get; set; } = null!;
        public virtual DbSet<NominaPercepcione> NominaPercepciones { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Percepcione> Percepciones { get; set; } = null!;
        public virtual DbSet<Permiso> Permisos { get; set; } = null!;
        public virtual DbSet<Provincia> Provincias { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<Puesto> Puestos { get; set; } = null!;
        public virtual DbSet<RolUsuario> RolUsuarios { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TipoCuenta> TipoCuentas { get; set; } = null!;
        public virtual DbSet<TipoNomina> TipoNominas { get; set; } = null!;
        public virtual DbSet<TipoPago> TipoPagos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=RRPAYROLL_DB;Trusted_connection=True;MultipleActiveResultSets=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividade>(entity =>
            {
                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__IdPro__6C190EBB");
            });

            modelBuilder.Entity<ActividadesAsignada>(entity =>
            {
                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.ActividadesAsignada)
                    .HasForeignKey(d => d.IdActividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__IdAct__6EF57B66");

                entity.HasOne(d => d.IdEmpleadoProyectoNavigation)
                    .WithMany(p => p.ActividadesAsignada)
                    .HasForeignKey(d => d.IdEmpleadoProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__IdEmp__6FE99F9F");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.ActividadesAsignada)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__IdEst__70DDC3D8");
            });

            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasOne(d => d.IdEmpleadoProyectoNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdEmpleadoProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asistenci__IdEmp__6383C8BA");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Rnc).HasColumnName("RNC");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clientes__IdEsta__4CA06362");
            });

            modelBuilder.Entity<Deduccione>(entity =>
            {
                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasOne(d => d.IdBancoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdBanco)
                    .HasConstraintName("FK__Empleados__IdBan__48CFD27E");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleados__IdEst__49C3F6B7");

                entity.HasOne(d => d.IdNacionalidadNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdNacionalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleados__IdNac__45F365D3");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleados__IdPro__46E78A0C");

                entity.HasOne(d => d.IdTipoCuentaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdTipoCuenta)
                    .HasConstraintName("FK__Empleados__IdTip__47DBAE45");
            });

            modelBuilder.Entity<EmpleadoProyecto>(entity =>
            {
                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.EmpleadoProyectos)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmpleadoP__IdEmp__60A75C0F");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.EmpleadoProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmpleadoP__IdPro__5FB337D6");

                entity.HasOne(d => d.IdPuestoNavigation)
                    .WithMany(p => p.EmpleadoProyectos)
                    .HasForeignKey(d => d.IdPuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmpleadoP__IdPue__5EBF139D");
            });

            modelBuilder.Entity<Hora>(entity =>
            {
                entity.HasOne(d => d.IdAsistenciaNavigation)
                    .WithMany(p => p.Horas)
                    .HasForeignKey(d => d.IdAsistencia)
                    .HasConstraintName("FK__Horas__IdAsisten__66603565");
            });

            modelBuilder.Entity<Licencia>(entity =>
            {
                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Licencia)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Licencias__IdEmp__59063A47");
            });

            modelBuilder.Entity<Nomina>(entity =>
            {
                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Nominas)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Nominas__IdEstad__76969D2E");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Nominas)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK__Nominas__IdProye__778AC167");

                entity.HasOne(d => d.IdTipoNominaNavigation)
                    .WithMany(p => p.Nominas)
                    .HasForeignKey(d => d.IdTipoNomina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nominas__IdTipoN__75A278F5");
            });

            modelBuilder.Entity<NominaDeduccione>(entity =>
            {
                entity.ToTable("Nomina_Deducciones");

                entity.HasOne(d => d.IdDeduccionesNavigation)
                    .WithMany(p => p.NominaDeducciones)
                    .HasForeignKey(d => d.IdDeducciones)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nomina_De__IdDed__02FC7413");

                entity.HasOne(d => d.IdNominaDetalleNavigation)
                    .WithMany(p => p.NominaDeducciones)
                    .HasForeignKey(d => d.IdNominaDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nomina_De__IdNom__02084FDA");
            });

            modelBuilder.Entity<NominaDetalle>(entity =>
            {
                entity.ToTable("NominaDetalle");

                entity.Property(e => e.Afp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("AFP");

                entity.Property(e => e.Infotep)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("INFOTEP");

                entity.Property(e => e.Isr)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("ISR");

                entity.Property(e => e.SalarioBruto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalarioNeto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Sfs)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SFS");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.NominaDetalles)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NominaDet__IdEmp__7B5B524B");

                entity.HasOne(d => d.IdNominaNavigation)
                    .WithMany(p => p.NominaDetalles)
                    .HasForeignKey(d => d.IdNomina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NominaDet__IdNom__7A672E12");
            });

            modelBuilder.Entity<NominaPercepcione>(entity =>
            {
                entity.ToTable("Nomina_Percepciones");

                entity.HasOne(d => d.IdNominaDetalleNavigation)
                    .WithMany(p => p.NominaPercepciones)
                    .HasForeignKey(d => d.IdNominaDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nomina_Pe__IdNom__7E37BEF6");

                entity.HasOne(d => d.IdPercepcionesNavigation)
                    .WithMany(p => p.NominaPercepciones)
                    .HasForeignKey(d => d.IdPercepciones)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nomina_Pe__IdPer__7F2BE32F");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.Property(e => e.Comision).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__Pagos__IdEmplead__07C12930");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Pagos__IdEstado__09A971A2");

                entity.HasOne(d => d.IdNominaDetalleNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdNominaDetalle)
                    .HasConstraintName("FK__Pagos__IdNominaD__08B54D69");
            });

            modelBuilder.Entity<Percepcione>(entity =>
            {
                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.FechaMcreacion).HasColumnName("FechaMCreacion");

                entity.HasOne(d => d.IdAsistenciaNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.IdAsistencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permisos__IdAsis__693CA210");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proyectos__IdEst__5BE2A6F2");
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__RolUsuari__IdRol__5629CD9C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__RolUsuari__IdUsu__5535A963");
            });

            modelBuilder.Entity<TipoNomina>(entity =>
            {
                entity.ToTable("TipoNomina");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.ToTable("TipoPago");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__Usuarios__IdEmpl__5165187F");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__IdEsta__52593CB8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
