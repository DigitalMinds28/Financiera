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
    public partial class WFCustomer : System.Web.UI.Page
    {
        CustomerLog objCus = new CustomerLog();
        private int _idCustomer;
        private int _identification;
        private string _name;
        private string _lastname;
        private string _phone;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TBId.Visible = false; //ocultamos el id
                showCustomer();
            }
        }

        private void showCustomer()
        {
            DataSet objData = new DataSet();
            objData = objCus.showCustomer();
            GVCustomer.DataSource = objData;
            GVCustomer.DataBind();
        }
      
        private void LimpiarCajas()
        {
            TBId.Text = "";
            TBIdentificacion.Text = "";
            TBNombre.Text = "";
            TBApellido.Text = "";
            TBTelefono.Text = "";
        }
       
       
       
        protected void GVCustomer_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            _idCustomer = Convert.ToInt32(GVCustomer.DataKeys[e.RowIndex].Values[0]);
            executed = objCus.deleteCustomer(_idCustomer);
            if (executed)
            {
                LblMensaje.Text = "El Cliente se elimino Exitosamente";
                GVCustomer.EditIndex = -1; showCustomer();
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            _idCustomer = Convert.ToInt32(TBId.Text);
            _identification = Convert.ToInt32(TBIdentificacion.Text);
            _name = TBNombre.Text;
            _lastname = TBNombre.Text;
            _phone = TBTelefono.Text;
            executed = objCus.updateCustomer(_idCustomer, _identification, _name, _lastname, _phone);
            if (executed)
            {
                LblMensaje.Text = "Cliente actualizado exitosamente!"; showCustomer();
                LimpiarCajas();
            }
            else
            {
                LblMensaje.Text = "Error al actualizar el Cliente!";
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            _identification = Convert.ToInt32(TBIdentificacion.Text);
            _name = TBNombre.Text;
            _lastname = TBApellido.Text;
            _phone = TBTelefono.Text;
            executed = objCus.saveCustomer(_identification, _name, _lastname, _phone);
            if (executed)
            {
                LblMensaje.Text = "Cliente Guardado exitosamente!"; showCustomer();
                LimpiarCajas();
            }
            else
            {
                LblMensaje.Text = "Error al guardar el Cliente!";
            }
        }

        protected void GVCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBId.Text = GVCustomer.SelectedRow.Cells[0].Text;
            TBIdentificacion.Text = GVCustomer.SelectedRow.Cells[1].Text;
            TBNombre.Text = GVCustomer.SelectedRow.Cells[2].Text;
            TBApellido.Text = GVCustomer.SelectedRow.Cells[3].Text;
            TBTelefono.Text = GVCustomer.SelectedRow.Cells[4].Text;
            BtnGuardar.Enabled = false;
        }
    }
}