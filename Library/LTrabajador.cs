using Microsoft.AspNetCore.Identity;
using SistemaWebClase.Areas.Trabajadores.Models;
using SistemaWebClase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebClase.Library
{
    public class LTrabajador
    {
        private readonly ApplicationDbContext context;
        public LTrabajador(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<tbTrabajador> GetTrabador(String valor)
        {
            List<tbTrabajador> ListaTrabjadores;
            if (valor == null)
            {
                ListaTrabjadores = context.tbTrabajadors.ToList();

            }
            else
            {
                ListaTrabjadores = context.tbTrabajadors.Where(x => x.Nombre.StartsWith(valor)).ToList();

            }

            return ListaTrabjadores;


        }
        public IdentityError Registrar_Trabajador(tbTrabajador trabajador)
        {
            IdentityError identityError;
            try
            {
                context.Add(trabajador);
                context.SaveChanges();
                identityError = new IdentityError
                {
                    Code = "Done"
                };
            }
            catch (Exception e)
            {
                identityError = new IdentityError
                {
                    Code = "Error",
                    Description = e.Message
                };
            }
            return identityError;
        }
    }
}
