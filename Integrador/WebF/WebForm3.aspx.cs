using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebF
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                if (Request.QueryString["IDUsuario"] != null)
                {
                    id = int.Parse(Request.QueryString["IDUsuario"]);
                    LlenarFormulario(id);
                }
            }
        }
        private void LlenarFormulario(int id)
        {
            using (var dbContext = new integradorEntities())
            {
                var usuario = dbContext.Usuario.FirstOrDefault(x => x.IDUsuario == id);
                if (usuario != null)
                {
                    lbl1.Text = usuario.Nombre;
                    lbl2.Text = usuario.Apellido;
                    lbl3.Text = usuario.IDUsuario.ToString();
                }
            }
        }

        protected void noBtn_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('¡Se ha cancelado la operación!'); window.location='" +
            Request.ApplicationPath + "WebForm1.aspx';", true);
        }

        protected void yesBtn_Click(object sender, EventArgs e)
        {
            using (var dbContext = new integradorEntities())
            {
                int id = int.Parse(Request.QueryString["IDUsuario"]);
                var usuario = dbContext.Usuario.FirstOrDefault(x => x.IDUsuario == id);
                dbContext.Usuario.Remove(usuario);
                dbContext.SaveChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "alert('¡Usuario eliminado!'); window.location='" +
                Request.ApplicationPath + "WebForm1.aspx';", true);
            }
        }
    }
}