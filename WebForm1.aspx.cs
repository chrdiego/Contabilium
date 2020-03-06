using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRubro
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static List<ViewModel> TraerProductos()
        {
            using(var dbContext = new Lunes17Entities())
            {
                List<ViewModel> view = new List<ViewModel>();
                var productos = dbContext.Producto.Include("Rubro").ToList();
                foreach (var item in productos)
                {
                    ViewModel view1 = new ViewModel();
                    view1.id = item.IDPRoducto;
                    view1.codigo = item.Codigo;
                    view1.nombre = item.Nombre;
                    view1.descripcion = item.Descripcion;
                    view1.rubro = item.Rubro.Nombre;
                    view.Add(view1);
                }
                return view;
            }
        }

        [WebMethod]
        public static List<ViewModelGenerico> TraerRubros()
        {
            using(var dbContext = new Lunes17Entities())
            {
                List<ViewModelGenerico> viewGenerico = new List<ViewModelGenerico>();
                var rubros = dbContext.Rubro.ToList();
                foreach(var item in rubros)
                {
                    ViewModelGenerico view1 = new ViewModelGenerico();
                    view1.id = item.IDRubro;
                    view1.nombre = item.Nombre;
                    viewGenerico.Add(view1);
                }
                return viewGenerico;
            }
        }

        [WebMethod]
        public static bool AgregarProducto(string codigo, string nombre, string descripcion, int rubro)
        {
            if (codigo != "" && nombre != "" && descripcion != "")
            {
                AgregarProductoDB(codigo, nombre, descripcion, rubro);
                return true;
            }
            else
                return false;            
        }

        [WebMethod]
        public static bool EliminarProducto(int id)
        {
            using(var dbContext = new Lunes17Entities())
            {
                var producto = dbContext.Producto.FirstOrDefault(x => x.IDPRoducto == id);
                dbContext.Producto.Remove(producto);
                dbContext.SaveChanges();
                return true;
            }
        }
        
        [WebMethod]
        public static bool ModificarDB(int id, string codigo, string nombre, string descripcion, int rubro)
        {
            using(var dbContext = new Lunes17Entities())
            {
                Producto aux = new Producto();
                aux.IDPRoducto = id;
                aux.Codigo = codigo;
                aux.Nombre = nombre;
                aux.Descripcion = descripcion;
                aux.IDRubro = rubro;
                var prodmod = dbContext.Producto.FirstOrDefault(x => x.IDPRoducto == id);
                if (aux.IDPRoducto == prodmod.IDPRoducto && aux.Codigo == prodmod.Codigo && aux.Nombre == prodmod.Nombre && aux.Descripcion == prodmod.Descripcion && aux.IDRubro == prodmod.IDRubro)
                    return false;
                prodmod.Codigo = codigo;
                prodmod.Nombre = nombre;
                prodmod.Descripcion = descripcion;
                prodmod.IDRubro = rubro;
                dbContext.SaveChanges();
                return true;
            }
        }

        public static void AgregarProductoDB(string codigo, string nombre, string descripcion, int rubro)
        {
            using(var dbContext = new Lunes17Entities())
            {
                Producto producto = new Producto();
                producto.Nombre = nombre;
                producto.Codigo = codigo;
                producto.Descripcion = descripcion;
                producto.IDRubro = rubro;
                dbContext.Producto.Add(producto);
                dbContext.SaveChanges();
            }
        }
    }
}