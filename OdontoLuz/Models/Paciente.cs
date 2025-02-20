namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Paciente")]
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            AntecedenteMujer = new HashSet<AntecedenteMujer>();
            AntecedenteSalud = new HashSet<AntecedenteSalud>();
            FamiliarPaciente = new HashSet<FamiliarPaciente>();
            FuncionesVitales = new HashSet<FuncionesVitales>();
            HabitosNocivos = new HashSet<HabitosNocivos>();
            HistoriaClinica = new HashSet<HistoriaClinica>();
        }

        [Key]
        public int Id_Paciente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(150)]
        public string Apellidos { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        public int Edad { get; set; }

        [Required]
        [StringLength(10)]
        public string Sexo { get; set; }

        [Required]
        [StringLength(20)]
        public string NroDocumento { get; set; }

        [StringLength(100)]
        public string GradoInstruccion { get; set; }

        [StringLength(100)]
        public string Ocupacion { get; set; }

        [StringLength(15)]
        public string EstadoCivil { get; set; }

        [StringLength(100)]
        public string Nacionalidad { get; set; }

        [Required]
        [StringLength(160)]
        public string Domicilio { get; set; }

        [Required]
        [StringLength(9)]
        public string Telefono { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public int? Id_TipoDocumento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AntecedenteMujer> AntecedenteMujer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AntecedenteSalud> AntecedenteSalud { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamiliarPaciente> FamiliarPaciente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuncionesVitales> FuncionesVitales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HabitosNocivos> HabitosNocivos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoriaClinica> HistoriaClinica { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }



        public List<Paciente> Listar()
        {
            var paciente = new List<Paciente>();
            try
            {
                using (var db = new Model1())
                {
                    paciente = db.Paciente.Include("TipoDocumento").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paciente;

        }


        public Paciente Obtener(int id)
        {
            var paciente = new Paciente();
            try
            {
                using (var db = new Model1())
                {
                    paciente = db.Paciente
                        .Include("TipoDocumento")
                        .Where(x => x.Id_Paciente == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paciente;
        }

        public List<Paciente> Buscar(string criterio)
        {
            var categorias = new List<Paciente>();
            try
            {
                using (var db = new Model1())
                {
                    categorias = db.Paciente.Include("TipoDocumento")
                        .Where(x => x.Nombres.Contains(criterio) ||
                                x.Apellidos.Contains(criterio) ||
                                x.NroDocumento.Contains(criterio) ||
                                x.TipoDocumento.Descripcion
                                .Contains(criterio))
                                .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return categorias;

        }


        public Paciente BuscarPaciente(string criterio)
        {
            Paciente paciente = null;
            try
            {
                using (var db = new Model1())
                {
                    paciente = db.Paciente.FirstOrDefault(x => x.NroDocumento.Contains(criterio));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paciente;
        }

        
        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.Id_Paciente > 0)
                    {
                        db.Entry(this).State = EntityState.Modified; //existe
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added; //nuevo registro
                    }
                    db.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Eliminar()
        {
            try
            {
                using (var db = new Model1())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
