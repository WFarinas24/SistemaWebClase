using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebClase.Areas.Trabajadores.Models
{
    public class tbTrabajador
    {
        [Key]
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public Boolean Estado { get; set; }


    }
}
