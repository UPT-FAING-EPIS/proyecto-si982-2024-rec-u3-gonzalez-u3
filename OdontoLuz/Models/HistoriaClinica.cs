namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web.Mvc;

    [Table("HistoriaClinica")]
    public partial class HistoriaClinica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HistoriaClinica()
        {
            Procedimiento = new HashSet<Procedimiento>();
        }

        [Key]
        public int Id_HistoriaClinica { get; set; }

        [StringLength(50)]
        public string CodigoHistoria { get; set; }

        public int? Id_Paciente { get; set; }

        public int? Id_usuario { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Procedimiento> Procedimiento { get; set; }


        public int? Buscarxdni(string nroDNI)
        {
            int? historiaClinica = null;
            try
            {
                using (var db = new Model1())
                {
                    historiaClinica = (from hc in db.HistoriaClinica
                                       join p in db.Paciente on hc.Id_Paciente equals p.Id_Paciente
                                       where p.NroDocumento == nroDNI
                                       select hc.Id_HistoriaClinica).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                // Manejar la excepción adecuadamente
                throw;
            }
            //var codigo = Convert.ToInt16(historiaClinica.CodigoHistoria);
            return historiaClinica;
        }


        public List<HistoriaClinica> Listar()
        {
            var historia = new List<HistoriaClinica>();
            try
            {
                using (var db = new Model1())
                {
                    historia = db.HistoriaClinica
                        .Include("Paciente")
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return historia;
        }

        public List<HistoriaClinica> Buscar(string criterio)
        {
            var categorias = new List<HistoriaClinica>();

            try
            {
                using (var db = new Model1())
                {
                    categorias = db.HistoriaClinica.Where(x => x.CodigoHistoria.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return categorias;
        }

        public HistoriaClinica Obtener(int id)
        {
            var historia = new HistoriaClinica();
            try
            {
                using (var db = new Model1())
                {
                    historia = db.HistoriaClinica.Where(x => x.Id_HistoriaClinica == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return historia;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.Id_HistoriaClinica > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
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
