namespace OdontoLuz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("TipoUsuario")]
    public partial class TipoUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int Id_TipoUsuario { get; set; }

        [Required]
        [StringLength(60)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }



        //creando el metodo para listar
        public List<TipoUsuario> Listar()
        {
            var tipousuario = new List<TipoUsuario>();
            try
            {
                using(var db=new Model1())
                {
                    tipousuario=db.TipoUsuario.ToList();
                }
            }catch (Exception ex)
            {
                throw ex;
            }
            return tipousuario;
        }

        public List<TipoUsuario> Buscar(string criterio)
        {
            var categorias = new List<TipoUsuario>();

            try
            {
                using (var db = new Model1())
                {
                    categorias = db.TipoUsuario.Where(x => x.Descripcion.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return categorias;
        }

        public TipoUsuario Obtener(int id)
        {
            var categoria = new TipoUsuario();
            try
            {
                using (var db = new Model1())
                {
                    categoria = db.TipoUsuario.Where(x => x.Id_TipoUsuario == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return categoria;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.Id_TipoUsuario > 0)
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
