using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<ViewModel> TraerProductos()
        {
            using (var dbContext = new Lunes17Entities())
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
            using (var dbContext = new Lunes17Entities())
            {
                List<ViewModelGenerico> viewGenerico = new List<ViewModelGenerico>();
                var rubros = dbContext.Rubro.ToList();
                foreach (var item in rubros)
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

        public static void AgregarProductoDB(string codigo, string nombre, string descripcion, int rubro)
        {
            using (var dbContext = new Lunes17Entities())
            {
                Producto producto = new Producto();
                producto.Nombre = nombre;
                producto.Codigo = codigo;
                producto.Descripcion = descripcion;
                producto.IDRubro = dbContext.Rubro.FirstOrDefault(x => x.IDRubro == rubro).IDRubro;
                dbContext.Producto.Add(producto);
                dbContext.SaveChanges();
            }
        }
    }
}