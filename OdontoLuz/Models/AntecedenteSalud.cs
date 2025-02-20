namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AntecedenteSalud")]
    public partial class AntecedenteSalud
    {
        [Key]
        public int Id_AntecedenteSalud { get; set; }

        public bool? Hospitalizado { get; set; }

        public bool? TratamientoMedico { get; set; }

        public bool? TransfusionesSanguineas { get; set; }

        public bool? Medicacion { get; set; }

        [Column(TypeName = "text")]
        public string DetalleMedicacion { get; set; }

        public int? Id_paciente { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
