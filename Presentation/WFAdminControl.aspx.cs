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
    public partial class WFAdminControl : System.Web.UI.Page
    {
        AdminControlLog objAdm = new AdminControlLog();
        ManagerLog objMan = new ManagerLog();
        AccountLog objAcco = new AccountLog();

        private int _idControlAdmin;
        private int _idManager;
        private int _idAccount;
        private string _post;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TBIdControlAdministrador.Visible = false;

                showAdminControl();
                showManagerDDL();
                showAccountDDL();

            }
        }
        private void showAdminControl()
        {
            DataSet objData = new DataSet();
            objData = objAdm.showAdminControl();
            GVControlAdmin.DataSource = objData;
            GVControlAdmin.DataBind();
        }

        private void showManagerDDL()
        {
            DDLAdmin.DataSource = objMan.showManagerDDL();
            DDLAdmin.DataValueField = "adm_id";
            DDLAdmin.DataTextField = "nombreAdmin";
            DDLAdmin.DataBind();
            DDLAdmin.Items.Insert(0, "Seleccione");
        }

        private void showAccountDDL()
        {
            DDLIdAccount.DataSource = objAcco.showAccountDDL();
            DDLIdAccount.DataValueField = "cue_id";
            DDLIdAccount.DataTextField = "cue_numero";
            DDLIdAccount.DataBind();
            DDLIdAccount.Items.Insert(0, "Seleccione");
        }

        protected void GVControlAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {

            TBIdControlAdministrador.Text = GVControlAdmin.SelectedRow.Cells[0].Text;
            TBcadmCargo.Text = GVControlAdmin.SelectedRow.Cells[1].Text;
            DDLIdAccount.Text = GVControlAdmin.SelectedRow.Cells[2].Text;
            DDLAdmin.Text = GVControlAdmin.SelectedRow.Cells[3].Text;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            _post = TBcadmCargo.Text;
            _idAccount = Convert.ToInt32(DDLIdAccount.Text);
            _idManager = Convert.ToInt32(DDLAdmin.Text);

            executed = objAdm.saveAdminControl(_post, _idAccount, _idManager);
            if (executed)
            {
                Lblmsj.Text = "Se guardo exitosamente";
                showAdminControl();
            }
            else
            {
                Lblmsj.Text = "Error al guardar";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            _idControlAdmin = Convert.ToInt32(TBIdControlAdministrador.Text);
            _post = TBcadmCargo.Text;
            _idAccount = Convert.ToInt32(DDLIdAccount.Text);
            _idManager = Convert.ToInt32(DDLAdmin.Text);
            executed = objAdm.updateAdminControl(_idControlAdmin, _post, _idAccount, _idManager);

            if (executed)
            {
                Lblmsj.Text = "Se actualizo exitosamente";
                showAdminControl();
            }
            else
            {
                Lblmsj.Text = "Error al actualizar";
            }
        }

        protected void GVControlAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _idControlAdmin = Convert.ToInt32(GVControlAdmin.DataKeys[e.RowIndex].Values[0]);
            executed = objAdm.deleteAdminControl(_idControlAdmin);

            if (executed)
            {
                Lblmsj.Text = "Eliminado Exitosamente";
                GVControlAdmin.EditIndex = -1; showAdminControl();
            }
        }

    }
}