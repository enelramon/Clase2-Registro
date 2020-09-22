using Clase2_Registro.Entidades;
using Clase2_Registro.DAL;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Clase2_Registro.BLL
{
    public class ActoresBLL
    {
        /// <summary>
        /// Permite insertar o modificar una entidad en la base de datos
        /// </summary>
        /// <param name="actor">La entidad que se desea guardar</param> 
        public static bool Guardar(Actores actor)
        {
            if (!Existe(actor.ActorId))//si no existe insertamos
                return Insertar(actor);
            else
                return Modificar(actor);
        }

        /// <summary>
        /// Permite insertar una entidad en la base de datos
        /// </summary>
        /// <param name="actor">La entidad que se desea guardar</param>
        private static bool Insertar(Actores actor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                int[] a ={1};

                a[3]=1;

                //Agregar la entidad que se desea insertar al contexto
                contexto.Actores.Add(actor);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        /// <summary>
        /// Permite modificar una entidad en la base de datos
        /// </summary>
        /// <param name="actor">La entidad que se desea modificar</param> 
        public static bool Modificar(Actores actor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(actor).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        /// <summary>
        /// Permite eliminar una entidad de la base de datos
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea eliminar</param> 
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entidad que se desea eliminar
                var actor = contexto.Actores.Find(id);

                if (actor != null)
                {
                    contexto.Actores.Remove(actor);//remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        /// <summary>
        /// Permite buscar una entidad en la base de datos
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param> 
        public static Actores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Actores actor;

            try
            {
                actor = contexto.Actores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return actor;
        }

        /// <summary>
        /// Permite obtener una lista filtrada por un criterio de busqueda
        /// </summary>
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<Actores> GetList(Expression<Func<Actores, bool>> criterio)
        {
            List<Actores> lista = new List<Actores>();
            Contexto contexto = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = contexto.Actores.Where(criterio).AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Actores
                    .Any(e => e.ActorId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Actores> Getactor()
        {
            List<Actores> lista = new List<Actores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Actores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}