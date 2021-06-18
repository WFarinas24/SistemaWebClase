using Microsoft.AspNetCore.Identity;
using SistemaWebClase.Areas.Categoria.Models;
using SistemaWebClase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebClase.Library
{
    public class LCategoria
    {
        private readonly ApplicationDbContext context; 
        public LCategoria( ApplicationDbContext context)
        {
            this.context = context; 
        }

        internal IdentityError EliminarCategoria(int categoriaID)
        {

            IdentityError identityError;
            try
            {

                var categoria = new TbCategoria()
                {
                    CategoriaID = categoriaID
                };
                context.Remove(categoria);

                
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

        public List<TbCategoria> GetCategoria(String valor)
        {
            List<TbCategoria> listaCategorias;
            if (valor == null)
            {
                listaCategorias = context.tbCategorias.ToList();

            }
            else
            {
                listaCategorias = context.tbCategorias.Where(x => x.Nombre.StartsWith(valor)).ToList(); 

            }

            return listaCategorias; 
        }
        public IdentityError Registrar_Categoria(TbCategoria categoria)
        {
            IdentityError identityError;
            try
            {

                if (categoria.CategoriaID.Equals(0) ) 
                {
                    context.Add(categoria);

                }
                else
                {
                    context.Update(categoria);

                }
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



        internal IdentityError UpdateEstado(int id)
        {
            IdentityError identityError;
            try
            {
                var categoria = context.tbCategorias.Where(x => x.CategoriaID.Equals(id)).ToList().ElementAt(0);

                categoria.Estado = !categoria.Estado;
                context.Update(categoria);
                context.SaveChanges();

                identityError = new IdentityError
                {
                    Code = "Done"
                };



            }
            catch (Exception e )
            {
                identityError = new IdentityError
                {
                    Code = "Erorr",
                    Description = e.Message
                };
            }
        return identityError ; 
    }
    }
}