using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class User
    {
        private string _email;
        private string _password;
        private string _salt;
        private string _state;
        public string Correo { get => _email; set => _email = value; }
        public string Contrasena { get => _password; set => _password = value; }
        public string Salt { get => _salt; set => _salt = value; }
        public string State { get => _state; set => _state = value; }
        public User(string _email, string _password, string _salt, string _state)
        {
            this._email = _email;
            this._password = _password;
            this._salt = _salt;
            this._state = _state;

        }
        public User()
        {
        }
    }
}