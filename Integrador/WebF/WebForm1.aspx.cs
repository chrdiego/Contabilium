using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebF
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                usersRepeater.DataSource = TraerUsuarios();
                usersRepeater.DataBind();
            }
        }

        private List<Usuario> TraerUsuarios()
        {
            using(var dbContext = new integradorEntities())
            {
                return dbContext.Usuario.ToList();
            }
        }

        public void AgregarUsuario(string nombre, string apellido, string edadString, string tipo)
        {
            using (var dbContext = new integradorEntities())
            {
                int.TryParse(edadString, out int edad);
                int idTipoUsuario = 0;
                int idTipoAdmin = 0;
                if (dbContext.TipoUsuario.Any(x => x.Tipo == "Usuario"))
                    idTipoUsuario = dbContext.TipoUsuario.FirstOrDefault(x => x.Tipo == "Usuario").IDTipoUsuario;
                if (dbContext.TipoUsuario.Any(x => x.Tipo == "Administrador"))
                    idTipoAdmin = dbContext.TipoUsuario.FirstOrDefault(x => x.Tipo == "Administrador").IDTipoUsuario;
                Usuario usuario1 = new Usuario
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Estado = true,
                    Edad = edad
                };
                if (tipo == "administrador")
                    usuario1.IDTipoUsuario = idTipoAdmin;
                else if (tipo == "usuario")
                    usuario1.IDTipoUsuario = idTipoUsuario;
                dbContext.Usuario.Add(usuario1);
                dbContext.SaveChanges();
            }
        }

        protected void agregarBtn_Click(object sender, EventArgs e)
        {
            txtBoxAddNombre.Visible = true;
            txtBoxAddApellido.Visible = true;
            txtBoxAddEdad.Visible = true;
            lblNombre.Visible = true;
            lblEdad.Visible = true;
            lblApellido.Visible = true;
            cancelarBtn.Visible = true;
            agregarABD.Visible = true;
            radioTipo.Visible = true;
        }

        protected void cancelarBtn_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtBoxAddNombre.Visible = false;
            txtBoxAddApellido.Visible = false;
            txtBoxAddEdad.Visible = false;
            lblNombre.Visible = false;
            lblEdad.Visible = false;
            lblApellido.Visible = false;
            cancelarBtn.Visible = false;
            agregarABD.Visible = false;
            radioTipo.Visible = false;
        }

        private void Limpiar()
        {
            txtBoxAddNombre.Text = "";
            txtBoxAddApellido.Text = "";
            txtBoxAddEdad.Text = "";
        }

        protected void agregarABD_Click(object sender, EventArgs e)
        {
            AgregarUsuario(txtBoxAddNombre.Text, txtBoxAddApellido.Text, txtBoxAddEdad.Text, radioTipo.SelectedValue);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('¡Usuario agregado!'); window.location='" +
            Request.ApplicationPath + "WebForm1.aspx';", true);
        }
    }
}