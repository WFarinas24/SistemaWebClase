using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebClase.Models
{
    public class DataPaginacion <T>
    {
        public List<T> List { get; set; }

        public string Pagi_info { get; set; }
        public string Pagi_Navegacion { get; set; } 
        public T Input { get; set; }
        public int Registros { get; set; }
        public string Search { get; set; }
        public string ErrorMessage { get; set; }

    }
}
