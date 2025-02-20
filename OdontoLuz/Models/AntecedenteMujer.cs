namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AntecedenteMujer")]
    public partial class AntecedenteMujer
    {
        [Key]
        public int Id_AntecedenteMujer { get; set; }

        public bool? UsaAnticonceptivo { get; set; }

        public bool? Embarazada { get; set; }

        public int? MesEmbarazo { get; set; }

        public bool? DandoLactar { get; set; }

        public int? Id_paciente { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
