namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("TipoDocumento")]
    public partial class TipoDocumento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoDocumento()
        {
            FamiliarPaciente = new HashSet<FamiliarPaciente>();
            Paciente = new HashSet<Paciente>();
        }

        [Key]
        public int Id_TipoDocumento { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamiliarPaciente> FamiliarPaciente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente> Paciente { get; set; }



        public List<TipoDocumento> Listar()
        {
            var tipodocumento = new List<TipoDocumento>();
            try
            {
                using (var db = new Model1())
                {
                    tipodocumento = db.TipoDocumento.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tipodocumento;
        }


    }
}
