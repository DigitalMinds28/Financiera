using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;

namespace Presentation
{
    public partial class WFLocation : System.Web.UI.Page
    {
        LocationLog objLoc = new LocationLog();
        private int _idLocation;
        private string _placename;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TBId.Visible = false; //ocultamos el id
                showLocation();
            }
        }
        private void showLocation()
        {
            DataSet objData = new DataSet();
            objData = objLoc.showlocation();
            GVLocation.DataSource = objData;
            GVLocation.DataBind();
        }
        private void LimpiarCajas()
        {
            TBId.Text = "";
            TBUbicacion.Text = "";
        }

        protected void GVLocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _idLocation = Convert.ToInt32(GVLocation.DataKeys[e.RowIndex].Values[0]);
            executed = objLoc.deletelocation(_idLocation);
            if (executed)
            {
                LblMensaje.Text = "Eliminado Exitosamente";
                GVLocation.EditIndex = -1; showLocation();
            }
        }

        protected void GVLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBId.Text = GVLocation.SelectedRow.Cells[0].Text;
            TBUbicacion.Text = GVLocation.SelectedRow.Cells[1].Text;
            BtnGuardar.Enabled = false;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            _placename = TBUbicacion.Text;
            executed = objLoc.savelocation(_placename);
            if (executed)
            {
                LblMensaje.Text = "Guardado Exitosamente!";
                showLocation(); LimpiarCajas();
            }
            else
            {
                LblMensaje.Text = "Error al Guardar!";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            _idLocation = Convert.ToInt32(TBId.Text);
            _placename = TBUbicacion.Text;
            executed = objLoc.updatelocation(_idLocation, _placename);
            if (executed)
            {
                LblMensaje.Text = "Actualizado Exitosamente!"; showLocation();
                LimpiarCajas();
            }
            else
            {
                LblMensaje.Text = "Error al Actualizar!";
            }
        }
    }
}