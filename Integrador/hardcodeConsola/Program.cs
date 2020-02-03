using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hardcodeConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            //HARDCODE DE TIPOS DE USUARIOS

            //using (var dbContext = new integradorEntities())
            //{
            //    List<TipoUsuario> tipoDeUsuarios = new List<TipoUsuario>();

            //    var tipoDeUsuario = dbContext.TipoUsuario.ToList();

            //    TipoUsuario tipo1 = new TipoUsuario();
            //    tipo1.Tipo = "Usuario";
            //    TipoUsuario tipo2 = new TipoUsuario();
            //    tipo2.Tipo = "Administrador";

            //    tipoDeUsuarios.Add(tipo1);
            //    tipoDeUsuarios.Add(tipo2);

            //    dbContext.TipoUsuario.AddRange(tipoDeUsuarios);

            //    dbContext.SaveChanges();
            //}

            // HARDCODE DE USUARIOS

            using(var dbContext = new integradorEntities())
            {
                int idTipoAdmin = 0;
                int idTipoUsuario = 0;

                if (dbContext.TipoUsuario.Any(x => x.Tipo == "Usuario"))
                    idTipoUsuario = dbContext.TipoUsuario.FirstOrDefault(x => x.Tipo == "Usuario").IDTipoUsuario;
                if(idTipoUsuario > 0)
                {
                    Usuario usuario1 = new Usuario();
                    usuario1.Nombre = "Diego";
                    usuario1.Apellido = "Chirdo";
                    usuario1.Estado = true;
                    usuario1.Edad = 22;
                    usuario1.IDTipoUsuario = idTipoUsuario;

                    Usuario usuario2 = new Usuario();
                    usuario2.Nombre = "Matías";
                    usuario2.Apellido = "Rincón";
                    usuario2.Estado = true;
                    usuario2.Edad = 19;
                    usuario2.IDTipoUsuario = idTipoUsuario;

                    Usuario usuario3 = new Usuario();
                    usuario3.Nombre = "Esteban";
                    usuario3.Apellido = "Molina";
                    usuario3.Estado = true;
                    usuario3.Edad = 23;
                    usuario3.IDTipoUsuario = idTipoUsuario;

                    Usuario usuario4 = new Usuario();
                    usuario4.Nombre = "Tomás";
                    usuario4.Apellido = "Melo";
                    usuario4.Estado = true;
                    usuario4.Edad = 18;
                    usuario4.IDTipoUsuario = idTipoUsuario;

                    dbContext.Usuario.Add(usuario1);
                    dbContext.Usuario.Add(usuario2);
                    dbContext.Usuario.Add(usuario3);
                    dbContext.Usuario.Add(usuario4);
                }

                if (dbContext.TipoUsuario.Any(x => x.Tipo == "Administrador"))
                    idTipoAdmin = dbContext.TipoUsuario.FirstOrDefault(x => x.Tipo == "Administrador").IDTipoUsuario;
                if(idTipoAdmin > 0)
                {
                    Usuario usuario5 = new Usuario();
                    usuario5.Nombre = "Carina";
                    usuario5.Apellido = "Rondán";
                    usuario5.Estado = true;
                    usuario5.Edad = 28;
                    usuario5.IDTipoUsuario = idTipoAdmin;

                    Usuario usuario6 = new Usuario();
                    usuario6.Nombre = "Lourdes";
                    usuario6.Apellido = "Vapor";
                    usuario6.Estado = true;
                    usuario6.Edad = 19;
                    usuario6.IDTipoUsuario = idTipoAdmin;

                    dbContext.Usuario.Add(usuario5);
                    dbContext.Usuario.Add(usuario6);
                }
                dbContext.SaveChanges();
            }
        }
    }
}
