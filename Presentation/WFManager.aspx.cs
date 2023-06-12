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
    
    public partial class WFManager : System.Web.UI.Page
    {
        ManagerLog ObjMan = new ManagerLog();
        private int _idManager;
        private string _admName;
        private string _admLastname;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TBiD.Visible = false; //ocultamos el id

                showManager();
            }

        }
        protected void showManager()
        {
            DataSet objData = new DataSet();
            objData = ObjMan.showManager();
            GVManager.DataSource = objData;
            GVManager.DataBind();
        }
        private void LimpiarCajas()
        {
            TBiD.Text = "";
            TBNombre.Text = "";
            TBApellido.Text = "";
        }


        protected void GVManager_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _idManager = Convert.ToInt32(GVManager.DataKeys[e.RowIndex].Values[0]);
            executed = ObjMan.deleteManager(_idManager);
            if (executed)
            {
                LblMensaje.Text = "Eliminado Exitosamente";
                GVManager.EditIndex = -1;
                showManager();
            }
        }

        protected void BTNGuardar_Click(object sender, EventArgs e)
        {
            _admName = TBNombre.Text;
            _admLastname = TBApellido.Text;
            executed = ObjMan.saveManager(_admName, _admLastname);
            if (executed)
            {
                LblMensaje.Text = "Guardado Exitosamente!";
                showManager();
                LimpiarCajas();
            }
            else
            {
                LblMensaje.Text = "Error al Guardar!";
            }

        }

        protected void BTNActualizar_Click(object sender, EventArgs e)
        {
            _idManager = Convert.ToInt32(TBiD.Text);
            _admName = TBNombre.Text;
            _admLastname = TBApellido.Text;
            executed = ObjMan.updateManager(_idManager, _admName, _admLastname);
            if (executed)
            {
                LblMensaje.Text = "Actualizado Exitosamente!";
                showManager();
                LimpiarCajas();
            }
            else
            {
                LblMensaje.Text = "Error al Actualizar!";
            }

        }

        protected void GVManager_SelectedIndexChanged1(object sender, EventArgs e)
        {
            TBiD.Text = GVManager.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVManager.SelectedRow.Cells[1].Text;
            TBApellido.Text = GVManager.SelectedRow.Cells[2].Text;
        }
    }
}