using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Model;
using SimpleCrypto;

namespace Presentation
{
    public partial class Default : System.Web.UI.Page
    {

        UserLog objUserLog = new UserLog();
        User objUser = new User();
        private string _email;
        private string _password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtGuardar_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();
            _email = TBCorreo.Text;
            _password = TBContrasena.Text;
            objUser = objUserLog.showUsersMail(_email);//Busca el correo del usuario
            if (objUser != null)
            {
                string passEncryp = cryptoService.Compute(_password, objUser.Salt);
                if (cryptoService.Compare(objUser.Contrasena, passEncryp))
                {
                    FormsAuthentication.RedirectFromLoginPage("Index.aspx", true);
                    TBCorreo.Text = "";
                    TBContrasena.Text = "";

                }
                else
                {
                    LblMsg.Text = "Correo o Contraseña Incorrectos!";
                }
            }
            else
            {
                LblMsg.Text = "Correo o Contraseña Incorrectos!";
            }
        }
    }
}