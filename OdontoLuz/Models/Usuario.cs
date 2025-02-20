namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            HistoriaClinica = new HashSet<HistoriaClinica>();
            Procedimiento = new HashSet<Procedimiento>();
        }

        [Key]
        public int Id_Usuario { get; set; }

        [Required]        
        public string Nombres { get; set; }

        
        [StringLength(255)]
        public string Apellidos { get; set; }

        [Required]        
        public string NroDocumento { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "El campo Teléfono solo puede contener números.")]
        public string Telefono { get; set; }

        [StringLength(160)]
        [EmailAddress(ErrorMessage = "El campo Correo no tiene un formato válido.")]
        public string CorreoElectronico { get; set; }

        [StringLength(100)]
        public string Cargo { get; set; }

        [Required]
        [StringLength(15)]
        public string Estado { get; set; }
      
        [StringLength(100)]
        [Required]
        public string NombreUsuario { get; set; }
        
        [StringLength(255)]
        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        public int? Id_TipoUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoriaClinica> HistoriaClinica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Procedimiento> Procedimiento { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }

        Model1 db=new Model1();


        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();
            try
            {
                using (var db = new Model1())
                {
                    usuarios = db.Usuario.Include("TipoUsuario").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;
        }


        public Usuario Obtener(int id)
        {
            var usuarios = new Usuario();
            try
            {
                using (var db = new Model1())
                {
                    usuarios = db.Usuario.Include("TipoUsuario").Where(x => x.Id_Usuario == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }

        public List<Usuario> Buscar(string criterio)
        {
            var categorias = new List<Usuario>();

            try
            {
                using (var db = new Model1())
                {
                    categorias = db.Usuario.Include("TipoUsuario").Where(x => x.Nombres.Contains(criterio) ||
                                x.Apellidos.Contains(criterio) || x.NombreUsuario.Contains(criterio) ||
                                x.TipoUsuario.Descripcion.Contains(criterio))
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
                    if (this.Id_Usuario > 0)
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

        public void Guardarcontraseña()
        {
            try
            {
                using (var db = new Model1())
                {
                    var usuario = db.Usuario.Find(this.Id_Usuario);
                    if (usuario != null)
                    {
                        // Actualiza solo la contraseña
                        usuario.Contraseña = this.Contraseña;

                        db.Entry(usuario).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El usuario no fue encontrado en la base de datos.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //login
        public bool Autenticar()
        {

            return db.Usuario
                   .Where(x => x.NombreUsuario == this.NombreUsuario
                   && x.Contraseña == this.Contraseña)
                   .FirstOrDefault() != null;
        }

        //obtener datos del login
        public Usuario ObtenerDatos(string NombreUsuario)
        {
            var usuario = new Usuario();
            try
            {
                using (var db = new Model1())
                {
                    usuario = db.Usuario.Include("TipoUsuario")
                        .Where(x => x.NombreUsuario == NombreUsuario)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }


    }
}
