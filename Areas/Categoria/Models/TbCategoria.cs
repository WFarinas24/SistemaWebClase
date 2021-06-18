using SistemaWebClase.Areas.Curso.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebClase.Areas.Categoria.Models
{
    public class TbCategoria
    {
        [Key]
        public int CategoriaID { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }
        public Boolean Estado { get; set; }

        public ICollection<tbCurso> Cursos { get; set; }
    }
}
