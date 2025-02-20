using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OdontoLuz.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AntecedenteMujer> AntecedenteMujer { get; set; }
        public virtual DbSet<AntecedenteSalud> AntecedenteSalud { get; set; }
        public virtual DbSet<FamiliarPaciente> FamiliarPaciente { get; set; }
        public virtual DbSet<FuncionesVitales> FuncionesVitales { get; set; }
        public virtual DbSet<HabitosNocivos> HabitosNocivos { get; set; }
        public virtual DbSet<HistoriaClinica> HistoriaClinica { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Procedimiento> Procedimiento { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AntecedenteSalud>()
                .Property(e => e.DetalleMedicacion)
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarPaciente>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarPaciente>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarPaciente>()
                .Property(e => e.NroDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarPaciente>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<FuncionesVitales>()
                .Property(e => e.Peso)
                .HasPrecision(10, 2);

            modelBuilder.Entity<FuncionesVitales>()
                .Property(e => e.Talla)
                .HasPrecision(5, 2);

            modelBuilder.Entity<FuncionesVitales>()
                .Property(e => e.PresionArterial)
                .IsUnicode(false);

            modelBuilder.Entity<FuncionesVitales>()
                .Property(e => e.Temperatura)
                .HasPrecision(5, 2);

            modelBuilder.Entity<HistoriaClinica>()
                .Property(e => e.CodigoHistoria)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.NroDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.GradoInstruccion)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Ocupacion)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.EstadoCivil)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Nacionalidad)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Domicilio)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Procedimiento>()
                .Property(e => e.NroTicket)
                .IsUnicode(false);

            modelBuilder.Entity<Procedimiento>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Procedimiento>()
                .Property(e => e.Costo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Procedimiento>()
                .Property(e => e.Turno)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDocumento>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoUsuario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NroDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.CorreoElectronico)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);
        }
    }
}
