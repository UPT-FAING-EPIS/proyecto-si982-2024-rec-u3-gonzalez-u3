namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FuncionesVitales
    {
        [Key]
        public int Id_FuncionesVitales { get; set; }

        public decimal? Peso { get; set; }

        public int? FrecuenciaRespiratoria { get; set; }

        public int? FrecuenciaCardiaca { get; set; }

        public decimal? Talla { get; set; }

        [StringLength(20)]
        public string PresionArterial { get; set; }

        public decimal? Temperatura { get; set; }

        public int? Id_paciente { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
