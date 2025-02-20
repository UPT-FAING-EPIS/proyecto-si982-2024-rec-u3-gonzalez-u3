namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HabitosNocivos
    {
        [Key]
        public int Id_HabitosNocivos { get; set; }

        public bool? Fuma { get; set; }

        public bool? ConsumeAlcohol { get; set; }

        public bool? AprietaLosDientes { get; set; }

        public bool? TeCafe { get; set; }

        public bool? SeMuerdeUñas { get; set; }

        public bool? Bruxismo { get; set; }

        public bool? SeChupaElDedo { get; set; }

        public bool? RespiraPorLaBoca { get; set; }

        public bool? Queilofagia { get; set; }

        public int? Id_paciente { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
