using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Data;
using Model;

namespace Logic
{
    public class UserLog
    {
        UserDat objUser = new UserDat();

        // procedimiento para mostar
        public DataSet showUser()
        {
            return objUser.showUser();
        }

        // procedimiento para guardar
        public bool saveUser(string _email, string _password, string _salt, string _state)
        {
            return objUser.saveUser(_email, _password, _salt, _state);

        }
            // procedimiento para actualizar
        public bool updateUser(int _idUser, string _email, string _password, string _salt, string _state)
        {

            return objUser.updateUser(_idUser, _email, _password, _salt, _state);

        }

        //Metodo para mostrar el Usuarios pasandole el correo
        public User showUsersMail(string _email)
        {
            return objUser.showUsersMail(_email);
        }

    }
}