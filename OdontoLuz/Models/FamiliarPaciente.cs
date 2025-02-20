namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FamiliarPaciente")]
    public partial class FamiliarPaciente
    {
        [Key]
        public int Id_Familiar { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(150)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(20)]
        public string NroDocumento { get; set; }

        [Required]
        [StringLength(9)]
        public string Telefono { get; set; }

        public int? Id_TipoDocumento { get; set; }

        public int? Id_paciente { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
