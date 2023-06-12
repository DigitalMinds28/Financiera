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
    public partial class WFAccount : System.Web.UI.Page
    {
        AccountLog objAcco = new AccountLog();
        CustomerLog objCus = new CustomerLog();

        private int _idAccount;
        private int _accountNumber;
        private double _cash;
        private int _idCustomer;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TBIdCuenta.Visible = false;

                showAccount();
                showCustomerDDL();
            }
        }

        protected void GvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBIdCuenta.Text = GvAccount.SelectedRow.Cells[0].Text;
            TBNumeroCuenta.Text = GvAccount.SelectedRow.Cells[1].Text;
            TBSaldoCuenta.Text = GvAccount.SelectedRow.Cells[2].Text;
            DDLCustomer.Text = GvAccount.SelectedRow.Cells[3].Text;

        }
        private void showAccount()
        {
            DataSet objData = new DataSet();
            objData = objAcco.showAccount();
            GvAccount.DataSource = objData;
            GvAccount.DataBind();
        }
        private void showCustomerDDL()
        {
            DDLCustomer.DataSource = objCus.showCustomerDDL();
            DDLCustomer.DataValueField = "clie_id";
            DDLCustomer.DataTextField = "nombreCliente";
            DDLCustomer.DataBind();
            DDLCustomer.Items.Insert(0, "Seleccione");
        }

        protected void GvAccount_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _idAccount = Convert.ToInt32(GvAccount.DataKeys[e.RowIndex].Values[0]);
            executed = objAcco.deleteAccount(_idAccount);
            if (executed)
            {
                Lblmsj.Text = "Eliminado Exitosamente";
                GvAccount.EditIndex = -1; showAccount();
            }

        }

        protected void BTNGuardar_Click(object sender, EventArgs e)
        {
            _accountNumber = Convert.ToInt32(TBNumeroCuenta.Text);
            _cash = Convert.ToDouble(TBSaldoCuenta.Text);
            _idCustomer = Convert.ToInt32(DDLCustomer.Text);

            executed = objAcco.saveAccount(_accountNumber, _cash, _idCustomer);

            if (executed)
            {
                Lblmsj.Text = "se guardo exitosamente";
                showAccount();
            }
            else
            {
                Lblmsj.Text = "Error al guardar";
            }

        }

        protected void BTNActualizar_Click(object sender, EventArgs e)
        {
            _idAccount = Convert.ToInt32(TBIdCuenta.Text);
            _accountNumber = Convert.ToInt32(TBNumeroCuenta.Text);
            _cash = Convert.ToDouble(TBSaldoCuenta.Text);
            _idCustomer = Convert.ToInt32(DDLCustomer.Text);

            executed = objAcco.updateAccount(_idAccount, _accountNumber, _cash, _idCustomer);

            if (executed)
            {
                Lblmsj.Text = "El cliente se actualizo exitosamente";
                showAccount();
            }
            else
            {
                Lblmsj.Text = "Error al actualizar el cliente";
            }

        }
    }
}