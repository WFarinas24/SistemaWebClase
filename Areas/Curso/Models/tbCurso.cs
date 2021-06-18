using SistemaWebClase.Areas.Categoria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebClase.Areas.Curso.Models
{
    public class tbCurso
    {
        [Key]
        public int CursoID { get;  set; }
        public string Nombre { get;  set; }
        public string Descripcion { get;  set; }
        public byte Horas { get;  set; }
        public float Costo { get;  set; }
        public Boolean Estado { get; set; }
        public int CategoriaID { get; set; }
        public byte[] Image { get; set; }
        public TbCategoria Categoria { get; set; }
    }
}
