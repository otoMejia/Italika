using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Italika.Controllers;
using Italika.Models;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Italika.Views
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.obtenerItalikas();
            }
        }

        protected void gvItalikas_SelectedIndexChanged(object sender, EventArgs e)
        { //ver el seleccionado
            BRANCHBITEntities ee = new BRANCHBITEntities();

            gvItalikas.Rows[((GridView)sender).SelectedIndex].BackColor = Color.Aqua;

            detalle.Visible = true;
            dvItalikas.ChangeMode(DetailsViewMode.ReadOnly);
            dvItalikas.Visible = true;
            dvItalikas.Focus();

            dvItalikas.DataSource = ee.BuscarItalika(Int32.Parse(((GridView)sender).SelectedDataKey.Value.ToString()), "");
            dvItalikas.DataBind();
        }

        private void obtenerItalikas()
        {
            BRANCHBITEntities ee = new BRANCHBITEntities();
            gvItalikas.DataSource = ee.BuscarItalika(0, tbBuscar.Text);
            gvItalikas.DataBind();
            dvItalikas.Visible = false;
            detalle.Visible = false;
        }

        protected void bBuscar_Click(object sender, EventArgs e)
        {
            this.obtenerItalikas();
        }

        protected async void dvItalikas_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            BR_ITALIKASController c = new BR_ITALIKASController();
            int idItalika = Int32.Parse(((DetailsView)sender).DataKey.Value.ToString());
            await c.DeleteConfirmed(idItalika);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Aviso", "alert('Registro eliminado.')", true);
            this.obtenerItalikas();
        }

        protected async void dvItalikas_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            BR_ITALIKASController c = new BR_ITALIKASController();
            BR_ITALIKAS bR_ITALIKA = new BR_ITALIKAS();
            bR_ITALIKA.SKU = e.Values["SKU"].ToString();
            bR_ITALIKA.FERT = e.Values["FERT"].ToString();
            bR_ITALIKA.MODELO = e.Values["MODELO"].ToString();
            bR_ITALIKA.TIPO = e.Values["TIPO"].ToString();
            bR_ITALIKA.NUM_SERIE = e.Values["NUM_SERIE"].ToString();
            bR_ITALIKA.FECHA = DateTime.Parse(e.Values["FECHA"].ToString());
            await c.Create(bR_ITALIKA);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Aviso", "alert('Registro exitoso.')", true);
            this.obtenerItalikas();
        }

        protected async void dvItalikas_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            BR_ITALIKAS bR_ITALIKA = new BR_ITALIKAS();
            bR_ITALIKA.SKU = e.NewValues["SKU"].ToString();
            bR_ITALIKA.FERT = e.NewValues["FERT"].ToString();
            bR_ITALIKA.MODELO = e.NewValues["MODELO"].ToString();
            bR_ITALIKA.TIPO = e.NewValues["TIPO"].ToString();
            bR_ITALIKA.NUM_SERIE = e.NewValues["NUM_SERIE"].ToString();
            bR_ITALIKA.FECHA = DateTime.Parse(e.NewValues["FECHA"].ToString());
            bR_ITALIKA.ID_ITALIKA = Int32.Parse(e.Keys["ID_ITALIKA"].ToString());
            BR_ITALIKASController c = new BR_ITALIKASController();
            await c.Edit(bR_ITALIKA);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Aviso", "alert('Actualización exitosa.')", true);
            this.obtenerItalikas();
        }

        protected void dvItalikas_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            BRANCHBITEntities ee = new BRANCHBITEntities();

            if (gvItalikas.SelectedDataKey != null)
            {
                ((DetailsView)sender).ChangeMode(e.NewMode);
                ((DetailsView)sender).DataSource = ee.BuscarItalika(Int32.Parse(gvItalikas.SelectedDataKey.Value.ToString()), "");
                ((DetailsView)sender).DataBind();
            }
            else
            {
                ((DetailsView)sender).Visible = false;
            }

        }       

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            ((Button)sender).Visible = false;
            dvItalikas.AutoGenerateInsertButton = true;
            dvItalikas.ChangeMode(DetailsViewMode.Insert);
            dvItalikas.Visible = true;
        }

    }
}