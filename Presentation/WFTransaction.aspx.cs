using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;

namespace Presentation
{
    public partial class WFTransaction : System.Web.UI.Page
    {
        TransactionLog objTrans = new TransactionLog();
        AccountLog objAcco = new AccountLog();
        LocationLog objLoc = new LocationLog();

        private int _idTransaction;
        private string _dateTime;
        private string _type;
        private double _monto;
        private int _idDestinationAccount;
        private int _Account_origin;
        private int _idLocation;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TBIdTransaccion.Visible = false;

                showTransaction();
                showAccountDDL();
                showLocationDDL();
                showAccountDestinoDDL();
            }
        }
        private void showTransaction()
        {
            DataSet objData = new DataSet();
            objData = objTrans.showTransaction();
            GVTransaccion.DataSource = objData;
            GVTransaccion.DataBind();
        }
        private void LimpiarCajas()
        {
            TBIdTransaccion.Text = "";
            TBTranFechayHora.Text = "";
            DDLTipo.Text = "";
            TBTranMonto.Text = "";
            //DDLCuentaDestino.Text = "";
        }
        private void showAccountDDL()
        {
            DDLCuentaId.DataSource = objAcco.showAccountDDL();
            DDLCuentaId.DataValueField = "cue_id";
            DDLCuentaId.DataTextField = "cue_numero";
            DDLCuentaId.DataBind();
            DDLCuentaId.Items.Insert(0, "Seleccione");
        }
        private void showAccountDestinoDDL()
        {
            DDLCuentaDestino.DataSource = objAcco.showAccountDDL();
            DDLCuentaDestino.DataValueField = "cue_id";
            DDLCuentaDestino.DataTextField = "cue_numero";
            DDLCuentaDestino.DataBind();
            DDLCuentaDestino.Items.Insert(0, "Seleccione");
        }
        private void showLocationDDL()
        {
            DDLUbicacionId.DataSource = objLoc.showlocationDDL();
            DDLUbicacionId.DataValueField = "ubi_id";
            DDLUbicacionId.DataTextField = "ubi_nombre";
            DDLUbicacionId.DataBind();
            DDLUbicacionId.Items.Insert(0, "Seleccione");
        }
        protected void GVTransaccion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _idTransaction = Convert.ToInt32(GVTransaccion.DataKeys[e.RowIndex].Values[0]);
            executed = objTrans.deleteTransaction(_idTransaction);

            if (executed)
            {
                Lblmsj.Text = "Eliminado Exitosamente";
                GVTransaccion.EditIndex = -1; showTransaction();
            }
        }

        protected void GVTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBIdTransaccion.Text = GVTransaccion.SelectedRow.Cells[0].Text;
            TBTranFechayHora.Text = GVTransaccion.SelectedRow.Cells[1].Text;
            DDLTipo.Text = GVTransaccion.SelectedRow.Cells[2].Text;
            TBTranMonto.Text = GVTransaccion.SelectedRow.Cells[3].Text;
            DDLCuentaDestino.Text = GVTransaccion.SelectedRow.Cells[4].Text;
            DDLCuentaId.Text = GVTransaccion.SelectedRow.Cells[5].Text;
            DDLUbicacionId.Text = GVTransaccion.SelectedRow.Cells[6].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _dateTime = TBTranFechayHora.Text;
            _type = DDLTipo.Text;
            _monto = Convert.ToDouble(TBTranMonto.Text);
            _idDestinationAccount = Convert.ToInt32(DDLCuentaDestino.Text);
            _Account_origin = Convert.ToInt32(DDLCuentaId.Text);
            _idLocation = Convert.ToInt32(DDLUbicacionId.Text);
            executed = objTrans.saveTransaction(_dateTime, _type, _monto, _idDestinationAccount, _Account_origin, _idLocation);
            if (executed)
            {
                Lblmsj.Text = "Se guardo exitosamente";
                showTransaction();
                LimpiarCajas();
            }
            else
            {
                Lblmsj.Text = "Error al guardar";
            }

        }
    }
    
}