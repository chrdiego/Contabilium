using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebF
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["IDUsuario"] != null)
                {
                    int id = int.Parse(Request.QueryString["IDUsuario"]);
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
                    txtBoxAddNombre.Text = usuario.Nombre;
                    txtBoxAddApellido.Text = usuario.Apellido;
                    txtBoxAddEdad.Text = usuario.Edad.ToString();
                }
            }
        }

        protected void modificarBtn_Click(object sender, EventArgs e)
        {
            using (var dbContext = new integradorEntities())
            {
                int id = int.Parse(Request.QueryString["IDUsuario"]);
                int idTipoUsuario = 0;
                int idTipoAdmin = 0;
                string tipo = radioTipo.SelectedValue;
                if (dbContext.TipoUsuario.Any(x => x.Tipo == "Usuario"))
                    idTipoUsuario = dbContext.TipoUsuario.FirstOrDefault(x => x.Tipo == "Usuario").IDTipoUsuario;
                if (dbContext.TipoUsuario.Any(x => x.Tipo == "Administrador"))
                    idTipoAdmin = dbContext.TipoUsuario.FirstOrDefault(x => x.Tipo == "Administrador").IDTipoUsuario;
                var usuario = dbContext.Usuario.FirstOrDefault(x => x.IDUsuario == id);
                if(txtBoxAddNombre.Text != "" && txtBoxAddApellido.Text != "" && txtBoxAddEdad.Text != "")
                {
                    usuario.Nombre = txtBoxAddNombre.Text;
                    usuario.Apellido = txtBoxAddApellido.Text;
                    usuario.Edad = int.Parse(txtBoxAddEdad.Text);
                    if (tipo == "administrador")
                        usuario.IDTipoUsuario = idTipoAdmin;
                    else if (tipo == "usuario")
                        usuario.IDTipoUsuario = idTipoUsuario;
                    dbContext.SaveChanges();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('¡Usuario modificado!'); window.location='" +
                    Request.ApplicationPath + "WebForm1.aspx';", true);
                }
                else
                {
                    string script = "alert('¡No ha llenado todos los campos!');";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                }
            }
        }

        protected void cancelarBtn_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('¡Se ha cancelado la operación!'); window.location='" +
            Request.ApplicationPath + "WebForm1.aspx';", true);
        }
    }
}