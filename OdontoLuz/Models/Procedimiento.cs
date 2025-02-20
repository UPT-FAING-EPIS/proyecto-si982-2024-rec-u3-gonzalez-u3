namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Procedimiento")]
    public partial class Procedimiento
    {
        [Key]
        public int Id_Procedimiento { get; set; }

        //public DateTime Fecha { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string NroTicket { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descripcion { get; set; }

        [Required]
        //[RegularExpression(@"^\d+(\.\d{1,2})?$")]
        //[Range(double.MaxValue)]
        public decimal Costo { get; set; }

        [Required]
        [StringLength(50)]
        public string Turno { get; set; }

        public int? Id_Usuario { get; set; }

        public int? Id_HistoriaClinica { get; set; }

        public virtual HistoriaClinica HistoriaClinica { get; set; }

        public virtual Usuario Usuario { get; set; }

            
        public List<Procedimiento> Listar()
        {
            var procedimiento = new List<Procedimiento>();
            try
            {
                using (var db = new Model1())
                {
                    procedimiento = db.Procedimiento.Include("HistoriaClinica").Include("Usuario").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return procedimiento;
        }


        public Procedimiento Obtener(int id)
        {
            var procedimiento = new Procedimiento();
            try
            {
                using (var db = new Model1())
                {
                    procedimiento = db.Procedimiento
                                    .Include("HistoriaClinica")
                                    .Include("Usuario")
                                    .Where(x => x.Id_Procedimiento == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return procedimiento;
        }
        public Procedimiento Buscarxdni(int id)
        {
            var procedimiento = new Procedimiento();
            try
            {
                using (var db = new Model1())
                {
                    procedimiento = db.Procedimiento
                                    .Include("HistoriaClinica")
                                    .Include("Usuario")
                                    .Where(x => x.HistoriaClinica.Id_Paciente == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return procedimiento;
        }
        
        public List<Procedimiento> Buscar(string criterio)
        {
            var categorias = new List<Procedimiento>();

            try
            {
                using (var db = new Model1())
                {
                    categorias = db.Procedimiento
                                .Include("HistoriaClinica")
                                .Include("Usuario")
                                .Where(x => x.Descripcion.Contains(criterio) || x.Turno.Contains(criterio) || x.NroTicket.Contains(criterio))                     
                                .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return categorias;

        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.Id_Procedimiento > 0)
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
