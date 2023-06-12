using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using SimpleCrypto;

namespace Presentation
{
    public partial class WFUser : System.Web.UI.Page
    {
        UserLog objUser = new UserLog();

        private int _idUser;
        private string _email;
        private string _password;
        private string _salt;
        private string _state;
        private string _encryptedPassword;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TBIdUser.Visible = false;

                showUser();
            }
        }

            protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBIdUser.Text = GVUser.SelectedRow.Cells[1].Text;
            TBCorreo.Text = GVUser.SelectedRow.Cells[2].Text;
            TBContraseña.Text = GVUser.SelectedRow.Cells[3].Text;
            TBEstado.Text = GVUser.SelectedRow.Cells[4].Text;
        }

        private void showUser()
        {
            DataSet objData = new DataSet();
            objData = objUser.showUser();
            GVUser.DataSource = objData;
            GVUser.DataBind();
        }

        private void LimpiarCajas()
        {
            TBCorreo.Text = "";
            TBContraseña.Text = "";
    
            TBEstado.Text = "";
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();     
            _email = Convert.ToString(TBCorreo.Text);
            _password = Convert.ToString(TBContraseña.Text);
            _salt = cryptoService.GenerateSalt();
            _state = Convert.ToString(DDLState.Text);
            _encryptedPassword = cryptoService.Compute(_password);

            executed = objUser.saveUser(_email, _encryptedPassword,  _salt,  _state);

            if (executed)
            {
                Lblmsj.Text = "se guardo exitosamente";
                showUser();
                LimpiarCajas();
            }
            else
            {
                Lblmsj.Text = "Error al guardar";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();
            _idUser = Convert.ToInt32(TBIdUser.Text);
            _email = Convert.ToString(TBCorreo.Text);
            _password = Convert.ToString(TBContraseña.Text);
            _encryptedPassword = cryptoService.Compute(_password);
            _salt = cryptoService.GenerateSalt();
            _state = Convert.ToString(DDLState.Text);

            executed = objUser.updateUser(_idUser, _email, _encryptedPassword, _salt, _state);

            if (executed)
            {
                Lblmsj.Text = "El Usuario se actualizo exitosamente";
                showUser();
                LimpiarCajas();
            }
            else
            {
                Lblmsj.Text = "Error al actualizar el Usuario";
            }
        }
    }
}